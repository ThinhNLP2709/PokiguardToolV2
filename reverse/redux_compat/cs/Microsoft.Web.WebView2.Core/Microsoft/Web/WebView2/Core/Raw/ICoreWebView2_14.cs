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
	[Guid("6DAA4F10-4A90-4753-8898-77C5DF534165")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_14 : ICoreWebView2_13 // TypeDefIndex: 11154
	{
		// Methods
		void _VtblGap1_103();
		void add_ServerCertificateErrorDetected(in ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F8FC0-0x00000001813F9060
		void remove_ServerCertificateErrorDetected(in EventRegistrationToken token); // 0x00000001813F9060-0x00000001813F90A0
		void ClearServerCertificateErrorActions(in ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler); // 0x00000001813F8F30-0x00000001813F8FC0
	}
}
