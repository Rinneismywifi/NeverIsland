using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OrderService.AddOrder(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                DialogResult result = MessageBox.Show("Add completely.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                DialogResult result = MessageBox.Show(exception.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}