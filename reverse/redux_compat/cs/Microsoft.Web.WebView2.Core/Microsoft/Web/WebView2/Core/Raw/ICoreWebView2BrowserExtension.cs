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
	[Guid("7EF7FFA0-FAC5-462C-B189-3D9EDBE575DA")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2BrowserExtension // TypeDefIndex: 10884
	{
		// Properties
		[DispId(1610678272)]
		string Id { get; } // 0x00000001813E1700-0x00000001813E1770 
		[DispId(1610678273)]
		string Name { get; } // 0x00000001813E1770-0x00000001813E17E0 
		[DispId(1610678275)]
		int IsEnabled { get; } // 0x00000001813E16B0-0x00000001813E1700 
	
		// Methods
		void Remove(in ICoreWebView2BrowserExtensionRemoveCompletedHandler handler); // 0x00000001813E1620-0x00000001813E16B0
		void Enable(in int IsEnabled, in ICoreWebView2BrowserExtensionEnableCompletedHandler handler); // 0x00000001813E1580-0x00000001813E1620
	}
}
