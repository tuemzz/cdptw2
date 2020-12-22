using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualHostManager.Models;
using VirtualHostManager.Service;

namespace VirtualHostManager.Forms
{
    public partial class BackupForm : BaseForm
    {
        private DataStorageService dataStorageService;
        public BackupForm()
        {
            InitializeComponent();
            dataStorageService = new DataStorageService();
            var filePath = Path.Combine(Application.UserAppDataPath, AppConst.BackupFolder);
            var files = Directory.GetFiles(filePath).Select(x => Path.GetFileNameWithoutExtension(x));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
