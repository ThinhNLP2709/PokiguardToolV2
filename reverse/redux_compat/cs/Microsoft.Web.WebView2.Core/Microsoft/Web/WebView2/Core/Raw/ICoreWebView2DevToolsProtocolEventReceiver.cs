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
	[Guid("B32CA51A-8371-45E9-9317-AF021D080367")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2DevToolsProtocolEventReceiver // TypeDefIndex: 10941
	{
		// Methods
		void add_DevToolsProtocolEventReceived(in ICoreWebView2DevToolsProtocolEventReceivedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E6DB0-0x00000001813E6E50
		void remove_DevToolsProtocolEventReceived(in EventRegistrationToken token); // 0x00000001813E6E50-0x00000001813E6E90
	}
}
