/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public sealed class Version : ICloneable, IComparable, IComparable<System.Version>, IEquatable<System.Version>, ISpanFormattable // TypeDefIndex: 2374
	{
		// Fields
		private readonly int _Major; // 0x10
		private readonly int _Minor; // 0x14
		private readonly int _Build; // 0x18
		private readonly int _Revision; // 0x1C
	
		// Properties
		public int Major { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int Minor { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public int Build { get; } // 0x0000000180B23260-0x0000000180B23270 
		public int Revision { get; } // 0x0000000180B232F0-0x0000000180B23300 
		private int DefaultFormatFieldCount { get; } // 0x000000018162AB70-0x000000018162AB90 
	
		// Constructors
		public Version(int major, int minor, int build, int revision); // 0x000000018162A910-0x000000018162AAF0
		public Version(int major, int minor, int build); // 0x000000018162A7A0-0x000000018162A910
		public Version(int major, int minor); // 0x000000018162A5C0-0x000000018162A6C0
		public Version(string version); // 0x000000018162A6C0-0x000000018162A7A0
		public Version(); // 0x000000018162AB40-0x000000018162AB70
		private Version(Version version); // 0x000000018162AAF0-0x000000018162AB40
	
		// Methods
		public object Clone(); // 0x0000000181629290-0x00000001816292F0
		public int CompareTo(object version); // 0x00000001816292F0-0x00000001816293C0
		public int CompareTo(Version value); // 0x00000001816293C0-0x0000000181629420
		public override bool Equals(object obj); // 0x0000000181629460-0x00000001816294B0
		public bool Equals(Version obj); // 0x0000000181629420-0x0000000181629460
		public override int GetHashCode(); // 0x00000001816294B0-0x00000001816294E0
		public override string ToString(); // 0x000000018162A2B0-0x000000018162A2F0
		public string ToString(int fieldCount); // 0x000000018162A260-0x000000018162A2B0
		public bool TryFormat(Span<char> destination, out int charsWritten); // 0x0000000181629E90-0x0000000181629F50
		public bool TryFormat(Span<char> destination, int fieldCount, out int charsWritten); // 0x000000018162A2F0-0x000000018162A410
		bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider); // 0x0000000181629E90-0x0000000181629F50
		private StringBuilder ToCachedStringBuilder(int fieldCount); // 0x0000000181629F50-0x000000018162A260
		public static Version Parse(string input); // 0x0000000181629DF0-0x0000000181629E90
		public static bool TryParse(string input, out Version result); // 0x000000018162A530-0x000000018162A5C0
		private static Version ParseVersion(ReadOnlySpan<char> input, bool throwOnFailure); // 0x00000001816294E0-0x0000000181629DF0
		private static bool TryParseComponent(ReadOnlySpan<char> component, string componentName, bool throwOnFailure, out int parsedComponent); // 0x000000018162A410-0x000000018162A530
		public static bool operator ==(Version v1, Version v2); // 0x000000018162AB90-0x000000018162ABD0
		public static bool operator !=(Version v1, Version v2); // 0x000000018162AC70-0x000000018162ACC0
		public static bool operator <(Version v1, Version v2); // 0x000000018162ACC0-0x000000018162AD60
		public static bool operator >(Version v1, Version v2); // 0x000000018162ABD0-0x000000018162AC70
	}
}
