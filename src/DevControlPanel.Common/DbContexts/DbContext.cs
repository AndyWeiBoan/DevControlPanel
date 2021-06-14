using LiteDB;
using System.Reflection;

namespace DevControlPanel.Common
{
    public class DbContext
    {
        public readonly LiteDatabase Database;

        public DbContext()
        {
            Database = new LiteDatabase(Assembly.GetEntryAssembly().Location);
        }
    }
}
