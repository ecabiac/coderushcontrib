using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;
using DevExpress.Refactor.Core;
using DevExpress.DXCore.TextBuffers;
using DevExpress.CodeRush.Core.Replacement;
using DevExpress.CodeRush.Diagnostics;
using DevExpress.CodeRush.Diagnostics.Core;

namespace CodeRushContrib.Ethan.RefactorXaml
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class FormatXamlAttributesPlugin : StandardPlugIn
    {
        private readonly static string[] _langs = new string[] { "XAML", "HTML/XML", "XML", "HTML", "HTMLX" };

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer _components = null;

        private PreviewRanges _breakApartPreview; 
        private FormatXamlAttributesOptions _options;


        private RefactoringProvider _refactorFormatXamlAttributes; 
        ////private LanguageElement _activeElement;
 
        /// <summary>
        /// Initializes a new instance of the FormatXamlPlugin class.
        /// </summary>
        public FormatXamlAttributesPlugin()
        {
            _components = new System.ComponentModel.Container();

            _refactorFormatXamlAttributes = new RefactoringProvider(_components);

            ((System.ComponentModel.ISupportInitialize)(_refactorFormatXamlAttributes)).BeginInit();
            _refactorFormatXamlAttributes.ActionHintText = "Formats Attributes";
            _refactorFormatXamlAttributes.DisplayName = "Format Xaml Attributes";
            _refactorFormatXamlAttributes.AutoActivate = true;
            _refactorFormatXamlAttributes.AutoUndo = false;
            _refactorFormatXamlAttributes.Description = "";
            _refactorFormatXamlAttributes.NeedsSelection = false;
            _refactorFormatXamlAttributes.ProviderName = "Format Xaml Attributes";
            _refactorFormatXamlAttributes.Register = true;
            _refactorFormatXamlAttributes.SupportsAsyncMode = false;

            _refactorFormatXamlAttributes.LanguageSupported += _refactorFormatXamlAttributes_LanguageSupported;
            _refactorFormatXamlAttributes.CheckAvailability += _refactorFormatXaml_CheckAvailability;
            _refactorFormatXamlAttributes.PreparePreview += _refactorFormatXaml_PreparePreview;
            _refactorFormatXamlAttributes.Apply += _refactorFormatXaml_Apply;

            ((System.ComponentModel.ISupportInitialize)(_refactorFormatXamlAttributes)).EndInit();
        }

        void _refactorFormatXamlAttributes_LanguageSupported(LanguageSupportedEventArgs ea)
        {
            var languageID = ea.LanguageID;
            ea.Handled = IsLanguageHandled(languageID);
        }

        private static bool IsLanguageHandled(string languageID)
        {
            return _langs.Contains(languageID);
        }

        private FormatXamlAttributesOptions Options
        {
            get
            {
                if (this._options == null)
                {
                    this._options = this.LoadOptions();
                }
                return this._options;
            }
        }

        private FormatXamlAttributesOptions LoadOptions()
        {
            var options = FormatXamlAttributesOptions.Default;
            using (DecoupledStorage storage = FormatXamlAttributesOptionsPage.Storage)
            {
                options.Load(storage);
            }
            return options;
        }
 
        void _refactorFormatXaml_Apply(object sender, ApplyContentEventArgs ea)
        {
            var element = GetActiveHtmlElement(ea.Element, Options.Sort);
            var keepFirstOnBaseLine = this.Options.KeepFirstAttribute;
            var closeOnOwnLine = Options.PutCloseTagOnOwnLine;

            if (((element != null) && (element.Attributes != null)) && (element.Attributes.Count != 0))
            {
                HtmlElement newElement = GetNewElement(element);
                string tabsBefore = GetTabsBefore(element, keepFirstOnBaseLine);
                for (int i = 0; i < element.Attributes.Count; i++)
                {
                    HtmlAttribute attribute = element.Attributes[i];
                    if (keepFirstOnBaseLine && (i == 0))
                    {
                        newElement.AddAttribute(attribute.Name, attribute.Value, attribute.AttributeQuoteType);
                    }
                    else
                    {
                        newElement.AddAttribute(string.Format("\r\n{0}{1}", tabsBefore, attribute.Name), attribute.Value, attribute.AttributeQuoteType);
                    }
                }

                ////if (closeOnOwnLine && !newElement.IsEmptyTag)
                ////{
                ////    string s = CodeRush.Language.GenerateElement(newElement);
                ////    s = CodeRush.StrUtil.RemoveLastLineTerminator(s);
                ////    s += string.Format("\r\n{0}", tabsBefore);

                ////    ////var endLine = newElement.EndLine;
                ////    ////endLine += 1;
                ////    ////var endOffset = newElement.EndOffset;
                ////    ////var sr = new SourceRange(endLine, endOffset);
                ////    ////((XmlElement)newElement).SetBlockEnd(sr);

                ////    newElement = new HtmlElement()
                ////    {

                ////    };
                ////}

                Apply(_refactorFormatXamlAttributes.DisplayName, element, newElement, tabsBefore);
            }
        }

        void _refactorFormatXaml_PreparePreview(object sender, PrepareContentPreviewEventArgs ea)
        {
            if (_breakApartPreview != null)
            {
                _breakApartPreview.ShowPreview(ea);
            }
        }

        void _refactorFormatXaml_CheckAvailability(object sender, CheckContentAvailabilityEventArgs ea)
        {
            ea.Available = GetAvailability(ea.Element, ea.Selection, false, ea.TextView);
        }

        private XmlNode GetActiveNode(LanguageElement element)
        {
            if (element == null)
            {
                return null;
            }

            return element as XmlNode;
        }

        private bool GetAvailability(LanguageElement element, TextViewSelection selection, bool lineUp, TextView view)
        {
            HtmlElement activeHtmlElement = GetActiveHtmlElement(element, false);
            if ((activeHtmlElement == null) || !activeHtmlElement.HasAttributes)
            {
                return false;
            }

            SourcePoint start = activeHtmlElement.Range.Start;
            SourcePoint end = activeHtmlElement.Range.End;
            if (activeHtmlElement.HasCloseTag && !(activeHtmlElement is AspDirective))
            {
                end = activeHtmlElement.InnerRange.Start;
            }

            SourceRange signatureRange = new SourceRange(start, end);
            if (!selection.Exists && !signatureRange.Contains(CodeRush.Caret.SourcePoint))
            {
                return false;
            }

            if (((selection != null) && selection.Exists) && !IsValidSelection(activeHtmlElement, selection, signatureRange))
            {
                return false;
            }

            if ((element.HasErrors || HasErrorsInParent(element)) || HasErrorsInChildren(element))
            {
                return false;
            }

            return GetBreakApartAvailability(activeHtmlElement, Options.KeepFirstAttribute, view);
        }

        private bool IsValidSelection(LanguageElement element, TextViewSelection selection, SourceRange signatureRange)
        {
            if ((element == null) || (selection == null))
            {
                return false;
            }

            return (!selection.Exists || (element.Range.Equals(selection.Range) || ((element.Range.Start.Equals(selection.Range.End) && element.Range.End.Equals(selection.Range.Start)) || (signatureRange.Equals(selection.Range) || (signatureRange.Start.Equals(selection.Range.End) && signatureRange.End.Equals(selection.Range.Start))))));
        }

        private bool HasErrorsInParent(LanguageElement element)
        {
            for (LanguageElement element2 = element.Parent; element2 != null; element2 = element2.Parent)
            {
                if (element2.HasErrors)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasErrorsInChildren(LanguageElement element)
        {
            ElementEnumerable enumerable = new ElementEnumerable(element);

            foreach (var item in enumerable)
            {
                LanguageElement current = (LanguageElement)item;
                if (element.HasErrors)
                {
                    return true;
                }
            }

            return false;
        }

        private bool GetBreakApartAvailability(HtmlElement element, bool keepFirstOnBaseLine, TextView view)
        {
            if (((element == null) || !element.HasAttributes) || (element.Attributes.Count == 1))
            {
                return false;
            }

            if (_breakApartPreview == null)
            {
                _breakApartPreview = new PreviewRanges();
            }

            if (_breakApartPreview.PreviewShown)
            {
                return true;
            }

            _breakApartPreview.Clear(view);
            int startLine = element.StartLine;
            int num2 = 0;
            bool flag = false;

            if (keepFirstOnBaseLine)
            {
                if (startLine != element.Attributes[0].StartLine)
                {
                    _breakApartPreview.Add(element.Attributes[0].Range, true);
                    flag = true;
                }
                num2 = 1;
            }

            for (int i = num2; i < element.Attributes.Count; i++)
            {
                HtmlAttribute attribute = element.Attributes[i];
                if (attribute.StartLine == startLine)
                {
                    _breakApartPreview.Add(attribute.Range, false);
                    flag = true;
                }
            }

            return flag;
        }

        private HtmlElement GetActiveHtmlElement(LanguageElement element, bool sortAttr)
        {
            if (element != null)
            {
                HtmlElement element2 = element as HtmlElement;
                HtmlAttribute attribute = element as HtmlAttribute;
                if ((element2 != null) || (attribute != null))
                {
                    while ((element2 == null) && (element != null))
                    {
                        element = element.Parent;
                        element2 = element as HtmlElement;
                    }
                    if (element2 == null)
                    {
                        return null;
                    }
                    ////if (sortAttr)
                    ////{
                    ////    element2.Attributes.Sort(new AttrSorter());
                    ////}
                    return element2;
                }
            }
            return null;
        }

        private string GetTabsBefore(HtmlElement element, bool keepFirstOnBaseLine)
        {
            TextEditorLanguageSettings settings = CodeRush.VSSettings.TextEditor[CodeRush.Language.Active];
            if (settings == null)
            {
                return string.Empty;
            }

            int startOffset = element.StartOffset;
            string firstSpaces = GetFirstSpaces(element);
            short tabSize = settings.TabSize;
            if (Options.OverrideTabSettings)
            {
                tabSize = Options.TabSize;
            }

            if (keepFirstOnBaseLine)
            {
                int num3 = (element.NameRange.End.Offset - startOffset) + 1;
                int count = num3 / tabSize;
                string tabs = GetTabs(count);
                while ((tabs.Length * tabSize) < num3)
                {
                    tabs = tabs + " ";
                }
                firstSpaces = firstSpaces + tabs;
            }
            else
            {
                firstSpaces = firstSpaces + "\t";
            }

            if (!settings.InsertTabs)
            {
                firstSpaces = CodeRush.StrUtil.UntabifyLine(firstSpaces, tabSize);
            }

            return firstSpaces;
        }

        private string GetFirstSpaces(HtmlElement element)
        {
            TextDocument active = CodeRush.Documents.Active as TextDocument;
            if (active == null)
            {
                return string.Empty;
            }

            int startLine = element.StartLine;
            HtmlElement parent = element.Parent as HtmlElement;
            if (parent != null)
            {
                startLine = parent.StartLine;
            }

            string text = active.GetText(startLine);
            int length = 0;

            while ((text[length] == ' ') || (text[length] == '\t'))
            {
                length++;
            }

            string str2 = text.Substring(0, length);
            if (((parent != null) && !parent.IsEmptyTag) && parent.HasCloseTag)
            {
                str2 = str2 + "\t";
            }

            return str2;
        }

        private HtmlElement GetNewElement(HtmlElement original)
        {
            if (original == null)
            {
                return null;
            }

            HtmlElement element = new HtmlElement() 
            { 
                Name = original.Name,
                HasCloseTag = false,
                IsEmptyTag = original.IsEmptyTag 
            };

            if (original is AspDirective)
            {
                element = new AspDirective();
            }

            return element;
        }

        private string GetTabs(int count)
        {
            string str = string.Empty;
            for (int i = 0; i < count; i++)
            {
                str = str + "\t";
            }
            return str;
        }

        private void Apply(string displayName, HtmlElement original, HtmlElement newElement, string tabsBefore)
        {
            if ((!string.IsNullOrEmpty(displayName) && (original != null)) && (newElement != null))
            {
                int num = original.NameRange.End.Offset - original.StartOffset;
                SourceRange insertionRange = GetInsertionRange(original);
                string s = CodeRush.Language.GenerateElement(newElement);
                s = CodeRush.StrUtil.RemoveLastLineTerminator(s);
                if (Options.PutCloseTagOnOwnLine)
                {
                    var terminator = @"/>";
                    if(!s.EndsWith(terminator))
                    {
                        terminator = @">";
                    }

                    s = s.Substring(0, s.Length - terminator.Length);
                    s += string.Format("\r\n{0}{1}", tabsBefore, terminator);
                }
                insertionRange.BindToCode(CodeRush.Documents.Active as TextDocument);
                ICompoundAction action = CodeRush.TextBuffers.NewMultiFileCompoundAction(displayName, true);
                IMultiLidContainerGroup group = CodeRush.LinkedIdentifiers.OpenMultiLidContainerGroup();
                try
                {
                    FileChangeCollection changes = new FileChangeCollection();
                    changes.Add(new FileChange(original.FileNode.Name, insertionRange, s));
                    CodeRush.File.ApplyChanges(changes, false, true);
                    CodeRush.Caret.MoveTo(insertionRange.Start.Line, (int)(insertionRange.Start.Offset + num));
                }
                catch (Exception exception)
                {
                    LogBase<Log>.SendException(displayName, exception);
                }
                finally
                {
                    if (_breakApartPreview != null)
                    {
                        _breakApartPreview.Clear();
                        _breakApartPreview = null;
                    }

                    group.Close();
                    action.Close();
                    insertionRange.RemoveAllBindings();
                }
            }
        }


        private SourceRange GetInsertionRange(HtmlElement element)
        {
            if (element == null)
            {
                return SourceRange.Empty;
            }
            SourcePoint start = element.Range.Start;
            SourcePoint end = element.Range.End;
            if (element.HasCloseTag && !(element is AspDirective))
            {
                end = element.InnerRange.Start;
            }
            return new SourceRange(start, end);
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}