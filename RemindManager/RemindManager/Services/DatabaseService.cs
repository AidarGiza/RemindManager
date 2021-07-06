using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemindManager.Services
{
    /// <summary>
    /// Сервис для работы с базой данных
    /// </summary>
    public class DatabaseService
    {
        SQLiteConnection database;

        public DatabaseService(string databasePath)
        {
            database = new SQLiteConnection(databasePath);

        }
    }
}