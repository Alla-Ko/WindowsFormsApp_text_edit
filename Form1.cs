using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp_text_edit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = Resource1.Notepad_23093;
            button_new.Visible = true;
            button_open.Visible = true;

            button_close.Visible = false;
            button_edit.Visible = false;
            button1.Visible = false;

        }

        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        //5 кнопок
        private void button_new_Click_1(object sender, EventArgs e)
        {
            Form2 form=new Form2();
            form.Show();
            form.FormClosed += (sender1, e1) =>
            {
                // Цей код виконається після закриття форми
                if (form.save==true)
                {
                    textBox1.Text = form.text;
                    if (textBox1.Text.Length > 0)
                    {
                        button_close.Visible = true;
                        button_edit.Visible = true;
                        button1.Visible = true;
                    }
                    else
                    {
                        button_close.Visible = false;
                        button_edit.Visible = false;
                        button1.Visible = false;
                    }
                }
            };
            
        }
        private void button_open_Click(object sender, EventArgs e)
        {
            //відкрити з файла
            //string my_filters = "Текстові файли (*.txt)|*.txt|Текст OpenDocument (*.odt)|*.odt|Документ Word (*.docx)|*.docx|Текст в форматі RTF (*.rtf)|*.rtf|Всі файли (*.*)|*.*";
            string my_filters = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";
            openFileDialog1.Filter = my_filters;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Файл порожній", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                button_close.Visible = true;
                button_edit.Visible = true;
                button1.Visible = true;

            }    
        }
        private void button_edit_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(textBox1.Text);
            form.Show();
            form.FormClosed += (sender1, e1) =>
            {
                // Цей код виконається після закриття форми

                if (form.save)
                {
                    textBox1.Text = form.text;
                    if (textBox1.Text.Length > 0)
                    {
                        button_close.Visible = true;
                        button_edit.Visible = true;
                        button1.Visible = true;
                    }
                    else
                    {
                        button_close.Visible = false;
                        button_edit.Visible = false;
                        button1.Visible = false;
                    }
                }
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //зберегти у файл
            //string my_filters = "Текстові файли (*.txt)|*.txt|Текст OpenDocument (*.odt)|*.odt|Документ Word (*.docx)|*.docx|Текст в форматі RTF (*.rtf)|*.rtf|Всі файли (*.*)|*.*";
            string my_filters = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";
            saveFileDialog1.Filter = my_filters;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл збережено", "Збереження файлу", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button_close_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button_new.Visible = true;
            button_open.Visible = true;
            button_close.Visible = false;
            button_edit.Visible = false;
            button1.Visible = false;
        }
    }
}
