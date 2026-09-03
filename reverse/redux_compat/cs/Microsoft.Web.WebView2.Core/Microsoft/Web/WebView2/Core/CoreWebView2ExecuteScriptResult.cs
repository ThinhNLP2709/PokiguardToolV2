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
	public class CoreWebView2ExecuteScriptResult // TypeDefIndex: 10553
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ExecuteScriptResult _nativeICoreWebView2ExecuteScriptResultValue; // 0x18
	
		// Properties
		internal ICoreWebView2ExecuteScriptResult _nativeICoreWebView2ExecuteScriptResult { get; set; } // 0x00000001813A16B0-0x00000001813A17C0 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2ScriptException Exception { get; } // 0x00000001813A1230-0x00000001813A13F0 
		public string ResultAsJson { get; } // 0x00000001813A13F0-0x00000001813A1550 
		public bool Succeeded { get; } // 0x00000001813A1550-0x00000001813A16B0 
	
		// Constructors
		internal CoreWebView2ExecuteScriptResult(object rawCoreWebView2ExecuteScriptResult); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public void TryGetResultAsString(out string stringResult, out int value); // 0x00000001813A1040-0x00000001813A1230
	}
}
