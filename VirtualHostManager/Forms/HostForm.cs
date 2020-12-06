using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualHostManager.Models;

namespace VirtualHostManager.Forms
{
    public partial class HostForm : Form
    {

        private HostContext context;
        public HostForm()
        {
            InitializeComponent();
            context = new HostContext();
            context.Read();
            var list = new BindingList<Hosts>();
            context.data.ForEach(x =>
            {
                list.Add(x);
            });
            //dataGridView1.DataSource = list;
            var editColumn = new DataGridViewButtonColumn
            {
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "Edit",
                DataPropertyName = "Edit",
        };
            dataGridView1.Columns.Add(editColumn);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 5 && e.RowIndex + 1 < senderGrid.RowCount)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void HostForm_Load(object sender, EventArgs e)
        {

        }
    }
}
