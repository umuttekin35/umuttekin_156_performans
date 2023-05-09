using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace umuttekin_156_performans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listele()
        {
            SQLiteConnection baglanti =
                new SQLiteConnection("Data Source=C:\\Users\\PC\\Desktop\\Yazılım\\kisirehberi.db;version=3");
            baglanti.Open();
            SQLiteDataAdapter da =
                new SQLiteDataAdapter("SELECT * FROM kisirehberi", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "kisirehberi");
            dataGridView1.DataSource = ds.Tables["kisirehberi"];
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti =
                    new SQLiteConnection("Data Source=C:\\Users\\PC\\Desktop\\Yazılım\\kisirehberi.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText =
                    "INSERT INTO kisirehberi VALUES('" + textBox1.Text + "','" +
                    textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA " + ex.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti =
                    new SQLiteConnection("Data Source=C:\\Users\\PC\\Desktop\\Yazılım\\kisirehberi.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText =
                    "DELETE FROM ogrenci WHERE telno='" + textBox3.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex.Message);
            }
        }
    }
}
