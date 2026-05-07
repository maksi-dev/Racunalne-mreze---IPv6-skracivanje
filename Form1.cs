using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipv6
{
    public partial class IPv6 : Form
    {
        public IPv6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //2A15:FFFF:0000:0000:0000:566A:0000:0000
            int n = 0, najd = 0, najdz = 0, dulj = 0;
            string ispis = "";
            string adresa = unos.Text;  //u adresa string unosim unos iz textboxa
            adresa = adresa.Trim(' ');  //uklanjam moguce slucajno upisane razmake nakon/ispred unosa
            //List<string> lista = new List<string>();    //lista u koju ce kasnije biti spremljeni segmenti IPv6 adrese
            string[] djel = adresa.Split(':');
            int l = djel.Length;
            if (l == 8)
            {
                foreach (string s in djel)
                {
                    if (s.Length != 4)
                    {
                        n = 1;
                    }
                }
                if (n == 0)
                {   
                    
                    for(int i = 0; i < 8; i++)
                    {
                        if (djel[i] == "0000"){
                            djel[i] = "0";
                        }
                    }
                    for(int i = 1; i < 8; i++)
                    {
                        if(djel[i] == "0" && djel [i-1] == "0")
                        {
                            dulj++;
                            if (dulj > najd)
                            {
                                najd = dulj;
                                najdz = i;
                            }
                        }
                        else
                        {
                            dulj = 0;
                        }
                    }
                    for ( int i = najdz-najd; i <= najdz ; i++)
                    {
                        djel[i] = "";
                    }
                    if (djel[0] == "0" && djel[1] == "")
                    {
                        djel[0] = ":";
                    }
                    ispis = djel[0];
                    for (int i = 1; i < 8; i++)
                    {
                        if (djel[i] == "" && djel[i-1]=="")
                        {

                        }
                        else
                        {
                            ispis = ispis + ":" + djel[i];
                        }
                    }
                    if (djel[7] == "")
                    {
                        ispis = ispis + ":";
                    }
                }
                else
                {
                    MessageBox.Show($"Neispravan format");
                }
                MessageBox.Show($"{ispis}");
            }
            else
            {
                MessageBox.Show($"Neispravan unos, premalo segmenata.");
            }
        }
    }
}
