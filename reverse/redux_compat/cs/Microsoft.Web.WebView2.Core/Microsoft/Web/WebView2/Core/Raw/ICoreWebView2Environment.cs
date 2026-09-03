/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("B96D755E-0319-4E92-A296-23436F46A1FC")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Environment // TypeDefIndex: 10946
	{
		// Properties
		[DispId(1610678274)]
		string BrowserVersionString { get; } // 0x00000001813E9250-0x00000001813E92C0 
	
		// Methods
		void CreateCoreWebView2Controller(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler); // 0x00000001813E8FD0-0x00000001813E9070
		ICoreWebView2WebResourceResponse CreateWebResourceResponse(in IStream Content, in int StatusCode, in string ReasonPhrase, in string Headers); // 0x00000001813E9070-0x00000001813E91B0
		void add_NewBrowserVersionAvailable(in ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E91B0-0x00000001813E9250
		void remove_NewBrowserVersionAvailable(in EventRegistrationToken token); // 0x00000001813E92C0-0x00000001813E9300
	}
}
