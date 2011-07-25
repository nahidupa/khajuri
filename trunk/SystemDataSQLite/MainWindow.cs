using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SystemDataSQLite
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {


                NorthWindSQLiteEntities context = new NorthWindSQLiteEntities();
                //context.DeleteObject();

                //using (NorthwindEntities context = new NorthwindEntities())
                //{
                
                var result = from Customer c in context.Customers
                             select c;
                List<Customer> customers = result.ToList();
               
                //}

                dataGridView1.DataSource = customers;

                
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
