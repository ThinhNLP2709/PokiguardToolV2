/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal static class HttpUtility // TypeDefIndex: 13284
	{
		// Fields
		private static Dictionary<string, char> _entities; // 0x00
		private static char[] _hexChars; // 0x08
		private static object _sync; // 0x10
	
		// Constructors
		static HttpUtility(); // 0x000000018260D400-0x000000018260D4D0
	
		// Methods
		private static Dictionary<string, char> getEntities(); // 0x000000018260D4D0-0x000000018260D5C0
		private static int getNumber(char c); // 0x000000018260D7D0-0x000000018260D810
		private static int getNumber(byte[] bytes, int offset, int count); // 0x000000018260D5C0-0x000000018260D6D0
		private static int getNumber(string s, int offset, int count); // 0x000000018260D6D0-0x000000018260D7D0
		private static string htmlDecode(string s); // 0x000000018260D810-0x000000018260DCC0
		private static string htmlEncode(string s, bool minimal); // 0x000000018260DCC0-0x000000018260DE60
		private static void initEntities(); // 0x000000018260DE60-0x0000000182611D10
		private static bool isAlphabet(char c); // 0x0000000182611D10-0x0000000182611D30
		private static bool isNumeric(char c); // 0x0000000182611D30-0x0000000182611D50
		private static bool isUnreserved(char c); // 0x0000000182611DA0-0x0000000182611DC0
		private static bool isUnreservedInRfc2396(char c); // 0x0000000182611D50-0x0000000182611D80
		private static bool isUnreservedInRfc3986(char c); // 0x0000000182611D80-0x0000000182611DA0
		private static byte[] urlDecodeToBytes(byte[] bytes, int offset, int count); // 0x0000000182611DC0-0x0000000182612030
		private static void urlEncode(byte b, Stream output); // 0x0000000182612200-0x00000001826123F0
		private static byte[] urlEncodeToBytes(byte[] bytes, int offset, int count); // 0x0000000182612030-0x0000000182612200
		internal static Uri CreateRequestUrl(string requestUri, string host, bool websocketRequest, bool secure); // 0x000000018260AD50-0x000000018260B070
		internal static IPrincipal CreateUser(string response, AuthenticationSchemes scheme, string realm, string method, Func<IIdentity, NetworkCredential> credentialsFinder); // 0x000000018260B070-0x000000018260B5A0
		internal static Encoding GetEncoding(string contentType); // 0x000000018260B5A0-0x000000018260B820
		internal static bool TryGetEncoding(string contentType, out Encoding result); // 0x000000018260BD90-0x000000018260BE20
		public static string HtmlAttributeEncode(string s); // 0x000000018260B940-0x000000018260B9F0
		public static void HtmlAttributeEncode(string s, TextWriter output); // 0x000000018260B820-0x000000018260B940
		public static string HtmlDecode(string s); // 0x000000018260B9F0-0x000000018260BAA0
		public static void HtmlDecode(string s, TextWriter output); // 0x000000018260BAA0-0x000000018260BBC0
		public static string HtmlEncode(string s); // 0x000000018260BBC0-0x000000018260BC70
		public static void HtmlEncode(string s, TextWriter output); // 0x000000018260BC70-0x000000018260BD90
		public static string UrlDecode(string s); // 0x000000018260C610-0x000000018260C670
		public static string UrlDecode(byte[] bytes, Encoding encoding); // 0x000000018260C670-0x000000018260C790
		public static string UrlDecode(string s, Encoding encoding); // 0x000000018260C4D0-0x000000018260C610
		public static string UrlDecode(byte[] bytes, int offset, int count, Encoding encoding); // 0x000000018260C250-0x000000018260C4D0
		public static byte[] UrlDecodeToBytes(byte[] bytes); // 0x000000018260BE20-0x000000018260BEE0
		public static byte[] UrlDecodeToBytes(string s); // 0x000000018260C140-0x000000018260C250
		public static byte[] UrlDecodeToBytes(byte[] bytes, int offset, int count); // 0x000000018260BEE0-0x000000018260C140
		public static string UrlEncode(byte[] bytes); // 0x000000018260CD30-0x000000018260CE40
		public static string UrlEncode(string s); // 0x000000018260D240-0x000000018260D400
		public static string UrlEncode(string s, Encoding encoding); // 0x000000018260D0B0-0x000000018260D240
		public static string UrlEncode(byte[] bytes, int offset, int count); // 0x000000018260CE40-0x000000018260D0B0
		public static byte[] UrlEncodeToBytes(byte[] bytes); // 0x000000018260CC70-0x000000018260CD30
		public static byte[] UrlEncodeToBytes(string s); // 0x000000018260CB10-0x000000018260CC70
		public static byte[] UrlEncodeToBytes(string s, Encoding encoding); // 0x000000018260C9F0-0x000000018260CB10
		public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count); // 0x000000018260C790-0x000000018260C9F0
	}
}
