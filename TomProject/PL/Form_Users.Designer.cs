namespace TomProject
{
    partial class form_Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Users));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.Administration = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.admin = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.manger = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.employee = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.txtpass = new DevExpress.XtraEditors.TextEdit();
            this.txtpermission = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Password = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.AutoScroll = false;
            this.fluentDesignFormContainer1.Controls.Add(this.accordionControl1);
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton3);
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton2);
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton1);
            this.fluentDesignFormContainer1.Controls.Add(this.label3);
            this.fluentDesignFormContainer1.Controls.Add(this.txtName);
            this.fluentDesignFormContainer1.Controls.Add(this.txtpass);
            this.fluentDesignFormContainer1.Controls.Add(this.txtpermission);
            this.fluentDesignFormContainer1.Controls.Add(this.label1);
            this.fluentDesignFormContainer1.Controls.Add(this.label2);
            this.fluentDesignFormContainer1.Controls.Add(this.gridControl1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 31);
            this.fluentDesignFormContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(991, 565);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Administration,
            this.manger,
            this.employee});
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.accordionControl1.ScaleImages = DevExpress.Utils.DefaultBoolean.False;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl1.Size = new System.Drawing.Size(272, 565);
            this.accordionControl1.TabIndex = 45;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // Administration
            // 
            this.Administration.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.admin});
            this.Administration.Expanded = true;
            this.Administration.Name = "Administration";
            this.Administration.Text = "الادارة";
            // 
            // admin
            // 
            this.admin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("admin.ImageOptions.SvgImage")));
            this.admin.Name = "admin";
            this.admin.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.admin.Text = "صاحب العمل ";
            this.admin.Click += new System.EventHandler(this.admin_Click_1);
            // 
            // manger
            // 
            this.manger.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("manger.ImageOptions.SvgImage")));
            this.manger.Name = "manger";
            this.manger.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.manger.Text = "المدير ";
            this.manger.Click += new System.EventHandler(this.manger_Click_1);
            // 
            // employee
            // 
            this.employee.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("employee.ImageOptions.SvgImage")));
            this.employee.Name = "employee";
            this.employee.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.employee.Text = "الموظفين ";
            this.employee.Click += new System.EventHandler(this.employee_Click_1);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.BackColor = System.Drawing.Color.Silver;
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.simpleButton3.Appearance.Options.UseBackColor = true;
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(497, 130);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.simpleButton3.Size = new System.Drawing.Size(146, 41);
            this.simpleButton3.TabIndex = 44;
            this.simpleButton3.Text = "تعديل البيانات";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.Silver;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(314, 130);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.simpleButton2.Size = new System.Drawing.Size(146, 41);
            this.simpleButton2.TabIndex = 43;
            this.simpleButton2.Text = "حذف البيانات ";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(676, 130);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.simpleButton1.Size = new System.Drawing.Size(146, 41);
            this.simpleButton1.TabIndex = 42;
            this.simpleButton1.Text = "حفظ البيانات";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(508, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "صلاحية المستخدم";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(707, 28);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MenuManager = this.fluentFormDefaultManager1;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(115, 20);
            this.txtName.TabIndex = 14;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(707, 88);
            this.txtpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpass.MenuManager = this.fluentFormDefaultManager1;
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(115, 20);
            this.txtpass.TabIndex = 13;
            // 
            // txtpermission
            // 
            this.txtpermission.FormattingEnabled = true;
            this.txtpermission.Items.AddRange(new object[] {
            "صاحب العمل",
            "مدير",
            "موظف"});
            this.txtpermission.Location = new System.Drawing.Point(370, 22);
            this.txtpermission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpermission.Name = "txtpermission";
            this.txtpermission.Size = new System.Drawing.Size(104, 21);
            this.txtpermission.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(859, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "الرقم السرى ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(845, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "اسم المستخدم";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(277, 177);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.MenuManager = this.fluentFormDefaultManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(714, 399);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sName,
            this.ID,
            this.Type,
            this.Password});
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // sName
            // 
            this.sName.Caption = "اسم المستخدم ";
            this.sName.FieldName = "sName";
            this.sName.MinWidth = 21;
            this.sName.Name = "sName";
            this.sName.Visible = true;
            this.sName.VisibleIndex = 2;
            this.sName.Width = 81;
            // 
            // ID
            // 
            this.ID.Caption = "رقم المستخدم ";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 21;
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 3;
            this.ID.Width = 81;
            // 
            // Type
            // 
            this.Type.Caption = "نوع الصلاحية";
            this.Type.FieldName = "Type";
            this.Type.MinWidth = 21;
            this.Type.Name = "Type";
            this.Type.Visible = true;
            this.Type.VisibleIndex = 0;
            this.Type.Width = 81;
            // 
            // Password
            // 
            this.Password.Caption = "كلمة السر ";
            this.Password.FieldName = "Password";
            this.Password.MinWidth = 21;
            this.Password.Name = "Password";
            this.Password.Visible = true;
            this.Password.VisibleIndex = 1;
            this.Password.Width = 81;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(991, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // form_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 596);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "form_Users";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "المستخدمين";
            this.Load += new System.EventHandler(this.form_Users_Load);
            this.fluentDesignFormContainer1.ResumeLayout(false);
            this.fluentDesignFormContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn sName;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraGrid.Columns.GridColumn Password;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtpass;
        private System.Windows.Forms.ComboBox txtpermission;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Administration;
        private DevExpress.XtraBars.Navigation.AccordionControlElement admin;
        private DevExpress.XtraBars.Navigation.AccordionControlElement employee;
        private DevExpress.XtraBars.Navigation.AccordionControlElement manger;
    }
}