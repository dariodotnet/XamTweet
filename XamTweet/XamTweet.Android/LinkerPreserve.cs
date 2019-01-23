using Akavache.Sqlite3;
using System;

namespace XamTweet.Droid
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