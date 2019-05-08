using System;
using System.Windows;
using System.Windows.Threading;

namespace GUI_DFM
{
    partial class MainWindow : Window
    {
        private void InitializeTimer()
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
            lblDate.Content = DateTime.Now.ToLongDateString();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
            lblDate.Content = DateTime.Now.ToLongDateString();
        }
    }
}
