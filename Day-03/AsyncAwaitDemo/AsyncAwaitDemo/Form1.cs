using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("In Button Click - Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
            var result = await PerformLongRunningTask();
            Debug.WriteLine("Result = {0}", result);
        }

        private Task<int> PerformLongRunningTask()
        {
            return Task.Run(() =>
            {
                Debug.WriteLine("In PerformLongRunningTask - Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10000);
                return new Random().Next(2000);
            });
        }
    }
}
