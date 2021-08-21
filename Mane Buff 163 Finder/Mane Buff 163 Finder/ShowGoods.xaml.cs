using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
    /// Interaction logic for ShowGoods.xaml
    /// </summary>
    public partial class ShowGoods : MahApps.Metro.Controls.MetroWindow 
    {
        public ShowGoods()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(ManeT.Good good in ManeDB.ManeDBListGoods())
            {
                string name = HttpUtility.UrlDecode(good.hash_name);
                ListBoxItem item = new ListBoxItem();
                item.Content = good.fetch_time.ToString("HH:mm") + " | " + good.volume + " : ["+ good.Rate.Substring(0,5) + "%] $" + good.lowest_price +" #" + name ;
                item.Tag = good;
                listbox_view.Items.Add(item);
            }
            

        }

        private void listbox_view_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = (ListBox)sender;

            if (listbox.SelectedIndex !=-1)
            {
                ListBoxItem it = (ListBoxItem)listbox.SelectedItem;
                ManeT.Good selectGood = (ManeT.Good)it.Tag;
                try
                {
                    string url = "https://buff.163.com/goods/" + selectGood.goodid;
                    System.Diagnostics.Process.Start("explorer.exe",url);
                }
                catch { }
            }
        }
    }
}
