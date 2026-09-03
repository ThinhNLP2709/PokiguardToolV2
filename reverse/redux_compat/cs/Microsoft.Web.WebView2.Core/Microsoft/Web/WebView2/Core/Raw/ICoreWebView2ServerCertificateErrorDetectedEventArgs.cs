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
	[Guid("012193ED-7C13-48FF-969D-A84C1F432A14")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ServerCertificateErrorDetectedEventArgs // TypeDefIndex: 11098
	{
		// Properties
		[DispId(1610678272)]
		COREWEBVIEW2_WEB_ERROR_STATUS ErrorStatus { get; } // 0x00000001813F49C0-0x00000001813F4A10 
		[DispId(1610678273)]
		string RequestUri { get; } // 0x00000001813F4A10-0x00000001813F4A80 
		[DispId(1610678274)]
		ICoreWebView2Certificate ServerCertificate { get; } // 0x00000001813F4A80-0x00000001813F4B10 
		[DispId(1610678275)]
		COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION Action { get; set; } // 0x00000001813F4970-0x00000001813F49C0 0x00000001813F4B10-0x00000001813F4B50
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813F48E0-0x00000001813F4970
	}
}
