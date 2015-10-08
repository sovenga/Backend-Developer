using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.pojos;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        static string p = "root";
        MySqlCommand cmd;
        static string conString = "SERVER=localhost;DATABASE=artistsDB;UID=root;Password=" + p + ";";
        MySqlConnection con = new MySqlConnection(conString);
        MySqlDataAdapter adaper;
        string[] artists_names_array = new string[16];
        string[] artists_ID_array = new string[16];
        string[] artists_aliases_array = new string[16];
        string[] artists_country_array = new string[16];
        DataSet dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            dataset = new DataSet();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
            readXLSLFile();
          
        }
        //public List<Artists>
        public void readXLSLFile()
        {
            /*try
            {*/


            string path = "C:\\Users\\Mod\\Desktop\\Project\\artists.xlsx ";

            Workbook wb = excel.Workbooks.Open(path);
            string data1 = excel.Cells[1, 1].Value.ToString();


            if (wb != null)
            {
                int i;
                int x = 0;
                for (i = 1; i <= 16; i++)
                {



                    artists_names_array[x] = excel.Cells[i, 1].Value.ToString();
                    artists_ID_array[x] = excel.Cells[i, 2].Value.ToString();
                    artists_country_array[x] = excel.Cells[i, 3].Value.ToString();
                    artists_aliases_array[x] = excel.Cells[i, 4].Value.ToString();


                    //cmd.CommandText = "INSERT INTO artists VALUES('" + 200 + "','" + artists_names_array[i] + "','" + artists_ID_array[i] + "','" + artists_aliases_array[i] + "','" + artists_country_array[i] + "');";
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO artists VALUES('" + 0 + "','" + artists_names_array[x] + "','" + artists_ID_array[x] + "','" + artists_aliases_array[x] + "','" + artists_country_array[x] + "');";
                    x++;
                    cmd.ExecuteNonQuery();
                }
            }
            else { //MessageBox.Show("File not found");
            }
            //wb.Close();
            /*}catch
            {

            }*/

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string searchChar = TextBox1.Text.ToString();

           
            try
            {
                string sql1 = "select * from artists where artist_name like %'" + searchChar + "'%";
                string sql = "select * from artists";
                adaper = new MySqlDataAdapter(sql, con);
                adaper.Fill(dataset);
                cmd.Parameters.AddWithValue("Artists_name", searchChar);
                dataset.WriteXml("C:\\Users\\Mod\\Desktop\\Project\\artists.xml");
            }
            catch
            {

            }
        }
        public List<Artist> getArtists(string searchChar)
        {
            List<Artist> artists = null;

            cmd = con.CreateCommand();
            cmd.CommandText = "select * from artists where artist_name like %'"+searchChar+"'%";
            //
            return artists;

        }
    }
}