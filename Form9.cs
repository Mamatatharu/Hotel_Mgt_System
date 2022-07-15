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

namespace project_of_hotel
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Hotel System;Integrated Security=True");
        public String ClientName { get; set; }
        public String RoomType { get; set; }
        public String Days { get; set; }

        private void Form9_Load(object sender, EventArgs e)
        {
            textBox1.Text = ClientName;
            comboBox1.Text = RoomType;
            txtDays.Text = Days;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            float txt1, txt2, txt3;
            txt1 = float.Parse(txtDays.Text);
            txt2 = float.Parse(txtprice.Text);
            txt3 = txt1 * txt2;
            txt_total.Text = (txt3.ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            float a, b, c;
            a = float.Parse(txt_total.Text);
            b = float.Parse(textBox2.Text);
            c = b - a;
            textBox3.Text = (c.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          /*
          AutoCompleteStringCollection col = new AutoCompleteStringCollection();
         
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlDataReader sdr = default(SqlDataReader);
            SqlCommand cmd = new SqlCommand("select ClientName from Table_payments", con);
           // cmd.Parameters.Add(new SqlParameter("@ClientName","%" +textBox1.Text+ "%"));
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
             sdr=cmd.ExecuteReader();
            
            while(sdr.Read())
            {
                col.Add(sdr.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = col;
            con.Close();
            //sdr.Close();
           */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Table_payments Values(@ClientName,@RoomType,@Days,@Price,@NetAmount,@Render,@Change)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ClientName", textBox1.Text);
                cmd.Parameters.AddWithValue("@RoomType", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Days", txtDays.Text);
                cmd.Parameters.AddWithValue("@Price", txtprice.Text);
                cmd.Parameters.AddWithValue("@NetAmount", txt_total.Text);
                cmd.Parameters.AddWithValue("@Render", textBox2.Text);
                cmd.Parameters.AddWithValue("@Change", textBox3.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                displayData();
            }
            catch(Exception yy)
            {
                MessageBox.Show(yy.Message);
            }
        }
       
        private void displayData()
        {
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_payments", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow select = dataGridView1.Rows[index];
            textBox1.Text = select.Cells[0].Value.ToString();
            comboBox1.Text = select.Cells[1].Value.ToString();
            txtDays.Text = select.Cells[2].Value.ToString();
            txtprice.Text = select.Cells[3].Value.ToString();
            txt_total.Text = select.Cells[4].Value.ToString();
            textBox2.Text = select.Cells[5].Value.ToString();
            textBox3.Text = select.Cells[6].Value.ToString();
        }     

        private void button4_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
               try
            {
                string ClientName = textBox1.Text;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Table_payments where ClientName='" + ClientName + "'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                   DialogResult result= MessageBox.Show("Deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   if (result==DialogResult.OK)
                   {
                       textBox1.Text = "";
                       comboBox1.Text = "";
                       txtDays.Text = "";
                       txtprice.Text = "";
                       txt_total.Text = "";
                       textBox2.Text = "";
                       textBox3.Text = "";
                       displayData();
                   }

            }
            catch(Exception yy)
            {
                MessageBox.Show(yy.Message);
            }
        }
        
      
    }
}
