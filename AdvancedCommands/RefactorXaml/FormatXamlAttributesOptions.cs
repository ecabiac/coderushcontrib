using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.StructuralParser;
using DevExpress.DXCore.Controls.XtraEditors;

namespace CodeRushContrib.Ethan.RefactorXaml
{
    public class FormatXamlAttributesOptions
    {
        // Fields
        private const string STR_KeepFirstAttribute = "KeepFirstAttribute";
        private const string STR_SortAttributes = "SortAttributes";

        // Methods
        public void Load(DecoupledStorage storage)
        {
            KeepFirstAttribute = false;
            Sort = false;
            OverrideTabSettings = true;
            TabSize = 2;
            PutCloseTagOnOwnLine = true;

            if (storage != null)
            {
                KeepFirstAttribute = storage.ReadBoolean("General", STR_KeepFirstAttribute, false);
                Sort = storage.ReadBoolean("General", STR_SortAttributes, false);

                OverrideTabSettings = storage.ReadBoolean("General", "OverrideTabSettings", true);
                TabSize = ((short)storage.ReadInt32("General", "TabSize", 2));
                PutCloseTagOnOwnLine = storage.ReadBoolean("General", "PutCloseTagOnOwnLine", true);
            }
        }

        public static FormatXamlAttributesOptions LoadFrom(DecoupledStorage storage)
        {
            FormatXamlAttributesOptions options = new FormatXamlAttributesOptions();
            options.Load(storage);
            return options;
        }

        public void Save(DecoupledStorage storage)
        {
            if (storage != null)
            {
                storage.WriteBoolean("General", "KeepFirstAttribute", KeepFirstAttribute);
                storage.WriteBoolean("General", "SortAttributes", Sort);
            }
        }

        // Properties
        public static FormatXamlAttributesOptions Default
        {
            get
            {
                return new FormatXamlAttributesOptions();
            }
        }

        public bool KeepFirstAttribute
        {
            get;
            set;
        }

        public bool Sort
        {
            get;
            set;
        }

        public bool PutCloseTagOnOwnLine { get; set; }

        public bool OverrideTabSettings { get; set; }

        public short TabSize { get; set; }
    }
}
