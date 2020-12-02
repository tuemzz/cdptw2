using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualHostManager.Models;
using VirtualHostManager.UserControls;

namespace VirtualHostManager.Forms
{
    public partial class VirtualHostList : Form
    {
        private VirtualHostContext context; 
        public VirtualHostList()
        {
            InitializeComponent();
            try
            {
                context = new VirtualHostContext();
                setItems();
            }
            catch(Exception ex)
            {
                //throw ex;
            }
        }

        private void VirtualHostList_Load(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void setItems()
        {
            var items = context.data;
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
            });
        }

        private void virtualHostItem1_Load(object sender, EventArgs e)
        {

        }

        private void tạoMớiToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
