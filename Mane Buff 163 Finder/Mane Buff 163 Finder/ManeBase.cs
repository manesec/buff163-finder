using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using MihaZupan;
using System.Net.Http;
using Newtonsoft.Json;

namespace Mane_Buff_163_Finder
{
    public class ManeBase
    {
        public static void Server()
        {
            Quanju.Status.Running = true;
            Quanju.Status.process_bar = 0;
            Quanju.Status.status = "Starting ... ";
            do
            {
                Ticker();
            } while (DateTime.Now < Quanju.Status.stoptime);
            Quanju.Status.Running = false;
            Quanju.Status.status = "Done!" ;

        }
        public static void Ticker()
        {
            if (Quanju.Fetch.FetchCSGO)
            {
                Random rd = new Random();
                int page = Quanju.Fetch.Page_Max + rd.Next(0, Quanju.Fetch.Page_Max_Random);
                for (int i = 1; i <= page; i++)
                {
                    try
                    {
                        Quanju.Status.status = $"{i}/{page} Fetching CSGO ...";
                        Buff163GetGoods("csgo", i);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                    int delay_sleep = Quanju.Fetch.Page_Delay + rd.Next(0, Quanju.Fetch.Page_Delay_Random);
                    Quanju.Status.status = $"{i}/{page} Delaying {delay_sleep} s...";
                    delay_sleep = delay_sleep * 1000;

                    if (Quanju.Status.Force_Stop)
                    {
                        Quanju.Status.status = "Force Stop." ;
                        return;
                    }
                    System.Threading.Thread.Sleep(delay_sleep);
                } 
            }

            if (Quanju.Fetch.FetchDota)
            {
                Random rd = new Random();
                int page = Quanju.Fetch.Page_Max + rd.Next(0, Quanju.Fetch.Page_Max_Random);
                for (int i = 1; i <= page; i++)
                {
                    try
                    {
                        Quanju.Status.status = $"{i}/{page} Fetching dota2 ...";
                        Buff163GetGoods("dota2", i);
                    }catch(Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                    int delay_sleep = Quanju.Fetch.Page_Delay + rd.Next(0, Quanju.Fetch.Page_Delay_Random);
                    Quanju.Status.status = $"{i}/{page} Delaying {delay_sleep} s...";
                    delay_sleep = delay_sleep * 1000;
                    if (Quanju.Status.Force_Stop)
                    {
                        Quanju.Status.status = "Force Stop." ;
                        return;
                    }
                    System.Threading.Thread.Sleep(delay_sleep);
                } 
            }
        }

        public static void Buff163GetGoods(string game,int page) {
            Quanju.Status.process_bar = 0;
            Random r = new Random();
            string Fake_unix = DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + r.Next(100, 999).ToString();

            System.Threading.Thread.Sleep(1000);

            HttpClientHandler handler;
            var proxy = new HttpToSocks5Proxy(Quanju.Proxy.ProxyAddr, Quanju.Proxy.ProxyPort);
            if (Quanju.Proxy.ProxyEnable)
            {

                handler = new HttpClientHandler { Proxy = proxy,UseCookies = false };
            }
            else
            {
                handler = new HttpClientHandler {UseCookies = false };
            }

            HttpClient httpClient = new HttpClient(handler, true);
            HttpRequestMessage rqm = new HttpRequestMessage(HttpMethod.Get, $"https://buff.163.com/api/market/goods?game={game}&page_num={page.ToString()}&_={Fake_unix}&page_size=20&min_price={Quanju.Filter.PriceMin}&max_price={Quanju.Filter.PriceMax}");
            if (Quanju.Cookie.cookie.Trim() != "")
            {
                rqm.Headers.Add("Cookie", Quanju.Cookie.cookie);
            }
            rqm.Headers.Add("Connection", "keep-alive");
            rqm.Headers.Add("Upgrade-Insecure-Requests", "1");
            rqm.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36");
            rqm.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            rqm.Headers.Add("Sec-Fetch-Site", "same-origin");
            rqm.Headers.Add("Sec-Fetch-Mode", "navigate");
            rqm.Headers.Add("Sec-Fetch-User", "?1");
            rqm.Headers.Add("Sec-Fetch-Dest", "document");
            rqm.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"92\", \" Not A;Brand\";v=\"99\", \"Google Chrome\";v=\"92\"");
            rqm.Headers.Add("sec-ch-ua-mobile", "?0");
            rqm.Headers.Add("Referer", "https://buff.163.com/");
            rqm.Headers.Add("Accept-Language", "en-US,en;q=0.9,zh-CN;q=0.8,zh;q=0.7,zh-TW;q=0.6,ja;q=0.5");

            var result = httpClient.Send(rqm);
            StreamReader sr = new StreamReader(result.Content.ReadAsStream(), Encoding.UTF8);
            string Return_str = sr.ReadToEnd();
            Debug.WriteLine("HTTPS GET: " + Return_str);

            dynamic json_read = JsonConvert.DeserializeObject(Return_str);

            foreach (var good_item in json_read.data.items)
            {
                if (Quanju.Status.Force_Stop)
                {
                    return;
                }

                try
                {
                    ManeT.Good agood = new ManeT.Good();
                    agood.appid = (string)good_item.appid;
                    agood.fetch_time = DateTime.Now;
                    agood.goodid = (string)good_item.id;

                    string steamlink = good_item.steam_market_url;
                    string [] steamlink_s = steamlink.Split("/");
                    steamlink = steamlink_s[steamlink_s.Length - 1];

                    agood.hash_name = steamlink;
                    agood.lowest_price = (string)good_item.sell_min_price;
                    agood.volume = (string)good_item.sell_num;

                    double steam_shell = double.Parse((string)(good_item.goods_info.steam_price_cny));
                    double buff163_buy = double.Parse((string)(good_item.sell_min_price));

                    if (Quanju.Fetch.Use_Steam_API)
                    {
                        double steam_return = SteamShellAPI(agood.appid, agood.hash_name);
                        if (steam_return >0)
                        {
                            agood.lowest_price = steam_return.ToString();
                            steam_shell = steam_return;
                        }
                    }
                    agood.Rate = (buff163_buy / (steam_shell * 0.85)).ToString();

                    bool save = true;
                    double rate = (buff163_buy / (steam_shell * 0.85));
                    Quanju.Status.thread_status = $"{agood.volume} : {rate}";
                    if ( rate > Quanju.Filter.Rate)
                    {
                        save = false;   
                    }

                    if (Quanju.Filter.ShellBiggerNum > int.Parse(agood.volume))
                    {
                        save = false;   
                    }
                    
                    if (save)
                    {
                        ManeDB.ManeDBInsertGood(agood);
                        Quanju.Status.new_good += 1;
                    }
                }
                catch
                {
                    Debug.WriteLine("Error to pass");
                }

                Quanju.Status.process_bar += 5;
            }
            handler.Dispose();
            httpClient.Dispose();
            rqm.Dispose();
            sr.Close();
        }
        public static double SteamShellAPI(string aid, string name)
        {

            System.Threading.Thread.Sleep(1000);
            try
            {
                HttpClientHandler handler;
                var proxy = new HttpToSocks5Proxy(Quanju.Proxy.ProxyAddr, Quanju.Proxy.ProxyPort);
                if (Quanju.Proxy.ProxyEnable)
                {

                    handler = new HttpClientHandler { Proxy = proxy,UseCookies = false };
                }
                else
                {
                    handler = new HttpClientHandler {UseCookies = false };
                }

                HttpClient httpClient = new HttpClient(handler, true);
                string url = $"https://steamcommunity.com/market/priceoverview/?appid={aid}&currency=23&market_hash_name={name}";
                HttpRequestMessage rqm = new HttpRequestMessage(HttpMethod.Get,url);
                var result = httpClient.Send(rqm);
                StreamReader sr = new StreamReader(result.Content.ReadAsStream(), Encoding.UTF8);
                string Return_str = sr.ReadToEnd();
                Debug.WriteLine("HTTPS GET: " + Return_str);
                try
                {
                    dynamic json_read = JsonConvert.DeserializeObject(Return_str);
                    string lowest_price = json_read.lowest_price;
                    if (lowest_price == null ||lowest_price.IndexOf("¥") == -1)
                    {
                        return 0.0;
                    }
                    lowest_price = lowest_price.Replace("¥ ", "");
                    return double.Parse(lowest_price);

                return 0.0;
                }
                catch
                {
                    return 0.0;
                }
            }
            catch
            {
                return 0.0;
            }
        }

    }
}
