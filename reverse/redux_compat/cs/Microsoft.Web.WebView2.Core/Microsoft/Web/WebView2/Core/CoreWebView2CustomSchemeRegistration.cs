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
	public class CoreWebView2CustomSchemeRegistration // TypeDefIndex: 10532
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2CustomSchemeRegistration _nativeICoreWebView2CustomSchemeRegistrationValue; // 0x18
		[CompilerGenerated]
		private readonly string _SchemeName_k__BackingField; // 0x20
		[CompilerGenerated]
		private bool _TreatAsSecure_k__BackingField; // 0x28
		[CompilerGenerated]
		private bool _HasAuthorityComponent_k__BackingField; // 0x29
		[CompilerGenerated]
		private List<string> _AllowedOrigins_k__BackingField; // 0x30
	
		// Properties
		internal ICoreWebView2CustomSchemeRegistration _nativeICoreWebView2CustomSchemeRegistration { get; set; } // 0x0000000181393390-0x00000001813934A0 0x00000001802FAF70-0x00000001802FAF80
		public string SchemeName { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public bool TreatAsSecure { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public bool HasAuthorityComponent { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018052D500-0x000000018052D510 0x000000018052D7C0-0x000000018052D7D0
		public List<string> AllowedOrigins { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
	
		// Nested types
		private class RawCustomSchemeRegistration : ICoreWebView2CustomSchemeRegistration // TypeDefIndex: 10533
		{
			// Fields
			[CompilerGenerated]
			private string _SchemeName_k__BackingField; // 0x10
			[CompilerGenerated]
			private int _TreatAsSecure_k__BackingField; // 0x18
			[CompilerGenerated]
			private int _HasAuthorityComponent_k__BackingField; // 0x1C
			[CompilerGenerated]
			private readonly List<string> _AllowedOrigins_k__BackingField; // 0x20
	
			// Properties
			public string SchemeName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public int TreatAsSecure { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
			public int HasAuthorityComponent { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
			private List<string> AllowedOrigins { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
	
			// Constructors
			public RawCustomSchemeRegistration(string schemeName, bool treatAsSecure, bool hasAuthorityComponent, List<string> allowedOrigins); // 0x00000001813A32F0-0x00000001813A33C0
	
			// Methods
			public void GetAllowedOrigins(out uint allowedOriginsCount, IntPtr allowedOriginsPtr); // 0x00000001813A3190-0x00000001813A32B0
			public void SetAllowedOrigins(uint allowedOriginsCount, ref string allowedOrigins); // 0x00000001813A32B0-0x00000001813A32F0
		}
	
		// Constructors
		internal CoreWebView2CustomSchemeRegistration(object rawCoreWebView2CustomSchemeRegistration); // 0x00000001813932F0-0x0000000181393390
		public CoreWebView2CustomSchemeRegistration(string schemeName); // 0x0000000181393250-0x00000001813932F0
	
		// Methods
		internal IntPtr GetNative(); // 0x0000000181393100-0x0000000181393250
	}
}
