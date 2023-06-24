using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RKIS_Lab5.Models;


namespace RKIS_Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ModelEF modelEF = new ModelEF();
            studentDataGridView.DataSource = modelEF.Student.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2AddData form2 = new Form2AddData();
            form2.Show();
            Hide();
        }

        private void studentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
