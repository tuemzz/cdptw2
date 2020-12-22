
namespace VirtualHostManager.Forms
{
    partial class BackupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.virtualHostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backupBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thaotacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.backupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.virtualHostBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // backupBindingSource
            // 
            this.backupBindingSource.DataSource = typeof(VirtualHostManager.Models.Backup);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileDataGridViewTextBoxColumn,
            this.thaotacDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.backupBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // virtualHostBindingSource
            // 
            this.virtualHostBindingSource.DataSource = typeof(VirtualHostManager.Models.VirtualHost);
            // 
            // backupBindingSource1
            // 
            this.backupBindingSource1.DataSource = typeof(VirtualHostManager.Models.Backup);
            // 
            // fileDataGridViewTextBoxColumn
            // 
            this.fileDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileDataGridViewTextBoxColumn.DataPropertyName = "File";
            this.fileDataGridViewTextBoxColumn.HeaderText = "File";
            this.fileDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fileDataGridViewTextBoxColumn.Name = "fileDataGridViewTextBoxColumn";
            // 
            // thaotacDataGridViewTextBoxColumn
            // 
            this.thaotacDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.thaotacDataGridViewTextBoxColumn.DataPropertyName = "Thaotac";
            this.thaotacDataGridViewTextBoxColumn.HeaderText = "Thaotac";
            this.thaotacDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.thaotacDataGridViewTextBoxColumn.Name = "thaotacDataGridViewTextBoxColumn";
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BackupForm";
            this.Text = "BackupForm";
            ((System.ComponentModel.ISupportInitialize)(this.backupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.virtualHostBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource backupBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thaotacDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource backupBindingSource1;
        private System.Windows.Forms.BindingSource virtualHostBindingSource;
    }
}