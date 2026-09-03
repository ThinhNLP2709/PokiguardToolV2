/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("97055CD4-512C-4264-8B5F-E3F446CEA6A5")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2WebResourceRequest // TypeDefIndex: 11138
	{
		// Properties
		[DispId(1610678272)]
		string Uri { get; set; } // 0x00000001813F7870-0x00000001813F78E0 0x00000001813F79C0-0x00000001813F7A10
		[DispId(1610678274)]
		string Method { get; set; } // 0x00000001813F7800-0x00000001813F7870 0x00000001813F7970-0x00000001813F79C0
		[DispId(1610678276)]
		IStream Content { get; set; } // 0x00000001813F76E0-0x00000001813F7770 0x00000001813F78E0-0x00000001813F7970
		[DispId(1610678278)]
		ICoreWebView2HttpRequestHeaders Headers { get; } // 0x00000001813F7770-0x00000001813F7800 
	}
}
