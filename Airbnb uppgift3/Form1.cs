using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Airbnb_uppgift3
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        private City valStadA;
        private City valStadBa;
        private City valStadBo;


        public Form1()
        {
            InitializeComponent();
            conn.ConnectionString = "Data Source=LAPTOP2\\TESTSQL; Initial Catalog=AirbnbTest; Integrated Security=True";
        }
        private List<Accomodation> GetData(string myCity)  //bra att använda en seperat metod
        {

             //JR- Stor gap här

            List<Accomodation> accomodationsList = new List<Accomodation>();


            try
            {
                conn.Open();

                SqlCommand myQuery = new SqlCommand("SELECT * FROM " + myCity + ";", conn); //JR bra lösning att ta använda stt sträng att bestämma city
                SqlDataReader myReader = myQuery.ExecuteReader();

                int Room_id;
                int Host_id;
                string Room_type;
                string Borough;
                string Neighborhood;
                int Reviews;
                double Overall_Satisfaction;
                int Bedrooms;
                int Accommodates;
                double Price;
                double Latitude;
                double Longitude;
                string Last_modified; string letOS; // tillfälliga strängar som sedan konverteras till double
                string letBed;
                string letPrice;

                // string letMS;
                string letLat;
                string letLong;

                while (myReader.Read())
                {
                    Room_id = (int)myReader["Room_id"];
                    Host_id = (int)myReader["Host_id"];
                    Room_type = (string)myReader["Room_type"];
                    Borough = myReader["Borough"].ToString();
                    Neighborhood = myReader["Neighborhood"].ToString();
                    Reviews = (int)myReader["reviews"];
                    letOS = myReader["Overall_Satisfaction"].ToString();
                    Overall_Satisfaction = double.Parse(letOS);
                    letBed = myReader["Bedrooms"].ToString();
                    Bedrooms = int.Parse(letBed);
                    Accommodates = (int)myReader["Accommodates"];
                    letPrice = myReader["Price"].ToString();
                    Price = double.Parse(letPrice);
                    bool MinstayTest = int.TryParse(Convert.ToString(myReader["Minstay"]), out int Minstay);
                    if (MinstayTest == false)
                    {
                        Minstay = 0;
                    }
                    letLat = myReader["Latitude"].ToString();
                    Latitude = double.Parse(letLat);
                    letLong = myReader["Longitude"].ToString();
                    Longitude = double.Parse(letLong);
                    Last_modified = myReader["Last_modified"].ToString();


                    Accomodation accomodations = new Accomodation(
                        Room_id,
                        Host_id,
                        Room_type,
                        Borough,
                        Neighborhood,
                        Reviews,
                        Overall_Satisfaction,
                        Accommodates,
                        Bedrooms,
                        (int)Price,
                        Minstay,
                        Latitude,
                        Longitude,
                        Last_modified);
                    accomodationsList.Add(accomodations);

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return accomodationsList;

        }
        private void cityData()
        {
            List<Accomodation> amsterdamlist = GetData("amsterdam");
            City Amsterdam1 = new City("amsterdam", 0, 0, 0, amsterdamlist);
            List<Accomodation> bostonlist = GetData("boston");
            City Boston1 = new City("boston", 0, 0, 0, bostonlist);
            List<Accomodation> barcelonalist = GetData("barcelona");
            City Barcelona1 = new City("barcelona", 0, 0, 0, barcelonalist);

            valStadA = Amsterdam1;
            valStadBa = Barcelona1;
            valStadBo = Boston1;


        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void plotchartA() //JR-behovs axis och chart titlar 
        {
            List<Accomodation> scatterList = valStadA.Accommodates;

            var priceprice = from i in scatterList
                             where i.Overall_satisfaction < 4.5
                             where i.Price < 500
                             select new { i.Overall_satisfaction, i.Price };
            foreach (var a in priceprice)
            {
                chart1.Series["Amsterdam"].Points.AddXY(a.Price, a.Overall_satisfaction);
            }
            chart1.Series["Amsterdam"].ChartType = SeriesChartType.Point;
        }
        private void plotchartBo()//JR-behovs axis och chart titlar 
        {
            List<Accomodation> scatterList = valStadBo.Accommodates;

            var priceprice = from i in scatterList
                             where i.Overall_satisfaction < 4.5
                             where i.Price < 500
                             select new { i.Overall_satisfaction, i.Price };
            foreach (var a in priceprice)
            {
                chart2.Series["Boston"].Points.AddXY(a.Price, a.Overall_satisfaction);
            }
            chart2.Series["Boston"].ChartType = SeriesChartType.Point;
        }
        private void plotchartBa()//JR-behovs axis och chart titlar 
        {
            List<Accomodation> scatterList = valStadBa.Accommodates;

            var priceprice = from i in scatterList
                             where i.Overall_satisfaction < 4.5
                             where i.Price < 500
                             select new { i.Overall_satisfaction, i.Price };
            foreach (var a in priceprice)
            {
                chart3.Series["Barcelona"].Points.AddXY(a.Price, a.Overall_satisfaction);
            }
            chart3.Series["Barcelona"].ChartType = SeriesChartType.Point;
        }

        private void histogramA()//JR-behovs axis och chart titlar 
        {
            List<Accomodation> histList = valStadA.Accommodates;

            var spridning = from f in histList
                            where f.Room_type == "Private room"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart4.Series["Amsterdam"].Points.AddY(b.Price);
            }
            chart4.Series["Amsterdam"].ChartType = SeriesChartType.Column;
        }

        private void histogramBo()//JR-behovs axis och chart titlar 
        {
            List<Accomodation> histList = valStadBo.Accommodates;

            var spridning = from f in histList
                            where f.Room_type == "Private room"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart5.Series["Boston"].Points.AddY(b.Price);
            }
            chart5.Series["Boston"].ChartType = SeriesChartType.Column;
        }

        private void histogramBa()//JR-behovs axis och chart titlar 
        {
            List<Accomodation> histList = valStadBa.Accommodates;

            var spridning = from f in histList
                            where f.Room_type == "Private room"
                            select new { f.Price };
            foreach (var b in spridning)
            {
                chart6.Series["Barcelona"].Points.AddY(b.Price);
            }
            chart6.Series["Barcelona"].ChartType = SeriesChartType.Column;
        }

        private void Form1_Load(object sender, EventArgs e) //JR- smart!!
        {
            cityData();
            plotchartA();
            plotchartBo();
            plotchartBa();
            histogramA();
            histogramBo();
            histogramBa();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }

}
/*JR- Allt ser ut jätte klart och tydligt
 * Bra variable namn men det blanda mellan svenska och engleska
 * Älska dina metoder att reducera kodmassa
 * 
 * Inga Felkontrol när connection inte uppkoppla, finns inga console i WindowsForms,bättre med messagebox
 * 
 */
