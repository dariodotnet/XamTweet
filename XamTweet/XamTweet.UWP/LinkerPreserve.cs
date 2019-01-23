using Akavache.Sqlite3;
using System;

namespace XamTweet.UWP
{
    [Preserve]
    public static class LinkerPreserve
    {
        static LinkerPreserve()
        {
            var persistentName = typeof(SQLitePersistentBlobCache).FullName;
            var encryptedName = typeof(SQLiteEncryptedBlobCache).FullName;
        }

        public class PreserveAttribute : Attribute { }
    }
}