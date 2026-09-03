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
	[Guid("E7188076-BCC3-11EB-8529-0242AC130003")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ClientCertificate // TypeDefIndex: 10896
	{
		// Properties
		[DispId(1610678272)]
		string Subject { get; } // 0x00000001813E2880-0x00000001813E28F0 
		[DispId(1610678273)]
		string Issuer { get; } // 0x00000001813E2730-0x00000001813E27A0 
		[DispId(1610678274)]
		double ValidFrom { get; } // 0x00000001813E28F0-0x00000001813E2940 
		[DispId(1610678275)]
		double ValidTo { get; } // 0x00000001813E2940-0x00000001813E2990 
		[DispId(1610678276)]
		string DerEncodedSerialNumber { get; } // 0x00000001813E2650-0x00000001813E26C0 
		[DispId(1610678277)]
		string DisplayName { get; } // 0x00000001813E26C0-0x00000001813E2730 
		[DispId(1610678279)]
		ICoreWebView2StringCollection PemEncodedIssuerCertificateChain { get; } // 0x00000001813E27F0-0x00000001813E2880 
		[DispId(1610678280)]
		COREWEBVIEW2_CLIENT_CERTIFICATE_KIND Kind { get; } // 0x00000001813E27A0-0x00000001813E27F0 
	
		// Methods
		string ToPemEncoding(); // 0x00000001813E25E0-0x00000001813E2650
	}
}
