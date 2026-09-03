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
	[Guid("7A626017-28BE-49B2-B865-3BA2B3522D90")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_18 : ICoreWebView2_17 // TypeDefIndex: 11158
	{
		// Methods
		void _VtblGap1_114();
		void add_LaunchingExternalUriScheme(in ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F95A0-0x00000001813F9640
		void remove_LaunchingExternalUriScheme(in EventRegistrationToken token); // 0x00000001813F9640-0x00000001813F9680
	}
}
