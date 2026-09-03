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
	[Guid("30D68B7D-20D9-4752-A9CA-EC8448FBB5C1")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2NavigationCompletedEventArgs // TypeDefIndex: 11024
	{
		// Properties
		[DispId(1610678272)]
		int IsSuccess { get; } // 0x00000001813ED5E0-0x00000001813ED630 
		[DispId(1610678273)]
		COREWEBVIEW2_WEB_ERROR_STATUS WebErrorStatus { get; } // 0x00000001813ED680-0x00000001813ED6D0 
		[DispId(1610678274)]
		ulong NavigationId { get; } // 0x00000001813ED630-0x00000001813ED680 
	}
}
