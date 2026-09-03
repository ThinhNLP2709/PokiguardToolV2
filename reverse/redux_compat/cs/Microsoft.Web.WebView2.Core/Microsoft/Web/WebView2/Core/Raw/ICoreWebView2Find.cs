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
	[Guid("A3EC0F5F-DDBC-54ED-8546-AF75A785B9A6")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Find // TypeDefIndex: 10976
	{
		// Properties
		[DispId(1610678272)]
		int ActiveMatchIndex { get; } // 0x00000001813EA150-0x00000001813EA1A0 
		[DispId(1610678273)]
		int MatchCount { get; } // 0x00000001813EA1A0-0x00000001813EA1F0 
	
		// Methods
		void add_ActiveMatchIndexChanged(in ICoreWebView2FindActiveMatchIndexChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EA010-0x00000001813EA0B0
		void remove_ActiveMatchIndexChanged(in EventRegistrationToken token); // 0x00000001813EA1F0-0x00000001813EA230
		void add_MatchCountChanged(in ICoreWebView2FindMatchCountChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EA0B0-0x00000001813EA150
		void remove_MatchCountChanged(in EventRegistrationToken token); // 0x00000001813EA230-0x00000001813EA270
		void Start(in ICoreWebView2FindOptions options, in ICoreWebView2FindStartCompletedHandler handler); // 0x00000001813E9EE0-0x00000001813E9FE0
		void FindNext(); // 0x00000001813E9E80-0x00000001813E9EB0
		void FindPrevious(); // 0x00000001813E9EB0-0x00000001813E9EE0
		void Stop(); // 0x00000001813E9FE0-0x00000001813EA010
	}
}
