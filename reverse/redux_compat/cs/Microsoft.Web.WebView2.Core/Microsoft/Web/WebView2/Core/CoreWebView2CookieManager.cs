/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2CookieManager // TypeDefIndex: 10530
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2CookieManager _nativeICoreWebView2CookieManagerValue; // 0x18
	
		// Properties
		internal ICoreWebView2CookieManager _nativeICoreWebView2CookieManager { get; set; } // 0x0000000181391680-0x0000000181391790 0x00000001802FAF70-0x00000001802FAF80
	
		// Nested types
		[CompilerGenerated]
		private struct _GetCookiesAsync_d__9 : IAsyncStateMachine // TypeDefIndex: 10531
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<List<CoreWebView2Cookie>> __t__builder; // 0x08
			public CoreWebView2CookieManager __4__this; // 0x20
			public string uri; // 0x28
			private CoreWebView2GetCookiesCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813A5070-0x00000001813A5530
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813A5530-0x00000001813A5590
		}
	
		// Constructors
		internal CoreWebView2CookieManager(object rawCoreWebView2CookieManager); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public CoreWebView2Cookie CreateCookie(string name, string cookieValue, string Domain, string Path); // 0x0000000181390CB0-0x0000000181390E90
		public CoreWebView2Cookie CopyCookie(CoreWebView2Cookie cookieParam); // 0x00000001813907F0-0x0000000181390A10
		public async Task<List<CoreWebView2Cookie>> GetCookiesAsync(string uri); // 0x0000000181391580-0x0000000181391680
		public void AddOrUpdateCookie(CoreWebView2Cookie cookie); // 0x0000000181390660-0x00000001813907F0
		public void DeleteCookie(CoreWebView2Cookie cookie); // 0x0000000181391000-0x0000000181391190
		public void DeleteCookies(string name, string uri); // 0x0000000181391390-0x0000000181391580
		public void DeleteCookiesWithDomainAndPath(string name, string Domain, string Path); // 0x0000000181391190-0x0000000181391390
		public void DeleteAllCookies(); // 0x0000000181390E90-0x0000000181391000
		public CoreWebView2Cookie CreateCookieWithSystemNetCookie(Cookie systemNetCookie); // 0x0000000181390A10-0x0000000181390CB0
	}
}
