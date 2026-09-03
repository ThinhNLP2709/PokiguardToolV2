/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public sealed class Cookie // TypeDefIndex: 9082
	{
		// Fields
		internal static readonly char[] PortSplitDelimiters; // 0x00
		internal static readonly char[] Reserved2Name; // 0x08
		internal static readonly char[] Reserved2Value; // 0x10
		private static Comparer staticComparer; // 0x18
		private string m_comment; // 0x10
		private Uri m_commentUri; // 0x18
		private CookieVariant m_cookieVariant; // 0x20
		private bool m_discard; // 0x24
		private string m_domain; // 0x28
		private bool m_domain_implicit; // 0x30
		private DateTime m_expires; // 0x38
		private string m_name; // 0x40
		private string m_path; // 0x48
		private bool m_path_implicit; // 0x50
		private string m_port; // 0x58
		private bool m_port_implicit; // 0x60
		private int[] m_port_list; // 0x68
		private bool m_secure; // 0x70
		[OptionalField]
		private bool m_httpOnly; // 0x71
		private DateTime m_timeStamp; // 0x78
		private string m_value; // 0x80
		private int m_version; // 0x88
		private string m_domainKey; // 0x90
		internal bool IsQuotedVersion; // 0x98
		internal bool IsQuotedDomain; // 0x99
	
		// Properties
		public string Comment { get; set; } // 0x0000000180377550-0x0000000180377560 0x000000018186A780-0x000000018186A7B0
		public Uri CommentUri { set; } // 0x00000001802FAF70-0x00000001802FAF80
		public bool HttpOnly { get; set; } // 0x000000018030D9D0-0x000000018030D9E0 0x00000001803CB1F0-0x00000001803CB200
		public bool Discard { set; } // 0x0000000181706050-0x0000000181706060
		public string Domain { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181C04850-0x0000000181C048C0
		private string _Domain { get; } // 0x0000000181C04570-0x0000000181C04630 
		public bool Expired { get; } // 0x0000000181C044D0-0x0000000181C04570 
		public DateTime Expires { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181C048C0-0x0000000181C048D0
		public string Name { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181C048D0-0x0000000181C04A30
		public string Path { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x0000000181C04A30-0x0000000181C04A80
		private string _Path { get; } // 0x0000000181C04630-0x0000000181C046B0 
		internal bool Plain { get; } // 0x0000000181A85EA0-0x0000000181A85EB0 
		public string Port { set; } // 0x0000000181C04A80-0x0000000181C04F30
		internal int[] PortList { get; } // 0x0000000180316960-0x0000000180316970 
		private string _Port { get; } // 0x0000000181C046B0-0x0000000181C04760 
		public bool Secure { get; set; } // 0x0000000180643BD0-0x0000000180643BE0 0x0000000180C4A240-0x0000000180C4A250
		public string Value { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x0000000181C04F30-0x0000000181C04F70
		internal CookieVariant Variant { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		internal string DomainKey { get; } // 0x0000000181C044B0-0x0000000181C044D0 
		public int Version { get; set; } // 0x000000018033D620-0x000000018033D630 0x0000000181C04F70-0x0000000181C04FF0
		private string _Version { get; } // 0x0000000181C04760-0x0000000181C04850 
	
		// Constructors
		public Cookie(); // 0x0000000181C03F70-0x0000000181C040D0
		public Cookie(string name, string value); // 0x0000000181C041E0-0x0000000181C044B0
		public Cookie(string name, string value, string path); // 0x0000000181C040D0-0x0000000181C04130
		public Cookie(string name, string value, string path, string domain); // 0x0000000181C04130-0x0000000181C041E0
		static Cookie(); // 0x0000000181C03DB0-0x0000000181C03F70
	
		// Methods
		internal bool InternalSetName(string value); // 0x0000000181C02810-0x0000000181C02910
		private static bool IsDomainEqualToHost(string domain, string host); // 0x0000000181C02910-0x0000000181C02970
		internal bool VerifySetDefaults(CookieVariant variant, Uri uri, bool isLocalDomain, string localDomain, bool set_default, bool isThrow); // 0x0000000181C02E40-0x0000000181C03DB0
		private static bool DomainCharsTest(string name); // 0x0000000181C02460-0x0000000181C024F0
		internal static IComparer GetComparer(); // 0x0000000181C02600-0x0000000181C02650
		public override bool Equals(object comparand); // 0x0000000181C024F0-0x0000000181C02600
		public override int GetHashCode(); // 0x0000000181C02650-0x0000000181C02810
		public override string ToString(); // 0x0000000181C02970-0x0000000181C02E40
	}
}
