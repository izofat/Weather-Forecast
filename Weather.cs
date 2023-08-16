using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Weather_Forecast
{
    public partial class Weather : Form
    {
        public Weather()
        {
            InitializeComponent();
        }
         public string a;
        

        // Before start change the all paths in the project i added a file images you can find them in there



        // selecting an item in the combobox triggers this
        private void comboBoxcities_SelectedIndexChanged(object sender, EventArgs e)
        {
            // showing datas
            groupBoxcontions.Visible = true;
            var city = "";
            Data senddata = new Data();
            city = comboBoxcities.SelectedItem.ToString();
            
            //sending city the class data
            senddata.City = city;
            //gettubg weather condition
            senddata.Willgive = "weather"; 
            //printing it
            labelweather.Text = senddata.Check();
            // setting the background image according to weathercondition
            if (senddata.Check() == "clear sky")
            {
                Bitmap image = new Bitmap("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Weather Forecast\\images\\sunny.jpg");
                this.BackgroundImage = image;
            }
            if (senddata.Check() == "few clouds" || senddata.Check() == "scattered clouds")
            {
                Bitmap image = new Bitmap("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Weather Forecast\\images\\scatteredcloud.jpg");
                this.BackgroundImage = image;
            }
            if (senddata.Check() == "broken clouds" || senddata.Check() == "overcast clouds")
            {
                Bitmap image = new Bitmap("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Weather Forecast\\images\\cloudy.jpg");
                this.BackgroundImage = image;
            }
            if (senddata.Check().Contains("rain"))
            {
                Bitmap image = new Bitmap("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Weather Forecast\\images\\rainy.jpg");
                this.BackgroundImage = image;
            }
            if (senddata.Check().Contains("thunderstorm"))
            {
                Bitmap image = new Bitmap("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Weather Forecast\\images\\thunderstorm.jpg");
                this.BackgroundImage = image;
            }
            if (senddata.Check().Contains("snow"))
            {
                Bitmap image = new Bitmap("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Weather Forecast\\images\\snow.jpg");
                this.BackgroundImage = image;
            }
            if (senddata.Check() == "mist" || senddata.Check() == "fog")
            {
                Bitmap image = new Bitmap("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Weather Forecast\\images\\mist.jpg");
                this.BackgroundImage = image;
            }

            // clearing the labels
            labeltemp.Text = "";
            labeltemp.Text = "Temperature ";
            labelhumidity.Text = "";
            labelhumidity.Text = "Humidity ";
            labelwind.Text = "";
            labelwind.Text = "Wind ";

            //getting the needed datas and printing it
            senddata.Willgive = "temperature";
            labeltemp.Text += senddata.Check() + "C";
            senddata.Willgive = "humidity";
            labelhumidity.Text += senddata.Check();
            senddata.Willgive = "windspeed";
            labelwind.Text += senddata.Check();
            
        }
    }
}
