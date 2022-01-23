using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //создание файла для данных
            try
            {
                StreamWriter streamWriter = new StreamWriter("C:\\Users\\JAMAL\\Desktop\\Reminder.txt", true);
                StreamWriter steamWriter = new StreamWriter("C:\\Users\\JAMAL\\Desktop\\Celebration.txt", true);
                streamWriter.Close();
                steamWriter.Close();
                listBox1.Items.AddRange(File.ReadAllLines(@"C:\\Users\\JAMAL\\Desktop\\Celebration.txt", Encoding.UTF8));
                listBox2.Items.AddRange(File.ReadAllLines("C:\\Users\\JAMAL\\Desktop\\Reminder.txt", Encoding.UTF8));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //создание праздника или напоминания и сохранения в файл
            if (radioButton2.Checked)
            {
                try
                {
                    Event celebration = new Celebration(Name_textBox.Text, Desc_textBox.Text, dateTimePicker2.Value);
                    String text = $"{celebration.getName} {celebration.getDescription} {celebration.getDate.ToString("d")}";

                    using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\JAMAL\\Desktop\\Celebration.txt", true))
                    {
                        streamWriter.WriteLine(text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка" + ex);
                }
            }
            else if (radioButton1.Checked)
            {
                try
                {
                    DateTime date = dateTimePicker2.Value;
                    Event reminder = new Reminder(Name_textBox.Text, Desc_textBox.Text, date);
                    String text = $"{reminder.getName} {reminder.getDescription} {reminder.getDate}";

                    using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\JAMAL\\Desktop\\Reminder.txt", true))
                    {
                        streamWriter.WriteLine(text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка" + ex);
                }
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(File.ReadAllLines(@"C:\\Users\\JAMAL\\Desktop\\Celebration.txt", Encoding.UTF8));
            listBox2.Items.Clear();
            listBox2.Items.AddRange(File.ReadAllLines("C:\\Users\\JAMAL\\Desktop\\Reminder.txt", Encoding.UTF8));

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор строки, которую нужно отредактировать
            if (checkBox1.Checked)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();

                }

            }


        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //удаление строки и сохранение изменений в файле
            try
            {
                if (listBox1.SelectedIndex != -1 && radioButton2.Checked)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    string writePath = "C:\\Users\\JAMAL\\Desktop\\Celebration.txt";
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        foreach (var item in listBox1.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }

                else if (listBox2.SelectedIndex != -1 && radioButton1.Checked)
                {

                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    string writePath = "C:\\Users\\JAMAL\\Desktop\\Reminder.txt";
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        foreach (var item in listBox2.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите элемент");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Редактирование строки и сохранения в файле
            try
            {
                if (checkBox1.Checked && radioButton2.Checked)
                {

                    listBox1.Items[listBox1.SelectedIndex] = textBox1.Text;
                    string writePath = "C:\\Users\\JAMAL\\Desktop\\Celebration.txt";
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        foreach (var item in listBox1.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                    textBox1.Text = "";
                }
                else if (checkBox1.Checked && radioButton1.Checked)
                {

                    listBox2.Items[listBox2.SelectedIndex] = textBox1.Text;
                    string writePath = "C:\\Users\\JAMAL\\Desktop\\Reminder.txt";
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        foreach (var item in listBox2.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                    textBox1.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // выбор строки, которую нужно отредактировать, и вывод в поле для изменения
            try
            {
                if (checkBox1.Checked)
                {


                    if (listBox2.SelectedIndex != -1)
                    {
                        textBox1.Text = listBox2.Items[listBox2.SelectedIndex].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + ex);
            }
        
        }
    }
}
