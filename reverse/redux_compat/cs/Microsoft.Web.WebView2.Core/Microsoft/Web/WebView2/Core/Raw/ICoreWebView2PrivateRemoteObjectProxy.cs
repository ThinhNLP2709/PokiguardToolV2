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
	[Guid("EFA2DF69-9CA4-40DB-A13A-EAF67A441314")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2PrivateRemoteObjectProxy // TypeDefIndex: 11064
	{
		// Methods
		int GetId(); // 0x00000001813F1D40-0x00000001813F1D90
		void add_Passivated(in ICoreWebView2PrivateRemoteObjectProxyPassivatedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F1D90-0x00000001813F1E30
		void remove_Passivated(in EventRegistrationToken token); // 0x00000001813F1E30-0x00000001813F1E70
	}
}
