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
	public class CoreWebView2SaveFileSecurityCheckStartingEventArgs : EventArgs // TypeDefIndex: 10600
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2SaveFileSecurityCheckStartingEventArgs _nativeICoreWebView2SaveFileSecurityCheckStartingEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2SaveFileSecurityCheckStartingEventArgs _nativeICoreWebView2SaveFileSecurityCheckStartingEventArgs { get; set; } // 0x00000001813CA5C0-0x00000001813CA6D0 0x00000001802FAF70-0x00000001802FAF80
		public bool CancelSave { get; set; } // 0x00000001813C9EE0-0x00000001813CA040 0x00000001813CA6D0-0x00000001813CA840
		public string DocumentOriginUri { get; } // 0x00000001813CA040-0x00000001813CA1A0 
		public string FileExtension { get; } // 0x00000001813CA1A0-0x00000001813CA300 
		public string FilePath { get; } // 0x00000001813CA300-0x00000001813CA460 
		public bool SuppressDefaultPolicy { get; set; } // 0x00000001813CA460-0x00000001813CA5C0 0x00000001813CA840-0x00000001813CA9B0
	
		// Constructors
		internal CoreWebView2SaveFileSecurityCheckStartingEventArgs(object rawCoreWebView2SaveFileSecurityCheckStartingEventArgs); // 0x00000001813C9E70-0x00000001813C9EE0
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813C9CE0-0x00000001813C9E70
	}
}
