using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sec6
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load_1(object sender, EventArgs e)
        {
            display();
        }
        

        private void display()
        {
            SqlConnection con = new SqlConnection("Data Source=aya;Initial Catalog=scool2;Integrated Security=True;TrustServerCertificate=True;");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from student", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void insert()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source=aya;Initial Catalog=scool2;Integrated Security=True;TrustServerCertificate=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into student(id,name,age) values(@id,@name,@age)", con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
            }
            else
            {
                MessageBox.Show("please provide details");
            }
        }


        private void delete()
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source=aya;Initial Catalog=scool2;Integrated Security=True;TrustServerCertificate=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from student where id=@id", con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record deleted Successfully");
            }
            else
            {
                MessageBox.Show("please enter id to delete");
            }
        }
       
 


        private void update()
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source=aya;Initial Catalog=scool2;Integrated Security=True;TrustServerCertificate=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("update student set name=@name, age=@age where id=@id", con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record updated Successfully");
            }
            else
            {
                
                MessageBox.Show("please enter details to update");
            }
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            insert();
            display();
            clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            delete();
            display();
            clear();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            update();
            display();
            clear();
        }








        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
