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
	public class CoreWebView2EnvironmentOptions // TypeDefIndex: 10551
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2EnvironmentOptions _nativeICoreWebView2EnvironmentOptionsValue; // 0x18
		internal ICoreWebView2EnvironmentOptions2 _nativeICoreWebView2EnvironmentOptions2Value; // 0x20
		internal ICoreWebView2EnvironmentOptions3 _nativeICoreWebView2EnvironmentOptions3Value; // 0x28
		internal ICoreWebView2EnvironmentOptions4 _nativeICoreWebView2EnvironmentOptions4Value; // 0x30
		internal ICoreWebView2EnvironmentOptions5 _nativeICoreWebView2EnvironmentOptions5Value; // 0x38
		internal ICoreWebView2EnvironmentOptions6 _nativeICoreWebView2EnvironmentOptions6Value; // 0x40
		internal ICoreWebView2EnvironmentOptions8 _nativeICoreWebView2EnvironmentOptions8Value; // 0x48
		internal ICoreWebView2EnvironmentOptions7 _nativeICoreWebView2EnvironmentOptions7Value; // 0x50
		[CompilerGenerated]
		private readonly List<CoreWebView2CustomSchemeRegistration> _CustomSchemeRegistrations_k__BackingField; // 0x58
		private const CoreWebView2ReleaseChannels kAllChannelsFlag = CoreWebView2ReleaseChannels.None | CoreWebView2ReleaseChannels.Stable | CoreWebView2ReleaseChannels.Beta | CoreWebView2ReleaseChannels.Dev | CoreWebView2ReleaseChannels.Canary; // Metadata: 0x006A1501
	
		// Properties
		internal ICoreWebView2EnvironmentOptions _nativeICoreWebView2EnvironmentOptions { get; set; } // 0x000000018139A4F0-0x000000018139A600 0x00000001802FAF70-0x00000001802FAF80
		public string AdditionalBrowserArguments { get; set; } // 0x0000000181398E60-0x0000000181398FC0 0x000000018139A600-0x000000018139A770
		public bool AllowSingleSignOnUsingOSPrimaryAccount { get; set; } // 0x0000000181398FC0-0x0000000181399120 0x000000018139A770-0x000000018139A8E0
		public string Language { get; set; } // 0x0000000181399800-0x0000000181399960 0x000000018139B010-0x000000018139B180
		public string TargetCompatibleBrowserVersion { get; set; } // 0x0000000181399C20-0x0000000181399D80 0x000000018139B460-0x000000018139B5D0
		internal ICoreWebView2EnvironmentOptions2 _nativeICoreWebView2EnvironmentOptions2 { get; set; } // 0x0000000181399D80-0x0000000181399E90 0x000000018033E830-0x000000018033E840
		public bool ExclusiveUserDataFolderAccess { get; set; } // 0x0000000181399540-0x00000001813996A0 0x000000018139AD30-0x000000018139AEA0
		internal ICoreWebView2EnvironmentOptions3 _nativeICoreWebView2EnvironmentOptions3 { get; set; } // 0x0000000181399E90-0x0000000181399FA0 0x000000018033E840-0x000000018033E850
		public bool IsCustomCrashReportingEnabled { get; set; } // 0x00000001813996A0-0x0000000181399800 0x000000018139AEA0-0x000000018139B010
		internal ICoreWebView2EnvironmentOptions4 _nativeICoreWebView2EnvironmentOptions4 { get; set; } // 0x0000000181399FA0-0x000000018139A0B0 0x0000000180378110-0x0000000180378120
		internal ICoreWebView2EnvironmentOptions5 _nativeICoreWebView2EnvironmentOptions5 { get; set; } // 0x000000018139A0B0-0x000000018139A1C0 0x000000018033E850-0x000000018033E860
		public bool EnableTrackingPrevention { get; set; } // 0x00000001813993E0-0x0000000181399540 0x000000018139ABC0-0x000000018139AD30
		internal ICoreWebView2EnvironmentOptions6 _nativeICoreWebView2EnvironmentOptions6 { get; set; } // 0x000000018139A1C0-0x000000018139A2D0 0x0000000180378120-0x0000000180378130
		public bool AreBrowserExtensionsEnabled { get; set; } // 0x0000000181399120-0x0000000181399280 0x000000018139A8E0-0x000000018139AA50
		internal ICoreWebView2EnvironmentOptions8 _nativeICoreWebView2EnvironmentOptions8 { get; set; } // 0x000000018139A3E0-0x000000018139A4F0 0x00000001803780C0-0x00000001803780D0
		public CoreWebView2ScrollbarStyle ScrollBarStyle { get; set; } // 0x0000000181399AC0-0x0000000181399C20 0x000000018139B2F0-0x000000018139B460
		internal ICoreWebView2EnvironmentOptions7 _nativeICoreWebView2EnvironmentOptions7 { get; set; } // 0x000000018139A2D0-0x000000018139A3E0 0x00000001806CCE80-0x00000001806CCE90
		public CoreWebView2ChannelSearchKind ChannelSearchKind { get; set; } // 0x0000000181399280-0x00000001813993E0 0x000000018139AA50-0x000000018139ABC0
		public CoreWebView2ReleaseChannels ReleaseChannels { get; set; } // 0x0000000181399960-0x0000000181399AC0 0x000000018139B180-0x000000018139B2F0
		public List<CoreWebView2CustomSchemeRegistration> CustomSchemeRegistrations { [CompilerGenerated] get; } // 0x00000001802F4000-0x00000001802F4010 
	
		// Nested types
		private class RawOptions : ICoreWebView2EnvironmentOptions, ICoreWebView2EnvironmentOptions2, ICoreWebView2EnvironmentOptions3, ICoreWebView2EnvironmentOptions4, ICoreWebView2EnvironmentOptions5, ICoreWebView2EnvironmentOptions6, ICoreWebView2EnvironmentOptions7, ICoreWebView2EnvironmentOptions8 // TypeDefIndex: 10552
		{
			// Fields
			[CompilerGenerated]
			private string _AdditionalBrowserArguments_k__BackingField; // 0x10
			[CompilerGenerated]
			private string _Language_k__BackingField; // 0x18
			[CompilerGenerated]
			private string _TargetCompatibleBrowserVersion_k__BackingField; // 0x20
			[CompilerGenerated]
			private int _AllowSingleSignOnUsingOSPrimaryAccount_k__BackingField; // 0x28
			[CompilerGenerated]
			private int _ExclusiveUserDataFolderAccess_k__BackingField; // 0x2C
			[CompilerGenerated]
			private int _IsCustomCrashReportingEnabled_k__BackingField; // 0x30
			[CompilerGenerated]
			private int _AreBrowserExtensionsEnabled_k__BackingField; // 0x34
			[CompilerGenerated]
			private COREWEBVIEW2_RELEASE_CHANNELS _ReleaseChannels_k__BackingField; // 0x38
			[CompilerGenerated]
			private COREWEBVIEW2_CHANNEL_SEARCH_KIND _ChannelSearchKind_k__BackingField; // 0x3C
			[CompilerGenerated]
			private COREWEBVIEW2_SCROLLBAR_STYLE _ScrollBarStyle_k__BackingField; // 0x40
			[CompilerGenerated]
			private List<CoreWebView2CustomSchemeRegistration> _CustomSchemeRegistrations_k__BackingField; // 0x48
			[CompilerGenerated]
			private int _EnableTrackingPrevention_k__BackingField; // 0x50
	
			// Properties
			public string AdditionalBrowserArguments { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public string Language { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public string TargetCompatibleBrowserVersion { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
			public int AllowSingleSignOnUsingOSPrimaryAccount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
			public int ExclusiveUserDataFolderAccess { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
			public int IsCustomCrashReportingEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
			public int AreBrowserExtensionsEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
			public COREWEBVIEW2_RELEASE_CHANNELS ReleaseChannels { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
			public COREWEBVIEW2_CHANNEL_SEARCH_KIND ChannelSearchKind { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
			public COREWEBVIEW2_SCROLLBAR_STYLE ScrollBarStyle { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
			public List<CoreWebView2CustomSchemeRegistration> CustomSchemeRegistrations { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
			public int EnableTrackingPrevention { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D660-0x000000018033D670 0x000000018033EC40-0x000000018033EC50
	
			// Constructors
			public RawOptions(string additionalBrowserArguments, string language, string targetCompatibleBrowserVersion, bool allowSingleSignOnUsingOSPrimaryAccount, List<CoreWebView2CustomSchemeRegistration> customSchemeRegistrations, CoreWebView2ReleaseChannels releaseChannels, CoreWebView2ChannelSearchKind channelSearchKind); // 0x00000001813A3740-0x00000001813A37F0
			public RawOptions(string additionalBrowserArguments, string language, string targetCompatibleBrowserVersion, bool allowSingleSignOnUsingOSPrimaryAccount, List<CoreWebView2CustomSchemeRegistration> customSchemeRegistrations); // 0x00000001813A36A0-0x00000001813A3740
	
			// Methods
			public void GetCustomSchemeRegistrations(out uint count, IntPtr registrationsPtr); // 0x00000001813A33C0-0x00000001813A3660
			public void SetCustomSchemeRegistrations(uint count, ref ICoreWebView2CustomSchemeRegistration registration); // 0x00000001813A3660-0x00000001813A36A0
		}
	
		// Constructors
		internal CoreWebView2EnvironmentOptions(object rawCoreWebView2EnvironmentOptions); // 0x00000001803855F0-0x0000000180385630
		public CoreWebView2EnvironmentOptions(string additionalBrowserArguments = null, string language = null, string targetCompatibleBrowserVersion = null, bool allowSingleSignOnUsingOSPrimaryAccount = false /* Metadata: 0x006A14FE */, List<CoreWebView2CustomSchemeRegistration> customSchemeRegistrations = null); // 0x0000000181398CB0-0x0000000181398E60
		public CoreWebView2EnvironmentOptions(string additionalBrowserArguments, string language, string targetCompatibleBrowserVersion, bool allowSingleSignOnUsingOSPrimaryAccount, List<CoreWebView2CustomSchemeRegistration> customSchemeRegistrations, CoreWebView2ReleaseChannels releaseChannels = CoreWebView2ReleaseChannels.None | CoreWebView2ReleaseChannels.Stable | CoreWebView2ReleaseChannels.Beta | CoreWebView2ReleaseChannels.Dev | CoreWebView2ReleaseChannels.Canary /* Metadata: 0x006A14FF */, CoreWebView2ChannelSearchKind channelSearchKind = CoreWebView2ChannelSearchKind.MostStable /* Metadata: 0x006A1500 */); // 0x0000000181398B00-0x0000000181398CB0
	}
}
