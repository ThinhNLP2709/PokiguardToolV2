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
	[Guid("B7434D98-6BC8-419D-9DA5-FB5A96D4DACD")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Notification // TypeDefIndex: 11038
	{
		// Properties
		[DispId(1610678277)]
		string Body { get; } // 0x00000001813EEAC0-0x00000001813EEB30 
		[DispId(1610678278)]
		COREWEBVIEW2_TEXT_DIRECTION_KIND Direction { get; } // 0x00000001813EEB30-0x00000001813EEB80 
		[DispId(1610678279)]
		string Language { get; } // 0x00000001813EEC40-0x00000001813EECB0 
		[DispId(1610678280)]
		string Tag { get; } // 0x00000001813EED50-0x00000001813EEDC0 
		[DispId(1610678281)]
		string IconUri { get; } // 0x00000001813EEB80-0x00000001813EEBF0 
		[DispId(1610678282)]
		string Title { get; } // 0x00000001813EEE10-0x00000001813EEE80 
		[DispId(1610678283)]
		string BadgeUri { get; } // 0x00000001813EE9E0-0x00000001813EEA50 
		[DispId(1610678284)]
		string BodyImageUri { get; } // 0x00000001813EEA50-0x00000001813EEAC0 
		[DispId(1610678285)]
		int ShouldRenotify { get; } // 0x00000001813EED00-0x00000001813EED50 
		[DispId(1610678286)]
		int RequiresInteraction { get; } // 0x00000001813EECB0-0x00000001813EED00 
		[DispId(1610678287)]
		int IsSilent { get; } // 0x00000001813EEBF0-0x00000001813EEC40 
		[DispId(1610678288)]
		double Timestamp { get; } // 0x00000001813EEDC0-0x00000001813EEE10 
	
		// Methods
		void add_CloseRequested(in ICoreWebView2NotificationCloseRequestedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EE940-0x00000001813EE9E0
		void remove_CloseRequested(in EventRegistrationToken token); // 0x00000001813EEE80-0x00000001813EEEC0
		void ReportShown(); // 0x00000001813EE910-0x00000001813EE940
		void ReportClicked(); // 0x00000001813EE8B0-0x00000001813EE8E0
		void ReportClosed(); // 0x00000001813EE8E0-0x00000001813EE910
		void GetVibrationPattern(out uint Count, out IntPtr vibrationPattern); // 0x00000001813EE860-0x00000001813EE8B0
	}
}
