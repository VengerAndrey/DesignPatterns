using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnection dbConnection = new DBConnection();

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Using real subject (DBConnection).");
            Console.WriteLine("-----------------------------------");
            dbConnection.Push("Data1");
            Console.WriteLine();

            VirtualDBConnection virtualDbConnection = new VirtualDBConnection();

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Using virtual proxy.");
            Console.WriteLine("-----------------------------------");
            virtualDbConnection.Push("Data2");
            virtualDbConnection.Push("Data3");
            Console.WriteLine();

            LogDBConnection logDbConnection = new LogDBConnection(dbConnection);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Using log proxy.");
            Console.WriteLine("-----------------------------------");
            logDbConnection.Push("Data4");
            Thread.Sleep(500);
            logDbConnection.Push("Data5");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Log:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var log in logDbConnection.LogList)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine();

            ProtectedDBConnection protectedDbConnection = new ProtectedDBConnection(dbConnection);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Using protection proxy.");
            Console.WriteLine("-----------------------------------");
            protectedDbConnection.Push("Data6");
            protectedDbConnection.GetAuthentication("admin");
            protectedDbConnection.Push("Data7");
            Console.WriteLine();

        }
    }

    interface IDBConnection
    {
        void Push(string data);
    }

    class DBConnection : IDBConnection
    {
        public void Push(string data)
        {
            Console.WriteLine($"Pushed {data} to DB.");
        }
    }

    class VirtualDBConnection : IDBConnection
    {
        private DBConnection dbConnection = null;

        public void Push(string data)
        {
            if (dbConnection == null)
            {
                dbConnection = new DBConnection();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Virtual proxy connected to the real subject (lazy initialization).");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            dbConnection.Push(data);
        }
    }

    class LogDBConnection : IDBConnection
    {
        private DBConnection dbConnection;
        public List<string> LogList { get; private set; } = new List<string>();

        public LogDBConnection(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void Push(string data)
        {
            dbConnection.Push(data);
            LogList.Add($"Pushed \"{data}\" at {DateTime.Now}.");
        }
    }

    class ProtectedDBConnection : IDBConnection
    {
        private DBConnection dbConnection;
        private bool isAuth = false;

        public ProtectedDBConnection(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void Push(string data)
        {
            if (isAuth)
            {
                dbConnection.Push(data);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have an access!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void GetAuthentication(string login)
        {
            if (login == "admin")
            {
                isAuth = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Access granted.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                isAuth = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Access denied!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
