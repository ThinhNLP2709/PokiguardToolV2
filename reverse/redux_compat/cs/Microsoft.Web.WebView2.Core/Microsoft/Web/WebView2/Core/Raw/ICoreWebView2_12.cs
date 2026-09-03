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
	[Guid("35D69927-BCFA-4566-9349-6B3E0D154CAC")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_12 : ICoreWebView2_11 // TypeDefIndex: 11152
	{
		// Properties
		[DispId(1611399170)]
		string StatusBarText { get; } // 0x00000001813F8DF0-0x00000001813F8E60 
	
		// Methods
		void _VtblGap1_99();
		void add_StatusBarTextChanged(in ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F8D50-0x00000001813F8DF0
		void remove_StatusBarTextChanged(in EventRegistrationToken token); // 0x00000001813F8E60-0x00000001813F8EA0
	}
}
