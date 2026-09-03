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
	[Guid("177CD9E7-B6F5-451A-94A0-5D7A3A4C4141")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2CookieManager // TypeDefIndex: 10922
	{
		// Methods
		ICoreWebView2Cookie CreateCookie(in string name, in string value, in string Domain, in string Path); // 0x00000001813E5370-0x00000001813E5460
		ICoreWebView2Cookie CopyCookie(in ICoreWebView2Cookie cookieParam); // 0x00000001813E5270-0x00000001813E5370
		void GetCookies(in string uri, in ICoreWebView2GetCookiesCompletedHandler handler); // 0x00000001813E55F0-0x00000001813E56B0
		void AddOrUpdateCookie(in ICoreWebView2Cookie cookie); // 0x00000001813E51E0-0x00000001813E5270
		void DeleteCookie(in ICoreWebView2Cookie cookie); // 0x00000001813E5490-0x00000001813E5520
		void DeleteCookies(in string name, in string uri); // 0x00000001813E5590-0x00000001813E55F0
		void DeleteCookiesWithDomainAndPath(in string name, in string Domain, in string Path); // 0x00000001813E5520-0x00000001813E5590
		void DeleteAllCookies(); // 0x00000001813E5460-0x00000001813E5490
	}
}
