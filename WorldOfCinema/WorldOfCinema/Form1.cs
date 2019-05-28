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

namespace WorldOfCinema
{
    public partial class Form1 : Form
    {
        public static string Login;
        public static string Password;
        public static UsersModel storage;
        public Form1()
        {
            InitializeComponent();
            //InitializeComponent();
            string pathToStorage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "films.txt"); // заполняет сеансы при включении
            string[] Mass = File.ReadAllLines(pathToStorage, Encoding.GetEncoding(1251));
            foreach (string str in Mass)
            {
                string[] words = str.Split(' ');
                var first = new Film();
                first.Name = words[0];
                first.MovieTime = words[1];
                first.Seat = words[2];
                first.SeatMax = words[3];
                ListViewItem listViewItem = new ListViewItem(new string[] {words[0], words[1], words[2]});
                listView1.Items.Add(listViewItem);
            }

            string pathToData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase.UsersModel"); // заполняет мои сеансы при включении   
            var xs = new XmlSerializer(typeof(UsersModel));
            var file = File.OpenRead(pathToData);
            storage = (UsersModel)xs.Deserialize(file);
            for (var h = 0; h < storage.Users.Count(); h++)
            {
                if (storage.Users[h].Login == Login && storage.Users[h].Password == Password)
                {
                    for (var g = 0; g < storage.Users[h].Basket.Count(); g++)
                    {
                        ListViewItem listViewItemBasket = new ListViewItem(new string[] {storage.Users[h].Basket[g].Name, storage.Users[h].Basket[g].MovieTime, storage.Users[h].Basket[g].Seat});
                        listView2.Items.Add(listViewItemBasket);
                    }
                }
            }
            file.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Зарегистрируйтесь или авторизируйтесь \n2. Выберите сеанс  и время ");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WorldOfCinema v 1.0 alpha \n© 2019 khidira & farid_2509");
        }

        private bool _CheckFileName(string fileName) // проверяет на совпадение переданного имени в listview2
        {
            foreach (ListViewItem item in listView2.Items)
            {
                // this is the code when all your subitems are file names - if an item contains only one subitem which is a filename,
                // then you can just against that subitem, which is better in terms of performance
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    // you might want to ignore the letter case
                    if (String.Equals(fileName, subItem.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e) // добавляет выбранный сеанс в мои сеансы
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string item = listView1.SelectedItems[0].SubItems[1].Text;
                string pathToStorage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "films.txt");
                string[] Mass = File.ReadAllLines(pathToStorage, Encoding.GetEncoding(1251));
                foreach (string str in Mass)
                {
                    string[] words = str.Split(' ');
                    if (words[0] == listView1.SelectedItems[0].SubItems[0].Text && words[1] == listView1.SelectedItems[0].SubItems[1].Text
                        && words[2] == listView1.SelectedItems[0].SubItems[2].Text)
                    {
                        if (_CheckFileName(words[1])) //метод проверяет на совпадение в listview 2
                        {
                            ListViewItem listViewItem = new ListViewItem(new string[] {words[0], words[1], words[2], words[3] });
                            // добавляем созданный элемент listViewItem (строку) в listView
                            listView2.Items.Add(listViewItem);
                            var item1 = new Film()
                            {
                                Name = words[0],
                                MovieTime = words[1],
                                Seat = words[2],
                                SeatMax = words[3],
                            };
                            for (var h = 0; h < storage.Users.Count(); h++)
                            {
                                if (storage.Users[h].Login == Login && storage.Users[h].Password == Password)
                                {
                                    storage.Users[h].Basket.Add(item1);
                                }
                            }
                            
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // при закрытии приложения сохраняет сеансы пользователя в файле пользоваелей
        {
            var xs = new XmlSerializer(typeof(UsersModel));
            var file = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase.UsersModel"));
            xs.Serialize(file, storage);
            file.Close();
        }

        private void button2_Click(object sender, EventArgs e) // удаляет все элементы из listview2
        {
            for (var h = 0; h < storage.Users.Count(); h++)
            {
                if (storage.Users[h].Login == Login && storage.Users[h].Password == Password)
                {
                    storage.Users[h].Basket = listView2.Items.OfType<Film>().ToList();

                    foreach (ListViewItem item in listView2.Items)
                    {
                        listView2.Items.Remove(item);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // выходит к окну авторизации
        {
            var xs = new XmlSerializer(typeof(UsersModel));
            var file = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase.UsersModel"));
            xs.Serialize(file, storage);
            file.Close();
            Program.checker = true;
            Close();
        }

        private void worldOfCinemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
