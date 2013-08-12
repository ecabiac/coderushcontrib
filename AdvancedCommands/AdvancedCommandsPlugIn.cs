using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CommentPlugIn
{
    public partial class AdvancedCommandsPlugIn : StandardPlugIn
    {
        // DXCore-generated code...
        #region InitializePlugIn
        public override void InitializePlugIn()
        {
            base.InitializePlugIn();
            doubleCommentAction.Execute += doubleCommentAction_Execute;
            //
            // TODO: Add your initialization code here.
            //
        }

        void doubleCommentAction_Execute(ExecuteEventArgs ea)
        {
            var activeTextDocument = CodeRush.Documents.ActiveTextDocument;
            if (activeTextDocument == null)
            {
                return;
            }

            var selection = activeTextDocument.ActiveViewSelection;
            selection.ExtendToWholeLines();
            
            var lang = CodeRush.Language;
            var commentedSelection = string.Empty;

            var lines = selection.Lines;
   
            foreach (var line in selection.Lines)
            {
                commentedSelection += lang.GetComment(lang.GetComment(line));
            }

            //selection.Text = commentedSelection;

            if (selection.AnchorIsAtEnd)
                selection.SwapPoints();
            selection.Clear();
        }
        #endregion
        #region FinalizePlugIn
        public override void FinalizePlugIn()
        {
            //
            // TODO: Add your finalization code here.
            //

            base.FinalizePlugIn();
        }
        #endregion
    }

}