using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace DALTest
{
    public partial class Form1 : Form
    {
        DataClassesSmartVigiDataContext DataContext = new DataClassesSmartVigiDataContext();

        public Form1()
        {
            InitializeComponent();
            utilisateursBindingSource.DataSource = DataContext.Utilisateurs;
            repertoireBindingSource.DataSource = DataContext.Repertoire;
            interventionsBindingSource.DataSource = DataContext.Interventions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataContext.SubmitChanges();
        }

        private void interventionsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
