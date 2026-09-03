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
	[Guid("79701053-7759-4162-8F7D-F1B3F084928D")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2WebResourceResponseView // TypeDefIndex: 11145
	{
		// Properties
		[DispId(1610678272)]
		ICoreWebView2HttpResponseHeaders Headers { get; } // 0x00000001813F8140-0x00000001813F81D0 
		[DispId(1610678273)]
		int StatusCode { get; } // 0x00000001813F8240-0x00000001813F8290 
		[DispId(1610678274)]
		string ReasonPhrase { get; } // 0x00000001813F81D0-0x00000001813F8240 
	
		// Methods
		void GetContent(in ICoreWebView2WebResourceResponseViewGetContentCompletedHandler handler); // 0x00000001813F80B0-0x00000001813F8140
	}
}
