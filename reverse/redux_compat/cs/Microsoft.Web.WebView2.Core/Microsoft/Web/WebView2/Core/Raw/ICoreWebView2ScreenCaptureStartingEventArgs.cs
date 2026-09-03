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
	[Guid("892C03FD-AEE3-5EBA-A1FA-6FD2F6484B2B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ScreenCaptureStartingEventArgs // TypeDefIndex: 11093
	{
		// Properties
		[DispId(1610678272)]
		int Cancel { get; set; } // 0x00000001813F4020-0x00000001813F4070 0x00000001813F4150-0x00000001813F4190
		[DispId(1610678274)]
		int Handled { get; set; } // 0x00000001813F4070-0x00000001813F40C0 0x00000001813F4190-0x00000001813F41D0
		[DispId(1610678276)]
		ICoreWebView2FrameInfo OriginalSourceFrameInfo { get; } // 0x00000001813F40C0-0x00000001813F4150 
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813F3F90-0x00000001813F4020
	}
}
