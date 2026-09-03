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
	[Guid("79110AD3-CD5D-4373-8BC3-C60658F17A5F")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Profile // TypeDefIndex: 11075
	{
		// Properties
		[DispId(1610678272)]
		string ProfileName { get; } // 0x00000001813F3370-0x00000001813F33E0 
		[DispId(1610678273)]
		int IsInPrivateModeEnabled { get; } // 0x00000001813F32D0-0x00000001813F3320 
		[DispId(1610678274)]
		string ProfilePath { get; } // 0x00000001813F33E0-0x00000001813F3450 
		[DispId(1610678275)]
		string DefaultDownloadFolderPath { get; set; } // 0x00000001813F3260-0x00000001813F32D0 0x00000001813F3450-0x00000001813F34A0
		[DispId(1610678277)]
		COREWEBVIEW2_PREFERRED_COLOR_SCHEME PreferredColorScheme { get; set; } // 0x00000001813F3320-0x00000001813F3370 0x00000001813F34A0-0x00000001813F34E0
	}
}
