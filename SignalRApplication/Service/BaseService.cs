using Humanizer;
using Microsoft.AspNetCore.SignalR;
using SignalRApplication.Models;
using SignalRApplication.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace SignalRApplication.Service
{

    public abstract class BaseService<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository; IConfiguration _configuration;
        private readonly IHubContext<SignalRServer> _hubContext;
        public BaseService(IHubContext<SignalRServer> hubContext, IConfiguration configuration)
        {
            _hubContext = hubContext;
            _configuration = configuration;
        }

        public IEnumerable<T> GetAll()
        {
            string? connectionString = _configuration.GetConnectionString("default");
            var items = new List<T>();
            string tableName = typeof(T).Name.Pluralize();
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlDependency.Start(connectionString);
            using SqlCommand cmd = new();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM  {tableName}";
            SqlDependency dependency = new(cmd);
            dependency.OnChange += Dependency_OnChange;

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var item = Activator.CreateInstance<T>();
                foreach (var property in item.GetType().GetProperties())
                {
                    if (reader[property.Name] is not System.DBNull)
                    {
                        property.SetValue(item, reader[property.Name]);
                    }
                }
                items.Add(item);
            }
            return items;
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            _hubContext.Clients.All.SendAsync("refleshTypes");
        }
    }
    public class ProductService : BaseService<Product>, IProductRepository
    {
        public ProductService(IHubContext<SignalRServer> hubContext, IConfiguration configuration) : base(hubContext, configuration)
        {
        }
    }
    public class CategoryService : BaseService<Category>, ICategoryRepository
    {
        public CategoryService(IHubContext<SignalRServer> hubContext, IConfiguration configuration) : base(hubContext, configuration)
        {
        }
    }

}