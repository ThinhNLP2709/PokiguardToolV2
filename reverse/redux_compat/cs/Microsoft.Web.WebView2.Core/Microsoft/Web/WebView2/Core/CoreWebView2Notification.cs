/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2Notification // TypeDefIndex: 10573
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Notification _nativeICoreWebView2NotificationValue; // 0x18
		private EventRegistrationToken _CloseRequestedToken; // 0x20
		private EventHandler<object> privateCloseRequested; // 0x28
	
		// Properties
		internal ICoreWebView2Notification _nativeICoreWebView2Notification { get; set; } // 0x00000001813B45E0-0x00000001813B46F0 0x00000001802FAF70-0x00000001802FAF80
		public string BadgeUri { get; } // 0x00000001813B3390-0x00000001813B34F0 
		public string Body { get; } // 0x00000001813B3650-0x00000001813B37B0 
		public string BodyImageUri { get; } // 0x00000001813B34F0-0x00000001813B3650 
		public CoreWebView2TextDirectionKind Direction { get; } // 0x00000001813B37B0-0x00000001813B3910 
		public string IconUri { get; } // 0x00000001813B3910-0x00000001813B3A70 
		public bool IsSilent { get; } // 0x00000001813B3A70-0x00000001813B3BD0 
		public string Language { get; } // 0x00000001813B3BD0-0x00000001813B3D30 
		public bool RequiresInteraction { get; } // 0x00000001813B3D30-0x00000001813B3E90 
		public bool ShouldRenotify { get; } // 0x00000001813B3E90-0x00000001813B3FF0 
		public string Tag { get; } // 0x00000001813B3FF0-0x00000001813B4150 
		public string Title { get; } // 0x00000001813B4200-0x00000001813B4360 
		public DateTime Timestamp { get; } // 0x00000001813B4150-0x00000001813B4200 
		public IReadOnlyList<ulong> VibrationPattern { get; } // 0x00000001813B4360-0x00000001813B45E0 
	
		// Events
		public event EventHandler<object> CloseRequested {
			add; // 0x00000001813B3100-0x00000001813B3390
			remove; // 0x00000001813B46F0-0x00000001813B48F0
		}
	
		// Constructors
		internal CoreWebView2Notification(object rawCoreWebView2Notification); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnCloseRequested(object args); // 0x000000018136EED0-0x000000018136EEF0
		public void ReportShown(); // 0x00000001813B2F90-0x00000001813B3100
		public void ReportClicked(); // 0x00000001813B2CB0-0x00000001813B2E20
		public void ReportClosed(); // 0x00000001813B2E20-0x00000001813B2F90
	}
}
