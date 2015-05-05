using System;
using System.IO;
using System.Reflection;

namespace MsSqlQuery.Integration.Test
{
    public static class Global
    {
        public static string ConnectionString()
        {
            var uri = dbUri();
            var result = "Data Source=" + dbUri().LocalPath;
            return result;
        }
        private static Uri dbUri()
        {
            string uriPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\AppData\Northwind.sdf";
            var result = new Uri(uriPath);
            return result;
        }

    }
}