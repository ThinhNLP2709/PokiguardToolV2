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
	[Guid("792B6ECA-5576-421C-9119-74EBB3A4FFB3")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2PermissionSetting // TypeDefIndex: 11047
	{
		// Properties
		[DispId(1610678272)]
		COREWEBVIEW2_PERMISSION_KIND PermissionKind { get; } // 0x00000001813EF4F0-0x00000001813EF540 
		[DispId(1610678273)]
		string PermissionOrigin { get; } // 0x00000001813EF540-0x00000001813EF5B0 
		[DispId(1610678274)]
		COREWEBVIEW2_PERMISSION_STATE PermissionState { get; } // 0x00000001813EF5B0-0x00000001813EF600 
	}
}
