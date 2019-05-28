using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WorldOfCinema
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();

        }

        static string FreeTest(string password)
        {
            byte[] hash = Encoding.ASCII.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pathToData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase.UsersModel");
            var first = new User();
            first.Login = textBox1.Text;
            first.Password = FreeTest(textBox2.Text);
            first.Status = textBox3.Text;
            listBox1.Items.Add(first);
            var storage = new UsersModel()
            {
                Users = listBox1.Items.OfType<User>().ToList()

            };
            var xs = new XmlSerializer(typeof(UsersModel));
            var file = File.Create(pathToData);
            xs.Serialize(file, storage);
            listBox1.Items.Clear();
            foreach (var items in storage.Users)
            {
                listBox1.Items.Add(items);
            }
            file.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
