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
	public class CoreWebView2SaveAsUIShowingEventArgs : EventArgs // TypeDefIndex: 10599
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2SaveAsUIShowingEventArgs _nativeICoreWebView2SaveAsUIShowingEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2SaveAsUIShowingEventArgs _nativeICoreWebView2SaveAsUIShowingEventArgs { get; set; } // 0x00000001813C94A0-0x00000001813C95B0 0x00000001802FAF70-0x00000001802FAF80
		public bool AllowReplace { get; set; } // 0x00000001813C8C60-0x00000001813C8DC0 0x00000001813C95B0-0x00000001813C9720
		public bool Cancel { get; set; } // 0x00000001813C8DC0-0x00000001813C8F20 0x00000001813C9720-0x00000001813C9890
		public string ContentMimeType { get; } // 0x00000001813C8F20-0x00000001813C9080 
		public CoreWebView2SaveAsKind Kind { get; set; } // 0x00000001813C9080-0x00000001813C91E0 0x00000001813C9890-0x00000001813C9A00
		public string SaveAsFilePath { get; set; } // 0x00000001813C91E0-0x00000001813C9340 0x00000001813C9A00-0x00000001813C9B70
		public bool SuppressDefaultDialog { get; set; } // 0x00000001813C9340-0x00000001813C94A0 0x00000001813C9B70-0x00000001813C9CE0
	
		// Constructors
		internal CoreWebView2SaveAsUIShowingEventArgs(object rawCoreWebView2SaveAsUIShowingEventArgs); // 0x00000001813C8BF0-0x00000001813C8C60
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813C8A60-0x00000001813C8BF0
	}
}
