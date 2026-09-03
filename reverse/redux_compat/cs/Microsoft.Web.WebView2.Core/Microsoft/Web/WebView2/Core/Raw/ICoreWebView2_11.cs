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
	[Guid("0BE78E56-C193-4051-B943-23B460C08BDB")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_11 : ICoreWebView2_10 // TypeDefIndex: 11151
	{
		// Methods
		void _VtblGap1_96();
		void CallDevToolsProtocolMethodForSession(in string sessionId, in string methodName, in string parametersAsJson, in ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler); // 0x00000001813F8B90-0x00000001813F8C70
		void add_ContextMenuRequested(in ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F8C70-0x00000001813F8D10
		void remove_ContextMenuRequested(in EventRegistrationToken token); // 0x00000001813F8D10-0x00000001813F8D50
	}
}
