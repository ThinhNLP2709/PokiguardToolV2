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
	[Guid("3598CFA2-D85D-5A9F-9228-4DDE1F59EC64")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Frame7 : ICoreWebView2Frame6 // TypeDefIndex: 10988
	{
		// Methods
		void _VtblGap1_27();
		void add_FrameCreated(in ICoreWebView2FrameChildFrameCreatedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EAC10-0x00000001813EACB0
		void remove_FrameCreated(in EventRegistrationToken token); // 0x00000001813EACB0-0x00000001813EACF0
	}
}
