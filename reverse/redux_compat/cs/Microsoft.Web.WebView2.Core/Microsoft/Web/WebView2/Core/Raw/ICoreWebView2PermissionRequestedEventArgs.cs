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
	[Guid("973AE2EF-FF18-4894-8FB2-3C758F046810")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2PermissionRequestedEventArgs // TypeDefIndex: 11043
	{
		// Properties
		[DispId(1610678272)]
		string Uri { get; } // 0x00000001813EF250-0x00000001813EF2C0 
		[DispId(1610678273)]
		COREWEBVIEW2_PERMISSION_KIND PermissionKind { get; } // 0x00000001813EF1B0-0x00000001813EF200 
		[DispId(1610678274)]
		int IsUserInitiated { get; } // 0x00000001813EF160-0x00000001813EF1B0 
		[DispId(1610678275)]
		COREWEBVIEW2_PERMISSION_STATE State { get; set; } // 0x00000001813EF200-0x00000001813EF250 0x00000001813EF2C0-0x00000001813EF300
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813EF0D0-0x00000001813EF160
	}
}
