using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinskWeather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + textBox1.Text+ "&appid=bf687598c1e7f9766ac87825eeb9944d&units=metric";
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
                richTextBox1.AppendText(weatherResponse.Name.ToString()+"\n"+
                                        weatherResponse.Main.Temp.ToString()+"\n"+
                                        weatherResponse.Main.Pressure.ToString()+"\n"+
                                        weatherResponse.Main.Humidity.ToString()+
                                        "\n\n");
                lblResultTemperature.Text = weatherResponse.Main.Temp.ToString();
                lblResultPressure.Text = weatherResponse.Main.Pressure.ToString();
            }catch(Exception)
            {
                
            }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResultTemperature.Text = "";
            lblResultPressure.Text = "";
        }
    }
}
