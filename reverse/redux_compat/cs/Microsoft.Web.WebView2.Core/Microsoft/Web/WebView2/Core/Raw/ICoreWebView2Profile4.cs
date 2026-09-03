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
	[Guid("8F4AE680-192E-4EC8-833A-21CFADAEF628")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Profile4 : ICoreWebView2Profile3 // TypeDefIndex: 11078
	{
		// Methods
		void _VtblGap1_12();
		void SetPermissionState(in COREWEBVIEW2_PERMISSION_KIND PermissionKind, in string origin, in COREWEBVIEW2_PERMISSION_STATE State, in ICoreWebView2SetPermissionStateCompletedHandler handler); // 0x00000001813F2980-0x00000001813F2A50
		void GetNonDefaultPermissionSettings(in ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler handler); // 0x00000001813F28F0-0x00000001813F2980
	}
}
