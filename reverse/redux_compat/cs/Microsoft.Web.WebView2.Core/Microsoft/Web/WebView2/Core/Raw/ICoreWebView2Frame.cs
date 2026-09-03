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
	[Guid("F1131A5E-9BA9-11EB-A8B3-0242AC130003")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Frame // TypeDefIndex: 10982
	{
		// Properties
		[DispId(1610678272)]
		string Name { get; } // 0x00000001813EC150-0x00000001813EC1C0 
	
		// Methods
		void add_NameChanged(in ICoreWebView2FrameNameChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EC0B0-0x00000001813EC150
		void remove_NameChanged(in EventRegistrationToken token); // 0x00000001813EC200-0x00000001813EC240
		void AddHostObjectToScriptWithOrigins(in string name, in object @object, in uint originsCount, in string[] origins); // 0x00000001813EBE30-0x00000001813EBF70
		void RemoveHostObjectFromScript(in string name); // 0x00000001813EBFC0-0x00000001813EC010
		void add_Destroyed(in ICoreWebView2FrameDestroyedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EC010-0x00000001813EC0B0
		void remove_Destroyed(in EventRegistrationToken token); // 0x00000001813EC1C0-0x00000001813EC200
		int IsDestroyed(); // 0x00000001813EBF70-0x00000001813EBFC0
	}
}
