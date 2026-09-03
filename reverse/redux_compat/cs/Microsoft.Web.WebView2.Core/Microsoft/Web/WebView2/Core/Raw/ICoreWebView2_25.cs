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
	[Guid("B5A86092-DF50-5B4F-A17B-6C8F8B40B771")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_25 : ICoreWebView2_24 // TypeDefIndex: 11166
	{
		// Methods
		void _VtblGap1_125();
		void add_SaveAsUIShowing(in ICoreWebView2SaveAsUIShowingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F9B30-0x00000001813F9BD0
		void remove_SaveAsUIShowing(in EventRegistrationToken token); // 0x00000001813F9BD0-0x00000001813F9C10
		void ShowSaveAsUI(in ICoreWebView2ShowSaveAsUICompletedHandler handler); // 0x00000001813F9AA0-0x00000001813F9B30
	}
}
