using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace RingaDing
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}