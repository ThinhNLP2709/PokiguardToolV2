/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System
{
	public abstract class UriParser // TypeDefIndex: 8674
	{
		// Fields
		private static readonly Dictionary<string, UriParser> m_Table; // 0x00
		private static Dictionary<string, UriParser> m_TempTable; // 0x08
		private UriSyntaxFlags m_Flags; // 0x10
		private UriSyntaxFlags m_UpdatableFlags; // 0x14
		private bool m_UpdatableFlagsUsed; // 0x18
		private int m_Port; // 0x1C
		private string m_Scheme; // 0x20
		internal static UriParser HttpUri; // 0x10
		internal static UriParser HttpsUri; // 0x18
		internal static UriParser WsUri; // 0x20
		internal static UriParser WssUri; // 0x28
		internal static UriParser FtpUri; // 0x30
		internal static UriParser FileUri; // 0x38
		internal static UriParser GopherUri; // 0x40
		internal static UriParser NntpUri; // 0x48
		internal static UriParser NewsUri; // 0x50
		internal static UriParser MailToUri; // 0x58
		internal static UriParser UuidUri; // 0x60
		internal static UriParser TelnetUri; // 0x68
		internal static UriParser LdapUri; // 0x70
		internal static UriParser NetTcpUri; // 0x78
		internal static UriParser NetPipeUri; // 0x80
		internal static UriParser VsMacrosUri; // 0x88
		private static readonly UriQuirksVersion s_QuirksVersion; // 0x90
		private static readonly UriSyntaxFlags HttpSyntaxFlags; // 0x94
		private static readonly UriSyntaxFlags FileSyntaxFlags; // 0x98
	
		// Properties
		internal string SchemeName { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal int DefaultPort { get; } // 0x0000000180B232F0-0x0000000180B23300 
		internal static bool ShouldUseLegacyV2Quirks { get; } // 0x0000000181B5A330-0x0000000181B5A390 
		internal UriSyntaxFlags Flags { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		internal bool IsSimple { get; } // 0x0000000181B5A320-0x0000000181B5A330 
	
		// Nested types
		private enum UriQuirksVersion // TypeDefIndex: 8675
		{
			V2 = 2,
			V3 = 3
		}
	
		private class BuiltInUriParser : UriParser // TypeDefIndex: 8676
		{
			// Constructors
			internal BuiltInUriParser(string lwrCaseScheme, int defaultPort, UriSyntaxFlags syntaxFlags); // 0x0000000181B5C550-0x0000000181B5C5E0
		}
	
		// Constructors
		static UriParser(); // 0x0000000181B59600-0x0000000181B5A2D0
		internal UriParser(UriSyntaxFlags flags); // 0x0000000181B5A2D0-0x0000000181B5A320
	
		// Methods
		protected virtual UriParser OnNewUri(); // 0x0000000180370C60-0x0000000180370C70
		protected virtual void InitializeAndValidate(Uri uri, out UriFormatException parsingError); // 0x0000000181B59120-0x0000000181B59160
		protected virtual string Resolve(Uri baseUri, Uri relativeUri, out UriFormatException parsingError); // 0x0000000181B593E0-0x0000000181B59600
		protected virtual bool IsBaseOf(Uri baseUri, Uri relativeUri); // 0x0000000181B592C0-0x0000000181B592F0
		protected virtual string GetComponents(Uri uri, UriComponents components, UriFormat format); // 0x0000000181B58D70-0x0000000181B58FF0
		protected virtual bool IsWellFormedOriginalString(Uri uri); // 0x0000000181B59360-0x0000000181B59380
		internal bool NotAny(UriSyntaxFlags flags); // 0x0000000181B59380-0x0000000181B593E0
		internal bool InFact(UriSyntaxFlags flags); // 0x0000000181B590C0-0x0000000181B59120
		internal bool IsAllSet(UriSyntaxFlags flags); // 0x0000000181B59260-0x0000000181B592C0
		private bool IsFullMatch(UriSyntaxFlags flags, UriSyntaxFlags expected); // 0x0000000181B592F0-0x0000000181B59360
		internal static UriParser FindOrFetchAsUnknownV1Syntax(string lwrCaseScheme); // 0x0000000181B58AA0-0x0000000181B58D70
		internal static UriParser GetSyntax(string lwrCaseScheme); // 0x0000000181B58FF0-0x0000000181B590C0
		internal UriParser InternalOnNewUri(); // 0x0000000181B591C0-0x0000000181B59220
		internal void InternalValidate(Uri thisUri, out UriFormatException parsingError); // 0x0000000181B59240-0x0000000181B59260
		internal string InternalResolve(Uri thisBaseUri, Uri uriLink, out UriFormatException parsingError); // 0x0000000181B59220-0x0000000181B59240
		internal bool InternalIsBaseOf(Uri thisBaseUri, Uri uriLink); // 0x0000000181B59180-0x0000000181B591A0
		internal string InternalGetComponents(Uri thisUri, UriComponents uriComponents, UriFormat uriFormat); // 0x0000000181B59160-0x0000000181B59180
		internal bool InternalIsWellFormedOriginalString(Uri thisUri); // 0x0000000181B591A0-0x0000000181B591C0
	}
}
