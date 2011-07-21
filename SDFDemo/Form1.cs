using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SDFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NorthwindEntities context = new NorthwindEntities();
            //context.DeleteObject();
            
            //using (NorthwindEntities context = new NorthwindEntities())
            //{
                var result = from Customer c in context.Customers
                             select c;
                List<Customer> customers = result.ToList();
            //}


        }
    }
}
