using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace WorldOfCinema
{
    public partial class ADmin : Form
    {
        public static Films films;
        public ADmin()
        {
            InitializeComponent();
            
            string pathToStorage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "films.txt"); // загружает список сеансов при включении
            string[] Mass = File.ReadAllLines(pathToStorage, Encoding.GetEncoding(1251));
            foreach (string str in Mass)
            {
                string[] words = str.Split(' ');
                var first = new Film();
                first.Name = words[0];
                first.MovieTime = words[1];
                first.Seat = words[2];
                first.SeatMax = words[3];
                listBox1.Items.Add(first);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Users().ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int i = 0;
        private void button2_Click(object sender, EventArgs e) // добавляет сеанс в файл и список
        {
            var first = new Film();
            first.Name = textBox1.Text;
            first.MovieTime = textBox2.Text;
            first.Seat = textBox3.Text;
            first.SeatMax = textBox3.Text;
            listBox1.Items.Add(first);
            FileStream aFile = new FileStream("films.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            aFile.Seek(0, SeekOrigin.End);
            sw.WriteLine(first.Name + " " + first.MovieTime + " " + first.Seat + " " + first.SeatMax);
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.checker = true;
            Close();
        }
        private Excel.Application exApp;
        private Excel.Worksheet exWrkSht;
        private void button4_Click(object sender, EventArgs e)
        {
            exApp = new Excel.Application();
            exApp.Visible = true;
            exApp.SheetsInNewWorkbook = 1;
            exApp.Workbooks.Add();
            exWrkSht = exApp.Workbooks[1].Worksheets.get_Item(1);
            exWrkSht.get_Range("A1").Value = "Название";
            exWrkSht.get_Range("B1").Value = "Цена";
            exWrkSht.get_Range("C1").Value = "Мест";
            string pathToStorage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "films.txt");
            string[] Mass = File.ReadAllLines(pathToStorage, Encoding.GetEncoding(1251));
            int i = 2;
            foreach (string str in Mass)
            {
                string[] words = str.Split(' ');
                exWrkSht.get_Range("A" + i.ToString()).Value = words[0];
                exWrkSht.get_Range("B" + i.ToString()).Value = words[1];
                exWrkSht.get_Range("D" + i.ToString()).Value = words[3];
                i++;
            }
            exApp.Workbooks[1].SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "films.xlsx"));
        }

        private Word.Application wdApp;
        private Word.Document docum;
        private void button5_Click(object sender, EventArgs e)
        {
            wdApp = new Word.Application();
            wdApp.Visible = true;
            wdApp.Documents.Add();
                docum = wdApp.Documents.get_Item(1);
            string pathToData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase.UsersModel");
            var xs = new XmlSerializer(typeof(UsersModel));
            var file = File.OpenRead(pathToData);
            var storage = (UsersModel)xs.Deserialize(file);
            file.Close();
            int u = 0, a = 0;
            foreach (var items in storage.Users)
            {
                if(items.Status == "user")
                {
                    u++;
                }
                if (items.Status == "admin")
                {
                    a++;
                }
            }
            wdApp.Selection.Text = "Пользователи: " + u.ToString() + " Администраторы: " + a.ToString();
            docum.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Users.docx"));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
