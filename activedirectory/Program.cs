using System;
using System.DirectoryServices;
using System.Configuration;


namespace activedirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var computerName = "comp1";

            string server = ConfigurationManager.AppSettings.Get("server");
            string userName = ConfigurationManager.AppSettings.Get("userName");
            string password = ConfigurationManager.AppSettings.Get("password");
            string domain = ConfigurationManager.AppSettings.Get("domain");

            var directoryContext = GetDirectoryContext(server,domain,userName, password);
            var result = FindComputer(computerName,directoryContext);
            var directoryEntry = result.GetDirectoryEntry();
            
            Console.WriteLine(directoryEntry.SchemaClassName);
            RemoveComputer(directoryEntry);
        }

        public static DirectoryEntry GetDirectoryContext(string serverFQDN, string distinguishedName, string userName, string password ){
            return new DirectoryEntry("LDAP://"+serverFQDN+"/"+ distinguishedName, userName, password);
        }
        
        public static void CreateComputer(string computerName, DirectoryEntry directoryEntry){

        }
        public static System.DirectoryServices.SearchResult FindComputer(string computerName, DirectoryEntry directoryEntry)
        {
                var searcher    = new DirectorySearcher(directoryEntry);
                searcher.Filter = string.Format("(&(objectClass=computer)(CN={0}))", computerName);
                searcher.PropertiesToLoad.Add("distinguishedName");
                var result = searcher.FindOne();
                Console.WriteLine(result.GetType());
                return result;
        }

        public static void RemoveComputer(System.DirectoryServices.DirectoryEntry directoryEntry){
            if(directoryEntry.SchemaClassName == "computer"){
                Console.WriteLine("true");
            }
            else{
                Console.WriteLine("false");
            }
        }
    }
}
