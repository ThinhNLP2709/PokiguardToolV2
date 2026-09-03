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
	public class CoreWebView2HttpResponseHeaders : IEnumerable<KeyValuePair<string, string>> // TypeDefIndex: 10566
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2HttpResponseHeaders _nativeICoreWebView2HttpResponseHeadersValue; // 0x18
	
		// Properties
		internal ICoreWebView2HttpResponseHeaders _nativeICoreWebView2HttpResponseHeaders { get; set; } // 0x00000001813AE290-0x00000001813AE3A0 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		internal CoreWebView2HttpResponseHeaders(object rawCoreWebView2HttpResponseHeaders); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public void AppendHeader(string name, string value); // 0x00000001813ADAF0-0x00000001813ADC70
		public bool Contains(string name); // 0x00000001813ADC70-0x00000001813ADDE0
		public string GetHeader(string name); // 0x00000001813ADDF0-0x00000001813ADF50
		public CoreWebView2HttpHeadersCollectionIterator GetHeaders(string name); // 0x00000001813ADF50-0x00000001813AE0F0
		public CoreWebView2HttpHeadersCollectionIterator GetIterator(); // 0x00000001813AE0F0-0x00000001813AE290
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001813ADDE0-0x00000001813ADDF0
		IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator(); // 0x00000001813ADDE0-0x00000001813ADDF0
		public CoreWebView2HttpHeadersCollectionIterator GetEnumerator(); // 0x00000001813ADDE0-0x00000001813ADDF0
	}
}
