using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mane_Buff_163_Finder
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : MahApps.Metro.Controls.MetroWindow
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UsersSetting.Default.ProxyEnable = (bool)check_proxy.IsChecked;

            try
            {
                string[] proxy = textbox_proxy.Text.Trim().Split(":");
                UsersSetting.Default.ProxyAddr = proxy[0];
                UsersSetting.Default.ProxyPort = int.Parse(proxy[1]);
            }
            catch
            {
                MessageBox.Show("ERROR ON PROXY TEXTBOX");
                e.Cancel = true;
            }

            UsersSetting.Default.Page_Delay = int.Parse(t_dp.Text);
            UsersSetting.Default.Page_Delay_Random = int.Parse(t_dpr.Text);
            UsersSetting.Default.Page_Max = int.Parse(t_mp.Text);
            UsersSetting.Default.Page_Max_Random= int.Parse(t_mpr.Text);
            UsersSetting.Default.Use_Steam_API = (bool)c_steam.IsChecked;
            UsersSetting.Default.ShowFinish = (bool)c_finish.IsChecked;
            UsersSetting.Default.FindedGood = (bool)c_find.IsChecked;
            UsersSetting.Default.cookie = t_cook.Text.Trim();
            UsersSetting.Default.PriceMin = int.Parse(tpm.Text);
            UsersSetting.Default.PriceMax = int.Parse(tpma.Text);
            UsersSetting.Default.Rate = double.Parse(t_rate.Text);
            UsersSetting.Default.ShellBiggerNum = int.Parse(tsell.Text);

        
            UsersSetting.Default.FetchCSGO = (bool)ccsco.IsChecked;
            UsersSetting.Default.FetchDota = (bool)cdota.IsChecked;

            UsersSetting.Default.Save();
            ManeSetting.load_setting();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            check_proxy.IsChecked = Quanju.Proxy.ProxyEnable;
            textbox_proxy.Text = Quanju.Proxy.ProxyAddr + ":" + Quanju.Proxy.ProxyPort.ToString();
            t_dp.Text = Quanju.Fetch.Page_Delay.ToString();
            t_dpr.Text = Quanju.Fetch.Page_Delay_Random.ToString();
            t_mp.Text = Quanju.Fetch.Page_Max.ToString();
            t_mpr.Text = Quanju.Fetch.Page_Max_Random.ToString();
            c_steam.IsChecked = Quanju.Fetch.Use_Steam_API;
            c_finish.IsChecked = Quanju.Notification.ShowFinish;
            c_find.IsChecked = Quanju.Notification.FindedGood;
            t_cook.Text = Quanju.Cookie.cookie;

            tpm.Text = Quanju.Filter.PriceMin.ToString();
            tpma.Text = Quanju.Filter.PriceMax.ToString();

            t_rate.Text = Quanju.Filter.Rate.ToString();

            tsell.Text = Quanju.Filter.ShellBiggerNum.ToString();


            ccsco.IsChecked = Quanju.Fetch.FetchCSGO;
            cdota.IsChecked = Quanju.Fetch.FetchDota;



        }
    }
}
