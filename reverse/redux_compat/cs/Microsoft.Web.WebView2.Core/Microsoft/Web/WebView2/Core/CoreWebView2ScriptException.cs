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
	public class CoreWebView2ScriptException // TypeDefIndex: 10603
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ScriptException _nativeICoreWebView2ScriptExceptionValue; // 0x18
	
		// Properties
		internal ICoreWebView2ScriptException _nativeICoreWebView2ScriptException { get; set; } // 0x00000001813CC890-0x00000001813CC9A0 0x00000001802FAF70-0x00000001802FAF80
		public uint ColumnNumber { get; } // 0x00000001813CC1B0-0x00000001813CC310 
		public uint LineNumber { get; } // 0x00000001813CC310-0x00000001813CC470 
		public string Message { get; } // 0x00000001813CC470-0x00000001813CC5D0 
		public string Name { get; } // 0x00000001813CC5D0-0x00000001813CC730 
		public string ToJson { get; } // 0x00000001813CC730-0x00000001813CC890 
	
		// Constructors
		internal CoreWebView2ScriptException(object rawCoreWebView2ScriptException); // 0x00000001803855F0-0x0000000180385630
	}
}
