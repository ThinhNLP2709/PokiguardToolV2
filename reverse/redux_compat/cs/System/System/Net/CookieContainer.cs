/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public class CookieContainer // TypeDefIndex: 9092
	{
		// Fields
		private static readonly HeaderVariantInfo[] HeaderInfo; // 0x00
		private Hashtable m_domainTable; // 0x10
		private int m_maxCookieSize; // 0x18
		private int m_maxCookies; // 0x1C
		private int m_maxCookiesPerDomain; // 0x20
		private int m_count; // 0x24
		private string m_fqdnMyDomain; // 0x28
	
		// Constructors
		public CookieContainer(); // 0x0000000181C009B0-0x0000000181C00AB0
		static CookieContainer(); // 0x0000000181C00880-0x0000000181C009B0
	
		// Methods
		private void AddRemoveDomain(string key, PathList value); // 0x0000000181BFD050-0x0000000181BFD1A0
		internal void Add(Cookie cookie, bool throwOnError); // 0x0000000181BFD1A0-0x0000000181BFDA20
		private bool AgeCookies(string domain); // 0x0000000181BFDA20-0x0000000181BFEA70
		private int ExpireCollection(CookieCollection cc); // 0x0000000181BFF9A0-0x0000000181BFFB20
		internal bool IsLocalDomain(string host); // 0x0000000181C003F0-0x0000000181C00690
		internal CookieCollection CookieCutter(Uri uri, string headerName, string setCookieHeader, bool isThrow); // 0x0000000181BFF1E0-0x0000000181BFF9A0
		internal CookieCollection InternalGetCookies(Uri uri); // 0x0000000181BFFF70-0x0000000181C003F0
		private void BuildCookieCollectionFromDomainMatches(Uri uri, bool isSecure, int port, CookieCollection cookies, List<string> domainAttribute, bool matchOnlyPlainCookie); // 0x0000000181BFEA70-0x0000000181BFF1E0
		private void MergeUpdateCollections(CookieCollection destination, CookieCollection source, int port, bool isSecure, bool isPlainOnly); // 0x0000000181C00690-0x0000000181C00880
		public string GetCookieHeader(Uri uri); // 0x0000000181BFFB20-0x0000000181BFFBF0
		internal string GetCookieHeader(Uri uri, out string optCookie2); // 0x0000000181BFFBF0-0x0000000181BFFF70
	}
}
