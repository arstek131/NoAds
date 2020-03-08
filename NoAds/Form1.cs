using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;

namespace NoAds
{
    public partial class Form1 : Form
    {
       [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public Form1()
        {
            
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            //check internet connection
            int desc;
            string l;

            l=InternetGetConnectedState(out desc, 0).ToString();


            if (l == "True")
            {
                
                //create a new string where download text from below URL
                var r = string.Empty;
                using (var web = new System.Net.WebClient())
                    r = web.DownloadString("http://winhelp2002.mvps.org/hosts.txt");

                //paste string in txt file
                System.IO.File.WriteAllText(@"C:\Windows\System32\drivers\etc\hosts", r);
                //System.IO.File.WriteAllText(@"C:\Users\Arslan-PC\Desktop\test.txt", r);

                MessageBox.Show("Done!");
                 
            }

            else
            {
                MessageBox.Show("Failed!\nYou need an internet connection!");
      
            }




            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mvps.org");
        }

      
    }
}
