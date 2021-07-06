namespace RemindManager.Utils
{
    public interface ISQLite
    {
        /// <summary>
        /// Получение пути к базе данных
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Путь к базе данных</returns>
        string GetDatabasePath(string filename);
    }
}
