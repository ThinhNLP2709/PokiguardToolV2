/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2HttpRequestHeaders : IEnumerable<KeyValuePair<string, string>> // TypeDefIndex: 10565
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2HttpRequestHeaders _nativeICoreWebView2HttpRequestHeadersValue; // 0x18
	
		// Properties
		internal ICoreWebView2HttpRequestHeaders _nativeICoreWebView2HttpRequestHeaders { get; set; } // 0x00000001813AD9E0-0x00000001813ADAF0 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		internal CoreWebView2HttpRequestHeaders(object rawCoreWebView2HttpRequestHeaders); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public string GetHeader(string name); // 0x00000001813AD250-0x00000001813AD3B0
		public CoreWebView2HttpHeadersCollectionIterator GetHeaders(string name); // 0x00000001813AD3B0-0x00000001813AD550
		public bool Contains(string name); // 0x00000001813AD0D0-0x00000001813AD240
		public void SetHeader(string name, string value); // 0x00000001813AD860-0x00000001813AD9E0
		public void RemoveHeader(string name); // 0x00000001813AD6F0-0x00000001813AD860
		public CoreWebView2HttpHeadersCollectionIterator GetIterator(); // 0x00000001813AD550-0x00000001813AD6F0
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001813AD240-0x00000001813AD250
		IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator(); // 0x00000001813AD240-0x00000001813AD250
		public CoreWebView2HttpHeadersCollectionIterator GetEnumerator(); // 0x00000001813AD240-0x00000001813AD250
	}
}
