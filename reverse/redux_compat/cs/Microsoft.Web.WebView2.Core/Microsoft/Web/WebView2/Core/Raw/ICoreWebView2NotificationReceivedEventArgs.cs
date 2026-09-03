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
	[Guid("1512DD5B-5514-4F85-886E-21C3A4C9CFE6")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2NotificationReceivedEventArgs // TypeDefIndex: 11040
	{
		// Properties
		[DispId(1610678272)]
		string SenderOrigin { get; } // 0x00000001813EE6B0-0x00000001813EE720 
		[DispId(1610678273)]
		ICoreWebView2Notification Notification { get; } // 0x00000001813EE620-0x00000001813EE6B0 
		[DispId(1610678274)]
		int Handled { get; set; } // 0x00000001813EE5D0-0x00000001813EE620 0x00000001813EE720-0x00000001813EE760
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813EE540-0x00000001813EE5D0
	}
}
