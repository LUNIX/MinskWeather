using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace MinskWeatherWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + txtBoxCity.Text + "&appid=bf687598c1e7f9766ac87825eeb9944d&units=metric";
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
                richTextBox.AppendText(weatherResponse.Name.ToString() + "\n" +
                                        weatherResponse.Main.Temp.ToString() + "\n" +
                                        weatherResponse.Main.Pressure.ToString() + "\n" +
                                        weatherResponse.Main.Humidity.ToString() +
                                        "\n\n");
                //lblResultTemperature.Text = weatherResponse.Main.Temp.ToString();
                //lblResultPressure.Text = weatherResponse.Main.Pressure.ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}
