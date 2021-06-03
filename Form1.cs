using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace AutoService
{
    public partial class Form1 : Form
    {
        DataService db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddAndEditForm addAndEditForm = new AddAndEditForm();
            DialogResult result = addAndEditForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            if(dataGridView1.DataSource == db.Staffs.Local.ToBindingList())
            {
                Staff staff = new Staff
                {
                    Address = addAndEditForm.textBox4.Text,
                    Email = addAndEditForm.textBox5.Text,
                    Phone_Number = addAndEditForm.textBox6.Text,
                    Fio = addAndEditForm.textBox7.Text,
                    Post = addAndEditForm.textBox8.Text,
                    Work_Experience = (int)addAndEditForm.numericUpDown1.Value
                };
                db.Staffs.Add(staff);
            }
            else if (dataGridView1.DataSource == db.CarWashes.Local.ToBindingList())
            {
                CarWash carWash = new CarWash
                {
                    Address = addAndEditForm.textBox9.Text,
                    Email = addAndEditForm.textBox10.Text,
                    Phone_Number = addAndEditForm.textBox11.Text,
                    Price = Convert.ToInt32(addAndEditForm.textBox12.Text),
                    Appellations = addAndEditForm.textBox13.Text,
                    Type = addAndEditForm.textBox14.Text
                };
                db.CarWashes.Add(carWash);
            }
            else if (dataGridView1.DataSource == db.PaintingWorks.Local.ToBindingList())
            {
                PaintingWorks paintingWorks = new PaintingWorks
                {
                    Address = addAndEditForm.textBox15.Text,
                    Email = addAndEditForm.textBox16.Text,
                    Phone_Number = addAndEditForm.textBox17.Text,
                    Price = Convert.ToInt32(addAndEditForm.textBox18.Text),
                    Appellations = addAndEditForm.textBox19.Text,
                    Type = addAndEditForm.textBox20.Text,
                    Queue = Convert.ToInt32(addAndEditForm.textBox21.Text)
                };
                db.PaintingWorks.Add(paintingWorks);
            }
            else if (dataGridView1.DataSource == db.TireShops.Local.ToBindingList())
            {
                TireShop tireShop = new TireShop
                {
                    Address = addAndEditForm.textBox22.Text,
                    Email = addAndEditForm.textBox23.Text,
                    Phone_Number = addAndEditForm.textBox24.Text,
                    Price = Convert.ToInt32(addAndEditForm.textBox25.Text),
                    Appellations = addAndEditForm.textBox26.Text,
                    Type = addAndEditForm.textBox27.Text,
                    Queue = Convert.ToInt32(addAndEditForm.textBox28.Text)
                };
                db.TireShops.Add(tireShop);
            }
            else if (dataGridView1.DataSource == db.Autoelectrics.Local.ToBindingList())
            {
                Autoelectrics autoelectrics = new Autoelectrics
                {
                    Address = addAndEditForm.textBox29.Text,
                    Email = addAndEditForm.textBox30.Text,
                    Phone_Number = addAndEditForm.textBox31.Text,
                    Price = Convert.ToInt32(addAndEditForm.textBox32.Text),
                    Appellations = addAndEditForm.textBox33.Text,
                    Type = addAndEditForm.textBox34.Text,
                    Queue = Convert.ToInt32(addAndEditForm.textBox35.Text)
                };
                db.Autoelectrics.Add(autoelectrics);
            }
            else if (dataGridView1.DataSource == db.Motors.Local.ToBindingList())
            {
                Motor motor = new Motor
                {
                    Address = addAndEditForm.textBox36.Text,
                    Email = addAndEditForm.textBox37.Text,
                    Phone_Number = addAndEditForm.textBox38.Text,
                    Price = Convert.ToInt32(addAndEditForm.textBox39.Text),
                    Appellations = addAndEditForm.textBox40.Text,
                    Type = addAndEditForm.textBox41.Text,
                    Queue = Convert.ToInt32(addAndEditForm.textBox42.Text)
                };
                db.Motors.Add(motor);
            }
            db.SaveChanges();
            MessageBox.Show("Новый объект добавлен");
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                db.SaveChanges();
                MessageBox.Show("Объект изменен");
            }
            else
                MessageBox.Show("Выберите строку таблицы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
                db.SaveChanges();
                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Выберите строку таблицы)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void carServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new DataService();
            db.Staffs.Load();
            dataGridView1.DataSource = db.Staffs.Local.ToBindingList();
            dataGridView1.Columns[0].HeaderText = "Ф.И.О.";
            dataGridView1.Columns[1].HeaderText = "Стаж работы";
            dataGridView1.Columns[2].HeaderText = "Должность";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "E-mail";
            dataGridView1.Columns[5].HeaderText = "Номер телефона";
        }

        private void washToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new DataService();
            db.CarWashes.Load();
            dataGridView1.DataSource = db.CarWashes.Local.ToBindingList();
            dataGridView1.Columns[0].HeaderText = "Вид работы";
            dataGridView1.Columns[1].HeaderText = "Цена";
            dataGridView1.Columns[2].HeaderText = "Название работы";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "E-mail";
            dataGridView1.Columns[5].HeaderText = "Номер телефона";
        }

        private void tireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new DataService();
            db.TireShops.Load();
            dataGridView1.DataSource = db.TireShops.Local.ToBindingList();
            dataGridView1.Columns[0].HeaderText = "Вид работы";
            dataGridView1.Columns[1].HeaderText = "Очередь";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Название работы";
            dataGridView1.Columns[4].HeaderText = "Адрес";
            dataGridView1.Columns[5].HeaderText = "E-mail";
            dataGridView1.Columns[6].HeaderText = "Номер телефона";
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new DataService();
            db.PaintingWorks.Load();
            dataGridView1.DataSource = db.PaintingWorks.Local.ToBindingList();
            dataGridView1.Columns[0].HeaderText = "Вид работы";
            dataGridView1.Columns[1].HeaderText = "Очередь";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Название работы";
            dataGridView1.Columns[4].HeaderText = "Адрес";
            dataGridView1.Columns[5].HeaderText = "E-mail";
            dataGridView1.Columns[6].HeaderText = "Номер телефона";
        }

        private void elToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new DataService();
            db.Autoelectrics.Load();
            dataGridView1.DataSource = db.Autoelectrics.Local.ToBindingList();
            dataGridView1.Columns[0].HeaderText = "Вид работы";
            dataGridView1.Columns[1].HeaderText = "Очередь";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Название работы";
            dataGridView1.Columns[4].HeaderText = "Адрес";
            dataGridView1.Columns[5].HeaderText = "E-mail";
            dataGridView1.Columns[6].HeaderText = "Номер телефона";
        }

        private void motorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new DataService();
            db.Motors.Load();
            dataGridView1.DataSource = db.Motors.Local.ToBindingList();
            dataGridView1.Columns[0].HeaderText = "Вид работы";
            dataGridView1.Columns[1].HeaderText = "Очередь";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Название работы";
            dataGridView1.Columns[4].HeaderText = "Адрес";
            dataGridView1.Columns[5].HeaderText = "E-mail";
            dataGridView1.Columns[6].HeaderText = "Номер телефона";
        }
    }
}
