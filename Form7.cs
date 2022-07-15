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
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Hotel System;Integrated Security=True");

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a clientname to insert successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter a FoodName to insert successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
            }

            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Please enter a PlateQuantity to insert successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.Focus();
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Please enter a Price to insert successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus();

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Table_foods Values(@ClientName,@FoodName,@PlateQuantity,@Price)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ClientName", textBox1.Text);
                cmd.Parameters.AddWithValue("@FoodName", comboBox1.Text);
                cmd.Parameters.AddWithValue("@PlateQuantity", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Price", comboBox3.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
            }
        }
        private void displayData()
        {
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_foods", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            displayData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Clientname is required to delete successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //int Clientname=Convert.ToInt32(textBox1.Text);
                    string Clientname = textBox1.Text;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Table_foods where ClientName='" + Clientname + "'", con);
                    cmd.CommandType = CommandType.Text;
                    // cmd.Parameters.AddWithValue("@ClientName", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DialogResult result = MessageBox.Show("Deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        textBox1.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        displayData();
                    }
                }
                catch (Exception yy)
                {
                    MessageBox.Show(yy.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow select = dataGridView1.Rows[index];
            textBox1.Text = select.Cells[0].Value.ToString();
            comboBox1.Text = select.Cells[1].Value.ToString();
            comboBox2.Text = select.Cells[2].Value.ToString();
            comboBox3.Text = select.Cells[3].Value.ToString();

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox3.Focus();
            }
        }

        private void comboBox3_KeyDown3(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }
   
    }
}
