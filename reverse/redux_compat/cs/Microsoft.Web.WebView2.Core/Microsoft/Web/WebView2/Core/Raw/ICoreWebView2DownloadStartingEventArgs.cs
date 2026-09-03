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
	[Guid("E99BBE21-43E9-4544-A732-282764EAFA60")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2DownloadStartingEventArgs // TypeDefIndex: 10944
	{
		// Properties
		[DispId(1610678272)]
		ICoreWebView2DownloadOperation DownloadOperation { get; } // 0x00000001813E7790-0x00000001813E7820 
		[DispId(1610678273)]
		int Cancel { get; set; } // 0x00000001813E7740-0x00000001813E7790 0x00000001813E78E0-0x00000001813E7920
		[DispId(1610678275)]
		string ResultFilePath { get; set; } // 0x00000001813E7870-0x00000001813E78E0 0x00000001813E7960-0x00000001813E79B0
		[DispId(1610678277)]
		int Handled { get; set; } // 0x00000001813E7820-0x00000001813E7870 0x00000001813E7920-0x00000001813E7960
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813E76B0-0x00000001813E7740
	}
}
