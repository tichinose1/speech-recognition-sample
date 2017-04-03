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

namespace SpeechRecognitionWpf3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OxfordClient.OnPartialResponseReceived += text =>
            {
                Dispatcher.InvokeAsync(() =>
                {
                    InputTextBox.Text = text;
                });
            };

            OxfordClient.OnResponseReceived += text =>
            {
                Dispatcher.InvokeAsync(() =>
                {
                    InputTextBox.IsEnabled = true;
                });
            };

            OxfordClient.Initialize();

            InputTextBox.IsEnabled = false;
            OxfordClient.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.IsEnabled = false;
            OxfordClient.Start();
        }
    }
}
