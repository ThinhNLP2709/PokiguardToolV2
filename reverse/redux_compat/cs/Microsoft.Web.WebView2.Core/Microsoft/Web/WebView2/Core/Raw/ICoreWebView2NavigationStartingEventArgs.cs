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
	[Guid("5B495469-E119-438A-9B18-7604F25F2E49")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2NavigationStartingEventArgs // TypeDefIndex: 11027
	{
		// Properties
		[DispId(1610678272)]
		string Uri { get; } // 0x00000001813EDAB0-0x00000001813EDB20 
		[DispId(1610678273)]
		int IsUserInitiated { get; } // 0x00000001813ED980-0x00000001813ED9D0 
		[DispId(1610678274)]
		int IsRedirected { get; } // 0x00000001813ED930-0x00000001813ED980 
		[DispId(1610678275)]
		ICoreWebView2HttpRequestHeaders RequestHeaders { get; } // 0x00000001813EDA20-0x00000001813EDAB0 
		[DispId(1610678276)]
		int Cancel { get; set; } // 0x00000001813ED8E0-0x00000001813ED930 0x00000001813EDB20-0x00000001813EDB60
		[DispId(1610678278)]
		ulong NavigationId { get; } // 0x00000001813ED9D0-0x00000001813EDA20 
	}
}
