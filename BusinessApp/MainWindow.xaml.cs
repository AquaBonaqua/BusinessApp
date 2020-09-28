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
using System.Collections.ObjectModel;

namespace BusinessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
 
            AppData.frame = MyFrame;
            MyFrame.Navigate(new PageMain());
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { Time.Content =  DateTime.Now.ToString("HH:mm tt ");  };
            timer.Start();
            ReadOnlyCollection<TimeZoneInfo> tzCollection;
            tzCollection = TimeZoneInfo.GetSystemTimeZones();
            id.ItemsSource = tzCollection;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DateTime now = DateTime.UtcNow;
                TimeZoneInfo selectedTimeZone = (TimeZoneInfo)id.SelectedItem;
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(now, selectedTimeZone);
                var timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = new TimeSpan(0, 1, 0);
                timer.IsEnabled = true;
                timer.Tick += (o, i) => { Time2.Content = cstTime.ToString("HH:mm tt "); };
                timer.Start();
                Time2.Content = cstTime.ToString("HH:mm tt");
            }

            catch
            {
                MessageBox.Show("Выберите часовой пояс!");
            }


        }

        private void id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
