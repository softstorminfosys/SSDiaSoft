namespace DiamondPro.MASTER
{
    partial class FrmUsersRights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsersRights));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.chkdel = new System.Windows.Forms.CheckBox();
            this.chkedit = new System.Windows.Forms.CheckBox();
            this.chkadd = new System.Windows.Forms.CheckBox();
            this.chkallow = new System.Windows.Forms.CheckBox();
            this.grdUserRights = new System.Windows.Forms.DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usertypeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formname = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formnameText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subitems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menulevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.addRights = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.editRights = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.delRights = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.printRights = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpFormRights = new System.Windows.Forms.GroupBox();
            this.btnclse = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.pnllogin = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserRights)).BeginInit();
            this.grpFormRights.SuspendLayout();
            this.pnllogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.chkprint);
            this.MainPanel.Controls.Add(this.chkdel);
            this.MainPanel.Controls.Add(this.chkedit);
            this.MainPanel.Controls.Add(this.chkadd);
            this.MainPanel.Controls.Add(this.chkallow);
            this.MainPanel.Controls.Add(this.grdUserRights);
            this.MainPanel.Controls.Add(this.grpFormRights);
            this.MainPanel.Location = new System.Drawing.Point(5, 6);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(839, 607);
            this.MainPanel.TabIndex = 4;
            // 
            // chkprint
            // 
            this.chkprint.AutoSize = true;
            this.chkprint.Location = new System.Drawing.Point(781, 94);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(15, 14);
            this.chkprint.TabIndex = 10;
            this.chkprint.UseVisualStyleBackColor = true;
            this.chkprint.CheckedChanged += new System.EventHandler(this.chkprint_CheckedChanged);
            // 
            // chkdel
            // 
            this.chkdel.AutoSize = true;
            this.chkdel.Location = new System.Drawing.Point(714, 94);
            this.chkdel.Name = "chkdel";
            this.chkdel.Size = new System.Drawing.Size(15, 14);
            this.chkdel.TabIndex = 8;
            this.chkdel.UseVisualStyleBackColor = true;
            this.chkdel.CheckedChanged += new System.EventHandler(this.chkdel_CheckedChanged);
            // 
            // chkedit
            // 
            this.chkedit.AutoSize = true;
            this.chkedit.Location = new System.Drawing.Point(653, 94);
            this.chkedit.Name = "chkedit";
            this.chkedit.Size = new System.Drawing.Size(15, 14);
            this.chkedit.TabIndex = 9;
            this.chkedit.UseVisualStyleBackColor = true;
            this.chkedit.CheckedChanged += new System.EventHandler(this.chkedit_CheckedChanged);
            // 
            // chkadd
            // 
            this.chkadd.AutoSize = true;
            this.chkadd.Location = new System.Drawing.Point(606, 94);
            this.chkadd.Name = "chkadd";
            this.chkadd.Size = new System.Drawing.Size(15, 14);
            this.chkadd.TabIndex = 8;
            this.chkadd.UseVisualStyleBackColor = true;
            this.chkadd.CheckedChanged += new System.EventHandler(this.chkadd_CheckedChanged);
            // 
            // chkallow
            // 
            this.chkallow.AutoSize = true;
            this.chkallow.Location = new System.Drawing.Point(529, 94);
            this.chkallow.Name = "chkallow";
            this.chkallow.Size = new System.Drawing.Size(15, 14);
            this.chkallow.TabIndex = 2;
            this.chkallow.UseVisualStyleBackColor = true;
            this.chkallow.CheckedChanged += new System.EventHandler(this.chkallow_CheckedChanged);
            // 
            // grdUserRights
            // 
            this.grdUserRights.AllowUserToAddRows = false;
            this.grdUserRights.AllowUserToDeleteRows = false;
            this.grdUserRights.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdUserRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserRights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.usertypeid,
            this.userid,
            this.formname,
            this.id,
            this.formnameText,
            this.subitems,
            this.menulevel,
            this.allow,
            this.addRights,
            this.editRights,
            this.delRights,
            this.printRights});
            this.grdUserRights.Location = new System.Drawing.Point(6, 112);
            this.grdUserRights.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdUserRights.Name = "grdUserRights";
            this.grdUserRights.RowHeadersVisible = false;
            this.grdUserRights.Size = new System.Drawing.Size(826, 490);
            this.grdUserRights.TabIndex = 1;
            this.grdUserRights.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // srno
            // 
            this.srno.DataPropertyName = "srno";
            this.srno.HeaderText = "srno";
            this.srno.Name = "srno";
            this.srno.Width = 130;
            // 
            // usertypeid
            // 
            this.usertypeid.DataPropertyName = "usertypeid";
            this.usertypeid.HeaderText = "usertypeid";
            this.usertypeid.Name = "usertypeid";
            this.usertypeid.Visible = false;
            // 
            // userid
            // 
            this.userid.DataPropertyName = "userid";
            this.userid.HeaderText = "userid";
            this.userid.Name = "userid";
            this.userid.Visible = false;
            // 
            // formname
            // 
            this.formname.DataPropertyName = "formname";
            this.formname.HeaderText = "Form Name";
            this.formname.Name = "formname";
            this.formname.Visible = false;
            this.formname.Width = 400;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // formnameText
            // 
            this.formnameText.DataPropertyName = "formnameText";
            this.formnameText.HeaderText = "Form Name";
            this.formnameText.Name = "formnameText";
            this.formnameText.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.formnameText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.formnameText.Width = 330;
            // 
            // subitems
            // 
            this.subitems.DataPropertyName = "subitems";
            this.subitems.HeaderText = "subitems";
            this.subitems.Name = "subitems";
            this.subitems.Visible = false;
            // 
            // menulevel
            // 
            this.menulevel.DataPropertyName = "menulevel";
            this.menulevel.HeaderText = "Menu Level";
            this.menulevel.Name = "menulevel";
            this.menulevel.Visible = false;
            // 
            // allow
            // 
            this.allow.DataPropertyName = "allow";
            this.allow.HeaderText = "Allow Page";
            this.allow.Name = "allow";
            // 
            // addRights
            // 
            this.addRights.DataPropertyName = "addRights";
            this.addRights.HeaderText = "ADD";
            this.addRights.Name = "addRights";
            this.addRights.Width = 50;
            // 
            // editRights
            // 
            this.editRights.DataPropertyName = "editRights";
            this.editRights.HeaderText = "EDIT";
            this.editRights.Name = "editRights";
            this.editRights.Width = 50;
            // 
            // delRights
            // 
            this.delRights.DataPropertyName = "delRights";
            this.delRights.HeaderText = "DELETE";
            this.delRights.Name = "delRights";
            this.delRights.Width = 70;
            // 
            // printRights
            // 
            this.printRights.DataPropertyName = "printRights";
            this.printRights.HeaderText = "PRINT";
            this.printRights.Name = "printRights";
            this.printRights.Width = 70;
            // 
            // grpFormRights
            // 
            this.grpFormRights.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grpFormRights.Controls.Add(this.btnclse);
            this.grpFormRights.Controls.Add(this.btnShow);
            this.grpFormRights.Controls.Add(this.btnSave);
            this.grpFormRights.Controls.Add(this.cmbUserType);
            this.grpFormRights.Location = new System.Drawing.Point(4, 8);
            this.grpFormRights.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFormRights.Name = "grpFormRights";
            this.grpFormRights.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFormRights.Size = new System.Drawing.Size(828, 78);
            this.grpFormRights.TabIndex = 0;
            this.grpFormRights.TabStop = false;
            this.grpFormRights.Text = "User Rights";
            // 
            // btnclse
            // 
            this.btnclse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnclse.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclse.Location = new System.Drawing.Point(686, 29);
            this.btnclse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnclse.Name = "btnclse";
            this.btnclse.Size = new System.Drawing.Size(84, 30);
            this.btnclse.TabIndex = 3;
            this.btnclse.Text = "&Close";
            this.btnclse.UseVisualStyleBackColor = false;
            this.btnclse.Click += new System.EventHandler(this.btnclse_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShow.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(492, 29);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(84, 30);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "S&how";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(589, 29);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbUserType
            // 
            this.cmbUserType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUserType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUserType.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Location = new System.Drawing.Point(88, 29);
            this.cmbUserType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(370, 30);
            this.cmbUserType.TabIndex = 0;
            this.cmbUserType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // pnllogin
            // 
            this.pnllogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnllogin.Controls.Add(this.btnclose);
            this.pnllogin.Controls.Add(this.btnlogin);
            this.pnllogin.Controls.Add(this.password);
            this.pnllogin.Controls.Add(this.label2);
            this.pnllogin.Location = new System.Drawing.Point(238, 150);
            this.pnllogin.Name = "pnllogin";
            this.pnllogin.Size = new System.Drawing.Size(374, 98);
            this.pnllogin.TabIndex = 13;
            // 
            // btnclose
            // 
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Location = new System.Drawing.Point(282, 58);
            this.btnclose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(82, 30);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            this.btnclose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(180, 58);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(82, 30);
            this.btnlogin.TabIndex = 11;
            this.btnlogin.Text = "&Login";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            this.btnlogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(108, 10);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(256, 31);
            this.password.TabIndex = 10;
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // FrmUsersRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(850, 616);
            this.Controls.Add(this.pnllogin);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmUsersRights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Rights";
            this.Load += new System.EventHandler(this.usersrights_Load);
            //this.SizeChanged += new System.EventHandler(this.FrmUsersRights_SizeChanged);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserRights)).EndInit();
            this.grpFormRights.ResumeLayout(false);
            this.pnllogin.ResumeLayout(false);
            this.pnllogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.DataGridView grdUserRights;
        private System.Windows.Forms.GroupBox grpFormRights;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Button btnclse;
        private System.Windows.Forms.CheckBox chkprint;
        private System.Windows.Forms.CheckBox chkdel;
        private System.Windows.Forms.CheckBox chkedit;
        private System.Windows.Forms.CheckBox chkadd;
        private System.Windows.Forms.CheckBox chkallow;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn usertypeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn userid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn formname;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn formnameText;
        private System.Windows.Forms.DataGridViewTextBoxColumn subitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn menulevel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allow;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addRights;
        private System.Windows.Forms.DataGridViewCheckBoxColumn editRights;
        private System.Windows.Forms.DataGridViewCheckBoxColumn delRights;
        private System.Windows.Forms.DataGridViewCheckBoxColumn printRights;
        private System.Windows.Forms.Panel pnllogin;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
    }
}