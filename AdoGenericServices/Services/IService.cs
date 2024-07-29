using AdoGenericServices.Models;
using PluralizeService.Core;
using System.Data.SqlClient;
using System.Reflection;
namespace AdoGenericServices.Services;

public interface IService<T> where T : BaseEntity
{
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    /*
    Task<bool> Delete(T entity);
    Task<bool> Delete(int Id);
    Task<T> GetByID(int id);
    Task<IEnumerable<T>> GetAll();*/
}
public class Service<T> : IService<T> where T : BaseEntity
{
    private string GetTableName<T>() where T : BaseEntity => PluralizationProvider.Pluralize(typeof(T).Name);

    public async Task<bool> Add(T entity)
    {
        string tableName = GetTableName<T>();
        string connection = Environment.GetEnvironmentVariable("ConnectionString");
       
        var columnName = typeof(T)
            .GetProperties()
            .Where(p => p.GetValue(entity) != null && p.GetCustomAttribute<PrimaryKeyAttribute>() == null)
            .ToDictionary(p => p.Name, p => p.GetValue(entity));

        using SqlConnection sqlConnection = new SqlConnection(connection);
        using SqlCommand sqlCommand = new($"Insert into dbo.{tableName}({string.Join(',', columnName.Keys)}) Values(@{string.Join(",@", columnName.Keys)})", sqlConnection);

        foreach (var item in columnName)
        {
            sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
        }

        
        if (sqlConnection.State == System.Data.ConnectionState.Closed)
        {
            await sqlConnection.OpenAsync();
        }
        bool result = await sqlCommand.ExecuteNonQueryAsync() > 0;
        sqlConnection.Close();
        Console.WriteLine($"{entity.GetType().Name} -> Added entity");
        /*
                Console.ReadKey();

                sqlConnection.Close();*/
        return result;
    }

    public async Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}