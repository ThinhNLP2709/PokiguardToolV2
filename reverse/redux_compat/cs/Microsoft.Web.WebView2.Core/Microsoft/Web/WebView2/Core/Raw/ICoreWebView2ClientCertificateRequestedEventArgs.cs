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
	[Guid("BC59DB28-BCC3-11EB-8529-0242AC130003")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ClientCertificateRequestedEventArgs // TypeDefIndex: 10898
	{
		// Properties
		[DispId(1610678272)]
		string Host { get; } // 0x00000001813E21A0-0x00000001813E2210 
		[DispId(1610678273)]
		int Port { get; } // 0x00000001813E22F0-0x00000001813E2340 
		[DispId(1610678274)]
		int IsProxy { get; } // 0x00000001813E2210-0x00000001813E2260 
		[DispId(1610678275)]
		ICoreWebView2StringCollection AllowedCertificateAuthorities { get; } // 0x00000001813E2070-0x00000001813E2100 
		[DispId(1610678276)]
		ICoreWebView2ClientCertificateCollection MutuallyTrustedCertificates { get; } // 0x00000001813E2260-0x00000001813E22F0 
		[DispId(1610678277)]
		ICoreWebView2ClientCertificate SelectedCertificate { get; set; } // 0x00000001813E2340-0x00000001813E23D0 0x00000001813E2450-0x00000001813E24E0
		[DispId(1610678279)]
		int Cancel { get; set; } // 0x00000001813E2100-0x00000001813E2150 0x00000001813E23D0-0x00000001813E2410
		[DispId(1610678281)]
		int Handled { get; set; } // 0x00000001813E2150-0x00000001813E21A0 0x00000001813E2410-0x00000001813E2450
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813E1FE0-0x00000001813E2070
	}
}
