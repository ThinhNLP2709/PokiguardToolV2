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
	[Guid("AC52D13F-0D38-475A-9DCA-876580D6793E")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2EnvironmentOptions4 // TypeDefIndex: 10964
	{
		// Methods
		void GetCustomSchemeRegistrations(out uint Count, out IntPtr schemeRegistrations); // 0x00000001813E8940-0x00000001813E8990
		void SetCustomSchemeRegistrations(in uint Count, in ICoreWebView2CustomSchemeRegistration schemeRegistrations); // 0x00000001813E8990-0x00000001813E8A30
	}
}
