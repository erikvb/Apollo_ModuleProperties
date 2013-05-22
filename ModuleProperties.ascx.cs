#region Copyright
// 
// Copyright (c) 2013
// by Erik van Balleogij / erik.vanballegoij@gmail.com
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion
#region Usings

using System;
using System.Web.UI;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Professional.HtmlPro;
using DotNetNuke.UI.Skins;

#endregion

namespace DesktopModules.Apollo.ModuleProperties
{

    public partial class ModuleProperties : SkinObjectBase
    {
        public string CssClass { get; set; }
        public string FormatString { get; set; }
        public string DateFormat { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            lblModuleProperties.CssClass = CssClass;
            if (ModuleControl != null && ModuleControl.ModuleContext.ModuleId > Null.NullInteger)
            {
                switch (ModuleControl.ModuleContext.Configuration.DesktopModule.ModuleName)
                {
                    case "DNN_HTML":
                        var workflowId = new HtmlTextController().GetWorkflow(ModuleControl.ModuleContext.ModuleId, ModuleControl.ModuleContext.TabId, ModuleControl.ModuleContext.PortalId).Value;

                        var htmlTextInfo = new HtmlTextController().GetTopHtmlText(ModuleControl.ModuleContext.ModuleId, true,
                            workflowId);
                        string formatString = string.IsNullOrEmpty(FormatString) ? "{0}" : FormatString;
                        string dateFormat = string.IsNullOrEmpty(DateFormat) ? "F" : DateFormat;

                        lblModuleProperties.Text = string.Format(formatString, htmlTextInfo.LastModifiedOnDate.ToString(dateFormat));
                        break;
                    default:
                        // do nothing
                        break;
                }
            }


        }
    }
}