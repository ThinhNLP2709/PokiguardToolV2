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
	public class CoreWebView2HttpHeadersCollectionIterator : IEnumerator<KeyValuePair<string, string>> // TypeDefIndex: 10564
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2HttpHeadersCollectionIterator _nativeICoreWebView2HttpHeadersCollectionIteratorValue; // 0x18
		private bool isInitialized; // 0x20
	
		// Properties
		internal ICoreWebView2HttpHeadersCollectionIterator _nativeICoreWebView2HttpHeadersCollectionIterator { get; set; } // 0x00000001813ACFC0-0x00000001813AD0D0 0x00000001802FAF70-0x00000001802FAF80
		public bool HasCurrentHeader { get; } // 0x00000001813ACE60-0x00000001813ACFC0 
		object IEnumerator.Current { get; } // 0x00000001813ACD50-0x00000001813ACDB0 
		public KeyValuePair<string, string> Current { get; } // 0x00000001813ACDB0-0x00000001813ACE60 
	
		// Constructors
		internal CoreWebView2HttpHeadersCollectionIterator(object rawCoreWebView2HttpHeadersCollectionIterator); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public bool MoveNext(); // 0x00000001813ACCA0-0x00000001813ACD10
		public void Reset(); // 0x00000001813ACD10-0x00000001813ACD50
		public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		private void GetCurrentHeader(out string name, out string value); // 0x00000001813ACAC0-0x00000001813ACCA0
	}
}
