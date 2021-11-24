using EFCodeFirst.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EFCodeFirst
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new View.Form1());
        }
    }
}
