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
	[Guid("9F760F8A-FB79-42BE-9990-7B56900FA9C7")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2AcceleratorKeyPressedEventArgs // TypeDefIndex: 10877
	{
		// Properties
		[DispId(1610678272)]
		COREWEBVIEW2_KEY_EVENT_KIND KeyEventKind { get; } // 0x00000001813E0C30-0x00000001813E0C80 
		[DispId(1610678273)]
		uint VirtualKey { get; } // 0x00000001813E0D20-0x00000001813E0D70 
		[DispId(1610678274)]
		int KeyEventLParam { get; } // 0x00000001813E0C80-0x00000001813E0CD0 
		[DispId(1610678275)]
		COREWEBVIEW2_PHYSICAL_KEY_STATUS PhysicalKeyStatus { get; } // 0x00000001813E0CD0-0x00000001813E0D20 
		[DispId(1610678276)]
		int Handled { get; set; } // 0x00000001813E0BE0-0x00000001813E0C30 0x00000001813E0D70-0x00000001813E0DB0
	}
}
