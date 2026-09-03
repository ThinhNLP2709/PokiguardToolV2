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
	[Guid("517B2D1D-7DAE-4A66-A4F4-10352FFB9518")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_15 : ICoreWebView2_14 // TypeDefIndex: 11155
	{
		// Properties
		[DispId(1611595778)]
		string FaviconUri { get; } // 0x00000001813F91E0-0x00000001813F9250 
	
		// Methods
		void _VtblGap1_106();
		void add_FaviconChanged(in ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F9140-0x00000001813F91E0
		void remove_FaviconChanged(in EventRegistrationToken token); // 0x00000001813F9250-0x00000001813F9290
		void GetFavicon(in COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, in ICoreWebView2GetFaviconCompletedHandler completedHandler); // 0x00000001813F90A0-0x00000001813F9140
	}
}
