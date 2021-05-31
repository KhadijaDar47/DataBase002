using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Collections;

namespace DataBasetry
{
    public partial class Form1 : Form
    {
        class Flight
        {
            public string FlightName;
            public string AirlineCode;
            public string AirlineName;

        }
        
        public Form1()
        {
            InitializeComponent();
        }
        Flight flight = new Flight();

        List<Flight> flist = new List<Flight>();

        SqlConnection SQ = new SqlConnection(@"Data Source=DESKTOP-RNCCR03\SQLEXPRESS;Initial Catalog=Flight;Integrated Security=True");



        //add data in DB
        private void button1_Click(object sender, EventArgs e)
        {


            flight.FlightName = textBox1.Text;
            flight.AirlineCode = textBox2.Text;
            flight.AirlineName = textBox3.Text;
            flist.Add(flight);
            

            SQ.Open();
            String query = "INSERT INTO FlightSchedule (FlightCode,AirlineCode,AirlineName) VALUES ('" + flist.ElementAt(flist.Count-1).FlightName + "','" + flist.ElementAt(flist.Count - 1).AirlineCode + "','" + flist.ElementAt(flist.Count - 1).AirlineName + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query,SQ);
            sda.SelectCommand.ExecuteNonQuery();
            SQ.Close();
            MessageBox.Show("BALLEY BALLEY","Hogyaa",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }



        //View Data
        private void button2_Click(object sender, EventArgs e)
        {

            SQ.Open();
            string query = "SELECT * FROM FlightSchedule";
            SqlDataAdapter sda = new SqlDataAdapter(query, SQ);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            SQ.Close();

        }



        //search data form db
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                SQ.Open();
                string query = "SELECT * FROM FlightSchedule where FlightCode = '" + textBox1.Text + "'";
             
            SqlCommand sda = new SqlCommand(query, SQ);
            SqlDataReader dr;
            
                dr = sda.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    textBox2.Text = (dr["AirlineCode"].ToString());
                    textBox3.Text = (dr["AirlineName"].ToString());
                }
                else
                {
                    MessageBox.Show("DATA NOT FOUND!!");
                }

                SQ.Close();
             }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //update from db
        private void button4_Click(object sender, EventArgs e)
        {

            SQ.Open();
            string query = "UPDATE  FlightSchedule SET AirlineCode = '" + textBox2.Text+ "', AirlineName = '" + textBox3.Text + "'Where FlightCode = '" + textBox1.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, SQ);
            sda.SelectCommand.ExecuteNonQuery();
            SQ.Close();
            MessageBox.Show("HO Gya Kam");
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

        }

        //Delete Data form db
        private void button5_Click(object sender, EventArgs e)
        {

            SQ.Open();
            string query = "DELETE FROM FlightSchedule where FlightCode = '"+textBox1.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, SQ);
            sda.SelectCommand.ExecuteNonQuery();
            SQ.Close();
            MessageBox.Show("Ja Ja Tur Ja ");
        }
    }
}
