using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.Extensions;
using DevExpress.CodeRush.StructuralParser;

namespace CodeRushContrib.NotificationObject
{
    public class ObservableObjectContextProvider : ContextProvider
    {
        public ObservableObjectContextProvider(IContainer container)
            : base(container)
        {
        }

        public ObservableObjectContextProvider()
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
                return activeClass.GetBaseTypes().Where(bt => bt.Name.Contains("ObservableObject")).Any();
            }

            return false;
        }

        #endregion

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ObservableObjectContextProvider
            // 
            this.Description = "Current class is derived from ObservableObject";
            this.ProviderName = "InObservableObjectDerived";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
