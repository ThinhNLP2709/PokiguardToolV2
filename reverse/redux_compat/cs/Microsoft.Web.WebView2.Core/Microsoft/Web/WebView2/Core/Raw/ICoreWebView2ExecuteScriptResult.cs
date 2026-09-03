/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("0CE15963-3698-4DF7-9399-71ED6CDD8C9F")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ExecuteScriptResult // TypeDefIndex: 10971
	{
		// Properties
		[DispId(1610678272)]
		int Succeeded { get; } // 0x00000001813E95D0-0x00000001813E9620 
		[DispId(1610678273)]
		string ResultAsJson { get; } // 0x00000001813E9560-0x00000001813E95D0 
		[DispId(1610678275)]
		ICoreWebView2ScriptException Exception { get; } // 0x00000001813E94D0-0x00000001813E9560 
	
		// Methods
		void TryGetResultAsString(out string stringResult, out int value); // 0x00000001813E9450-0x00000001813E94D0
	}
}
