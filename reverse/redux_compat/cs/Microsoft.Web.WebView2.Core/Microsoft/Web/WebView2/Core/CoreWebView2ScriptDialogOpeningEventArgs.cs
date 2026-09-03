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
	public class CoreWebView2ScriptDialogOpeningEventArgs : EventArgs // TypeDefIndex: 10602
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ScriptDialogOpeningEventArgs _nativeICoreWebView2ScriptDialogOpeningEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2ScriptDialogOpeningEventArgs _nativeICoreWebView2ScriptDialogOpeningEventArgs { get; set; } // 0x00000001813CBE70-0x00000001813CBF80 0x00000001802FAF70-0x00000001802FAF80
		public string DefaultText { get; } // 0x00000001813CB790-0x00000001813CB8F0 
		public CoreWebView2ScriptDialogKind Kind { get; } // 0x00000001813CB8F0-0x00000001813CBA50 
		public string Message { get; } // 0x00000001813CBA50-0x00000001813CBBB0 
		public string ResultText { get; set; } // 0x00000001813CBBB0-0x00000001813CBD10 0x00000001813CBF80-0x00000001813CC0F0
		public string Uri { get; } // 0x00000001813CBD10-0x00000001813CBE70 
	
		// Constructors
		internal CoreWebView2ScriptDialogOpeningEventArgs(object rawCoreWebView2ScriptDialogOpeningEventArgs); // 0x00000001813CB720-0x00000001813CB790
	
		// Methods
		public void Accept(); // 0x00000001813CB420-0x00000001813CB590
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813CB590-0x00000001813CB720
	}
}
