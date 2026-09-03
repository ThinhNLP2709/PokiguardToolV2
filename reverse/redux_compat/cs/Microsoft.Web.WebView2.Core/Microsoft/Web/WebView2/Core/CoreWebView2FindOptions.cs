/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2FindOptions // TypeDefIndex: 10558
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2FindOptions _nativeICoreWebView2FindOptionsValue; // 0x18
	
		// Properties
		internal ICoreWebView2FindOptions _nativeICoreWebView2FindOptions { get; set; } // 0x00000001813A6B20-0x00000001813A6C30 0x00000001802FAF70-0x00000001802FAF80
		public string FindTerm { get; set; } // 0x00000001813A6440-0x00000001813A65A0 0x00000001813A6C30-0x00000001813A6DA0
		public bool IsCaseSensitive { get; set; } // 0x00000001813A65A0-0x00000001813A6700 0x00000001813A6DA0-0x00000001813A6F10
		public bool ShouldHighlightAllMatches { get; set; } // 0x00000001813A6700-0x00000001813A6860 0x00000001813A6F10-0x00000001813A7080
		public bool ShouldMatchWord { get; set; } // 0x00000001813A6860-0x00000001813A69C0 0x00000001813A7080-0x00000001813A71F0
		public bool SuppressDefaultFindDialog { get; set; } // 0x00000001813A69C0-0x00000001813A6B20 0x00000001813A71F0-0x00000001813A7360
	
		// Constructors
		internal CoreWebView2FindOptions(object rawCoreWebView2FindOptions); // 0x00000001803855F0-0x0000000180385630
	}
}
