using System;
using System.IO;

namespace Mine
{
    public class Constants
    {
        public const string DatabaseFilename = "mine.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            //Open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Create a database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            //enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get{
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }

        }
    }
}
