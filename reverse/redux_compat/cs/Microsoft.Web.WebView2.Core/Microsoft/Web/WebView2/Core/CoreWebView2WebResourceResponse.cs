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
	public class CoreWebView2WebResourceResponse // TypeDefIndex: 10623
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2WebResourceResponse _nativeICoreWebView2WebResourceResponseValue; // 0x18
	
		// Properties
		internal ICoreWebView2WebResourceResponse _nativeICoreWebView2WebResourceResponse { get; set; } // 0x00000001813D9190-0x00000001813D92A0 0x00000001802FAF70-0x00000001802FAF80
		public Stream Content { get; set; } // 0x00000001813D8BA0-0x00000001813D8D10 0x00000001813D92A0-0x00000001813D9450
		public CoreWebView2HttpResponseHeaders Headers { get; } // 0x00000001813D8D10-0x00000001813D8ED0 
		public string ReasonPhrase { get; set; } // 0x00000001813D8ED0-0x00000001813D9030 0x00000001813D9450-0x00000001813D95C0
		public int StatusCode { get; set; } // 0x00000001813D9030-0x00000001813D9190 0x00000001813D95C0-0x00000001813D9730
	
		// Constructors
		internal CoreWebView2WebResourceResponse(object rawCoreWebView2WebResourceResponse); // 0x00000001803855F0-0x0000000180385630
	}
}
