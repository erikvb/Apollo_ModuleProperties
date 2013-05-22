Apollo ModuleProperties for DotNetNuke 7.x
==========================================

This Container SkinObject can display attributes modules. First fully supported module is the HTML module

Usage:

* install zip package as regular extension
* create a container file, and register the skinobject at the top of the page, like this:

    <%@ Register TagPrefix="Apollo" TagName="MODULEPROPERTIES" Src="~/DesktopModules/Apollo/ModuleProperties/ModuleProperties.ascx" %>
    
* use the skinobject in the container file, like this:

    <Apollo:MODULEPROPERTIES ID="ModuleProperties" runat="server" FormatString="Last modified on: {0}" DateFormat="F"/>
    
this will render as the following HTML:

    <span id="dnn_ctr485_ModuleProperties_lblModuleProperties">Last modified on: Wednesday, May 22, 2013 12:04:58 PM</span>
    
**Supported Attributes**
* CssClass: the CSS class to be used on the span that wraps the information
* FormatString: text format that allows you to put the actual modified date in context. In order for this to work, the format string needs to have exactly 1 parameter {0}
* DateFormat: the modification date can be formatted seperately. See here for valid formats: http://msdn.microsoft.com/en-us/library/az4se3k1.aspx

