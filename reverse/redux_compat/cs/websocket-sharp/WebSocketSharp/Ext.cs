/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using WebSocketSharp.Net;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp
{
	public static class Ext // TypeDefIndex: 13216
	{
		// Fields
		private static readonly byte[] _last; // 0x00
		private static readonly int _retry; // 0x08
		private const string _tspecials = "()<>@,;:\\\"/[]?={} \t"; // Metadata: 0x006A77F4
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass20_0 // TypeDefIndex: 13217
		{
			// Fields
			public int end; // 0x10
			public string[] values; // 0x18
			public int len; // 0x20
			public Func<int, bool> seek; // 0x28
	
			// Constructors
			public __c__DisplayClass20_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _ContainsTwice_b__0(int idx); // 0x00000001825DF290-0x00000001825DF360
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 13218
		{
			// Fields
			public Stream sourceStream; // 0x10
			public Action completed; // 0x18
			public Stream destinationStream; // 0x20
			public byte[] buff; // 0x28
			public int bufferLength; // 0x30
			public AsyncCallback callback; // 0x38
			public Action<Exception> error; // 0x40
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _CopyToAsync_b__0(IAsyncResult ar); // 0x00000001825DF360-0x00000001825DF470
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass57_0 // TypeDefIndex: 13219
		{
			// Fields
			public Stream stream; // 0x10
			public int retry; // 0x18
			public byte[] buff; // 0x20
			public int offset; // 0x28
			public int length; // 0x2C
			public AsyncCallback callback; // 0x30
			public Action<byte[]> completed; // 0x38
			public Action<Exception> error; // 0x40
	
			// Constructors
			public __c__DisplayClass57_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ReadBytesAsync_b__0(IAsyncResult ar); // 0x00000001825DF470-0x00000001825DF650
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_0 // TypeDefIndex: 13220
		{
			// Fields
			public int bufferLength; // 0x10
			public Stream stream; // 0x18
			public byte[] buff; // 0x20
			public int retry; // 0x28
			public Action<long> read; // 0x30
			public Action<byte[]> completed; // 0x38
			public MemoryStream dest; // 0x40
			public Action<Exception> error; // 0x48
	
			// Constructors
			public __c__DisplayClass58_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ReadBytesAsync_b__0(long len); // 0x00000001825DF650-0x00000001825DF770
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass58_1 // TypeDefIndex: 13221
		{
			// Fields
			public long len; // 0x10
			public __c__DisplayClass58_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass58_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ReadBytesAsync_b__1(IAsyncResult ar); // 0x00000001825DF770-0x00000001825DFB20
		}
	
		[CompilerGenerated]
		private sealed class _SplitHeaderValue_d__60 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 13222
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private string value; // 0x28
			public string __3__value; // 0x30
			private char[] separators; // 0x38
			public char[] __3__separators; // 0x40
			private int _len_5__1; // 0x48
			private int _end_5__2; // 0x4C
			private StringBuilder _buff_5__3; // 0x50
			private bool _escaped_5__4; // 0x58
			private bool _quoted_5__5; // 0x59
			private int _i_5__6; // 0x5C
			private char _c_5__7; // 0x60
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _SplitHeaderValue_d__60(int __1__state); // 0x00000001825DE850-0x00000001825DE8A0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x00000001825DE4D0-0x00000001825DE730
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001825DE810-0x00000001825DE850
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x00000001825DE730-0x00000001825DE810
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001825DE730-0x00000001825DE810
		}
	
		[CompilerGenerated]
		private sealed class _TrimEach_d__71 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 13223
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private IEnumerable<string> source; // 0x28
			public IEnumerable<string> __3__source; // 0x30
			private IEnumerator<string> __s__1; // 0x38
			private string _elm_5__2; // 0x40
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _TrimEach_d__71(int __1__state); // 0x00000001825DE850-0x00000001825DE8A0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001825DEBE0-0x00000001825DEC80
			private bool MoveNext(); // 0x00000001825DE8A0-0x00000001825DEAE0
			private void __m__Finally1(); // 0x00000001825DEC80-0x00000001825DECD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001825DEBA0-0x00000001825DEBE0
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x00000001825DEAE0-0x00000001825DEBA0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001825DEAE0-0x00000001825DEBA0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass84_0 // TypeDefIndex: 13224
		{
			// Fields
			public Action completed; // 0x10
			public MemoryStream src; // 0x18
			public Action<Exception> error; // 0x20
	
			// Constructors
			public __c__DisplayClass84_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _WriteBytesAsync_b__0(); // 0x00000001825DFB20-0x00000001825DFB60
			internal void _WriteBytesAsync_b__1(Exception ex); // 0x00000001825DFB60-0x00000001825DFBB0
		}
	
		// Constructors
		static Ext(); // 0x00000001825DCB10-0x00000001825DCB90
	
		// Extension methods
		private static byte[] compress(this byte[] data); // 0x00000001825DCF70-0x00000001825DD0B0
		private static MemoryStream compress(this Stream stream); // 0x00000001825DCCC0-0x00000001825DCF70
		private static byte[] compressToArray(this Stream stream); // 0x00000001825DCB90-0x00000001825DCCC0
		private static byte[] decompress(this byte[] data); // 0x00000001825DD1E0-0x00000001825DD320
		private static MemoryStream decompress(this Stream stream); // 0x00000001825DD320-0x00000001825DD570
		private static byte[] decompressToArray(this Stream stream); // 0x00000001825DD0B0-0x00000001825DD1E0
		private static bool isHttpMethod(this string value); // 0x00000001825DD600-0x00000001825DD740
		private static bool isHttpMethod10(this string value); // 0x00000001825DD570-0x00000001825DD600
		private static bool isPredefinedScheme(this string value); // 0x00000001825DD740-0x00000001825DD980
		internal static byte[] Append(this ushort code, string reason); // 0x00000001825D8720-0x00000001825D8880
		internal static byte[] Compress(this byte[] data, CompressionMethod method); // 0x00000001825D8970-0x00000001825D89E0
		internal static Stream Compress(this Stream stream, CompressionMethod method); // 0x00000001825D8900-0x00000001825D8970
		internal static byte[] CompressToArray(this Stream stream, CompressionMethod method); // 0x00000001825D8880-0x00000001825D8900
		internal static bool Contains(this string value, params char[] anyOf); // 0x00000001825D8AE0-0x00000001825D8B20
		internal static bool Contains(this NameValueCollection collection, string name); // 0x00000001825D8B20-0x00000001825D8B50
		internal static bool Contains(this NameValueCollection collection, string name, string value, StringComparison comparisonTypeForValue); // 0x00000001825D8B50-0x00000001825D8C70
		internal static bool Contains<T>(this IEnumerable<T> source, Func<T, bool> condition);
		internal static bool ContainsTwice(this string[] values); // 0x00000001825D89E0-0x00000001825D8AE0
		internal static T[] Copy<T>(this T[] sourceArray, int length);
		internal static T[] Copy<T>(this T[] sourceArray, long length);
		internal static void CopyTo(this Stream sourceStream, Stream destinationStream, int bufferLength); // 0x00000001825D8E30-0x00000001825D8EF0
		internal static void CopyToAsync(this Stream sourceStream, Stream destinationStream, int bufferLength, Action completed, Action<Exception> error); // 0x00000001825D8C70-0x00000001825D8E30
		internal static byte[] Decompress(this byte[] data, CompressionMethod method); // 0x00000001825D8FE0-0x00000001825D9050
		internal static Stream Decompress(this Stream stream, CompressionMethod method); // 0x00000001825D8F70-0x00000001825D8FE0
		internal static byte[] DecompressToArray(this Stream stream, CompressionMethod method); // 0x00000001825D8EF0-0x00000001825D8F70
		internal static void Emit(this EventHandler eventHandler, object sender, EventArgs e); // 0x000000018089B130-0x000000018089B150
		internal static void Emit<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e)
			where TEventArgs : EventArgs;
		internal static string GetAbsolutePath(this Uri uri); // 0x00000001825D9050-0x00000001825D9140
		internal static WebSocketSharp.Net.CookieCollection GetCookies(this NameValueCollection headers, bool response); // 0x00000001825D9140-0x00000001825D91F0
		internal static string GetDnsSafeHost(this Uri uri, bool bracketIPv6); // 0x00000001825D9240-0x00000001825D9290
		internal static string GetMessage(this CloseStatusCode code); // 0x00000001825D9290-0x00000001825D9400
		internal static string GetName(this string nameAndValue, char separator); // 0x00000001825D9400-0x00000001825D9450
		internal static string GetUTF8DecodedString(this byte[] bytes); // 0x00000001825D9A90-0x00000001825D9AD0
		internal static byte[] GetUTF8EncodedBytes(this string s); // 0x00000001825D9AD0-0x00000001825D9B10
		internal static string GetValue(this string nameAndValue, char separator); // 0x00000001825D9CA0-0x00000001825D9D60
		internal static string GetValue(this string nameAndValue, char separator, bool unquote); // 0x00000001825D9B10-0x00000001825D9CA0
		internal static bool IsCompressionExtension(this string value, CompressionMethod method); // 0x00000001825D9D80-0x00000001825D9E20
		internal static bool IsControl(this byte opcode); // 0x00000001825D9E30-0x00000001825D9E40
		internal static bool IsControl(this Opcode opcode); // 0x00000001825D9E20-0x00000001825D9E30
		internal static bool IsData(this byte opcode); // 0x00000001825D9E40-0x00000001825D9E60
		internal static bool IsData(this Opcode opcode); // 0x00000001825D9E40-0x00000001825D9E60
		internal static bool IsEqualTo(this int value, char c, Action<int> beforeComparing); // 0x00000001825D9EE0-0x00000001825D9F20
		internal static bool IsHttpMethod(this string value, Version version); // 0x00000001825D9F30-0x00000001825DA190
		internal static bool IsPortNumber(this int value); // 0x00000001825DA3C0-0x00000001825DA3E0
		internal static bool IsReserved(this ushort code); // 0x00000001825DA3E0-0x00000001825DA410
		internal static bool IsReserved(this CloseStatusCode code); // 0x00000001825DA3E0-0x00000001825DA410
		internal static bool IsSupported(this byte opcode); // 0x00000001825DA410-0x00000001825DA490
		internal static bool IsText(this string value); // 0x00000001825DA490-0x00000001825DA580
		internal static bool IsToken(this string value); // 0x00000001825DA580-0x00000001825DA620
		internal static bool KeepsAlive(this NameValueCollection headers, Version version); // 0x00000001825DA620-0x00000001825DA740
		internal static bool MaybeUri(this string value); // 0x00000001825DA740-0x00000001825DA7D0
		internal static string Quote(this string value); // 0x00000001825DA7D0-0x00000001825DA860
		internal static byte[] ReadBytes(this Stream stream, int length); // 0x00000001825DABF0-0x00000001825DAD20
		internal static byte[] ReadBytes(this Stream stream, long length, int bufferLength); // 0x00000001825DAD20-0x00000001825DAF70
		internal static void ReadBytesAsync(this Stream stream, int length, Action<byte[]> completed, Action<Exception> error); // 0x00000001825DA860-0x00000001825DAA10
		internal static void ReadBytesAsync(this Stream stream, long length, int bufferLength, Action<byte[]> completed, Action<Exception> error); // 0x00000001825DAA10-0x00000001825DABF0
		internal static T[] Reverse<T>(this T[] array);
		internal static IEnumerable<string> SplitHeaderValue(this string value, params char[] separators); // 0x00000001825DAF70-0x00000001825DB020
		internal static byte[] ToByteArray(this Stream stream); // 0x00000001825DB0C0-0x00000001825DB2D0
		internal static byte[] ToByteArray(this ushort value, ByteOrder order); // 0x00000001825DB2D0-0x00000001825DB340
		internal static byte[] ToByteArray(this ulong value, ByteOrder order); // 0x00000001825DB340-0x00000001825DB3B0
		internal static CompressionMethod ToCompressionMethod(this string value); // 0x00000001825DB3B0-0x00000001825DB610
		internal static string ToExtensionString(this CompressionMethod method, params string[] parameters); // 0x00000001825DB610-0x00000001825DB750
		internal static IPAddress ToIPAddress(this string value); // 0x00000001825DB820-0x00000001825DB8D0
		internal static List<TSource> ToList<TSource>(this IEnumerable<TSource> source);
		internal static string ToString(this IPAddress address, bool bracketIPv6); // 0x00000001825DB8D0-0x00000001825DB970
		internal static ushort ToUInt16(this byte[] source, ByteOrder sourceOrder); // 0x00000001825DB970-0x00000001825DBA80
		internal static ulong ToUInt64(this byte[] source, ByteOrder sourceOrder); // 0x00000001825DBA80-0x00000001825DBB90
		internal static IEnumerable<string> TrimEach(this IEnumerable<string> source); // 0x00000001825DBCB0-0x00000001825DBD40
		internal static string TrimSlashFromEnd(this string value); // 0x00000001825DBD40-0x00000001825DBDD0
		internal static string TrimSlashOrBackslashFromEnd(this string value); // 0x00000001825DBDD0-0x00000001825DBE90
		internal static bool TryCreateVersion(this string versionString, out Version result); // 0x00000001825DBE90-0x00000001825DBF10
		internal static bool TryCreateWebSocketUri(this string uriString, out Uri result, out string message); // 0x00000001825DBF10-0x00000001825DC410
		internal static bool TryGetUTF8DecodedString(this byte[] bytes, out string s); // 0x00000001825DC410-0x00000001825DC490
		internal static bool TryGetUTF8EncodedBytes(this string s, out byte[] bytes); // 0x00000001825DC490-0x00000001825DC510
		internal static bool TryOpenRead(this FileInfo fileInfo, out FileStream fileStream); // 0x00000001825DC510-0x00000001825DC580
		internal static string Unquote(this string value); // 0x00000001825DC580-0x00000001825DC650
		internal static bool Upgrades(this NameValueCollection headers, string protocol); // 0x00000001825DC650-0x00000001825DC710
		internal static string UrlDecode(this string value, Encoding encoding); // 0x00000001825DC710-0x00000001825DC770
		internal static string UrlEncode(this string value, Encoding encoding); // 0x00000001825DC770-0x00000001825DC7D0
		internal static void WriteBytes(this Stream stream, byte[] bytes, int bufferLength); // 0x00000001825DC970-0x00000001825DCB10
		internal static void WriteBytesAsync(this Stream stream, byte[] bytes, int bufferLength, Action completed, Action<Exception> error); // 0x00000001825DC7D0-0x00000001825DC970
		public static string GetDescription(this WebSocketSharp.Net.HttpStatusCode code); // 0x00000001825D91F0-0x00000001825D9240
		public static string GetStatusDescription(this int code); // 0x00000001825D9450-0x00000001825D9A90
		public static bool IsCloseStatusCode(this ushort value); // 0x00000001825D9D60-0x00000001825D9D80
		public static bool IsEnclosedIn(this string value, char c); // 0x00000001825D9E60-0x00000001825D9EE0
		public static bool IsHostOrder(this ByteOrder order); // 0x00000001825D9F20-0x00000001825D9F30
		public static bool IsLocal(this IPAddress address); // 0x00000001825DA190-0x00000001825DA3A0
		public static bool IsNullOrEmpty(this string value); // 0x00000001825DA3A0-0x00000001825DA3C0
		public static T[] SubArray<T>(this T[] array, int startIndex, int length);
		public static T[] SubArray<T>(this T[] array, long startIndex, long length);
		public static void Times(this int n, Action<int> action); // 0x00000001825DB020-0x00000001825DB070
		public static void Times(this long n, Action<long> action); // 0x00000001825DB070-0x00000001825DB0C0
		public static byte[] ToHostOrder(this byte[] source, ByteOrder sourceOrder); // 0x00000001825DB750-0x00000001825DB820
		public static string ToString<T>(this T[] array, string separator);
		public static Uri ToUri(this string value); // 0x00000001825DBB90-0x00000001825DBCB0
	}
}
