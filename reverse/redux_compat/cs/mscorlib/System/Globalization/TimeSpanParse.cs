/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	internal static class TimeSpanParse // TypeDefIndex: 3415
	{
		// Nested types
		private enum ParseFailureKind : byte // TypeDefIndex: 3416
		{
			None = 0,
			ArgumentNull = 1,
			Format = 2,
			FormatWithParameter = 3,
			Overflow = 4
		}
	
		[Flags]
		private enum TimeSpanStandardStyles : byte // TypeDefIndex: 3417
		{
			None = 0,
			Invariant = 1,
			Localized = 2,
			Any = 3,
			RequireFull = 4
		}
	
		private enum TTT : byte // TypeDefIndex: 3418
		{
			None = 0,
			End = 1,
			Num = 2,
			Sep = 3,
			NumOverflow = 4
		}
	
		[IsByRefLike]
		[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
		private struct TimeSpanToken // TypeDefIndex: 3419
		{
			// Fields
			internal TTT _ttt; // 0x00
			internal int _num; // 0x04
			internal int _zeroes; // 0x08
			internal ReadOnlySpan<char> _sep; // 0x10
	
			// Constructors
			public TimeSpanToken(TTT type); // 0x0000000181559380-0x0000000181559390
			public TimeSpanToken(int number); // 0x00000001815593B0-0x00000001815593D0
			public TimeSpanToken(TTT type, int number, int leadingZeroes, ReadOnlySpan<char> separator); // 0x0000000181559390-0x00000001815593B0
	
			// Methods
			public bool IsInvalidFraction(); // 0x0000000181559320-0x0000000181559380
		}
	
		[IsByRefLike]
		[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
		private struct TimeSpanTokenizer // TypeDefIndex: 3420
		{
			// Fields
			private ReadOnlySpan<char> _value; // 0x00
			private int _pos; // 0x10
	
			// Constructors
			internal TimeSpanTokenizer(ReadOnlySpan<char> input); // 0x00000001815595F0-0x0000000181559600
			internal TimeSpanTokenizer(ReadOnlySpan<char> input, int startPosition); // 0x0000000180F378A0-0x0000000180F378B0
	
			// Methods
			internal TimeSpanToken GetNextToken(); // 0x00000001815593D0-0x00000001815595F0
		}
	
		[IsByRefLike]
		[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
		private struct TimeSpanRawInfo // TypeDefIndex: 3421
		{
			// Fields
			internal TTT _lastSeenTTT; // 0x00
			internal int _tokenCount; // 0x04
			internal int _sepCount; // 0x08
			internal int _numCount; // 0x0C
			private TimeSpanFormat.FormatLiterals _posLoc; // 0x10
			private TimeSpanFormat.FormatLiterals _negLoc; // 0x38
			private bool _posLocInit; // 0x60
			private bool _negLocInit; // 0x61
			private string _fullPosPattern; // 0x68
			private string _fullNegPattern; // 0x70
			internal TimeSpanToken _numbers0; // 0x78
			internal TimeSpanToken _numbers1; // 0x98
			internal TimeSpanToken _numbers2; // 0xB8
			internal TimeSpanToken _numbers3; // 0xD8
			internal TimeSpanToken _numbers4; // 0xF8
			internal ReadOnlySpan<char> _literals0; // 0x118
			internal ReadOnlySpan<char> _literals1; // 0x128
			internal ReadOnlySpan<char> _literals2; // 0x138
			internal ReadOnlySpan<char> _literals3; // 0x148
			internal ReadOnlySpan<char> _literals4; // 0x158
			internal ReadOnlySpan<char> _literals5; // 0x168
	
			// Properties
			internal TimeSpanFormat.FormatLiterals PositiveInvariant { get; } // 0x0000000181559080-0x00000001815590F0 
			internal TimeSpanFormat.FormatLiterals NegativeInvariant { get; } // 0x0000000181558F60-0x0000000181558FD0 
			internal TimeSpanFormat.FormatLiterals PositiveLocalized { get; } // 0x00000001815590F0-0x00000001815591A0 
			internal TimeSpanFormat.FormatLiterals NegativeLocalized { get; } // 0x0000000181558FD0-0x0000000181559080 
	
			// Methods
			internal bool FullAppCompatMatch(TimeSpanFormat.FormatLiterals pattern); // 0x00000001815579A0-0x0000000181557C00
			internal bool PartialAppCompatMatch(TimeSpanFormat.FormatLiterals pattern); // 0x0000000181558B70-0x0000000181558D60
			internal bool FullMatch(TimeSpanFormat.FormatLiterals pattern); // 0x00000001815587E0-0x0000000181558AC0
			internal bool FullDMatch(TimeSpanFormat.FormatLiterals pattern); // 0x0000000181558080-0x00000001815581C0
			internal bool FullHMMatch(TimeSpanFormat.FormatLiterals pattern); // 0x00000001815581C0-0x0000000181558360
			internal bool FullDHMMatch(TimeSpanFormat.FormatLiterals pattern); // 0x0000000181557C00-0x0000000181557E10
			internal bool FullHMSMatch(TimeSpanFormat.FormatLiterals pattern); // 0x00000001815585D0-0x00000001815587E0
			internal bool FullDHMSMatch(TimeSpanFormat.FormatLiterals pattern); // 0x0000000181557E10-0x0000000181558080
			internal bool FullHMSFMatch(TimeSpanFormat.FormatLiterals pattern); // 0x0000000181558360-0x00000001815585D0
			internal void Init(DateTimeFormatInfo dtfi); // 0x0000000181558AC0-0x0000000181558B70
			internal bool ProcessToken(ref TimeSpanToken tok, ref TimeSpanResult result); // 0x0000000181558D60-0x0000000181558F60
			private bool AddSep(ReadOnlySpan<char> sep, ref TimeSpanResult result); // 0x0000000181557850-0x00000001815579A0
			private bool AddNum(TimeSpanToken num, ref TimeSpanResult result); // 0x0000000181557700-0x0000000181557850
		}
	
		private struct TimeSpanResult // TypeDefIndex: 3422
		{
			// Fields
			internal TimeSpan parsedTimeSpan; // 0x00
			private readonly bool _throwOnFailure; // 0x08
	
			// Constructors
			internal TimeSpanResult(bool throwOnFailure); // 0x0000000181559310-0x0000000181559320
	
			// Methods
			internal bool SetFailure(ParseFailureKind kind, string resourceKey, object messageArgument = null, string argumentName = null); // 0x00000001815591A0-0x0000000181559310
		}
	
		// Methods
		internal static long Pow10(int pow); // 0x0000000181553AF0-0x0000000181553BE0
		private static bool TryTimeToTicks(bool positive, TimeSpanToken days, TimeSpanToken hours, TimeSpanToken minutes, TimeSpanToken seconds, TimeSpanToken fraction, out long result); // 0x0000000181557540-0x0000000181557700
		internal static TimeSpan Parse(ReadOnlySpan<char> input, IFormatProvider formatProvider); // 0x0000000181553AB0-0x0000000181553AF0
		private static bool TryParseTimeSpan(ReadOnlySpan<char> input, TimeSpanStandardStyles style, IFormatProvider formatProvider, ref TimeSpanResult result); // 0x0000000181556B60-0x0000000181557540
		private static bool ProcessTerminalState(ref TimeSpanRawInfo raw, TimeSpanStandardStyles style, ref TimeSpanResult result); // 0x0000000181553BE0-0x0000000181553D40
		private static bool ProcessTerminal_DHMSF(ref TimeSpanRawInfo raw, TimeSpanStandardStyles style, ref TimeSpanResult result); // 0x0000000181553D40-0x0000000181554180
		private static bool ProcessTerminal_HMS_F_D(ref TimeSpanRawInfo raw, TimeSpanStandardStyles style, ref TimeSpanResult result); // 0x00000001815544B0-0x0000000181555730
		private static bool ProcessTerminal_HM_S_D(ref TimeSpanRawInfo raw, TimeSpanStandardStyles style, ref TimeSpanResult result); // 0x0000000181555730-0x0000000181556800
		private static bool ProcessTerminal_HM(ref TimeSpanRawInfo raw, TimeSpanStandardStyles style, ref TimeSpanResult result); // 0x0000000181556800-0x0000000181556B60
		private static bool ProcessTerminal_D(ref TimeSpanRawInfo raw, TimeSpanStandardStyles style, ref TimeSpanResult result); // 0x0000000181554180-0x00000001815544B0
	}
}
