using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Constructor.Models
{
    public static class Helper
    {
        public static string GetComputerName()
        {
            return Environment.MachineName;
        }
        public static string GetzLocalIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var address in host.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }
            throw new Exception("Not Netvork");
        }
        public static string GetIp()    
        {
            var apiUrl = new Uri("https://api.ipify.org");
            IpRes
            return new WebClient().DownloadString(apiUrl).Trim();
        }
        private static async Task<IpResponse> GetToAdress(string url)
        {
            using HttpResponseMessage response = await new HttpClient().GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            IpResponse ipResponse = JsonSerializer.Deserialize<IpResponse>(responseBody);
            return ipResponse;
        }
        public class IpResponse
        {
            public string? IP;
        }
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedIp { get; set; } = null!;
        public string CreatedComputerName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        private string? _updatedIp;
        public string? UpdatedIp { get => _updatedIp; set
            {
                _updatedIp = value;
                if (value != null) this.UpdatedDate = DateTime.Now;
            }
        }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreatedIp = Helper.GetIp();
            CreatedDate = DateTime.Now;
            UpdatedDate = updatedDate;
            IsDeleted = isDeleted;
        }
    }
    public class Employee : BaseEntity 
    {
        public string FirsName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
