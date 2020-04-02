using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Snowie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isConnecting;
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(700);
            dt.Tick += dtTicker;
            dt.Start();

            isConnecting = false;
        }

        private void dtTicker(object sender, EventArgs e)
        {
            if (isConnecting)
            {
                if (ConnectingLabel.Content.Equals("Connecting..."))
                    ConnectingLabel.Content = "Connecting";
                else if (ConnectingLabel.Content.Equals("Connecting"))
                    ConnectingLabel.Content = "Connecting.";
                else if (ConnectingLabel.Content.Equals("Connecting."))
                    ConnectingLabel.Content = "Connecting..";
                else if (ConnectingLabel.Content.Equals("Connecting.."))
                    ConnectingLabel.Content = "Connecting...";
            }
        }

        private void OpenChatWindow()
        {
            var chat = new ChatWindow();
            chat.Show();
        }


        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isConnecting)
            {
                isConnecting = true;
                ConnectButton.Content = "Cancel";
                InfoPanel.Visibility = Visibility.Collapsed;
                ConnectingPanel.Visibility = Visibility.Visible;
                OpenChatWindow();
                this.Close();
            }
            else
            {
                isConnecting = false;
                ConnectButton.Content = "Connect";
                InfoPanel.Visibility = Visibility.Visible;
                ConnectingPanel.Visibility = Visibility.Collapsed;
            }
        }
    }
}
