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

namespace Самостійне_завдання__XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заповніть усі поля.", "Помилка.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown2.Value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown2.Value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }

            else
            {
                MessageBox.Show("Виберіть строку для видалення.", "Помилка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблиця вільна.", "Помилка.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("Weight");
                dt.Columns.Add("Cook");
                dt.Columns.Add("Experience");
                ds.Tables.Add(dt);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Employee"].NewRow();
                    row["Name"] = r.Cells[0].Value;
                    row["Weight"] = r.Cells[1].Value;
                    row["Cook"] = r.Cells[2].Value;
                    row["Experience"] = r.Cells[3].Value;
                    ds.Tables["Employee"].Rows.Add(row);
                }
                ds.WriteXml("\"C:\\Users\\ALEX\\source\\repos\\Самостійне завдання  XML\\XMLFile1.xml\"");
                MessageBox.Show("XML файл успішно завантажен.", "Виповленно.");
            }
            catch
            {
                MessageBox.Show("Неможливо зберігти XML файл.", "Помилка");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Очистити поле перед загругкою нового файлу.", "Полилка.");
            }
            else
            {
                if (File.Exists("C:\\Users\\ALEX\\source\\repos\\Самостійне завдання  XML\\XMLFile1.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("C:\\Users\\ALEX\\source\\repos\\Самостійне завдання  XML\\XMLFile1.xml");
                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["Name"];
                        dataGridView1.Rows[n].Cells[1].Value = item["Weight"];
                        dataGridView1.Rows[n].Cells[2].Value = item["Cook"];
                        dataGridView1.Rows[n].Cells[3].Value = item["Experience"];

                    }
                }
                else
                {
                    MessageBox.Show("XML файл не знайден.", "Помилка.");
                }
            }
        }
    }
}

