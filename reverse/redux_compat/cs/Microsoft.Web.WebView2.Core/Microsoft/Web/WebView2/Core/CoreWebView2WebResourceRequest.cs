/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2WebResourceRequest // TypeDefIndex: 10621
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2WebResourceRequest _nativeICoreWebView2WebResourceRequestValue; // 0x18
	
		// Properties
		internal ICoreWebView2WebResourceRequest _nativeICoreWebView2WebResourceRequest { get; set; } // 0x00000001813D6DB0-0x00000001813D6EC0 0x00000001802FAF70-0x00000001802FAF80
		public Stream Content { get; set; } // 0x00000001813D67C0-0x00000001813D6930 0x00000001813D6EC0-0x00000001813D7070
		public CoreWebView2HttpRequestHeaders Headers { get; } // 0x00000001813D6930-0x00000001813D6AF0 
		public string Method { get; set; } // 0x00000001813D6AF0-0x00000001813D6C50 0x00000001813D7070-0x00000001813D71E0
		public string Uri { get; set; } // 0x00000001813D6C50-0x00000001813D6DB0 0x00000001813D71E0-0x00000001813D7350
	
		// Constructors
		internal CoreWebView2WebResourceRequest(object rawCoreWebView2WebResourceRequest); // 0x00000001803855F0-0x0000000180385630
	}
}
