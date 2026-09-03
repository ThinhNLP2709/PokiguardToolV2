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
	[Guid("56E473F1-E155-45E6-98F4-A1F80550A165")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2PrivateKeyPressedEventArgs // TypeDefIndex: 11059
	{
		// Properties
		[DispId(1610678272)]
		COREWEBVIEW2_KEY_EVENT_KIND KeyEventKind { get; } // 0x00000001813F17B0-0x00000001813F1800 
		[DispId(1610678273)]
		uint VirtualKey { get; } // 0x00000001813F18A0-0x00000001813F18F0 
		[DispId(1610678274)]
		int KeyEventLParam { get; } // 0x00000001813F1800-0x00000001813F1850 
		[DispId(1610678275)]
		COREWEBVIEW2_PHYSICAL_KEY_STATUS PhysicalKeyStatus { get; } // 0x00000001813F1850-0x00000001813F18A0 
		[DispId(1610678276)]
		int Handled { get; set; } // 0x00000001813F1760-0x00000001813F17B0 0x00000001813F18F0-0x00000001813F1930
	}
}
