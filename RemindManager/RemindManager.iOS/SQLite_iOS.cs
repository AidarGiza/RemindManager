using RemindManager.Utils;
using System;
using System.IO;

namespace RemindManager.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }

        /// <summary>
        /// Получение пути к базе данных для iOS
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Путь к базе данных</returns>
        public string GetDatabasePath(string filename)
        {
            // Определение пути к БД
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            // Папка библиотеки
            string libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, filename);

            return path;
        }
    }
}