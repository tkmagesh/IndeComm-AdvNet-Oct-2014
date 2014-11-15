using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace TPLDemo
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

        private void btnDoWork_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Work Started..");
            var t = new Task(DoWork);
            TaskAwaiter taskAwaiter = t.GetAwaiter();
            
            t.ContinueWith((t2) =>
            {
                MessageBox.Show("Work Completed..");
            });
            t.Start();
            
        }

        private void DoWork()
        {
            for(var i=0;i<10000;i++)
                for(var j=0;j<10000;j++)
                    for(var k=0;k<100;k++){}
            Debug.WriteLine("Task actual completion..!");
        }
    }
}
