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
	[Guid("B50D82CC-CC28-481D-9614-CB048895E6A0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Frame3 : ICoreWebView2Frame2 // TypeDefIndex: 10984
	{
		// Methods
		void _VtblGap1_21();
		void add_PermissionRequested(in ICoreWebView2FramePermissionRequestedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EA930-0x00000001813EA9D0
		void remove_PermissionRequested(in EventRegistrationToken token); // 0x00000001813EA9D0-0x00000001813EAA10
	}
}
