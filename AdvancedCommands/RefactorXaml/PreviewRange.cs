using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.StructuralParser;
using DevExpress.Refactor.Core;

namespace CodeRushContrib.Ethan.RefactorXaml
{
    public class PreviewRange
    {
        // Fields
        private SourceRange _Range;
        private bool _Up;

        // Methods
        public PreviewRange(SourceRange range, bool up)
        {
            this._Range = range;
            this._Up = up;
        }

        public void ShowArrow(PrepareContentPreviewEventArgs ea)
        {
            if (!this._Up)
            {
                ea.AddArrow90(this._Range.End, RefactorColors.ArrowFill, RefactorColors.ArrowOutline);
            }
        }

        // Properties
        public SourceRange Range
        {
            get
            {
                return this._Range;
            }
        }
    }
}
