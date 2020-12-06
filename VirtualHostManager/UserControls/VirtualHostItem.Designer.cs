namespace VirtualHostManager.UserControls
{
    partial class VirtualHostItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.indexlbl = new System.Windows.Forms.Label();
            this.urllbl = new System.Windows.Forms.Label();
            this.directorylbl = new System.Windows.Forms.Label();
            this.button2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.button3 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.button4 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.SuspendLayout();
            // 
            // indexlbl
            // 
            this.indexlbl.AutoSize = true;
            this.indexlbl.Location = new System.Drawing.Point(20, 12);
            this.indexlbl.Name = "indexlbl";
            this.indexlbl.Size = new System.Drawing.Size(13, 13);
            this.indexlbl.TabIndex = 0;
            this.indexlbl.Text = "1";
            // 
            // urllbl
            // 
            this.urllbl.AutoSize = true;
            this.urllbl.Location = new System.Drawing.Point(68, 12);
            this.urllbl.Name = "urllbl";
            this.urllbl.Size = new System.Drawing.Size(80, 13);
            this.urllbl.TabIndex = 1;
            this.urllbl.Text = "http://localhost";
            // 
            // directorylbl
            // 
            this.directorylbl.AutoSize = true;
            this.directorylbl.Location = new System.Drawing.Point(391, 12);
            this.directorylbl.Name = "directorylbl";
            this.directorylbl.Size = new System.Drawing.Size(90, 13);
            this.directorylbl.TabIndex = 2;
            this.directorylbl.Text = "C:\\xampp\\htdocs";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Depth = 0;
            this.button2.Icon = null;
            this.button2.Location = new System.Drawing.Point(912, 0);
            this.button2.MouseState = MaterialSkin.MouseState.HOVER;
            this.button2.Name = "button2";
            this.button2.Primary = true;
            this.button2.Size = new System.Drawing.Size(54, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "View";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Depth = 0;
            this.button3.Icon = null;
            this.button3.Location = new System.Drawing.Point(1060, 0);
            this.button3.MouseState = MaterialSkin.MouseState.HOVER;
            this.button3.Name = "button3";
            this.button3.Primary = true;
            this.button3.Size = new System.Drawing.Size(69, 36);
            this.button3.TabIndex = 5;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button4.Depth = 0;
            this.button4.Icon = null;
            this.button4.Location = new System.Drawing.Point(990, 0);
            this.button4.MouseState = MaterialSkin.MouseState.HOVER;
            this.button4.Name = "button4";
            this.button4.Primary = true;
            this.button4.Size = new System.Drawing.Size(50, 36);
            this.button4.TabIndex = 6;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.Color.OliveDrab;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(837, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 36);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Enable";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(-13, 38);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialDivider1.Size = new System.Drawing.Size(1173, 2);
            this.materialDivider1.TabIndex = 8;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // VirtualHostItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.directorylbl);
            this.Controls.Add(this.urllbl);
            this.Controls.Add(this.indexlbl);
            this.Name = "VirtualHostItem";
            this.Size = new System.Drawing.Size(1160, 43);
            this.Load += new System.EventHandler(this.VirtualHostItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label indexlbl;
        private System.Windows.Forms.Label urllbl;
        private System.Windows.Forms.Label directorylbl;
        private MaterialSkin.Controls.MaterialRaisedButton button2;
        private MaterialSkin.Controls.MaterialRaisedButton button3;
        private MaterialSkin.Controls.MaterialRaisedButton button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
    }
}
