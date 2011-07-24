using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using Templates;

namespace MySqlBTToolKit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDBManager_Click(object sender, EventArgs e)
        {
            using (DbManager db = new DbManager("MySql"))
            {
                var query = new SqlQuery<orders>();
                var test= query.SelectAll(db);
            }
        }
    }
}
