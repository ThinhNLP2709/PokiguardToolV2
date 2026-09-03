/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Buffers;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[ComVisible(true)]
	public static class Path // TypeDefIndex: 3707
	{
		// Fields
		[Obsolete("see GetInvalidPathChars and GetInvalidFileNameChars methods.")]
		public static readonly char[] InvalidPathChars; // 0x00
		public static readonly char AltDirectorySeparatorChar; // 0x08
		public static readonly char DirectorySeparatorChar; // 0x0A
		public static readonly char PathSeparator; // 0x0C
		internal static readonly string DirectorySeparatorStr; // 0x10
		public static readonly char VolumeSeparatorChar; // 0x18
		internal static readonly char[] PathSeparatorChars; // 0x20
		private static readonly bool dirEqualsVolume; // 0x28
		internal static readonly char[] trimEndCharsWindows; // 0x30
		internal static readonly char[] trimEndCharsUnix; // 0x38
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3708
		{
			// Fields
			public static readonly __c __9; // 0x00
			[TupleElementNames(new string[5] {"First", "FirstLength", "Second", "SecondLength", "HasSeparator" })]
			public static SpanAction<char, ValueTuple<IntPtr, int, IntPtr, int, bool>> __9__59_0; // 0x08
			[TupleElementNames(new string[9] {"First", "FirstLength", "Second", "SecondLength", "Third", "ThirdLength", "FirstHasSeparator", "ThirdHasSeparator", null })]
			public static SpanAction<char, ValueTuple<IntPtr, int, IntPtr, int, IntPtr, int, bool, ValueTuple<bool>>> __9__60_0; // 0x10
	
			// Constructors
			static __c(); // 0x00000001815DBD30-0x00000001815DBDA0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _JoinInternal_b__59_0(Span<char> destination, [TupleElementNames(new string[5] {"First", "FirstLength", "Second", "SecondLength", "HasSeparator" })] ValueTuple<IntPtr, int, IntPtr, int, bool> state); // 0x00000001815DB750-0x00000001815DB8D0
			internal void _JoinInternal_b__60_0(Span<char> destination, [TupleElementNames(new string[9] {"First", "FirstLength", "Second", "SecondLength", "Third", "ThirdLength", "FirstHasSeparator", "ThirdHasSeparator", null })] ValueTuple<IntPtr, int, IntPtr, int, IntPtr, int, bool, ValueTuple<bool>> state); // 0x00000001815DB8D0-0x00000001815DBB00
		}
	
		// Constructors
		static Path(); // 0x00000001815CCB00-0x00000001815CCE30
	
		// Methods
		public static string ChangeExtension(string path, string extension); // 0x00000001815C8D90-0x00000001815C8FA0
		public static string Combine(string path1, string path2); // 0x00000001815C9450-0x00000001815C96C0
		internal static string CleanPath(string s); // 0x00000001815C8FA0-0x00000001815C9450
		public static string GetDirectoryName(string path); // 0x00000001815C9CF0-0x00000001815CA020
		public static ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path); // 0x00000001815C9C40-0x00000001815C9CF0
		public static string GetExtension(string path); // 0x00000001815CA020-0x00000001815CA120
		public static string GetFileName(string path); // 0x00000001815CA2B0-0x00000001815CA3A0
		public static string GetFileNameWithoutExtension(string path); // 0x00000001815CA120-0x00000001815CA180
		public static string GetFullPath(string path); // 0x00000001815CA720-0x00000001815CA780
		internal static string GetFullPathInternal(string path); // 0x00000001815CA3A0-0x00000001815CA3F0
		private static extern int GetFullPathName(string path, int numBufferChars, StringBuilder buffer, ref IntPtr lpFilePartOrNull); // 0x00000001815CA630-0x00000001815CA720
		internal static string GetFullPathName(string path); // 0x00000001815CA3F0-0x00000001815CA630
		internal static string WindowsDriveAdjustment(string path); // 0x00000001815CC890-0x00000001815CCB00
		internal static string InsecureGetFullPath(string path); // 0x00000001815CB320-0x00000001815CBAE0
		internal static bool IsDirectorySeparator(char c); // 0x00000001815CBAE0-0x00000001815CBB50
		public static string GetPathRoot(string path); // 0x00000001815CA8C0-0x00000001815CAC90
		public static string GetTempFileName(); // 0x00000001815CAE70-0x00000001815CB250
		public static string GetTempPath(); // 0x00000001815CB250-0x00000001815CB320
		private static string get_temp_path(); // 0x00000001815CCED0-0x00000001815CCEE0
		public static bool IsPathRooted(ReadOnlySpan<char> path); // 0x00000001815CBCE0-0x00000001815CBD90
		public static bool IsPathRooted(string path); // 0x00000001815CBB50-0x00000001815CBCE0
		public static char[] GetInvalidFileNameChars(); // 0x00000001815CA780-0x00000001815CA830
		public static char[] GetInvalidPathChars(); // 0x00000001815CA830-0x00000001815CA8C0
		private static int findExtension(string path); // 0x00000001815CCE30-0x00000001815CCED0
		private static string GetServerAndShare(string path); // 0x00000001815CAC90-0x00000001815CAE70
		private static bool SameRoot(string root, string path); // 0x00000001815CC660-0x00000001815CC890
		private static string CanonicalizePath(string path); // 0x00000001815C86C0-0x00000001815C8D90
		public static string Combine(params string[] paths); // 0x00000001815C98B0-0x00000001815C9C40
		public static string Combine(string path1, string path2, string path3); // 0x00000001815C96C0-0x00000001815C98B0
		public static ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path); // 0x00000001815CA180-0x00000001815CA2B0
		public static string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2); // 0x00000001815CC320-0x00000001815CC3D0
		public static string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3); // 0x00000001815CC3D0-0x00000001815CC660
		private static string JoinInternal(ReadOnlySpan<char> first, ReadOnlySpan<char> second); // 0x00000001815CC0C0-0x00000001815CC320
		private static string JoinInternal(ReadOnlySpan<char> first, ReadOnlySpan<char> second, ReadOnlySpan<char> third); // 0x00000001815CBD90-0x00000001815CC0C0
	}
}
