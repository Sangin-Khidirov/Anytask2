using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWorldOfCinema
{
    public partial class AddFilm : Form
    {
        public AddFilm()
        {
            InitializeComponent();
        }
        public Film Films { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            Films.Name = textBox1.Text;
            Films.Seats = textBox2.Text;
            Films.Time = textBox3.Text;
        }

        private void AddFilm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Films.Name;
            textBox2.Text = Films.Seats;
            textBox3.Text = Films.Time;
        }
    }
}
