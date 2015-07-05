namespace CodeRushContrib.NotificationObject
{
    partial class NotificationObjectPlugIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NotificationObjectPlugIn()
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
            this.notificationObjectDerivedContextProvider = new CodeRushContrib.NotificationObject.NotificationObjectContextProvider(this.components);
            this.observableObjectContextProvider = new CodeRushContrib.NotificationObject.ObservableObjectContextProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Images16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationObjectDerivedContextProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.observableObjectContextProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // notificationObjectDerivedContextProvider
            // 
            this.notificationObjectDerivedContextProvider.Description = "Current class is derived from Notification Object";
            this.notificationObjectDerivedContextProvider.ForElement = DevExpress.CodeRush.StructuralParser.LanguageElementType.Unknown;
            this.notificationObjectDerivedContextProvider.IsDocumentation = false;
            this.notificationObjectDerivedContextProvider.ProviderName = "Editor\\Code\\InNotificationObjectDerived";
            this.notificationObjectDerivedContextProvider.Register = true;
            // 
            // observableObjectContextProvider
            // 
            this.observableObjectContextProvider.Description = "Current class is derived from ObservableObject";
            this.observableObjectContextProvider.ForElement = DevExpress.CodeRush.StructuralParser.LanguageElementType.Unknown;
            this.observableObjectContextProvider.IsDocumentation = false;
            this.observableObjectContextProvider.ProviderName = "Editor\\Code\\InObservableObjectDerived";
            this.observableObjectContextProvider.Register = true;
            ((System.ComponentModel.ISupportInitialize)(this.Images16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationObjectDerivedContextProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.observableObjectContextProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private CodeRushContrib.NotificationObject.NotificationObjectContextProvider notificationObjectDerivedContextProvider;
        private ObservableObjectContextProvider observableObjectContextProvider;
    }
}