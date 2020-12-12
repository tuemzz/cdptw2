using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class VirtualHostDetail : MaterialForm
    {
        public VirtualHostDetail()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }
        public VirtualHostDetailType formType { set; get; }
        public string Url
        {
            get { return urlText.Text; }
            set { urlText.Text = value; }
        }
        public string Directory
        {
            get { return directoryText.Text; }
            set { directoryText.Text = value; }
        }
        public string CreateAt
        {
            get { return dateCreated.Value.ToString(); }
            set { dateCreated.Value = string.IsNullOrEmpty(value) ? DateTime.Now : DateTime.Parse(value); }
        }
        public string Description
        {
            get { return noteText.Text; }
            set { noteText.Text = value; }
        }
        public bool Status
        {
            get { return materialCheckBox1.Checked; }
            set { materialCheckBox1.Checked = value; }
        }
        public string Context
        {
            get { return ContextText.Text; }
            set { ContextText.Text = value; }
        }

        public Action saveCallback { set; get; }

        private void VirtualHostDetail_Load(object sender, EventArgs e)
        {
            if(formType == VirtualHostDetailType.View)
            {
                ContextText.Enabled = false;
                materialCheckBox1.Checked = false;
                directoryText.Enabled = false;
                noteText.Enabled = false;
                urlText.Enabled = false;
                dateCreated.Enabled = false;
            }
        }

        private void statusCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveCallback?.Invoke();
            this.Close();
        }
    }
}
