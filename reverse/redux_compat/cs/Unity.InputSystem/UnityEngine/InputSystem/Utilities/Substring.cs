/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal struct Substring : IComparable<UnityEngine.InputSystem.Utilities.Substring>, IEquatable<UnityEngine.InputSystem.Utilities.Substring> // TypeDefIndex: 6642
	{
		// Fields
		private readonly string m_String; // 0x00
		private readonly int m_Index; // 0x08
		private readonly int m_Length; // 0x0C
	
		// Properties
		public bool isEmpty { get; } // 0x0000000181CFFE70-0x0000000181CFFE80 
		public int length { get; } // 0x0000000180732D30-0x0000000180732D40 
		public int index { get; } // 0x0000000180732D20-0x0000000180732D30 
		public char this[int index] { get => default; } // 0x0000000181CFFDF0-0x0000000181CFFE70 
	
		// Constructors
		public Substring(string str); // 0x0000000181CFFD60-0x0000000181CFFDA0
		public Substring(string str, int index, int length); // 0x0000000180BE46C0-0x0000000180BE4700
		public Substring(string str, int index); // 0x0000000181CFFDA0-0x0000000181CFFDF0
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181CFF930-0x0000000181CFFAB0
		public bool Equals(string other); // 0x0000000181CFFB40-0x0000000181CFFBF0
		public bool Equals(Substring other); // 0x0000000181CFFAB0-0x0000000181CFFB40
		public bool Equals(InternedString other); // 0x0000000181CFF890-0x0000000181CFF930
		public int CompareTo(Substring other); // 0x0000000181CFF7C0-0x0000000181CFF840
		public static int Compare(Substring left, Substring right, StringComparison comparison); // 0x0000000181CFF840-0x0000000181CFF890
		public bool StartsWith(string str); // 0x0000000181CFFC70-0x0000000181CFFD00
		public string Substr(int index = 0 /* Metadata: 0x006991DA */, int length = -1 /* Metadata: 0x006991DB */); // 0x0000000181CFFD00-0x0000000181CFFD30
		public override string ToString(); // 0x0000000181CFFD30-0x0000000181CFFD60
		public override int GetHashCode(); // 0x0000000181CFFBF0-0x0000000181CFFC70
		public static bool operator ==(Substring a, Substring b); // 0x0000000181CFFAB0-0x0000000181CFFB40
		public static bool operator !=(Substring a, Substring b); // 0x0000000181CFFFC0-0x0000000181D00050
		public static bool operator ==(Substring a, InternedString b); // 0x0000000181CFFEF0-0x0000000181CFFF60
		public static bool operator !=(Substring a, InternedString b); // 0x0000000181D00050-0x0000000181D000D0
		public static bool operator ==(InternedString a, Substring b); // 0x0000000181CFFE80-0x0000000181CFFEF0
		public static bool operator !=(InternedString a, Substring b); // 0x0000000181D000D0-0x0000000181D00150
		public static implicit operator Substring(string s); // 0x0000000181CFFF60-0x0000000181CFFFC0
	}
}
