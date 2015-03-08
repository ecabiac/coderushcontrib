using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;
using DevExpress.CodeRush.Extensions;

namespace CodeRushContrib.NotificationObject
{
    public class NotificationObjectContextProvider : ContextProvider
    {
        public NotificationObjectContextProvider(IContainer container)
            : base(container)
        {
        }

        public NotificationObjectContextProvider()
        {
        }

        #region Public Members

        #region Attributes

        /// <summary>Gets or sets what element the documentation must apply to.</summary> 
        public LanguageElementType ForElement { get; set; }

        /// <summary>Gets or sets whether the current element must be in a documentation element.</summary>         
        public bool IsDocumentation { get; set; }
        #endregion

        /// <summary>Determines if this context is satisfied.</summary> 
        /// <param name="parameters">The optional parameters.</param> 
        /// <returns><see langword="true"/> if the context is valid or <see langword="false"/> otherwise.</returns> 
        public override bool IsContextSatisfied(string parameters)
        {
            //Make sure we are seeing any changes 
            CodeRush.Source.ParseIfTextChanged();

            //////No current element 
            ////if (CurrentElement == null)
            ////    return false;

            var activeClass = CodeRush.Source.ActiveClass;
            if (activeClass != null)
            {
                return activeClass.GetBaseTypes().Where(bt => bt.Name.Contains("NotificationObject")).Any();
            }

            return false;
        }

        #endregion

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // NotificationObjectContextProvider
            // 
            this.Description = "Current class is derived from Notification Object";
            this.ProviderName = "InNotificationObjectDerived";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}