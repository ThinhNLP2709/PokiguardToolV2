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
	[Guid("FBF70C2F-EB1F-4383-85A0-163E92044011")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Profile8 : ICoreWebView2Profile7 // TypeDefIndex: 11082
	{
		// Methods
		void _VtblGap1_21();
		void Delete(); // 0x00000001813F2D50-0x00000001813F2D90
		void add_Deleted(in ICoreWebView2ProfileDeletedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F2D90-0x00000001813F2E30
		void remove_Deleted(in EventRegistrationToken token); // 0x00000001813F2E30-0x00000001813F2E70
	}
}
