namespace CodeRushContrib.AdvancedCommands
{
    partial class AdvancedCommandsPlugIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AdvancedCommandsPlugIn()
        {
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>
            InitializeComponent();
        }

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
            this.doubleCommentAction = new DevExpress.CodeRush.Core.Action(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Images16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleCommentAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // doubleCommentAction
            // 
            this.doubleCommentAction.ActionName = "CRADV_SelectionDoubleComment";
            this.doubleCommentAction.CommonMenu = DevExpress.CodeRush.Menus.VsCommonBar.None;
            this.doubleCommentAction.Description = "Creates a comment with four slashes";
            this.doubleCommentAction.ImageBackColor = System.Drawing.Color.Empty;
            this.doubleCommentAction.ToolbarItem.ButtonIsPressed = false;
            this.doubleCommentAction.ToolbarItem.Caption = null;
            this.doubleCommentAction.ToolbarItem.Image = null;
            ((System.ComponentModel.ISupportInitialize)(this.Images16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleCommentAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.CodeRush.Core.Action doubleCommentAction;
    }
}