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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace Mane_Buff_163_Finder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        System.Windows.Threading.DispatcherTimer UITimer = new System.Windows.Threading.DispatcherTimer();
       
        public MainWindow()
        {
            ManeSetting.load_setting();
            InitializeComponent();
            UITimer.Tick += UITimer_Tick;
            UITimer.Interval = TimeSpan.FromMilliseconds(100);
            UITimer.Start();
            ManeDB.ManeDBConnect();
        }

        private void UITimer_Tick(object sender, EventArgs e)
        {
            processbar.Value = Quanju.Status.process_bar;
            status_label.Content = Quanju.Status.status;
            l_delay.Content = $"Delay: {Quanju.Fetch.Page_Delay} + rand({Quanju.Fetch.Page_Delay_Random})";
            l_page.Content = $"Max Page: {Quanju.Fetch.Page_Max} + rand({Quanju.Fetch.Page_Max_Random})";
            l_filter.Content = $"Findind On RMB ${Quanju.Filter.PriceMin} ~ ${Quanju.Filter.PriceMax}";
            l_rate.Content = $"Rate: Small then {Quanju.Filter.Rate}";
            l_proxy.Content = $"Proxy: {Quanju.Proxy.ProxyEnable} - {Quanju.Proxy.ProxyAddr}:{Quanju.Proxy.ProxyPort}";

            if (!Quanju.Status.Running && Quanju.Status.Force_Stop)
            {
                Quanju.Status.Force_Stop = false;
            }

            if (!Quanju.Status.Running)
            {
                StartBTN.IsEnabled = true;
                StartBTN.Content = "start";
            }
            l_stop.Content = $"Stop on : {Quanju.Status.stoptime.ToString("dd/MM HH:mm")}";
            l_new.Content = $"New {Quanju.Status.new_good} items";
            l_thread.Content = Quanju.Status.thread_status;


        }

        private void SettingBTN_Click(object sender, RoutedEventArgs e)
        {
            new Setting().ShowDialog();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (StartBTN.Content.ToString() == "start")
            {
                System.Threading.Thread t = new System.Threading.Thread(ManeBase.Server);
                t.Start();
                StartBTN.Content = "stop";
            }
            else
            {
                StartBTN.IsEnabled = false;
                Quanju.Status.Force_Stop = true;
                StartBTN.Content = "Waiting ...";
            }
        }


        private void ShowGood_Click(object sender, RoutedEventArgs e)
        {
            new ShowGoods().ShowDialog();
        }

        private void detime_Click(object sender, RoutedEventArgs e)
        {
            Quanju.Status.stoptime = Quanju.Status.stoptime.AddMinutes(-30);
            if (Quanju.Status.stoptime < DateTime.Now)
            {
                Quanju.Status.stoptime = DateTime.Now;
            }
        }

        private void addtime_Click(object sender, RoutedEventArgs e)
        {
            Quanju.Status.stoptime = Quanju.Status.stoptime.AddHours(1);
        }
    }
}
