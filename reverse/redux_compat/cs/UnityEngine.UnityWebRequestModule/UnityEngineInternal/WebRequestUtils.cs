/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Scripting;

// Image 45: UnityEngine.UnityWebRequestModule.dll - Assembly: UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15315-15336

namespace UnityEngineInternal
{
	internal static class WebRequestUtils // TypeDefIndex: 15318
	{
		// Fields
		private static readonly Regex domainRegex; // 0x00
	
		// Constructors
		static WebRequestUtils(); // 0x00000001825D1360-0x00000001825D13F0
	
		// Methods
		[RequiredByNativeCode]
		internal static string RedirectTo(string baseUri, string redirectUri); // 0x00000001825D1160-0x00000001825D1260
		internal static string MakeInitialUrl(string targetUrl, string localUrl); // 0x00000001825D0A70-0x00000001825D0D50
		internal static string MakeUriString(Uri targetUri, string targetUrl, bool prependProtocol); // 0x00000001825D0D50-0x00000001825D1160
		private static string URLDecode(string encoded); // 0x00000001825D1260-0x00000001825D1360
	}
}
