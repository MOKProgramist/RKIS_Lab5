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
    public partial class Form2AddData : Form
    {
        public Form2AddData()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите фото сотрудника";
            ofd.Filter = "Файлы JPG,PNG|*.jpg;*.png;|Все файлы (*.*)|*.*";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);  
            }
        }

        private void Form2AddData_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBoxName.Text) || String.IsNullOrWhiteSpace(textBoxGroup.Text))
            {
                MessageBox.Show("Заполните все поля!!");
                return;
            }

            if(pictureBox1.Image == null)
            {
                MessageBox.Show("Укажажите файл с фотографией!!");
                return;
            }

            ModelEF modelEF = new ModelEF(); 
            Student student = new Student();

            student.Name = textBoxName.Text;
            student.Group_ = textBoxGroup.Text;

            byte[] bImg = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));

            student.Photo = bImg;
            modelEF.Student.Add(student);

            try
            {
                modelEF.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("Сохрпанено", "Успех");
            resetData();
            return;
        }

        private void resetData()
        {
            textBoxName.Text = string.Empty;
            textBoxGroup.Text = string.Empty;   
            pictureBox1.Image = null;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Hide();
            form1.Show();
           
        }
    }
}
