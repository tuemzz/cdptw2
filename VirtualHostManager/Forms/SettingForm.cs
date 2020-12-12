using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using VirtualHostManager.Models;
using VirtualHostManager.Service;

namespace VirtualHostManager.Forms
{
    public partial class SettingForm : Form
    {
        private DataStorageService dataStorageService;
        private VirtualHostDataGridViewColumns hostDataGridViewColumns;
        public SettingForm()
        {
            InitializeComponent();

            dataStorageService = new DataStorageService();
            hostDataGridViewColumns = dataStorageService.Read<VirtualHostDataGridViewColumns>(AppConst.VirtualHostCoumns);
            if (hostDataGridViewColumns == null)
            {
                hostDataGridViewColumns = new VirtualHostDataGridViewColumns()
                {
                    Author = true,
                    CreateAt = true,
                    Description = true,
                    Directory = true,
                    ErrorLogs = true,
                    Status = true,
                    UpdateAt = true,
                    Url = true,
                };
            }

            var list = hostDataGridViewColumns.GetType()
                                              .GetProperties()
                                              .Select(x => new { Name = x.Name, Value = (bool)x.GetValue(hostDataGridViewColumns)})
                                              .ToList();
            list.ForEach(x =>
            {
                checkedListBox1.Items.Add(x.Name);
                checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, x.Value);
            });
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var value = e.NewValue.ToString() == "Checked" ? true : false ;

            hostDataGridViewColumns.GetType()
                                   .GetProperty(checkedListBox1.Items[e.Index].ToString())
                                   .SetValue(hostDataGridViewColumns, value);
            dataStorageService.Save(AppConst.VirtualHostCoumns, hostDataGridViewColumns);
        }
    }
}
