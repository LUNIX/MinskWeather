using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest request;
            request = WebRequest.Create(@"https://www.meteoservice.ru/weather/now/minsk.html");
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                using (var reader = new System.IO.StreamReader(stream))
                {
                    string data = reader.ReadToEnd();
                    string town = new Regex(@"<h1>(?<town>.*)</h1>").Match(data).Groups["town"].Value;
                    string temp = new Regex(@"<span class=""temperature"">(?<temp>[^<]+)<span title=""Градус Цельсия"">").Match(data).Groups["temp"].Value;
                    string osadki = new Regex(@"<td class=""title"">Облачность:</td>[^<]*?<td>(?<osadki>[^<]+)</td>").Match(data).Groups["osadki"].Value;
                    Console.WriteLine(town + "\nТемпература воздуха: " + temp + "\nОсадки: " + osadki);
                    Console.ReadLine();
                }
            }
        }
    }
}
