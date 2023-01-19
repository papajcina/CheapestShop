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
using System.Web.UI.WebControls;

namespace Prodavnicve
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\Prodavnicve\Prodavnicve\lista.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Mleko");
            checkedListBox1.Items.Add("Pasteta");
            checkedListBox1.Items.Add("Leb");

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int j = 0;
            int[] nizkup1 = new int[100];
            int[] nizkup2 = new int[100];
            int[] nizkup3 = new int[100];
            int[] nizkup4 = new int[100];
            int[] nizkup5 = new int[100];
            int[] nizkup6 = new int[100];
            int[] nizkup7 = new int[100];
            foreach (string item in checkedListBox1.CheckedItems)
            {
                if (checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select Id, Min(" + item + ") as Kup FROM Tabelata Group By Id ", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        string tbd = reader1["Id"].ToString();
                        if (tbd == "1")
                        {
                            nizkup1[j] = (int)reader1["Kup"];
                            j++;
                        }
                        if (tbd == "2")
                        {
                            nizkup2[j] = (int)reader1["Kup"];
                            j++;
                        }
                        if (tbd == "3")
                        {
                            nizkup3[j] = (int)reader1["Kup"];
                            j++;
                        }
                        if (tbd == "4")
                        {
                            nizkup4[j] = (int)reader1["Kup"];
                            j++;
                        }
                        if (tbd == "5")
                        {
                            nizkup5[j] = (int)reader1["Kup"];
                            j++;
                        }
                        if (tbd == "6")
                        {
                            nizkup6[j] = (int)reader1["Kup"];
                            j++;
                        }
                        if (tbd == "7")
                        {
                            nizkup7[j] = (int)reader1["Kup"];
                            j++;
                        }
                    }






                    reader1.Close();
                    con.Close();


                }

                
            }

            int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0, sum6 = 0, sum7 = 0;
            for (int w = 0; w < nizkup1.Length; w++)
            {
                sum1 += nizkup1[w];
            }
            for (int w = 0; w < nizkup2.Length; w++)
            {
                sum2 += nizkup2[w];
            }
            for (int w = 0; w < nizkup3.Length; w++)
            {
                sum3 += nizkup3[w];
            }
            for (int w = 0; w < nizkup4.Length; w++)
            {
                sum4 += nizkup4[w];
            }
            for (int w = 0; w < nizkup5.Length; w++)
            {
                sum5 += nizkup5[w];
            }
            for (int w = 0; w < nizkup6.Length; w++)
            {
                sum6 += nizkup6[w];
            }
            for (int w = 0; w < nizkup7.Length; w++)
            {
                sum7 += nizkup7[w];
            }

            int[] nizsum = { sum1, sum2, sum3, sum4, sum5, sum6, sum7 };
            int min = nizsum.Min();
            int mini = Array.IndexOf(nizsum, nizsum.Min()) + 1;
            textBox2.Text = min.ToString();
            textBox1.Text = mini.ToString();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
