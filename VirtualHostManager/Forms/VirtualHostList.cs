﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualHostManager.Extensions;
using VirtualHostManager.Models;
using VirtualHostManager.Service;

namespace VirtualHostManager.Forms
{
    public partial class VirtualHostList : BaseForm
    {
        private VirtualHostContext context;
        BindingList<VirtualHost> listVirtualHostForm = new BindingList<VirtualHost>();
        private DataStorageService dataStorageService;

        private int CurrentPage = 1;
        int PagesCount = 1;
        int pageRows = 28;
        public VirtualHostList() : base()
        {

            InitializeComponent();
            dataStorageService = new DataStorageService();

            var filePath = dataStorageService.Read<string>(AppConst.filePathConfig).Replace("\"", "");
            if (!string.IsNullOrEmpty(filePath))
            {
                context = new VirtualHostContext(filePath);
                context.Read();
                setItems();
            }
            //var a = new GetDirectoryForm().ShowDialog();
            //setup();   //creating new column
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
                    dataStorageService.Save(AppConst.filePathConfig, filePath);
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
            //flowLayoutPanel1.Controls.Clear();
            var items = context.data;
            listVirtualHostForm = new BindingList<VirtualHost>();
            items.ForEach(x =>
            {
                //flowLayoutPanel1.Controls.Add(newItem);
                listVirtualHostForm.Add(x);
            });
            dataGridView1.DataSource = items;
            PagesCount = Convert.ToInt32(Math.Ceiling(items.Count * 1.0 / pageRows));
            CurrentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();

            var columnConfig = dataStorageService.Read<VirtualHostDataGridViewColumns>(AppConst.VirtualHostColumns);
            if (columnConfig == null)
            {
                columnConfig = new VirtualHostDataGridViewColumns()
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
            var list = columnConfig.GetType()
                                              .GetProperties()
                                              .Select(x => new { Name = x.Name, Value = (bool)x.GetValue(columnConfig) })
                                              .ToList();
            list.ForEach(x =>
            {
                dataGridView1.Columns[x.Name + "DataGridViewTextBoxColumn"].Visible = x.Value;
            });
        }
        private void RebindGridForPageChange()
        {
            try
            {
                var data = context.data.Where(x => x.Url.Contains(textBox1.Text) || x.Directory.Contains(textBox1.Text)).ToList();
                PagesCount = Convert.ToInt32(Math.Ceiling(data.Count * 1.0 / pageRows));
                //Rebinding the Datagridview with data
                int datasourcestartIndex = (CurrentPage - 1) * pageRows;
                listVirtualHostForm = new BindingList<VirtualHost>();
                for (int i = datasourcestartIndex; i < datasourcestartIndex + pageRows; i++)
                {
                    if (i >= data.Count)
                        break;

                    listVirtualHostForm.Add(data[i]);
                }


                dataGridView1.DataSource = listVirtualHostForm;
                dataGridView1.Refresh();
            }
            catch (Exception ex) { }
        }

        //Method that handles the pagination button clicks
        private void ToolStripButtonClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton ToolStripButton = ((ToolStripButton)sender);

                //Determining the current page
                if (ToolStripButton == btnBackward)
                    CurrentPage--;
                else if (ToolStripButton == btnForward)
                    CurrentPage++;
                else
                    CurrentPage = Convert.ToInt32(ToolStripButton.Text, CultureInfo.InvariantCulture);

                if (CurrentPage < 1)
                    CurrentPage = 1;
                else if (CurrentPage > PagesCount)
                    CurrentPage = PagesCount;

                //Rebind the Datagridview with the data.
                RebindGridForPageChange();

                //Change the pagiantions buttons according to page number
                RefreshPagination();
            }
            catch (Exception) { }
        }
        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

            //pageStartIndex contains the first button number of pagination.
            int pageStartIndex = 1;

            if (PagesCount > 5 && CurrentPage > 2)
                pageStartIndex = CurrentPage - 2;

            if (PagesCount > 5 && CurrentPage > PagesCount - 2)
                pageStartIndex = PagesCount - 4;

