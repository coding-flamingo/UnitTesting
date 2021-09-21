using ConsoleAppToTest.Managers;
using ConsoleAppToTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppToTest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IDBService dbService  = new DBService();
            RecordManager recordManager = new RecordManager(dbService);
            await recordManager.AddRecordAsync("rob");
        }
    }
}