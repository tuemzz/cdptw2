using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualHostManager.Models;
using VirtualHostManager.UserControls;

namespace VirtualHostManager.Forms
{
    public partial class VirtualHostList : MaterialForm
    {
        private VirtualHostContext context;
        List<VirtualHostItem> listVirtualHostForm = new List<VirtualHostItem>();
        public VirtualHostList()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            //var a = new GetDirectoryForm().ShowDialog();
            //setup();
        }

        private void VirtualHostList_Load(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void setup()
        {

            try
            {
                var filePath = getFilePath();
                if (filePath == "" || !File.Exists(filePath))
                {
                    MessageBox.Show("Vui lòng sửa lại đường dẫn", "Đường dẫn lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    context = new VirtualHostContext(filePath);
                    context.Read();
                    setItems();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }


        private void setItems()
        {
            flowLayoutPanel1.Controls.Clear();
            var items = context.data;
            listVirtualHostForm = new List<VirtualHostItem>();
            items.ForEach(x =>
            {
                var newItem = new VirtualHostItem();
                newItem.Url = x.Url;
                newItem.Id = (items.IndexOf(x) + 1).ToString();
                newItem.Directory = x.Directory;
                newItem.Description = x.Description;
                newItem.Date = x.Date;
                newItem.Context = x.Context;
                newItem.Status = x.Status;

                /*
                 * Set up callback
                 */
                newItem.UpdateFormCallback = () =>
                {
                    var listData = new List<VirtualHost>();
                    foreach (VirtualHostItem c in listVirtualHostForm)
                    {
                        listData.Add(new VirtualHost()
                        {
                            Url = c.Url,
                            Directory = c.Directory,
                            Description = c.Description,
                            Date = c.Date,
                            Context = c.Context,
                            Status = c.Status,
                        });
                    }
                    context.data = listData;
                    context.SaveChanges();

                    ServiceController sc = new ServiceController("wampapache64");
                    if (sc.Site != null && sc.Status == ServiceControllerStatus.Running)
                    {
                        Task.Run(() =>
                        {
                            sc.Stop();
                            sc.WaitForStatus(ServiceControllerStatus.Stopped);
                            sc.Start();
                        });
                    }
                };
                newItem.DeleteCallback = () =>
                {
                    flowLayoutPanel1.Controls.Remove(newItem);
                };

                flowLayoutPanel1.Controls.Add(newItem);
                listVirtualHostForm.Add(newItem);
            });
        }

        private string getFilePath()
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    return fbd.FileName;
                }
                return "";
            }
        }


        private void virtualHostItem1_Load(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tuỳChỉnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setup();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(listVirtualHostForm.Where(x => x.Url.Contains(textBox1.Text)).ToArray());
        }

        private void bindingNavigatorCountItem_Click(object sender, EventArgs e)
        {

        }

        private void tạoMớiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var newItem = new VirtualHostItem();
            newItem.Id = (flowLayoutPanel1.Controls.Count + 1).ToString();
            newItem.Context = @"<VirtualHost *:80>
  ServerName localhost
  ServerAlias localhost
  DocumentRoot ""${INSTALL_DIR}/www""
  < Directory ""${INSTALL_DIR}/www/"" >
     Options + Indexes + Includes + FollowSymLinks + MultiViews
    AllowOverride All
    Require local
  </ Directory >
</ VirtualHost > ";
            /*
             * Set up callback
             */
            newItem.UpdateFormCallback = () =>
            {
                var listData = new List<VirtualHost>();
                foreach (VirtualHostItem c in flowLayoutPanel1.Controls)
                {
                    listData.Add(new VirtualHost()
                    {
                        Url = c.Url,
                        Directory = c.Directory,
                        Description = c.Description,
                        Date = c.Date,
                        Context = c.Context,
                        Status = c.Status,
                    });
                }
                context.data = listData;
                context.SaveChanges();

                ServiceController sc = new ServiceController("wampapache64");
                if (sc.Site != null && sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Start();
                }
            };
            newItem.DeleteCallback = () =>
            {
                flowLayoutPanel1.Controls.Remove(newItem);
            };
            flowLayoutPanel1.Controls.Add(newItem);
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đổiĐườngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setup();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            var newItem = new VirtualHostItem();
            newItem.Id = (flowLayoutPanel1.Controls.Count + 1).ToString();
            newItem.Context = @"<VirtualHost *:80>
  ServerName localhost
  ServerAlias localhost
  DocumentRoot ""${INSTALL_DIR}/www""
  < Directory ""${INSTALL_DIR}/www/"" >
     Options + Indexes + Includes + FollowSymLinks + MultiViews
    AllowOverride All
    Require local
  </ Directory >
</ VirtualHost > ";
            /*
             * Set up callback
             */
            newItem.UpdateFormCallback = () =>
            {
                var listData = new List<VirtualHost>();
                foreach (VirtualHostItem c in listVirtualHostForm)
                {
                    listData.Add(new VirtualHost()
                    {
                        Url = c.Url,
                        Directory = c.Directory,
                        Description = c.Description,
                        Date = c.Date,
                        Context = c.Context,
                        Status = c.Status,
                    });
                }
                context.data = listData;
                context.SaveChanges();

                ServiceController sc = new ServiceController("wampapache64");
                if (sc.Site != null && sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Start();
                }
            };
            newItem.DeleteCallback = () =>
            {
                flowLayoutPanel1.Controls.Remove(newItem);
            };
            flowLayoutPanel1.Controls.Add(newItem);
            listVirtualHostForm.Add(newItem);

        }
    }
}
