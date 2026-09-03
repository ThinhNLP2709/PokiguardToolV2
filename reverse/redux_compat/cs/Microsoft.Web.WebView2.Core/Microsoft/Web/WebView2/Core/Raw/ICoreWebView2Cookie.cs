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
	[Guid("AD26D6BE-1486-43E6-BF87-A2034006CA21")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Cookie // TypeDefIndex: 10920
	{
		// Properties
		[DispId(1610678272)]
		string Name { get; } // 0x00000001813E5920-0x00000001813E5990 
		[DispId(1610678273)]
		string Value { get; set; } // 0x00000001813E5990-0x00000001813E5A00 0x00000001813E5B00-0x00000001813E5B50
		[DispId(1610678275)]
		string Domain { get; } // 0x00000001813E56B0-0x00000001813E5720 
		[DispId(1610678276)]
		string Path { get; } // 0x00000001813E5860-0x00000001813E58D0 
		[DispId(1610678277)]
		double Expires { get; set; } // 0x00000001813E5720-0x00000001813E5770 0x00000001813E5A00-0x00000001813E5A40
		[DispId(1610678279)]
		int IsHttpOnly { get; set; } // 0x00000001813E5770-0x00000001813E57C0 0x00000001813E5A40-0x00000001813E5A80
		[DispId(1610678281)]
		COREWEBVIEW2_COOKIE_SAME_SITE_KIND SameSite { get; set; } // 0x00000001813E58D0-0x00000001813E5920 0x00000001813E5AC0-0x00000001813E5B00
		[DispId(1610678283)]
		int IsSecure { get; set; } // 0x00000001813E57C0-0x00000001813E5810 0x00000001813E5A80-0x00000001813E5AC0
		[DispId(1610678285)]
		int IsSession { get; } // 0x00000001813E5810-0x00000001813E5860 
	}
}
