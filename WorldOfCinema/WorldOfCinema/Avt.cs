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
    public partial class Avt : Form
    {
        static public string status;

        public Avt()
        {
            InitializeComponent();
        }

        private void Check()
        {
            string login = textBox1.Text;
            string password = FreeTest(textBox2.Text);
            string pathToStorage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase.UsersModel");
            var xs = new XmlSerializer(typeof(UsersModel));
            var file = File.OpenRead(pathToStorage);
            var storage = (UsersModel)xs.Deserialize(file);
            for (var i = 0; i < storage.Users.Count(); i++)
            {
                if (storage.Users[i].Login == login && storage.Users[i].Password == password)
                {
                    status = storage.Users[i].Status;
                    if (status == "user")
                    {
                        Form1.Login = login;
                        Form1.Password = password;
                    }
                    Close();
                }
            }
            file.Close();
            MessageBox.Show("Ошибка доступа. Неверные логин или пароль.");
        }

        static string FreeTest(string password) // шифрует переданную строку
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

        private void button1_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.checker = false;
            Close();
        }

        private void Avt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.checker = false;
        }

        private void Avt_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
