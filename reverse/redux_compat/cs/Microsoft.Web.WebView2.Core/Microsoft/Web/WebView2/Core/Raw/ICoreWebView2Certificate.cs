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
	[Guid("C5FB2FCE-1CAC-4AEE-9C79-5ED0362EAAE0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Certificate // TypeDefIndex: 10893
	{
		// Properties
		[DispId(1610678272)]
		string Subject { get; } // 0x00000001813E1D60-0x00000001813E1DD0 
		[DispId(1610678273)]
		string Issuer { get; } // 0x00000001813E1C60-0x00000001813E1CD0 
		[DispId(1610678274)]
		double ValidFrom { get; } // 0x00000001813E1DD0-0x00000001813E1E20 
		[DispId(1610678275)]
		double ValidTo { get; } // 0x00000001813E1E20-0x00000001813E1E70 
		[DispId(1610678276)]
		string DerEncodedSerialNumber { get; } // 0x00000001813E1B80-0x00000001813E1BF0 
		[DispId(1610678277)]
		string DisplayName { get; } // 0x00000001813E1BF0-0x00000001813E1C60 
		[DispId(1610678279)]
		ICoreWebView2StringCollection PemEncodedIssuerCertificateChain { get; } // 0x00000001813E1CD0-0x00000001813E1D60 
	
		// Methods
		string ToPemEncoding(); // 0x00000001813E1B10-0x00000001813E1B80
	}
}
