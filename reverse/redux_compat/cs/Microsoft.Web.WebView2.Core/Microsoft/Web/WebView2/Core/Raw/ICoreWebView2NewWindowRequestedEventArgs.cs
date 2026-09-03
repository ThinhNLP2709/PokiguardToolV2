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
	[Guid("34ACB11C-FC37-4418-9132-F9C21D1EAFB9")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2NewWindowRequestedEventArgs // TypeDefIndex: 11032
	{
		// Properties
		[DispId(1610678272)]
		string Uri { get; } // 0x00000001813EE0B0-0x00000001813EE120 
		[DispId(1610678273)]
		ICoreWebView2 NewWindow { get; set; } // 0x00000001813EDF90-0x00000001813EE020 0x00000001813EE160-0x00000001813EE1F0
		[DispId(1610678275)]
		int Handled { get; set; } // 0x00000001813EDEF0-0x00000001813EDF40 0x00000001813EE120-0x00000001813EE160
		[DispId(1610678277)]
		int IsUserInitiated { get; } // 0x00000001813EDF40-0x00000001813EDF90 
		[DispId(1610678279)]
		ICoreWebView2WindowFeatures WindowFeatures { get; } // 0x00000001813EE020-0x00000001813EE0B0 
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813EDE60-0x00000001813EDEF0
	}
}
