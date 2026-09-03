/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System
{
	[Serializable]
	[TypeConverter(typeof(UriTypeConverter))]
	public class Uri : ISerializable // TypeDefIndex: 8659
	{
		// Fields
		public static readonly string UriSchemeFile; // 0x00
		public static readonly string UriSchemeFtp; // 0x08
		public static readonly string UriSchemeGopher; // 0x10
		public static readonly string UriSchemeHttp; // 0x18
		public static readonly string UriSchemeHttps; // 0x20
		internal static readonly string UriSchemeWs; // 0x28
		internal static readonly string UriSchemeWss; // 0x30
		public static readonly string UriSchemeMailto; // 0x38
		public static readonly string UriSchemeNews; // 0x40
		public static readonly string UriSchemeNntp; // 0x48
		public static readonly string UriSchemeNetTcp; // 0x50
		public static readonly string UriSchemeNetPipe; // 0x58
		public static readonly string SchemeDelimiter; // 0x60
		private string m_String; // 0x10
		private string m_originalUnicodeString; // 0x18
		private UriParser m_Syntax; // 0x20
		private string m_DnsSafeHost; // 0x28
		private Flags m_Flags; // 0x30
		private UriInfo m_Info; // 0x38
		private bool m_iriParsing; // 0x40
		private static bool s_ConfigInitialized; // 0x68
		private static bool s_ConfigInitializing; // 0x69
		private static UriIdnScope s_IdnScope; // 0x6C
		private static bool s_IriParsing; // 0x70
		private static bool useDotNetRelativeOrAbsolute; // 0x71
		internal static readonly bool IsWindowsFileSystem; // 0x72
		private static object s_initLock; // 0x78
		internal static readonly char[] HexLowerChars; // 0x80
		private static readonly char[] _WSchars; // 0x88
	
		// Properties
		private bool IsImplicitFile { get; } // 0x0000000181B0D7C0-0x0000000181B0D7D0 
		private bool IsUncOrDosPath { get; } // 0x0000000181B0D890-0x0000000181B0D8A0 
		private bool IsDosPath { get; } // 0x0000000181B0D6E0-0x0000000181B0D6F0 
		private bool IsUncPath { get; } // 0x0000000181B0D8A0-0x0000000181B0D8B0 
		private Flags HostType { get; } // 0x0000000181B0D490-0x0000000181B0D4A0 
		private UriParser Syntax { get; } // 0x00000001802F8630-0x00000001802F8640 
		private bool IsNotAbsoluteUri { get; } // 0x0000000180E6C6E0-0x0000000180E6C6F0 
		private bool AllowIdn { get; } // 0x0000000181B0CD70-0x0000000181B0CE40 
		internal bool UserDrivenParsing { get; } // 0x0000000181B0E190-0x0000000181B0E1A0 
		private ushort SecuredPathIndex { get; } // 0x0000000181B0DF30-0x0000000181B0DF90 
		public string AbsolutePath { get; } // 0x0000000181B0CB50-0x0000000181B0CC20 
		private string PrivateAbsolutePath { get; } // 0x0000000181B0DC60-0x0000000181B0DD50 
		public string AbsoluteUri { get; } // 0x0000000181B0CC20-0x0000000181B0CD70 
		public string LocalPath { get; } // 0x0000000181B0D940-0x0000000181B0D9C0 
		public string Authority { get; } // 0x0000000181B0CE40-0x0000000181B0CED0 
		public UriHostNameType HostNameType { get; } // 0x0000000181B0D340-0x0000000181B0D490 
		public bool IsDefaultPort { get; } // 0x0000000181B0D5E0-0x0000000181B0D6E0 
		public bool IsFile { get; } // 0x0000000181B0D6F0-0x0000000181B0D7C0 
		public bool IsLoopback { get; } // 0x0000000181B0D7D0-0x0000000181B0D890 
		public string PathAndQuery { get; } // 0x0000000181B0DA80-0x0000000181B0DB50 
		public string[] Segments { get; } // 0x0000000181B0DF90-0x0000000181B0E190 
		public bool IsUnc { get; } // 0x0000000181B0D8B0-0x0000000181B0D940 
		public string Host { get; } // 0x0000000181B0D4A0-0x0000000181B0D530 
		private static object InitializeLock { get; } // 0x0000000181B0D530-0x0000000181B0D5E0 
		public int Port { get; } // 0x0000000181B0DB50-0x0000000181B0DC60 
		public string Query { get; } // 0x0000000181B0DD50-0x0000000181B0DEA0 
		public string Fragment { get; } // 0x0000000181B0D1E0-0x0000000181B0D330 
		public string Scheme { get; } // 0x0000000181B0DEA0-0x0000000181B0DF30 
		private bool OriginalStringSwitched { get; } // 0x0000000181B0D9C0-0x0000000181B0DA20 
		public string OriginalString { get; } // 0x0000000181B0DA20-0x0000000181B0DA80 
		public string DnsSafeHost { get; } // 0x0000000181B0CED0-0x0000000181B0D1E0 
		public bool IsAbsoluteUri { get; } // 0x00000001817D1AF0-0x00000001817D1B00 
		public bool UserEscaped { get; } // 0x0000000181B0E1A0-0x0000000181B0E1B0 
		public string UserInfo { get; } // 0x0000000181B0E1B0-0x0000000181B0E240 
		internal bool HasAuthority { get; } // 0x0000000181B0D330-0x0000000181B0D340 
	
		// Nested types
		[Flags]
		private enum Flags : ulong // TypeDefIndex: 8660
		{
			Zero = 0,
			HostNotParsed = 0,
			SchemeNotCanonical = 1,
			UserNotCanonical = 2,
			HostNotCanonical = 4,
			PortNotCanonical = 8,
			PathNotCanonical = 16,
			QueryNotCanonical = 32,
			FragmentNotCanonical = 64,
			CannotDisplayCanonical = 127,
			E_UserNotCanonical = 128,
			E_HostNotCanonical = 256,
			E_PortNotCanonical = 512,
			E_PathNotCanonical = 1024,
			E_QueryNotCanonical = 2048,
			E_FragmentNotCanonical = 4096,
			E_CannotDisplayCanonical = 8064,
			ShouldBeCompressed = 8192,
			FirstSlashAbsent = 16384,
			BackslashInPath = 32768,
			IndexMask = 65535,
			IPv6HostType = 65536,
			IPv4HostType = 131072,
			DnsHostType = 196608,
			UncHostType = 262144,
			BasicHostType = 327680,
			UnusedHostType = 393216,
			HostTypeMask = 458752,
			UnknownHostType = 458752,
			UserEscaped = 524288,
			AuthorityFound = 1048576,
			HasUserInfo = 2097152,
			LoopbackHost = 4194304,
			NotDefaultPort = 8388608,
			UserDrivenParsing = 16777216,
			CanonicalDnsHost = 33554432,
			ErrorOrParsingRecursion = 67108864,
			DosPath = 134217728,
			UncPath = 268435456,
			ImplicitFile = 536870912,
			MinimalUriInfoSet = 1073741824,
			AllUriInfoSet = 2147483648,
			IdnHost = 4294967296,
			HasUnicode = 8589934592,
			HostUnicodeNormalized = 17179869184,
			RestUnicodeNormalized = 34359738368,
			UnicodeHost = 68719476736,
			IntranetUri = 137438953472,
			UseOrigUncdStrOffset = 274877906944,
			UserIriCanonical = 549755813888,
			PathIriCanonical = 1099511627776,
			QueryIriCanonical = 2199023255552,
			FragmentIriCanonical = 4398046511104,
			IriCanonical = 8246337208320,
			CompressedSlashes = 17592186044416
		}
	
		private class UriInfo // TypeDefIndex: 8661
		{
			// Fields
			public string Host; // 0x10
			public string ScopeId; // 0x18
			public string String; // 0x20
			public Offset Offset; // 0x28
			public string DnsSafeHost; // 0x38
			public MoreInfo MoreInfo; // 0x40
	
			// Constructors
			public UriInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private struct Offset // TypeDefIndex: 8662
		{
			// Fields
			public ushort Scheme; // 0x00
			public ushort User; // 0x02
			public ushort Host; // 0x04
			public ushort PortValue; // 0x06
			public ushort Path; // 0x08
			public ushort Query; // 0x0A
			public ushort Fragment; // 0x0C
			public ushort End; // 0x0E
		}
	
		private class MoreInfo // TypeDefIndex: 8663
		{
			// Fields
			public string Path; // 0x10
			public string Query; // 0x18
			public string Fragment; // 0x20
			public string AbsoluteUri; // 0x28
			public int Hash; // 0x30
			public string RemoteUrl; // 0x38
	
			// Constructors
			public MoreInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Flags]
		private enum Check // TypeDefIndex: 8664
		{
			None = 0,
			EscapedCanonical = 1,
			DisplayCanonical = 2,
			DotSlashAttn = 4,
			FoundNonAscii = 8,
			BackslashInPath = 16,
			ReservedFound = 32,
			NotIriCanonical = 64,
			DotSlashEscaped = 128
		}
	
		// Constructors
		public Uri(string uriString); // 0x0000000181B0C680-0x0000000181B0C7B0
		public Uri(string uriString, UriKind uriKind); // 0x0000000181B0C380-0x0000000181B0C420
		public Uri(Uri baseUri, string relativeUri); // 0x0000000181B0C810-0x0000000181B0C900
		public Uri(Uri baseUri, Uri relativeUri); // 0x0000000181B0C420-0x0000000181B0C680
		protected Uri(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B0C900-0x0000000181B0CB50
		private Uri(Flags flags, UriParser uriParser, string uri); // 0x0000000181B0C7B0-0x0000000181B0C810
		static Uri(); // 0x0000000181B0BDB0-0x0000000181B0C380
	
		// Methods
		internal static bool IriParsingStatic(UriParser syntax); // 0x0000000181B07510-0x0000000181B075B0
		private bool AllowIdnStatic(UriParser syntax, Flags flags); // 0x0000000181AFD690-0x0000000181AFD750
		private bool IsIntranet(string schemeHost); // 0x00000001802E7840-0x00000001802E7850
		private void SetUserDrivenParsing(); // 0x0000000181B0B120-0x0000000181B0B140
		private bool NotAny(Flags flags); // 0x0000000181B07BE0-0x0000000181B07BF0
		private bool InFact(Flags flags); // 0x0000000181B06090-0x0000000181B060A0
		private static bool StaticNotAny(Flags allFlags, Flags checkFlags); // 0x0000000181B0B170-0x0000000181B0B180
		private static bool StaticInFact(Flags allFlags, Flags checkFlags); // 0x0000000181B0B140-0x0000000181B0B150
		private UriInfo EnsureUriInfo(); // 0x0000000181B02630-0x0000000181B02670
		private void EnsureParseRemaining(); // 0x0000000181B02610-0x0000000181B02630
		private void EnsureHostString(bool allowDnsOptimization); // 0x0000000181B025A0-0x0000000181B02610
		private void CreateUri(Uri baseUri, string relativeUri, bool dontEscape); // 0x0000000181B02280-0x0000000181B025A0
		private static ParsingError GetCombinedString(Uri baseUri, string relativeStr, bool dontEscape, ref string result); // 0x0000000181B03960-0x0000000181B03B80
		private static UriFormatException GetException(ParsingError err); // 0x0000000181B04170-0x0000000181B04320
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B05240-0x0000000181B05320
		protected void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B05240-0x0000000181B05320
		private static bool StaticIsFile(UriParser syntax); // 0x0000000181B0B150-0x0000000181B0B170
		private static void InitializeUriConfig(); // 0x0000000181B060A0-0x0000000181B06290
		private string GetLocalPath(); // 0x0000000181B04990-0x0000000181B05240
		public static UriHostNameType CheckHostName(string name); // 0x0000000181AFF860-0x0000000181AFFA70
		internal static bool IsGenDelim(char ch); // 0x0000000181B079B0-0x0000000181B079E0
		public static bool IsHexDigit(char character); // 0x0000000181B079E0-0x0000000181B07A10
		public static int FromHex(char digit); // 0x0000000181B030E0-0x0000000181B03180
		public override int GetHashCode(); // 0x0000000181B04320-0x0000000181B044D0
		public override string ToString(); // 0x0000000181B0B320-0x0000000181B0B440
		public static bool operator ==(Uri uri1, Uri uri2); // 0x0000000181B0E240-0x0000000181B0E280
		public static bool operator !=(Uri uri1, Uri uri2); // 0x0000000181B0E280-0x0000000181B0E430
		public override bool Equals(object comparand); // 0x0000000181B02670-0x0000000181B02E00
		private static bool CheckForColonInFirstPathSegment(string uriString); // 0x0000000181AFF3E0-0x0000000181AFF480
		internal static string InternalEscapeString(string rawString); // 0x0000000181B06EE0-0x0000000181B06FC0
		private static ParsingError ParseScheme(string uriString, ref Flags flags, ref UriParser syntax); // 0x0000000181B08F10-0x0000000181B09000
		internal UriFormatException ParseMinimal(); // 0x0000000181B07BF0-0x0000000181B07C70
		private ParsingError PrivateParseMinimal(); // 0x0000000181B09120-0x0000000181B098D0
		private void PrivateParseMinimalIri(string newHost, ushort idx); // 0x0000000181B09000-0x0000000181B09120
		private void CreateUriInfo(Flags cF); // 0x0000000181B01CA0-0x0000000181B02280
		private void CreateHostString(); // 0x0000000181B01470-0x0000000181B01910
		private static string CreateHostStringHelper(string str, ushort idx, ushort end, ref Flags flags, ref string scopeId); // 0x0000000181B01260-0x0000000181B01470
		private void GetHostViaCustomSyntax(); // 0x0000000181B044D0-0x0000000181B04990
		internal string GetParts(UriComponents uriParts, UriFormat formatAs); // 0x0000000181B05320-0x0000000181B05330
		private string GetEscapedParts(UriComponents uriParts); // 0x0000000181B04080-0x0000000181B04170
		private string GetUnescapedParts(UriComponents uriParts, UriFormat formatAs); // 0x0000000181B05710-0x0000000181B057E0
		private string ReCreateParts(UriComponents parts, ushort nonCanonical, UriFormat formatAs); // 0x0000000181B098D0-0x0000000181B0ABB0
		private string GetUriPartsFromUserString(UriComponents uriParts); // 0x0000000181B057E0-0x0000000181B06090
		private void ParseRemaining(); // 0x0000000181B07C70-0x0000000181B08A00
		private static unsafe ushort ParseSchemeCheckImplicitFile(char* uriString, ushort length, ref ParsingError err, ref Flags flags, ref UriParser syntax); // 0x0000000181B08A00-0x0000000181B08F10
		private static unsafe bool CheckKnownSchemes(long* lptr, ushort nChars, ref UriParser syntax); // 0x0000000181AFFA70-0x0000000181AFFF90
		private static unsafe ParsingError CheckSchemeSyntax(char* ptr, ushort length, ref UriParser syntax); // 0x0000000181AFFF90-0x0000000181B000B0
		private unsafe ushort CheckAuthorityHelper(char* pString, ushort idx, ushort length, ref ParsingError err, ref Flags flags, UriParser syntax, ref string newHost); // 0x0000000181AFE070-0x0000000181AFEF30
		private unsafe void CheckAuthorityHelperHandleDnsIri(char* pString, ushort start, int end, int startInput, bool iriParsing, bool hasUnicode, UriParser syntax, string userInfoString, ref Flags flags, ref bool justNormalized, ref string newHost, ref ParsingError err); // 0x0000000181AFDB20-0x0000000181AFE070
		private unsafe void CheckAuthorityHelperHandleAnyHostIri(char* pString, int startInput, int end, bool iriParsing, bool hasUnicode, UriParser syntax, ref Flags flags, ref string newHost, ref ParsingError err); // 0x0000000181AFD810-0x0000000181AFDB20
		private void FindEndOfComponent(string input, ref ushort idx, ushort end, char delim); // 0x0000000181B03030-0x0000000181B030E0
		private unsafe void FindEndOfComponent(char* str, ref ushort idx, ushort end, char delim); // 0x0000000181B02F90-0x0000000181B03030
		private unsafe Check CheckCanonical(char* str, ref ushort idx, ushort end, char delim); // 0x0000000181AFEF30-0x0000000181AFF3E0
		private char[] GetCanonicalPath(char[] dest, ref int pos, UriFormat formatAs); // 0x0000000181B03180-0x0000000181B03960
		private static unsafe void UnescapeOnly(char* pch, int start, ref int end, char ch1, char ch2, char ch3); // 0x0000000181B0BBA0-0x0000000181B0BDB0
		private static char[] Compress(char[] dest, ushort start, ref int destLength, UriParser syntax); // 0x0000000181B00A60-0x0000000181B00F80
		internal static int CalculateCaseInsensitiveHashCode(string text); // 0x0000000181AFD750-0x0000000181AFD810
		private static string CombineUri(Uri basePart, string relativePart, UriFormat uriFormat); // 0x0000000181B000B0-0x0000000181B00A60
		private static bool IsLWS(char ch); // 0x0000000181B07A10-0x0000000181B07A40
		private static bool IsAsciiLetter(char character); // 0x0000000181B07630-0x0000000181B07650
		internal static bool IsAsciiLetterOrDigit(char character); // 0x0000000181B075B0-0x0000000181B07630
		internal static bool IsBidiControlCharacter(char ch); // 0x0000000181B07970-0x0000000181B079B0
		internal static unsafe string StripBidiControlCharacter(char* strToClean, int start, int length); // 0x0000000181B0B180-0x0000000181B0B320
		private void CreateThis(string uri, bool dontEscape, UriKind uriKind); // 0x0000000181B01AC0-0x0000000181B01CA0
		private void InitializeUri(ParsingError err, UriKind uriKind, out UriFormatException e); // 0x0000000181B06290-0x0000000181B06EE0
		private bool CheckForConfigLoad(string data); // 0x0000000181AFF480-0x0000000181AFF540
		private bool CheckForUnicode(string data); // 0x0000000181AFF720-0x0000000181AFF860
		private bool CheckForEscapedUnreserved(string data); // 0x0000000181AFF540-0x0000000181AFF720
		public static bool TryCreate(string uriString, UriKind uriKind, out Uri result); // 0x0000000181B0B440-0x0000000181B0B510
		public static bool TryCreate(Uri baseUri, string relativeUri, out Uri result); // 0x0000000181B0B510-0x0000000181B0B800
		public static bool TryCreate(Uri baseUri, Uri relativeUri, out Uri result); // 0x0000000181B0B800-0x0000000181B0B9F0
		public string GetComponents(UriComponents components, UriFormat format); // 0x0000000181B03E80-0x0000000181B04080
		public bool IsWellFormedOriginalString(); // 0x0000000181B07A40-0x0000000181B07A90
		public static bool IsWellFormedUriString(string uriString, UriKind uriKind); // 0x0000000181B07A90-0x0000000181B07BE0
		internal bool InternalIsWellFormedOriginalString(); // 0x0000000181B06FC0-0x0000000181B07510
		public static string UnescapeDataString(string stringToUnescape); // 0x0000000181B0B9F0-0x0000000181B0BBA0
		public static string EscapeDataString(string stringToEscape); // 0x0000000181B02E00-0x0000000181B02F30
		internal string EscapeUnescapeIri(string input, int start, int end, UriComponents component); // 0x0000000181B02F30-0x0000000181B02F90
		internal static Uri CreateHelper(string uriString, bool dontEscape, UriKind uriKind, ref UriFormatException e); // 0x0000000181B00F80-0x0000000181B01260
		internal static Uri ResolveHelper(Uri baseUri, Uri relativeUri, ref string newUriString, ref bool userEscaped, out UriFormatException e); // 0x0000000181B0ABB0-0x0000000181B0B120
		private string GetRelativeSerializationString(UriFormat format); // 0x0000000181B05330-0x0000000181B05710
		internal string GetComponentsHelper(UriComponents uriComponents, UriFormat uriFormat); // 0x0000000181B03B80-0x0000000181B03E80
		public bool IsBaseOf(Uri uri); // 0x0000000181B078A0-0x0000000181B07970
		internal bool IsBaseOfHelper(Uri uriLink); // 0x0000000181B07650-0x0000000181B078A0
		private void CreateThisFromUri(Uri otherUri); // 0x0000000181B01910-0x0000000181B01AC0
	}
}
