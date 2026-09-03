/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[NonVersionable]
	public struct Guid : IFormattable, IComparable, IComparable<System.Guid>, IEquatable<System.Guid>, ISpanFormattable // TypeDefIndex: 2265
	{
		// Fields
		public static readonly Guid Empty; // 0x00
		private int _a; // 0x00
		private short _b; // 0x04
		private short _c; // 0x06
		private byte _d; // 0x08
		private byte _e; // 0x09
		private byte _f; // 0x0A
		private byte _g; // 0x0B
		private byte _h; // 0x0C
		private byte _i; // 0x0D
		private byte _j; // 0x0E
		private byte _k; // 0x0F
	
		// Nested types
		[Flags]
		private enum GuidStyles // TypeDefIndex: 2266
		{
			None = 0,
			NumberFormat = 0,
			AllowParenthesis = 1,
			AllowBraces = 2,
			AllowDashes = 4,
			AllowHexPrefix = 8,
			Any = 15,
			RequireParenthesis = 16,
			RequireBraces = 32,
			RequireDashes = 64,
			DigitFormat = 64,
			ParenthesisFormat = 80,
			BraceFormat = 96,
			RequireHexPrefix = 128,
			HexFormat = 160
		}
	
		private enum GuidParseThrowStyle // TypeDefIndex: 2267
		{
			None = 0,
			All = 1,
			AllButOverflow = 2
		}
	
		private enum ParseFailureKind // TypeDefIndex: 2268
		{
			None = 0,
			ArgumentNull = 1,
			Format = 2,
			FormatWithParameter = 3,
			NativeException = 4,
			FormatWithInnerException = 5
		}
	
		private struct GuidResult // TypeDefIndex: 2269
		{
			// Fields
			internal Guid _parsedGuid; // 0x00
			internal GuidParseThrowStyle _throwStyle; // 0x10
			private ParseFailureKind _failure; // 0x14
			private string _failureMessageID; // 0x18
			private object _failureMessageFormatArgument; // 0x20
			private string _failureArgumentName; // 0x28
			private Exception _innerException; // 0x30
	
			// Methods
			internal void Init(GuidParseThrowStyle canThrow); // 0x00000001805D5560-0x00000001805D5570
			internal void SetFailure(Exception nativeException); // 0x00000001815F7CF0-0x00000001815F7D10
			internal void SetFailure(ParseFailureKind failure, string failureMessageID); // 0x00000001815F7D10-0x00000001815F7DA0
			internal void SetFailure(ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument); // 0x00000001815F7C60-0x00000001815F7CF0
			internal void SetFailure(ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument, string failureArgumentName, Exception innerException); // 0x00000001815F7BD0-0x00000001815F7C60
			internal Exception GetGuidParseException(); // 0x00000001815F7A30-0x00000001815F7BD0
		}
	
		// Constructors
		public Guid(byte[] b); // 0x00000001815FAF50-0x00000001815FAFE0
		public Guid(ReadOnlySpan<byte> b); // 0x00000001815FAD80-0x00000001815FAF50
		public Guid(int a, short b, short c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k); // 0x00000001815FB0E0-0x00000001815FB130
		public Guid(string g); // 0x00000001815FAFE0-0x00000001815FB0E0
	
		// Methods
		public static Guid NewGuid(); // 0x00000001815F86A0-0x00000001815F86F0
		public static Guid Parse(string input); // 0x00000001815F8780-0x00000001815F8890
		public static Guid Parse(ReadOnlySpan<char> input); // 0x00000001815F86F0-0x00000001815F8780
		public static bool TryParse(string input, out Guid result); // 0x00000001815FAB30-0x00000001815FABF0
		public static bool TryParse(ReadOnlySpan<char> input, out Guid result); // 0x00000001815FABF0-0x00000001815FAC60
		public static bool TryParseExact(string input, string format, out Guid result); // 0x00000001815F96C0-0x00000001815F9840
		public static bool TryParseExact(ReadOnlySpan<char> input, ReadOnlySpan<char> format, out Guid result); // 0x00000001815F9840-0x00000001815F9940
		private static bool TryParseGuid(ReadOnlySpan<char> guidString, GuidStyles flags, ref GuidResult result); // 0x00000001815FA940-0x00000001815FAB30
		private static bool TryParseGuidWithHexPrefix(ReadOnlySpan<char> guidString, ref GuidResult result); // 0x00000001815F9C80-0x00000001815FA590
		private static bool TryParseGuidWithNoStyle(ReadOnlySpan<char> guidString, ref GuidResult result); // 0x00000001815FA590-0x00000001815FA940
		private static bool TryParseGuidWithDashes(ReadOnlySpan<char> guidString, ref GuidResult result); // 0x00000001815F9940-0x00000001815F9C80
		private static bool StringToShort(ReadOnlySpan<char> str, int requiredLength, int flags, out short result, ref GuidResult parseResult); // 0x00000001815F8BD0-0x00000001815F8C30
		private static bool StringToShort(ReadOnlySpan<char> str, ref int parsePos, int requiredLength, int flags, out short result, ref GuidResult parseResult); // 0x00000001815F8B70-0x00000001815F8BD0
		private static bool StringToInt(ReadOnlySpan<char> str, int requiredLength, int flags, out int result, ref GuidResult parseResult); // 0x00000001815F8890-0x00000001815F88E0
		private static bool StringToInt(ReadOnlySpan<char> str, ref int parsePos, int requiredLength, int flags, out int result, ref GuidResult parseResult); // 0x00000001815F88E0-0x00000001815F8A70
		private static bool StringToLong(ReadOnlySpan<char> str, ref int parsePos, int flags, out long result, ref GuidResult parseResult); // 0x00000001815F8A70-0x00000001815F8B70
		private static ReadOnlySpan<char> EatAllWhitespace(ReadOnlySpan<char> str); // 0x00000001815F81C0-0x00000001815F83F0
		private static bool IsHexPrefix(ReadOnlySpan<char> str, int i); // 0x00000001815F8610-0x00000001815F86A0
		private void WriteByteHelper(Span<byte> destination); // 0x00000001815FAC60-0x00000001815FAD80
		public byte[] ToByteArray(); // 0x00000001815F8C70-0x00000001815F8DC0
		public override string ToString(); // 0x00000001815F8DC0-0x00000001815F8E00
		public override int GetHashCode(); // 0x00000001815F84A0-0x00000001815F84B0
		public override bool Equals(object o); // 0x00000001815F8420-0x00000001815F84A0
		public bool Equals(Guid g); // 0x00000001815F83F0-0x00000001815F8420
		private int GetResult(uint me, uint them); // 0x00000001815F84B0-0x00000001815F84D0
		public int CompareTo(object value); // 0x00000001815F7DA0-0x00000001815F8020
		public int CompareTo(Guid value); // 0x00000001815F8020-0x00000001815F81C0
		public static bool operator ==(Guid a, Guid b); // 0x00000001815FB130-0x00000001815FB160
		public static bool operator !=(Guid a, Guid b); // 0x00000001815FB160-0x00000001815FB190
		public string ToString(string format); // 0x00000001815F9040-0x00000001815F9050
		private static char HexToChar(int a); // 0x00000001815F84D0-0x00000001815F84F0
		private static unsafe int HexsToChars(char* guidChars, int a, int b); // 0x00000001815F8590-0x00000001815F8610
		private static unsafe int HexsToCharsHexOutput(char* guidChars, int a, int b); // 0x00000001815F84F0-0x00000001815F8590
		public string ToString(string format, IFormatProvider provider); // 0x00000001815F8E00-0x00000001815F9040
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default); // 0x00000001815F9050-0x00000001815F96C0
		bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider); // 0x00000001815F8C30-0x00000001815F8C70
	}
}
