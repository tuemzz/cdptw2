using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualHostManager.Models;

namespace VirtualHostManager.UserControls
{
    public partial class VirtualHostItem : UserControl
    {
        public VirtualHostItem()
        {
            InitializeComponent();
        }

        #region Property
        public string Url
        {
            get { return urllbl.Text; }
            set { urllbl.Text = value; }
        }
        public string Directory
        {
            get { return directorylbl.Text; }
            set { directorylbl.Text = value; }
        }
        public string Id
        {
            get { return indexlbl.Text; }
            set { indexlbl.Text = value; }
        }
        public string Date { set; get; }
        public string Description { set; get; }
        public bool Status
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; checkBox1.Text = checkBox1.Checked ? "Enable" : "Disable"; }
        }
        public string Context { set; get; }
        public Action DeleteCallback { set; get; }
        public Action UpdateFormCallback { set; get; }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new VirtualHostManager.Forms.VirtualHostDetail();
            dialog.formType = VirtualHostDetailType.View;
            dialog.Url = Url;
            dialog.Directory = Directory;
            dialog.Date = Date;
            dialog.Context = Context;
            dialog.Description = Description;
            dialog.Status = Status;
            dialog.saveCallback = () =>
            {
                Url = dialog.Url;
                Directory = dialog.Directory;
                Date = dialog.Date;
                Context = dialog.Context;
                Description = dialog.Description;
                Status = dialog.Status;

                UpdateFormCallback?.Invoke();
            };
            dialog.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dialog = new VirtualHostManager.Forms.VirtualHostDetail();
            dialog.formType = VirtualHostDetailType.Edit;
            dialog.Url = Url;
            dialog.Directory = Directory;
            dialog.Date = Date;
            dialog.Description = Description;
            dialog.Context = Context;
            dialog.Status = Status;
            dialog.saveCallback = () =>
            {
                Url = dialog.Url;
                Directory = dialog.Directory;
                Date = dialog.Date;
                Description = dialog.Description;
                Context = dialog.Context;
                Status = dialog.Status;

                UpdateFormCallback?.Invoke();
            };
            dialog.ShowDialog();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFormCallback?.Invoke();
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Enable";
                checkBox1.ForeColor = Color.White;
                checkBox1.BackColor = Color.Green;
            }
            else
            {
                checkBox1.Text = "Disable";
                checkBox1.ForeColor = Color.Black;
                checkBox1.BackColor = Color.DarkGray;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCallback?.Invoke();
            UpdateFormCallback?.Invoke();
        }

        private void VirtualHostItem_Load(object sender, EventArgs e)
        {

        }
    }
}
