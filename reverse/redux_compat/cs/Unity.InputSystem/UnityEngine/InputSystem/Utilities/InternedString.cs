/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	public struct InternedString : IEquatable<UnityEngine.InputSystem.Utilities.InternedString>, IComparable<UnityEngine.InputSystem.Utilities.InternedString> // TypeDefIndex: 6603
	{
		// Fields
		private readonly string m_StringOriginalCase; // 0x00
		private readonly string m_StringLowerCase; // 0x08
	
		// Properties
		public int length { get; } // 0x0000000181CF0DC0-0x0000000181CF0DD0 
	
		// Constructors
		public InternedString(string text); // 0x0000000181CF0D10-0x0000000181CF0DC0
	
		// Methods
		public bool IsEmpty(); // 0x0000000181CF0CE0-0x0000000181CF0CF0
		public string ToLower(); // 0x0000000180C5CF90-0x0000000180C5CFA0
		public override bool Equals(object obj); // 0x0000000181CF0B80-0x0000000181CF0CA0
		public bool Equals(InternedString other); // 0x0000000181CF0CA0-0x0000000181CF0CB0
		public int CompareTo(InternedString other); // 0x0000000181CF0B60-0x0000000181CF0B80
		public override int GetHashCode(); // 0x0000000181CF0CB0-0x0000000181CF0CE0
		public override string ToString(); // 0x0000000181CF0CF0-0x0000000181CF0D10
		public static bool operator ==(InternedString a, InternedString b); // 0x0000000181CF0CA0-0x0000000181CF0CB0
		public static bool operator !=(InternedString a, InternedString b); // 0x0000000181CF0E40-0x0000000181CF0E50
		public static bool operator ==(InternedString a, string b); // 0x0000000181CF0DF0-0x0000000181CF0E10
		public static bool operator !=(InternedString a, string b); // 0x0000000181CF0E70-0x0000000181CF0E90
		public static bool operator ==(string a, InternedString b); // 0x0000000181CF0DD0-0x0000000181CF0DF0
		public static bool operator !=(string a, InternedString b); // 0x0000000181CF0E50-0x0000000181CF0E70
		public static bool operator <(InternedString left, InternedString right); // 0x0000000181CF0E90-0x0000000181CF0EC0
		public static bool operator >(InternedString left, InternedString right); // 0x0000000181CF0E10-0x0000000181CF0E40
		public static implicit operator string(InternedString str); // 0x0000000181CF0CF0-0x0000000181CF0D10
	}
}
