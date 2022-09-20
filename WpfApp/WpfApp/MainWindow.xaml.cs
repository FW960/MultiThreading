using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread? _thread;

        private MyFibNum? _myFibNumWpf;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_thread is not null)
            {
                _thread.Interrupt();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _myFibNumWpf = new MyFibNum();

            _thread = new Thread(Process) {IsBackground = true};

            _thread.Start();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            if (_myFibNumWpf is not null && !_thread.IsAlive)
            {
                _thread = new Thread(Process) {IsBackground = true};

                _thread.Start();
            }
        }

        private void Process()
        {
            while (true)
            {
                try
                {
                    ulong value = _myFibNumWpf.CalculateNext();

                    TextBlockFib.Dispatcher.BeginInvoke(() =>
                    {
                        TextBlockFib.Text = $"Number: {_myFibNumWpf.FibNums.Count - 1}\r\nValue: {value}";
                    });

                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException)
                {
                    return;
                }
            }
        }
    }
}