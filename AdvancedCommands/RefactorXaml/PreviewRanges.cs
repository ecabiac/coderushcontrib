using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.StructuralParser;
using DevExpress.Refactor.Core;

namespace CodeRushContrib.Ethan.RefactorXaml
{
    public class PreviewRanges : CollectionBase
    {
        // Fields
        private bool _PreviewShown;

        // Methods
        public void Add(PreviewRange range)
        {
            if (range != null)
            {
                base.InnerList.Add(range);
            }
        }

        public void Add(SourceRange range, bool up)
        {
            this.Add(new PreviewRange(range, up));
        }

        public void Clear(TextView view)
        {
            if (view != null)
            {
                this.HidePreview(null);
            }
            base.Clear();
        }

        public void HidePreview(HideContentPreviewEventArgs ea)
        {
            this._PreviewShown = false;
        }

        public void ShowPreview(PrepareContentPreviewEventArgs ea)
        {
            if (ea.TextView != null)
            {
                foreach (PreviewRange range in this)
                {
                    range.ShowArrow(ea);
                }
                foreach (PreviewRange range2 in this)
                {
                    ea.AddBrushStrokeHighlighter(range2.Range, RefactorColors.MoveCode);
                }
                this._PreviewShown = true;
            }
        }

        // Properties
        public PreviewRange this[int index]
        {
            get
            {
                return (base.InnerList[index] as PreviewRange);
            }
        }

        public bool PreviewShown
        {
            get
            {
                return this._PreviewShown;
            }
        }
    }
}
