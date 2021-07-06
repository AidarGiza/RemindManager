using RemindManager.Utils;
using System;
using System.IO;

namespace RemindManager.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        /// <summary>
        /// Получение пути к базе данных для Android
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Путь к базе данных</returns>
        public string GetDatabasePath(string filename)
        {
            // Путь к папке с документами
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            // Путь к базе данных
            var path = Path.Combine(documentsPath, filename);
            return path;
        }
    }
}