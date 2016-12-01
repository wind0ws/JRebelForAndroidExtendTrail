using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace JRebelForAndroidExtendTrail
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("==============   Welcome  =============\r\n");

            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
            RegistryKey currentUserRegistery = Registry.CurrentUser;
            string subKey = "SOFTWARE\\JavaSoft\\Prefs\\jrebel-android";
            string startTrailTime = RegistryHelper.GetRegistryData(currentUserRegistery, subKey, "tt");
            string endTrailTime = RegistryHelper.GetRegistryData(currentUserRegistery, subKey, "te");
           
            Console.WriteLine("Current start trail time is: "+startTrailTime);
            Console.WriteLine("Current  end  trail time is: " + endTrailTime);

            if (todayDate != startTrailTime.Substring(0, 10))
            {
                startTrailTime = todayDate + startTrailTime.Substring(10);
                Console.WriteLine("Set trail start time to: " + startTrailTime);
                RegistryHelper.SetRegistryData(currentUserRegistery, subKey, "tt", startTrailTime);
            }
            int currentYear = DateTime.Now.Year;
            int trailEndYear = int.Parse(endTrailTime.Substring(0, 4));
            if (trailEndYear <= currentYear)
            {
                endTrailTime = (currentYear + 10).ToString() + endTrailTime.Substring(4);
                Console.WriteLine("Set trail end  time to: "+ endTrailTime);
                RegistryHelper.SetRegistryData(currentUserRegistery, subKey, "te", endTrailTime);
            }

            Console.WriteLine("\r\nOk,Done.Press any key to exit...");
            Console.ReadKey();
        }


    }
}
