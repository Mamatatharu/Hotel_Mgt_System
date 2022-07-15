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
using System.Globalization;


namespace project_of_hotel
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Hotel System;Integrated Security=True");

        public Form4()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
           
            if(textBox1.Text=="")
            {
                errorProvider1.SetError(textBox1, "ID is required!");
                textBox1.Focus();
               // MessageBox.Show("Id is required to insert successfully!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                else if (textBox2.Text=="")
            {
                errorProvider1.SetError(textBox2, "Client's Name is required!");
                textBox2.Focus();
               // MessageBox.Show("Client's Name is required to insert successfully!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox3.Text=="")
            {
                errorProvider1.SetError(textBox3, "Address is required!");
                textBox3.Focus();
                //MessageBox.Show("Address is required to insert successfully!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox4.Text=="")
            {
                errorProvider1.SetError(textBox4, "Phone Number is requird!");
                textBox4.Focus();
               // MessageBox.Show("Phone number is required to insert successfully!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Room Number is requird!");
                textBox5.Focus();
            }
            else if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox5, "Room Type is requird!");
                comboBox1.Focus();
            }
            else
            {
                errorProvider1.Clear();
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Table_mgt_reserve Values(@ID,@ClientName, @Address, @Phone,@EntryDate,@DepartureDate,@RoomNo,@RoomType)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@ClientName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@EntryDate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@DepartureDate", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@RoomNo", textBox5.Text);
                cmd.Parameters.AddWithValue("@RoomType", comboBox1.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
                errorProvider1.Clear();

            }
        }
        private void displayData()
        {
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_mgt_reserve", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                int id = Convert.ToInt32(textBox1.Text);
              
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Table_mgt_reserve where ID =" + id + "", con);
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@ID", textBox1.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                   DialogResult result= MessageBox.Show("Delete successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   if (result==DialogResult.OK)
                   {
                       textBox1.Text = "";
                       textBox2.Text = "";
                       textBox3.Text = "";
                       textBox4.Text = "";
                       textBox5.Text = "";
                       textBox6.Text = "";
                       textBox7.Text = "";
                       textBox8.Text = "";
                       comboBox1.Text = "";
                       displayData();
                   }

            }
            catch(Exception yy)
            {
                MessageBox.Show(yy.Message);
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please select the item to update successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Table_mgt_reserve Set ClientName=@ClientName, Address=@Address, Phone=@Phone,EntryDate=@EntryDate,DepartureDate=@DepartureDate,RoomNo=@RoomNo,RoomType=@RoomType where ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@ClientName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@EntryDate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@DepartureDate", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@RoomNo", textBox5.Text);
                cmd.Parameters.AddWithValue("@RoomType", comboBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int index = e.RowIndex;
            DataGridViewRow select = dataGridView1.Rows[index];
            textBox1.Text = select.Cells[0].Value.ToString();
            textBox2.Text = select.Cells[1].Value.ToString();
            textBox3.Text = select.Cells[2].Value.ToString();
            textBox4.Text = select.Cells[3].Value.ToString();
            textBox6.Text = select.Cells[4].Value.ToString();
            textBox7.Text = select.Cells[5].Value.ToString();
            textBox5.Text = select.Cells[6].Value.ToString();
            comboBox1.Text = select.Cells[7].Value.ToString();
           // dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
           // dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value); 

          /*  DateTime newDatetime;
            DateTime newDateTime1;
            if(DateTime.TryParse(textBox6.Text,out newDatetime))
            {
                dateTimePicker1.Value=newDatetime;
            }
            else if(DateTime.TryParse(textBox7.Text,out newDateTime1))
            {
                dateTimePicker2.Value = newDateTime1;
            }
            else
            {
                //....
            }
            DateTime getDate = new DateTime();
            getDate = Convert.ToDateTime(textBox6.Text);
            dateTimePicker1.Text = getDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            textBox5.Text = select.Cells[5].Value.ToString();
            dataGridView1.SelectionMode=DataGridViewSelectionMode.FullRowSelect;*/
            if(dataGridView1.SelectedRows.Count>0)
            {
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value);
                dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value);
                DateTime d1 = dateTimePicker1.Value;
                DateTime d2 = dateTimePicker2.Value;
                TimeSpan ts = d2 - d1;
                int days = ts.Days;
                textBox8.Text = days.ToString() + "Days";


            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                dateTimePicker1.Focus();
                errorProvider1.Clear();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox2.Focus();
                errorProvider1.Clear();

            }
        }

        private void textBox3_KeyDown2(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox4.Focus();
                errorProvider1.Clear();

            }
        }

        private void textBox2_KeyDown3(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox3.Focus();
                errorProvider1.Clear();

            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker2_KeyDown4(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown6(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
                errorProvider1.Clear();
            }
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.SlateBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Transparent;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form4 = new Form4();
            Form form9 = new Form9();
            using(var f=new Form9())
            {
                f.ClientName = textBox2.Text;
                f.RoomType = comboBox1.Text;
                f.Days = textBox8.Text;
                f.ShowDialog();
            }
            form4.Hide();

        }

        private void txt_searchName_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_mgt_reserve where ClientName like '"+txt_searchName.Text+"%'", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           // MessageBox.Show("Hello");
            textBox6.Text = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            textBox7.Text = dateTimePicker2.Value.ToString("yyyy/MM/dd");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sdp = new SqlDataAdapter("select * from Table_mgt_reserve", con);
            DataTable td = new DataTable();
            sdp.Fill(td);
            dataGridView1.DataSource = td;
            con.Close();
        }

        private void dateTimePicker1_KeyUp(object sender, KeyEventArgs e)
        {
            if((e.KeyCode==Keys.Back)||(e.KeyCode==Keys.Delete))
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = dateTimePicker2.Value;
            TimeSpan ts = d2-d1;
            int days = ts.Days;
            textBox8.Text = "Days:" + ts.TotalDays.ToString();
        }

        private void comboBox1_KeyDown7(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
                errorProvider1.Clear();
            }
        }
      
    }
}
