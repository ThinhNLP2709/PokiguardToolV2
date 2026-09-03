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

namespace System
{
	public struct HashCode // TypeDefIndex: 2270
	{
		// Fields
		private static readonly uint s_seed; // 0x00
		private uint _v1; // 0x00
		private uint _v2; // 0x04
		private uint _v3; // 0x08
		private uint _v4; // 0x0C
		private uint _queue1; // 0x10
		private uint _queue2; // 0x14
		private uint _queue3; // 0x18
		private uint _length; // 0x1C
	
		// Constructors
		static HashCode(); // 0x00000001815FB920-0x00000001815FB980
	
		// Methods
		private static uint GenerateGlobalSeed(); // 0x00000001815FB3A0-0x00000001815FB3D0
		public static int Combine<T1, T2>(T1 value1, T2 value2);
		public static int Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3);
		public static int Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4);
		public static int Combine<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5);
		public static int Combine<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6);
		public static int Combine<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7);
		public static int Combine<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8);
		private static uint Rol(uint value, int count); // 0x00000001815FB690-0x00000001815FB6B0
		private static void Initialize(out uint v1, out uint v2, out uint v3, out uint v4); // 0x00000001815FB420-0x00000001815FB4F0
		private static uint Round(uint hash, uint input); // 0x00000001815FB6B0-0x00000001815FB720
		private static uint QueueRound(uint hash, uint queuedValue); // 0x00000001815FB620-0x00000001815FB690
		private static uint MixState(uint v1, uint v2, uint v3, uint v4); // 0x00000001815FB580-0x00000001815FB620
		private static uint MixEmptyState(); // 0x00000001815FB4F0-0x00000001815FB550
		private static uint MixFinal(uint hash); // 0x00000001815FB550-0x00000001815FB580
		public void Add<T>(T value);
		private void Add(int value); // 0x00000001815FB190-0x00000001815FB350
		public int ToHashCode(); // 0x00000001815FB720-0x00000001815FB920
		[Obsolete("HashCode is a mutable struct and should not be compared with other HashCodes. Use ToHashCode to retrieve the computed hash code.", true)]
		public override int GetHashCode(); // 0x00000001815FB3D0-0x00000001815FB420
		[Obsolete("HashCode is a mutable struct and should not be compared with other HashCodes.", true)]
		public override bool Equals(object obj); // 0x00000001815FB350-0x00000001815FB3A0
	}
}
