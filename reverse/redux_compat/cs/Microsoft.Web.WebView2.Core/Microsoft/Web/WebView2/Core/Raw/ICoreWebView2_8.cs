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
	[Guid("E9632730-6E1E-43AB-B7B8-7B2C9E62E094")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_8 : ICoreWebView2_7 // TypeDefIndex: 11176
	{
		// Properties
		[DispId(1611137026)]
		int IsMuted { get; set; } // 0x00000001813FAA10-0x00000001813FAA60 0x00000001813FAAE0-0x00000001813FAB20
		[DispId(1611137030)]
		int IsDocumentPlayingAudio { get; } // 0x00000001813FA9C0-0x00000001813FAA10 
	
		// Methods
		void _VtblGap1_78();
		void add_IsMutedChanged(in ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FA920-0x00000001813FA9C0
		void remove_IsMutedChanged(in EventRegistrationToken token); // 0x00000001813FAAA0-0x00000001813FAAE0
		void add_IsDocumentPlayingAudioChanged(in ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FA880-0x00000001813FA920
		void remove_IsDocumentPlayingAudioChanged(in EventRegistrationToken token); // 0x00000001813FAA60-0x00000001813FAAA0
	}
}
