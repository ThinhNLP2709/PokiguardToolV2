/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections
{
	internal static class HashHelpers // TypeDefIndex: 3489
	{
		// Fields
		public static readonly int[] primes; // 0x00
		private static ConditionalWeakTable<object, SerializationInfo> s_serializationInfoTable; // 0x08
	
		// Properties
		internal static ConditionalWeakTable<object, SerializationInfo> SerializationInfoTable { get; } // 0x0000000181599CE0-0x0000000181599D90 
	
		// Constructors
		static HashHelpers(); // 0x0000000181599BF0-0x0000000181599CE0
	
		// Methods
		public static bool IsPrime(int candidate); // 0x0000000181599B40-0x0000000181599BF0
		public static int GetPrime(int min); // 0x00000001815998F0-0x0000000181599B40
		public static int ExpandPrime(int oldSize); // 0x0000000181599870-0x00000001815998F0
	}
}
