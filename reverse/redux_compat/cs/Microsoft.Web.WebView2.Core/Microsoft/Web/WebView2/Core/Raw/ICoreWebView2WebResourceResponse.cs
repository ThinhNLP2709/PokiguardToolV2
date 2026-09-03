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
	[Guid("AAFCC94F-FA27-48FD-97DF-830EF75AAEC9")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2WebResourceResponse // TypeDefIndex: 11142
	{
		// Properties
		[DispId(1610678272)]
		IStream Content { get; set; } // 0x00000001813F8290-0x00000001813F8320 0x00000001813F8470-0x00000001813F8500
		[DispId(1610678274)]
		ICoreWebView2HttpResponseHeaders Headers { get; } // 0x00000001813F8320-0x00000001813F83B0 
		[DispId(1610678275)]
		int StatusCode { get; set; } // 0x00000001813F8420-0x00000001813F8470 0x00000001813F8550-0x00000001813F8590
		[DispId(1610678277)]
		string ReasonPhrase { get; set; } // 0x00000001813F83B0-0x00000001813F8420 0x00000001813F8500-0x00000001813F8550
	}
}
