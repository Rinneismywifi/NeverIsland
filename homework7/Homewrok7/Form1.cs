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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OrderService.orders.Add(new Order("1", "Setsuna", "5cm-CD", "2"));
            OrderService.orders.Add(new Order("2", "Rinne", "Islander", "5"));
            OrderService.orders.Add(new Order("3", "Sara", "Jinja", "5"));
            OrderService.orders.Add(new Order("4", "Karen", "Maji", "100"));
            OrderService.orders.Add(new Order("5", "Kotaro", "Ohrola", "3"));
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bindingSource1.DataSource = OrderService.orders;
        }

        private void Update()
        {
            bindingSource1.DataSource = new List<Order>();
            bindingSource1.DataSource = OrderService.orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            DialogResult result = addForm.ShowDialog();
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 changeForm = new Form3((Order)this.dataGridView1.CurrentRow.DataBoundItem);
                DialogResult result = changeForm.ShowDialog();
                dataGridView1.Invalidate();
            }
            catch
            {
                DialogResult result = MessageBox.Show("You do not select the order", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Delete the order?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    if (this.dataGridView1.SelectedRows.Count <= 0)
                    {
                        throw new Exception();
                    }
                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        OrderService.DelOrder((Order)row.DataBoundItem);
                    }
                    Update();
                    DialogResult result = MessageBox.Show("Deleted.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Deleted fail.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Order")
                {
                    bindingSource1.DataSource = OrderService.FindByNum(textBox1.Text);
                }
                else if (comboBox1.Text == "Customer")
                {
                    bindingSource1.DataSource = OrderService.FindByName(textBox1.Text);
                }
                else if (comboBox1.Text == "Production")
                {
                    bindingSource1.DataSource = OrderService.FindByProduct(textBox1.Text);
                }
                else if (comboBox1.Text == "Cost")
                {
                    bindingSource1.DataSource = OrderService.FindByCost(textBox1.Text);
                }
                else if (comboBox1.Text == "Show all order")
                {
                    bindingSource1.DataSource = OrderService.orders;
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show("Not found.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bindingSource1.DataSource = OrderService.orders;
            }
        }
    }
}
