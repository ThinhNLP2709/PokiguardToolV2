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
	[Guid("EE0EB9DF-6F12-46CE-B53F-3F47B9C928E0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Environment10 : ICoreWebView2Environment9 // TypeDefIndex: 10947
	{
		// Methods
		void _VtblGap1_17();
		ICoreWebView2ControllerOptions CreateCoreWebView2ControllerOptions(); // 0x00000001813E7BC0-0x00000001813E7C50
		void CreateCoreWebView2ControllerWithOptions(in IntPtr ParentWindow, in ICoreWebView2ControllerOptions options, in ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler); // 0x00000001813E7C50-0x00000001813E7D60
		void CreateCoreWebView2CompositionControllerWithOptions(in IntPtr ParentWindow, in ICoreWebView2ControllerOptions options, in ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler); // 0x00000001813E7AB0-0x00000001813E7BC0
	}
}
