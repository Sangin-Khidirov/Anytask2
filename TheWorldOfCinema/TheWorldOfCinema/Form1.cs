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

namespace TheWorldOfCinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var films = new AddFilm() { Films = new Film() };
            if (films.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(films.Films);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Film)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Кинотеатр|*.cinema" };

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(Cinema));
            var file = File.OpenRead(ofd.FileName);
            var cinema = (Cinema)xs.Deserialize(file);
            file.Close();

            textBox1.Text = cinema.Name;
            textBox2.Text = cinema.Adress;
            listBox1.Items.Clear();
            foreach (var films in cinema.Films)
            {
                listBox1.Items.Add(films);
            }
           
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Кинотеатр|*.cinema" };
            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;
            var cinema = new Cinema()
            {
                Name = textBox1.Text,
                Adress = textBox2.Text,
                Films = listBox1.Items.OfType<Film>().ToList(),
            };
            var xs = new XmlSerializer(typeof(Cinema));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, cinema);
            file.Close();
        }
    }
}