            for (int i = pageStartIndex; i < pageStartIndex + 5; i++)
            {
                if (i > PagesCount)
                {
                    items[i - pageStartIndex].Visible = false;
                }
                else
                {
                    //Changing the page numbers
                    items[i - pageStartIndex].Text = i.ToString(CultureInfo.InvariantCulture);
                    items[i - pageStartIndex].Visible = true;

                    //Setting the Appearance of the page number buttons
                    if (i == CurrentPage)
                    {
                        items[i - pageStartIndex].BackColor = Color.Black;
                        items[i - pageStartIndex].ForeColor = Color.White;
                    }
                    else
                    {
                        items[i - pageStartIndex].BackColor = Color.White;
                        items[i - pageStartIndex].ForeColor = Color.Black;
                    }
                }
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CurrentPage = 1;
            //Rebind the Datagridview with the data.
            RebindGridForPageChange();

            //Change the pagiantions buttons according to page number
            RefreshPagination();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đổiĐườngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setup();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            var model = new VirtualHost();
            //listVirtualHostForm.Add(newItem);var dialog = new VirtualHostManager.Forms.VirtualHostDetail();
            var dialog = new VirtualHostManager.Forms.VirtualHostDetail();
            dialog.formType = VirtualHostDetailType.Edit;
            dialog.Url = "";
            dialog.Directory = "";
            dialog.CreateAt = "";
            dialog.Description = "";
            dialog.Context = dataStorageService.VirualHostTemplateRead(AppConst.VirtualHostTemplate);
            dialog.Status = true;
            dialog.saveCallback = () =>
            {
                generateBackup();
                model.Url = dialog.Url;
                model.Directory = dialog.Directory;
                model.CreateAt = DateTime.Now.ToString();
                model.UpdateAt = DateTime.Now.ToString();
                model.Description = dialog.Description;
                model.Context = dialog.Context;
                model.Status = dialog.Status;
                model.Author = dialog.Author;
                context.data.Add(model);
                //Rebind the Datagridview with the data.
                RebindGridForPageChange();
                setItems();
            };
            using (Panel p = this.blurPanel())
            {
                dialog.ShowDialog();
            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gridView.Rows[r.Index].HeaderCell.Value = ((CurrentPage - 1) * pageRows + (r.Index + 1)).ToString();
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                gridView.Rows[e.RowIndex].Cells["EditAction"].Value = "Edit";
                gridView.Rows[e.RowIndex].Cells["DeleteAction"].Value = "Delete";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["EditAction"].Index && e.RowIndex >= 0)
            {
                DataGridView gridView = sender as DataGridView;
                var index = Int32.Parse((string)gridView.Rows[e.RowIndex].HeaderCell.Value) - 1;
                var model = context.data.ElementAt(index);
                var dialog = new VirtualHostManager.Forms.VirtualHostDetail();
                dialog.formType = VirtualHostDetailType.Edit;
                dialog.Url = model.Url;
                dialog.Directory = model.Directory;
                dialog.CreateAt = model.CreateAt;
                dialog.Description = model.Description;
                dialog.Context = model.Context;
                dialog.Status = model.Status;
                dialog.Author = model.Author;

                dialog.saveCallback = () =>
                {
                    generateBackup();
                    model.Url = dialog.Url;
                    model.Directory = dialog.Directory;
                    model.CreateAt = dialog.CreateAt;
                    model.UpdateAt = DateTime.Now.ToString();
                    model.Description = dialog.Description;
                    model.Context = dialog.Context;
                    model.Status = dialog.Status;
                    model.Author = dialog.Author;
                    context.data[index] = model;
                        //Rebind the Datagridview with the data.
                        RebindGridForPageChange();
                };
                using (Panel p = this.blurPanel())
                {
                    dialog.ShowDialog();
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DeleteAction"].Index && e.RowIndex >= 0)
            {
                DataGridView gridView = sender as DataGridView;
                var index = Int32.Parse((string)gridView.Rows[e.RowIndex].HeaderCell.Value) - 1;
                generateBackup();
                context.data.RemoveAt(index);
                RebindGridForPageChange();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void hostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Panel p = this.blurPanel())
            {
                var dialog = new VirtualHostManager.Forms.HostForm();
                dialog.ShowDialog();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Panel p = this.blurPanel())
            {
                var dialog = new VirtualHostManager.Forms.SettingForm();
                dialog.ShowDialog();
                setItems();
            }
        }


        private void restartWampToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Can use dialog.FileName
                    // Save data
                    context.setPath(dialog.FileName);
                    context.SaveChanges();
                }
            }
        }
        private Panel blurPanel()
        {
            // take a screenshot of the form and darken it:
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(this.PointToScreen(new Point(0, 0)), new Point(0, 0), this.ClientRectangle.Size);
                double percent = 0.60;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brsh = new SolidBrush(darken))
                {
                    G.FillRectangle(brsh, this.ClientRectangle);
                }
            }
            // put the darkened screenshot into a Panel and bring it to the front:
            Panel p = new Panel();
            p.Location = new Point(0, 0);
            p.Size = this.ClientRectangle.Size;
            p.BackgroundImage = bmp;
            this.Controls.Add(p);
            p.BringToFront();

            return p;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateBackup()
        {
            var fileName = Path.Combine(AppConst.BackupFolder,DateTime.Now.ToString("MMddyyyyhhmmsstt")+".txt");

            if (!Directory.Exists(Path.Combine(Application.UserAppDataPath, AppConst.BackupFolder)))
            {
                Directory.CreateDirectory(Path.Combine(Application.UserAppDataPath, AppConst.BackupFolder));
            }
            dataStorageService.Save(fileName, context.data);
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Panel p = this.blurPanel())
            {
                var dialog = new VirtualHostManager.Forms.BackupForm();
                dialog.ShowDialog();
            }
        }
    }
}
