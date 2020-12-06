﻿
namespace VirtualHostManager.Forms
{
    partial class VirtualHostDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualHostDetail));
            this.noteText = new System.Windows.Forms.TextBox();
            this.label4 = new MaterialSkin.Controls.MaterialLabel();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.dateCreated = new System.Windows.Forms.DateTimePicker();
            this.directoryText = new System.Windows.Forms.TextBox();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.urlText = new System.Windows.Forms.TextBox();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.ContextText = new System.Windows.Forms.TextBox();
            this.label5 = new MaterialSkin.Controls.MaterialLabel();
            this.saveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cancelBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // noteText
            // 
            this.noteText.Location = new System.Drawing.Point(13, 233);
            this.noteText.Multiline = true;
            this.noteText.Name = "noteText";
            this.noteText.Size = new System.Drawing.Size(409, 35);
            this.noteText.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Depth = 0;
            this.label4.Font = new System.Drawing.Font("Roboto", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(12, 211);
            this.label4.MouseState = MaterialSkin.MouseState.HOVER;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ghi chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ngày tạo";
            // 
            // dateCreated
            // 
            this.dateCreated.Location = new System.Drawing.Point(12, 188);
            this.dateCreated.Name = "dateCreated";
            this.dateCreated.Size = new System.Drawing.Size(409, 20);
            this.dateCreated.TabIndex = 12;
            // 
            // directoryText
            // 
            this.directoryText.Location = new System.Drawing.Point(12, 143);
            this.directoryText.Name = "directoryText";
            this.directoryText.Size = new System.Drawing.Size(409, 20);
            this.directoryText.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Đường dẫn thư mục";
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(13, 98);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(409, 20);
            this.urlText.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Url";
            // 
            // ContextText
            // 
            this.ContextText.Location = new System.Drawing.Point(12, 293);
            this.ContextText.Multiline = true;
            this.ContextText.Name = "ContextText";
            this.ContextText.Size = new System.Drawing.Size(409, 150);
            this.ContextText.TabIndex = 17;
            this.ContextText.Text = resources.GetString("ContextText.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Font = new System.Drawing.Font("Roboto", 11F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(12, 271);
            this.label5.MouseState = MaterialSkin.MouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Code";
            // 
            // saveBtn
            // 
            this.saveBtn.AutoSize = true;
            this.saveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveBtn.Depth = 0;
            this.saveBtn.Icon = null;
            this.saveBtn.Location = new System.Drawing.Point(375, 464);
            this.saveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Primary = true;
            this.saveBtn.Size = new System.Drawing.Size(47, 36);
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "Lưu";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelBtn.Depth = 0;
            this.cancelBtn.Icon = null;
            this.cancelBtn.Location = new System.Drawing.Point(320, 464);
            this.cancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Primary = true;
            this.cancelBtn.Size = new System.Drawing.Size(48, 36);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Huỷ";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(16, 456);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(406, 2);
            this.materialDivider1.TabIndex = 22;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.AutoSize = true;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox1.Location = new System.Drawing.Point(16, 466);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(150, 30);
            this.materialCheckBox1.TabIndex = 23;
            this.materialCheckBox1.Text = "materialCheckBox1";
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            this.materialCheckBox1.Visible = false;
            // 
            // VirtualHostDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(433, 508);
            this.Controls.Add(this.materialCheckBox1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.ContextText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.noteText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateCreated);
            this.Controls.Add(this.directoryText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlText);
            this.Controls.Add(this.label1);
            this.Name = "VirtualHostDetail";
            this.Sizable = false;
            this.Text = "Chi tiết";
            this.Load += new System.EventHandler(this.VirtualHostDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox noteText;
        private MaterialSkin.Controls.MaterialLabel label4;
        private MaterialSkin.Controls.MaterialLabel label3;
        private System.Windows.Forms.DateTimePicker dateCreated;
        private System.Windows.Forms.TextBox directoryText;
        private MaterialSkin.Controls.MaterialLabel label2;
        private System.Windows.Forms.TextBox urlText;
        private MaterialSkin.Controls.MaterialLabel label1;
        private System.Windows.Forms.TextBox ContextText;
        private MaterialSkin.Controls.MaterialLabel label5;
        private MaterialSkin.Controls.MaterialRaisedButton saveBtn;
        private MaterialSkin.Controls.MaterialRaisedButton cancelBtn;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
    }
}