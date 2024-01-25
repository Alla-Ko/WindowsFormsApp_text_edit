using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_text_edit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Icon = Resource1.Notepad_23093;
        }
        public Form2(string s)
        {
            InitializeComponent();
            text = s;
            textBox1.Text = text;
            this.Icon = Resource1.Notepad_23093;
            button_close.Visible = true;
            button_save.Visible = true;
            

        }
        public string text = "";
        public bool save =false;

        private void button_save_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;
            save = true;
            Close();
            
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            save = false;
            Close();
            
        }
    }
}
