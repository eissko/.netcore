using System;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Configuration;
//using System.Collections.Specialized;


namespace activedirectory2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string server = ConfigurationManager.AppSettings.Get("server");
            string userName = ConfigurationManager.AppSettings.Get("userName");
            string password = ConfigurationManager.AppSettings.Get("password");
            string domain = ConfigurationManager.AppSettings.Get("domain");
            string compName = ConfigurationManager.AppSettings.Get("compName");
             
            var searchRequest  = GetSearchRequest(compName, domain);


            var ldapconnection = GetLdapConnection(server,userName, password);
            var searchResult = (SearchResponse)ldapconnection.SendRequest(searchRequest);
  
            Console.WriteLine(searchResult.ResultCode);
            Console.WriteLine(searchResult.Entries[0].Attributes["DistinguishedName"][0].ToString());
            
            // RemoveComputer(directoryEntry);
        
        }

        public static SearchRequest GetSearchRequest(string computerName, string domain)
        {
                var distinguishedName = domain;
                var ldapFilter = string.Format("(&(objectClass=computer)(CN={0}))", computerName);
                var searchScope = SearchScope.Subtree;
                var attributeList = new string[] { "DistinguishedName" };                
                var searcher    = new SearchRequest (distinguishedName,ldapFilter,searchScope,attributeList);


                return searcher;
        }     
        public static LdapConnection GetLdapConnection(string server, string userName, string password ){
            NetworkCredential credentials = new NetworkCredential(userName,password);
            LdapDirectoryIdentifier ldapDirectoryIdentifier = new LdapDirectoryIdentifier(server);     
            return new LdapConnection(ldapDirectoryIdentifier,credentials);
        }

    }
}
