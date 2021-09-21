using ConsoleAppToTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppToTest.Managers
{
    public class RecordManager
    {
        private readonly IDBService _dbService;
        public RecordManager(IDBService dBService)
        {
            _dbService = dBService;
        }

        public async Task<bool> AddRecordAsync (string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            { throw new ArgumentNullException("id is null"); }
            if(!string.IsNullOrWhiteSpace(await _dbService.GetRecordAsync(id)))
            {
                return false;
            }
            return await _dbService.AddRecordAsync(id);
        }
    }
}
