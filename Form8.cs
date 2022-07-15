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
    public partial class Form8 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Hotel System;Integrated Security=True");
        public Form8()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter ID to insert successfully!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Please enter Name to insert successfully!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();

            }
            else if(comboBox1.Text=="")
            {
                MessageBox.Show("Please select a value from Gender to insert successfully!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
             }
            else if(textBox3.Text=="")
            {
                MessageBox.Show("Please enter Address to insert successfully!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if(textBox4.Text=="")
            {
                MessageBox.Show("Please enter Phone to  successfully!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
             }
            else if(comboBox2.Text=="")
            {
                MessageBox.Show("Please select a value from works to insert successfully!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.Focus();
            }
            else if(comboBox3.Text=="")
            {
                MessageBox.Show("Please select a value from schedule to insert successfully!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Table_mgt_room Values(@ID,@Name,@Gender,@Address,@Phone,@Works,@Schedule)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@Works", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Schedule", comboBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
            }
            
        }
        private void displayData()
        {
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_mgt_room", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
        }
      

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Table_mgt_room where ID="+id+"", con);
                cmd.CommandType = CommandType.Text;
              //  cmd.Parameters.AddWithValue("@ID", textBox1.Text);

                cmd.ExecuteNonQuery();
                con.Close();
               DialogResult result= MessageBox.Show("Deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result==DialogResult.OK)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    displayData();
                }
            }
            catch(Exception yy)
            {
                MessageBox.Show(yy.Message);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please select the ID to update successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Table_mgt_room Set Name=@Name,Gender=@Gender,Address=@Address,Phone=@Phone,Works=@Works,Schedule=@Schedule where ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@Works", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Schedule", comboBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Information is updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown3(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown4(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown5(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox3.Focus();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow select = dataGridView1.Rows[index];
            textBox1.Text = select.Cells[0].Value.ToString();
            textBox2.Text = select.Cells[1].Value.ToString();
            comboBox1.Text = select.Cells[2].Value.ToString();
            textBox3.Text = select.Cells[3].Value.ToString();
            textBox4.Text = select.Cells[4].Value.ToString();
            comboBox2.Text = select.Cells[5].Value.ToString();
            comboBox3.Text = select.Cells[6].Value.ToString();

        }

        private void comboBox3_KeyDown6(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_mgt_room where ID like '"+txt_Search.Text+"%'", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
            con.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_mgt_room", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
            con.Close();
        }
    }
}
