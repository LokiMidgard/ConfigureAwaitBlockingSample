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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test.Do().ConfigureAwait(false);
        }
    }

    public class Test
    {
        public static async Task Do()
        {
            await SubTask().ConfigureAwait(false);
            // We are still in the UI thread here
            SubTask2().Wait(); // <-- This will block the current thread it doesn't matter if SubTask2 uses ConfigureAwait(false)
        }

        public static Task SubTask()
        {
            // simulate fast completion
            return Task.CompletedTask;
        }

        public static async Task SubTask2()
        {
            await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
        }
    }
}
