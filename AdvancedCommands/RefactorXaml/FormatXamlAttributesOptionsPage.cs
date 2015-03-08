using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.CodeRush.Core;
using DevExpress.DXCore.Controls.XtraEditors;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.DXCore.Controls.XtraEditors.Controls;

namespace CodeRushContrib.Ethan.RefactorXaml
{
    [System.ComponentModel.DesignerCategory("Code")]
    [UserLevel(UserLevel.NewUser)]
    public class FormatXamlAttributesOptionsPage : OptionsPage
    {
        // Fields
        private CheckEdit chkDontSort;
        private CheckEdit chkKeepFirstAttr;
        private CheckEdit chkSortAlphabet;
        private IContainer components;
        private Label label1;
        private Label label2;

        // Methods
        public FormatXamlAttributesOptionsPage()
        {
            this.InitializeComponent();
        }

        private FormatXamlAttributesOptions ControlToOptions()
        {
            var options = FormatXamlAttributesOptions.Default;
            options.Sort = this.chkSortAlphabet.Checked;
            options.KeepFirstAttribute = this.chkKeepFirstAttr.Checked;
            return options;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public static string GetCategory()
        {
            return @"Editor\Refactoring";
        }

        public static string GetPageName()
        {
            return "Format Xaml Attributes";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ////this.label1 = new Label();
            ////this.chkDontSort = new CheckEdit();
            ////this.chkSortAlphabet = new CheckEdit();
            ////this.chkKeepFirstAttr = new CheckEdit();
            ////this.label2 = new Label();
            ////this.chkDontSort.Properties.BeginInit();
            ////this.chkSortAlphabet.Properties.BeginInit();
            ////this.chkKeepFirstAttr.Properties.BeginInit();
            ////this.BeginInit();
            ////base.SuspendLayout();
            ////this.label1.AutoSize = true;
            ////this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xcc);
            ////this.label1.Location = new Point(8, 8);
            ////this.label1.Name = "label1";
            ////this.label1.Size = new Size(0x5b, 13);
            ////this.label1.TabIndex = 0;
            ////this.label1.Text = "Sort attributes:";
            ////this.chkDontSort.Location = new Point(0x18, 0x22);
            ////this.chkDontSort.Name = "chkDontSort";
            ////this.chkDontSort.Properties.Caption = "Don't sort";
            ////this.chkDontSort.Properties.CheckStyle = CheckStyles.Radio;
            ////this.chkDontSort.Properties.RadioGroupIndex = 1;
            ////this.chkDontSort.Size = new Size(160, 0x12);
            ////this.chkDontSort.TabIndex = 1;
            ////this.chkDontSort.TabStop = false;
            ////this.chkSortAlphabet.Location = new Point(0x18, 0x3d);
            ////this.chkSortAlphabet.Name = "chkSortAlphabet";
            ////this.chkSortAlphabet.Properties.Caption = "Alphabetically";
            ////this.chkSortAlphabet.Properties.CheckStyle = CheckStyles.Radio;
            ////this.chkSortAlphabet.Properties.RadioGroupIndex = 1;
            ////this.chkSortAlphabet.Size = new Size(160, 0x12);
            ////this.chkSortAlphabet.TabIndex = 2;
            ////this.chkSortAlphabet.TabStop = false;
            ////this.chkKeepFirstAttr.Location = new Point(0x18, 0x7f);
            ////this.chkKeepFirstAttr.Name = "chkKeepFirstAttr";
            ////this.chkKeepFirstAttr.Properties.Caption = "Keep the first attribute on the base tag line";
            ////this.chkKeepFirstAttr.Size = new Size(0xf1, 0x12);
            ////this.chkKeepFirstAttr.TabIndex = 3;
            ////this.label2.AutoSize = true;
            ////this.label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xcc);
            ////this.label2.Location = new Point(8, 0x65);
            ////this.label2.Name = "label2";
            ////this.label2.Size = new Size(0x88, 13);
            ////this.label2.TabIndex = 4;
            ////this.label2.Text = "Break Apart Attributes:";
            ////base.Controls.Add(this.label2);
            ////base.Controls.Add(this.chkKeepFirstAttr);
            ////base.Controls.Add(this.chkSortAlphabet);
            ////base.Controls.Add(this.chkDontSort);
            ////base.Controls.Add(this.label1);
            ////base.Name = "OptBreakApartLineUpAttributes";
            ////base.PreparePage += new OptionsPage.PreparePageEventHandler(this.OptBreakLineUpAttributes_PreparePage);
            ////base.RestoreDefaults += new OptionsPage.RestoreDefaultsEventHandler(this.OptBreakLineUpAttributes_RestoreDefaults);
            ////base.CommitChanges += new OptionsPage.CommitChangesEventHandler(this.OptBreakLineUpAttributes_CommitChanges);
            ////this.chkDontSort.Properties.EndInit();
            ////this.chkSortAlphabet.Properties.EndInit();
            ////this.chkKeepFirstAttr.Properties.EndInit();
            ////this.EndInit();
            ////base.ResumeLayout(false);
            ////base.PerformLayout();
        }

        private void OptBreakLineUpAttributes_CommitChanges(object sender, OptionsPageStorageEventArgs ea)
        {
            var options = this.ControlToOptions();
            using (DecoupledStorage storage = ea.Storage)
            {
                options.Save(storage);
            }
        }

        private void OptBreakLineUpAttributes_PreparePage(object sender, OptionsPageStorageEventArgs ea)
        {
            using (DecoupledStorage storage = ea.Storage)
            {
                this.UpdateControls(FormatXamlAttributesOptions.LoadFrom(storage));
            }
        }

        private void OptBreakLineUpAttributes_RestoreDefaults(object sender, OptionsPageEventArgs ea)
        {
            this.UpdateControls(FormatXamlAttributesOptions.Default);
        }

        ////public static void Show()
        ////{
        ////    CodeRush.Command.Execute("Options", FullPath);
        ////}

        private void UpdateControls(FormatXamlAttributesOptions options)
        {
            this.chkDontSort.Checked = !options.Sort;
            this.chkSortAlphabet.Checked = options.Sort;
            this.chkKeepFirstAttr.Checked = options.KeepFirstAttribute;
        }

        // Properties
        public override string Category
        {
            get
            {
                return GetCategory();
            }
        }

        public static string FullPath
        {
            get
            {
                return (String.Format(@"{0}\{1}", GetCategory(), GetPageName()));
            }
        }

        public override string PageName
        {
            get
            {
                return GetPageName();
            }
        }

        public static DecoupledStorage Storage
        {
            get
            {
                return CodeRush.Options.GetStorage(GetCategory(), GetPageName());
            }
        }
    }


}