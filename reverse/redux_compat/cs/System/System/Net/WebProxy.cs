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
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public class WebProxy : IWebProxy, ISerializable // TypeDefIndex: 9101
	{
		// Fields
		private bool _UseRegistry; // 0x10
		private bool _BypassOnLocal; // 0x11
		private bool m_EnableAutoproxy; // 0x12
		private Uri _ProxyAddress; // 0x18
		private ArrayList _BypassList; // 0x20
		private ICredentials _Credentials; // 0x28
		private Regex[] _RegExBypassList; // 0x30
		private Hashtable _ProxyHostAddresses; // 0x38
		private AutoWebProxyScriptEngine m_ScriptEngine; // 0x40
	
		// Properties
		public ICredentials Credentials { get; } // 0x000000018033D240-0x000000018033D250 
		public bool UseDefaultCredentials { get; set; } // 0x0000000181C15270-0x0000000181C152E0 0x0000000181C152E0-0x0000000181C15360
		internal AutoWebProxyScriptEngine ScriptEngine { get; } // 0x0000000180377940-0x0000000180377950 
	
		// Constructors
		public WebProxy(); // 0x0000000181C14E00-0x0000000181C14E70
		public WebProxy(Uri Address, bool BypassOnLocal, string[] BypassList, ICredentials Credentials); // 0x0000000181C14E70-0x0000000181C14F40
		protected WebProxy(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C14F40-0x0000000181C15270
		internal WebProxy(bool enableAutoproxy); // 0x0000000181C14DD0-0x0000000181C14E00
	
		// Methods
		public Uri GetProxy(Uri destination); // 0x0000000181C14190-0x0000000181C14360
		private void UpdateRegExList(bool canThrow); // 0x0000000181C14BF0-0x0000000181C14DD0
		private bool IsMatchInBypassList(Uri input); // 0x0000000181C149D0-0x0000000181C14B60
		private bool IsLocal(Uri host); // 0x0000000181C14860-0x0000000181C149D0
		private bool IsLocalInProxyHash(Uri host); // 0x0000000181C14770-0x0000000181C14860
		public bool IsBypassed(Uri host); // 0x0000000181C14680-0x0000000181C14770
		private bool IsBypassedManual(Uri host); // 0x0000000181C143C0-0x0000000181C14680
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B0FAD0-0x0000000181B0FB00
		protected virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C13FC0-0x0000000181C14110
		public static IWebProxy CreateDefaultProxy(); // 0x0000000181C13F70-0x0000000181C13FC0
		internal void UnsafeUpdateFromRegistry(); // 0x000000018030F220-0x000000018030F230
		private bool GetProxyAuto(Uri destination, out Uri proxyUri); // 0x0000000181C14110-0x0000000181C14190
		private bool IsBypassedAuto(Uri destination, out bool isBypassed); // 0x0000000181C14360-0x0000000181C143C0
		private static bool AreAllBypassed(IEnumerable<string> proxies, bool checkFirstOnly); // 0x0000000181C13DE0-0x0000000181C13F70
		private static Uri ProxyUri(string proxyName); // 0x0000000181C14B60-0x0000000181C14BF0
	}
}
