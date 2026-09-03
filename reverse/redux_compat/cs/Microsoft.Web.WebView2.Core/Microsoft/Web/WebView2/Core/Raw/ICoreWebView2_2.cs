/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("9E8F0CF8-E670-4B5E-B2BC-73E061E3184C")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_2 : ICoreWebView2 // TypeDefIndex: 11160
	{
		// Properties
		[DispId(1610743813)]
		ICoreWebView2CookieManager CookieManager { get; } // 0x00000001813FA110-0x00000001813FA1A0 
		[DispId(1610743814)]
		ICoreWebView2Environment Environment { get; } // 0x00000001813FA1A0-0x00000001813FA230 
	
		// Methods
		void _VtblGap1_58();
		void add_WebResourceResponseReceived(in ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FA070-0x00000001813FA110
		void remove_WebResourceResponseReceived(in EventRegistrationToken token); // 0x00000001813FA270-0x00000001813FA2B0
		void NavigateWithWebResourceRequest(in ICoreWebView2WebResourceRequest Request); // 0x00000001813F9F40-0x00000001813F9FD0
		void add_DOMContentLoaded(in ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F9FD0-0x00000001813FA070
		void remove_DOMContentLoaded(in EventRegistrationToken token); // 0x00000001813FA230-0x00000001813FA270
	}
}
