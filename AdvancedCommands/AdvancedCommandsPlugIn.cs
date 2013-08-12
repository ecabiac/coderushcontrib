using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CodeRushContrib.AdvancedCommands
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

            foreach (var line in lines)
            {
                var lineText = line.TrimStart();

                var commentLine = lang.GetComment(lang.GetComment(lineText));
                var idx = commentLine.LastIndexOf(System.Environment.NewLine);
                commentLine = commentLine.Remove(idx);
                commentedSelection += commentLine;
            }

            selection.Text = commentedSelection;
            selection.Format();

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