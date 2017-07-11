namespace DiamondPro.TRANSACTION
{
    partial class FrmBoxNumbering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBoxNumbering));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtCts = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtBoxNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.BtnClear = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grdTo = new DevExpress.XtraGrid.GridControl();
            this.DeleteRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvTo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtQuality = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtChavni = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtCarat = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtTTCarat = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rtxtTTAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rchkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtChavni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtCarat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtTTCarat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtTTAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtAmount);
            this.panelControl1.Controls.Add(this.labelControl16);
            this.panelControl1.Controls.Add(this.txtRate);
            this.panelControl1.Controls.Add(this.labelControl15);
            this.panelControl1.Controls.Add(this.txtCts);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.txtBoxNo);
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1061, 48);
            this.panelControl1.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.EditValue = "0.000";
            this.txtAmount.EnterMoveNextControl = true;
            this.txtAmount.Location = new System.Drawing.Point(657, 9);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Properties.Appearance.Options.UseFont = true;
            this.txtAmount.Properties.DisplayFormat.FormatString = "f3";
            this.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmount.Properties.EditFormat.FormatString = "f3";
            this.txtAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmount.Properties.Mask.EditMask = "f3";
            this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmount.Properties.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(135, 26);
            this.txtAmount.TabIndex = 82;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.labelControl16.Location = new System.Drawing.Point(604, 10);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(44, 25);
            this.labelControl16.TabIndex = 83;
            this.labelControl16.Text = "ટોટલ :";
            // 
            // txtRate
            // 
            this.txtRate.EditValue = "0.000";
            this.txtRate.EnterMoveNextControl = true;
            this.txtRate.Location = new System.Drawing.Point(463, 10);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Properties.Appearance.Options.UseFont = true;
            this.txtRate.Properties.DisplayFormat.FormatString = "f3";
            this.txtRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRate.Properties.EditFormat.FormatString = "f3";
            this.txtRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRate.Properties.Mask.EditMask = "f3";
            this.txtRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRate.Properties.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(135, 26);
            this.txtRate.TabIndex = 80;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.labelControl15.Location = new System.Drawing.Point(421, 10);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(31, 25);
            this.labelControl15.TabIndex = 81;
            this.labelControl15.Text = "ભાવ:";
            // 
            // txtCts
            // 
            this.txtCts.EditValue = "0.000";
            this.txtCts.EnterMoveNextControl = true;
            this.txtCts.Location = new System.Drawing.Point(317, 11);
            this.txtCts.Name = "txtCts";
            this.txtCts.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCts.Properties.Appearance.Options.UseFont = true;
            this.txtCts.Properties.DisplayFormat.FormatString = "f0";
            this.txtCts.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCts.Properties.EditFormat.FormatString = "f0";
            this.txtCts.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCts.Properties.Mask.EditMask = "f0";
            this.txtCts.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCts.Properties.ReadOnly = true;
            this.txtCts.Size = new System.Drawing.Size(95, 26);
            this.txtCts.TabIndex = 78;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.labelControl11.Location = new System.Drawing.Point(271, 10);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(43, 25);
            this.labelControl11.TabIndex = 79;
            this.labelControl11.Text = "વજન :";
            // 
            // txtBoxNo
            // 
            this.txtBoxNo.EnterMoveNextControl = true;
            this.txtBoxNo.Location = new System.Drawing.Point(84, 11);
            this.txtBoxNo.Name = "txtBoxNo";
            this.txtBoxNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNo.Properties.Appearance.Options.UseFont = true;
            this.txtBoxNo.Size = new System.Drawing.Size(182, 26);
            this.txtBoxNo.TabIndex = 77;
            this.txtBoxNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxNo_KeyPress);
            this.txtBoxNo.Validated += new System.EventHandler(this.txtBoxNo_Validated);
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.labelControl13.Location = new System.Drawing.Point(7, 10);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(70, 25);
            this.labelControl13.TabIndex = 76;
            this.labelControl13.Text = "બોક્ષ નંબર:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.BtnClear);
            this.panelControl2.Controls.Add(this.BtnDelete);
            this.panelControl2.Controls.Add(this.BtnSave);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 540);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1061, 47);
            this.panelControl2.TabIndex = 1;
            // 
            // BtnClear
            // 
            this.BtnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BtnClear.Appearance.Options.UseFont = true;
            this.BtnClear.Image = ((System.Drawing.Image)(resources.GetObject("BtnClear.Image")));
            this.BtnClear.Location = new System.Drawing.Point(229, 8);
            this.BtnClear.LookAndFeel.SkinName = "Blue";
            this.BtnClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(104, 31);
            this.BtnClear.TabIndex = 17;
            this.BtnClear.Text = "&Clear";
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BtnDelete.Appearance.Options.UseFont = true;
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.Location = new System.Drawing.Point(120, 8);
            this.BtnDelete.LookAndFeel.SkinName = "Blue";
            this.BtnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(104, 31);
            this.BtnDelete.TabIndex = 16;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSave.Appearance.Options.UseFont = true;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(11, 8);
            this.BtnSave.LookAndFeel.SkinName = "Blue";
            this.BtnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(104, 31);
            this.BtnSave.TabIndex = 15;
            this.BtnSave.Text = "&Save";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // grdTo
            // 
            this.grdTo.ContextMenuStrip = this.DeleteRecord;
            this.grdTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTo.Location = new System.Drawing.Point(0, 48);
            this.grdTo.MainView = this.dgvTo;
            this.grdTo.Name = "grdTo";
            this.grdTo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxtTTCarat,
            this.repositoryItemTextEdit1,
            this.rtxtTTAmount,
            this.rchkSelect,
            this.rtxtQuality,
            this.rtxtChavni,
            this.rtxtCarat,
            this.rtxtRate,
            this.rtxtAmount});
            this.grdTo.Size = new System.Drawing.Size(1061, 492);
            this.grdTo.TabIndex = 4;
            this.grdTo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvTo});
            // 
            // DeleteRecord
            // 
            this.DeleteRecord.Name = "DeleteRecord";
            this.DeleteRecord.Size = new System.Drawing.Size(61, 4);
            this.DeleteRecord.Text = "Delete Selected Record";
            this.DeleteRecord.Click += new System.EventHandler(this.DeleteRecord_Click);
            // 
            // dgvTo
            // 
            this.dgvTo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.dgvTo.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvTo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn6});
            this.dgvTo.GridControl = this.grdTo;
            this.dgvTo.Name = "dgvTo";
            this.dgvTo.OptionsNavigation.EnterMoveNextColumn = true;
            this.dgvTo.OptionsNavigation.UseTabKey = false;
            this.dgvTo.OptionsView.ColumnAutoWidth = false;
            this.dgvTo.OptionsView.ShowAutoFilterRow = true;
            this.dgvTo.OptionsView.ShowFooter = true;
            this.dgvTo.OptionsView.ShowGroupPanel = false;
            this.dgvTo.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.dgvTo_CustomSummaryCalculate);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Quality";
            this.gridColumn1.ColumnEdit = this.rtxtQuality;
            this.gridColumn1.FieldName = "Quality";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 112;
            // 
            // rtxtQuality
            // 
            this.rtxtQuality.AutoHeight = false;
            this.rtxtQuality.Name = "rtxtQuality";
            this.rtxtQuality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtQuality_KeyPress);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Chavni";
            this.gridColumn2.ColumnEdit = this.rtxtChavni;
            this.gridColumn2.FieldName = "Chavni";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 110;
            // 
            // rtxtChavni
            // 
            this.rtxtChavni.AutoHeight = false;
            this.rtxtChavni.Name = "rtxtChavni";
            this.rtxtChavni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtChavni_KeyPress);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Carat";
            this.gridColumn3.ColumnEdit = this.rtxtCarat;
            this.gridColumn3.FieldName = "Cts";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cts", "{0:0.##}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 90;
            // 
            // rtxtCarat
            // 
            this.rtxtCarat.AutoHeight = false;
            this.rtxtCarat.DisplayFormat.FormatString = "f2";
            this.rtxtCarat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtCarat.EditFormat.FormatString = "f2";
            this.rtxtCarat.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtCarat.Mask.EditMask = "f2";
            this.rtxtCarat.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rtxtCarat.Name = "rtxtCarat";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Rate";
            this.gridColumn4.ColumnEdit = this.rtxtRate;
            this.gridColumn4.FieldName = "Rate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 104;
            // 
            // rtxtRate
            // 
            this.rtxtRate.AutoHeight = false;
            this.rtxtRate.DisplayFormat.FormatString = "f2";
            this.rtxtRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtRate.EditFormat.FormatString = "f2";
            this.rtxtRate.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtRate.Mask.EditMask = "f2";
            this.rtxtRate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rtxtRate.Name = "rtxtRate";
            this.rtxtRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtRate_KeyDown);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Amount";
            this.gridColumn5.ColumnEdit = this.rtxtAmount;
            this.gridColumn5.FieldName = "Amount";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:0.##}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 129;
            // 
            // rtxtAmount
            // 
            this.rtxtAmount.AutoHeight = false;
            this.rtxtAmount.DisplayFormat.FormatString = "f2";
            this.rtxtAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtAmount.EditFormat.FormatString = "f2";
            this.rtxtAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtAmount.Mask.EditMask = "f2";
            this.rtxtAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rtxtAmount.Name = "rtxtAmount";
            this.rtxtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtAmount_KeyDown);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "QualityId";
            this.gridColumn8.FieldName = "QualityId";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "ChavniId";
            this.gridColumn9.FieldName = "ChavniId";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "NDID";
            this.gridColumn6.FieldName = "NDID";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // rtxtTTCarat
            // 
            this.rtxtTTCarat.AutoHeight = false;
            this.rtxtTTCarat.DisplayFormat.FormatString = "f2";
            this.rtxtTTCarat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtTTCarat.EditFormat.FormatString = "f2";
            this.rtxtTTCarat.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtTTCarat.Mask.EditMask = "f2";
            this.rtxtTTCarat.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rtxtTTCarat.Name = "rtxtTTCarat";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "f2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "f2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "f2";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // rtxtTTAmount
            // 
            this.rtxtTTAmount.AutoHeight = false;
            this.rtxtTTAmount.DisplayFormat.FormatString = "f2";
            this.rtxtTTAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtTTAmount.EditFormat.FormatString = "f2";
            this.rtxtTTAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rtxtTTAmount.Mask.EditMask = "f2";
            this.rtxtTTAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rtxtTTAmount.Name = "rtxtTTAmount";
            // 
            // rchkSelect
            // 
            this.rchkSelect.AutoHeight = false;
            this.rchkSelect.Name = "rchkSelect";
            this.rchkSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            // 
            // FrmBoxNumbering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 587);
            this.Controls.Add(this.grdTo);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmBoxNumbering";
            this.Text = "Box Numbering";
            this.Load += new System.EventHandler(this.FrmBoxNumbering_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtChavni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtCarat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtTTCarat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtTTAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton BtnClear;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraGrid.GridControl grdTo;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtTTCarat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtTTAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkSelect;
        private DevExpress.XtraEditors.TextEdit txtBoxNo;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtCts;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtQuality;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtChavni;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtCarat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtRate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.ContextMenuStrip DeleteRecord;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}