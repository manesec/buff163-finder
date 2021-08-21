using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace Mane_Buff_163_Finder
{
    public static class Quanju
    {
        public static SqliteConnection Mane_SqliteConnection;

        public static class Proxy
        {
            public static bool ProxyEnable = true;
            public static string ProxyAddr = "127.0.0.1";
            public static int ProxyPort = 10808;
        }
        public static class Fetch
        {
            public static int Page_Delay = 10;
            public static int Page_Max = 10;
            public static int Page_Delay_Random = 10;
            public static int Page_Max_Random = 10;
            public static bool Use_Steam_API = false;
            public static bool FetchCSGO = true;
            public static bool FetchDota = true;

        }
        public static class Notification
        {
            public static bool ShowFinish = true;
            public static bool FindedGood = true;
        }
        public static class Cookie
        {
            public static string cookie = "";
        }
        public static class Filter
        {
            public static int PriceMin = 10;
            public static int PriceMax = 10;
            public static double Rate = 0.7;
            public static int ShellBiggerNum = 50;
 
        }
        public static class Status
        {
            public static bool Running = false;
            public static string status = "";
            public static int process_bar = 0;
            public static bool NewMessage = false;
            public static bool Force_Stop = false;
            public static DateTime stoptime = DateTime.Now;
            public static int new_good = 0;
            public static string thread_status = "";
        }
    }
}
