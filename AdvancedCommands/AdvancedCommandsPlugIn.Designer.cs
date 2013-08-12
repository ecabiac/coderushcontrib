namespace CommentPlugIn
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
            this.codeProvider1 = new DevExpress.CodeRush.Core.CodeProvider(this.components);
            this.doubleCommentAction = new DevExpress.CodeRush.Core.Action(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Images16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleCommentAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // codeProvider1
            // 
            this.codeProvider1.ActionHintText = "";
            this.codeProvider1.ApplicationSphere.CodeMoving = false;
            this.codeProvider1.ApplicationSphere.CodeSimplification = false;
            this.codeProvider1.ApplicationSphere.MemberSignature = false;
            this.codeProvider1.AutoActivate = true;
            this.codeProvider1.AutoUndo = false;
            this.codeProvider1.CodeIssueMessage = null;
            this.codeProvider1.Description = "";
            this.codeProvider1.Image = null;
            this.codeProvider1.NeedsSelection = false;
            this.codeProvider1.ParentMenu = null;
            this.codeProvider1.ProviderName = "";
            this.codeProvider1.Register = true;
            this.codeProvider1.RequiresSubMenuChoice = false;
            this.codeProvider1.SupportsAsyncMode = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.codeProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleCommentAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.CodeRush.Core.CodeProvider codeProvider1;
        private DevExpress.CodeRush.Core.Action doubleCommentAction;
    }
}