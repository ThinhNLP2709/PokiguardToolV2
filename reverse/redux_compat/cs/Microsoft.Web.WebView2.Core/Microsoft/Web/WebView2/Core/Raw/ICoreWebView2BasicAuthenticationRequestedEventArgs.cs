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
	[Guid("EF05516F-D897-4F9E-B672-D8E2307A3FB0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2BasicAuthenticationRequestedEventArgs // TypeDefIndex: 10881
	{
		// Properties
		[DispId(1610678272)]
		string Uri { get; } // 0x00000001813E10E0-0x00000001813E1150 
		[DispId(1610678273)]
		string Challenge { get; } // 0x00000001813E0FE0-0x00000001813E1050 
		[DispId(1610678274)]
		ICoreWebView2BasicAuthenticationResponse Response { get; } // 0x00000001813E1050-0x00000001813E10E0 
		[DispId(1610678275)]
		int Cancel { get; set; } // 0x00000001813E0F90-0x00000001813E0FE0 0x00000001813E1150-0x00000001813E1190
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813E0F00-0x00000001813E0F90
	}
}
