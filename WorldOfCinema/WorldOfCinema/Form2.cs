using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfCinema
{
    public partial class Form2 : Form
    {
        private object фильмы;

        public Form2()
        {
            InitializeComponent();
        }

        private void ФильмыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            фильмы = ActiveForm;
        }
    }
}
