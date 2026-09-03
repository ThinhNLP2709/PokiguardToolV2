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
	[Guid("D60AC92C-37A6-4B26-A39E-95CFE59047BB")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2CustomSchemeRegistration // TypeDefIndex: 10928
	{
		// Properties
		[DispId(1610678272)]
		string SchemeName { get; } // 0x00000001813E6040-0x00000001813E60B0 
		[DispId(1610678273)]
		int TreatAsSecure { get; set; } // 0x00000001813E60B0-0x00000001813E6100 0x00000001813E6140-0x00000001813E6180
		[DispId(1610678277)]
		int HasAuthorityComponent { get; set; } // 0x00000001813E5FF0-0x00000001813E6040 0x00000001813E6100-0x00000001813E6140
	
		// Methods
		void GetAllowedOrigins(out uint allowedOriginsCount, out IntPtr allowedOrigins); // 0x00000001813E5F30-0x00000001813E5F80
		void SetAllowedOrigins(in uint allowedOriginsCount, in string allowedOrigins); // 0x00000001813E5F80-0x00000001813E5FF0
	}
}
