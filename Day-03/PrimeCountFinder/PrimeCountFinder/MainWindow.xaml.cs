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

namespace PrimeCountFinder
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

        private void btnFindPrimes_Click(object sender, RoutedEventArgs e)
        {
            var start = 100000;
            var end = 200000;
            var t = Task.Factory.StartNew<int>((obj) =>
            {
                var result = GetPrimeCount(obj);
                return result;
            }, new PrimeFindData {Start = start, End = end});
            t.ContinueWith(antecendent =>
            {
                MessageBox.Show(antecendent.Result.ToString());
            });
            MessageBox.Show("Work started");
        }

        private int GetPrimeCount(object data)
        {
            var primeFindData = (PrimeFindData) data;
            var primeCount = 0;
            for (var i = primeFindData.Start; i <= primeFindData.End; i++)
            {
                if (isPrime(i))
                    primeCount++;
            }
            return primeCount;
        }

        private bool isPrime(int n)
        {
            for(var i=2;i<=(n/2);i++)
                if (n%i == 0) return false;
            return true;
        }
    }

    public class PrimeFindData
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
}
