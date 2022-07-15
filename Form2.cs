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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBoxuser_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Hotel System;Integrated Security=True");
            con.Open();
            String query = "Select Id from Table_login Where Username='" + textBoxuser.Text + "'and Password='" + textBoxpswd.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if(dt.Rows.Count==1)
            {
                Form form2 = new Form2();
                Form form3 = new Form3();
                form2.Hide();
                form3.Show();
                button1.BackColor = Color.YellowGreen;
            }
            else
            {
                if (textBoxuser.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username to login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(textBoxpswd.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password to login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
                else
                {
                    MessageBox.Show("This Username or Password Doesn't Exists", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            } 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.LawnGreen;
        }
       
    }
}
