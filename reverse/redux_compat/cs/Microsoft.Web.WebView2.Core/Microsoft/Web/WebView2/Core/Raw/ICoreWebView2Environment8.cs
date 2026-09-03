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
	[Guid("D6EB91DD-C3D2-45E5-BD29-6DC2BC4DE9CF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Environment8 : ICoreWebView2Environment7 // TypeDefIndex: 10959
	{
		// Methods
		void _VtblGap1_13();
		void add_ProcessInfosChanged(in ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E8600-0x00000001813E86A0
		void remove_ProcessInfosChanged(in EventRegistrationToken token); // 0x00000001813E86A0-0x00000001813E86E0
		ICoreWebView2ProcessInfoCollection GetProcessInfos(); // 0x00000001813E8570-0x00000001813E8600
	}
}
