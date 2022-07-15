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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Hotel System;Integrated Security=True");

        public Form6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Room number is required to insert successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select value from RoomType to insert successfully! ");
                comboBox1.Focus();
            }
             else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value from Rate to insert successfully!");
                comboBox2.Focus();
            }
            else if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please checked one radiobutton to insert successfully!");
                radioButton1.Focus();
                radioButton2.Focus();

            }            

            else
            {
            
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Table_room Values(@ID,@RoomNo,@RoomType,@Rate,@Availability)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", textBox3.Text);               
                cmd.Parameters.AddWithValue("@RoomNo", textBox1.Text);
                cmd.Parameters.AddWithValue("@RoomType", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Rate", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Availability", textBox2.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
        }
            
        }
        private void displayData()
        {
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_room", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
            dataGridView1.Columns[0].Visible = false;
        }
      

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked= false;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double room_no = Convert.ToInt64(textBox1.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Table_room where RoomNo="+room_no+"", con);
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@RoomNo", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
               DialogResult result= MessageBox.Show("Deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(result==DialogResult.OK)
                {
                    textBox1.Text = "";
                    comboBox1.Text="";
                    comboBox2.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    displayData();
                    if(radioButton1.Checked==true)
                    {
                        radioButton1.Checked = false;
                         
                    }
                    else if( radioButton2.Checked==true)
                    {
                        radioButton2.Checked=false;
                    }
                }

            }
            catch(Exception yy)
            {
                MessageBox.Show(yy.Message);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please select item to update successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Table_room Set ID=@ID, RoomNo=@RoomNo,RoomType=@RoomType,Rate=@Rate,Availability=@Availability where ID=@ID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", textBox3.Text);
                cmd.Parameters.AddWithValue("@RoomNo", textBox1.Text);
                cmd.Parameters.AddWithValue("@RoomType", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Rate", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Availability", textBox2.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                textBox2.Text = "YES";
            }
           

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                textBox2.Text = "NO";

            }
           
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
            if(e.KeyCode==Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow select = dataGridView1.Rows[index];
            textBox3.Text = select.Cells[0].Value.ToString();
            textBox1.Text = select.Cells[1].Value.ToString();
            comboBox1.Text = select.Cells[2].Value.ToString();
            comboBox2.Text = select.Cells[3].Value.ToString();
            textBox2.Text = select.Cells[4].Value.ToString();
            if (textBox2.Text == "YES")
            {
                radioButton1.Checked = true;
                               
            }
            else if (textBox2.Text == "NO")
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
           
            }

        private void comboBox2_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown3(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }
    }
}
