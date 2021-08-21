using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mane_Buff_163_Finder
{
    public class ManeSetting
    {
        public static void load_setting()
        {
            Quanju.Proxy.ProxyEnable = UsersSetting.Default.ProxyEnable;
            Quanju.Proxy.ProxyAddr = UsersSetting.Default.ProxyAddr;
            Quanju.Proxy.ProxyPort = UsersSetting.Default.ProxyPort;
            
            Quanju.Fetch.Page_Delay = UsersSetting.Default.Page_Delay;
            Quanju.Fetch.Page_Max = UsersSetting.Default.Page_Max;
            Quanju.Fetch.Page_Delay_Random = UsersSetting.Default.Page_Delay_Random;
            Quanju.Fetch.Page_Max_Random = UsersSetting.Default.Page_Max_Random;
            Quanju.Fetch.Use_Steam_API = UsersSetting.Default.Use_Steam_API;
            Quanju.Fetch.FetchCSGO = UsersSetting.Default.FetchCSGO;
            Quanju.Fetch.FetchDota = UsersSetting.Default.FetchDota;

            Quanju.Notification.ShowFinish = UsersSetting.Default.ShowFinish;
            Quanju.Notification.FindedGood = UsersSetting.Default.FindedGood;

            Quanju.Cookie.cookie = UsersSetting.Default.cookie;

            Quanju.Filter.PriceMax = UsersSetting.Default.PriceMax;
            Quanju.Filter.PriceMin = UsersSetting.Default.PriceMin;
            Quanju.Filter.Rate = UsersSetting.Default.Rate;
            Quanju.Filter.ShellBiggerNum = UsersSetting.Default.ShellBiggerNum;

        }
    }
}
