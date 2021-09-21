using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppToTest.Services
{
    public interface IDBService
    {
        Task<string> GetRecordAsync(string key);
        Task<bool> AddRecordAsync(string key);
    }
    public class DBService : IDBService
    {
        public async Task<string> GetRecordAsync(string key)
        {
            return "Hi";
        }

        public async Task<bool> AddRecordAsync(string key)
        {
            return true;
        }
    }
}
