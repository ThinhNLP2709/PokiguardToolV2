/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.IntegerTime
{
	[Serializable]
	public struct DiscreteTime : IEquatable<Unity.IntegerTime.DiscreteTime>, IFormattable, IComparable<Unity.IntegerTime.DiscreteTime> // TypeDefIndex: 7386
	{
		// Fields
		[SerializeField]
		public long Value; // 0x00
		public static readonly DiscreteTime Zero; // 0x00
		public static readonly DiscreteTime MinValue; // 0x08
		public static readonly DiscreteTime MaxValue; // 0x10
		private static readonly int TicksPerSecondBits; // 0x18
		private static readonly int NonPow2TpsBits; // 0x1C
	
		// Constructors
		public DiscreteTime(float v); // 0x000000018218C440-0x000000018218C4B0
		public DiscreteTime(double v); // 0x000000018218C3D0-0x000000018218C440
		private DiscreteTime(long v, int _); // 0x0000000180CBE820-0x0000000180CBE830
		static DiscreteTime(); // 0x000000018218C290-0x000000018218C3D0
	
		// Methods
		public static DiscreteTime FromTicks(long v); // 0x0000000180370C60-0x0000000180370C70
		public static explicit operator float(DiscreteTime d); // 0x000000018218C520-0x000000018218C540
		public static explicit operator double(DiscreteTime d); // 0x000000018218C500-0x000000018218C520
		public static bool operator !=(DiscreteTime lhs, DiscreteTime rhs); // 0x000000018126B560-0x000000018126B570
		public static bool operator >(DiscreteTime lhs, DiscreteTime rhs); // 0x0000000181620E20-0x0000000181620E30
		public static bool operator >=(DiscreteTime lhs, DiscreteTime rhs); // 0x0000000181620E10-0x0000000181620E20
		public static DiscreteTime operator +(DiscreteTime lhs, DiscreteTime rhs); // 0x000000018218C4B0-0x000000018218C500
		public static DiscreteTime operator -(DiscreteTime lhs, DiscreteTime rhs); // 0x000000018218C540-0x000000018218C5A0
		[IsReadOnly]
		public bool Equals(DiscreteTime rhs); // 0x0000000180DF5FE0-0x0000000180DF5FF0
		[IsReadOnly]
		public override bool Equals(object o); // 0x000000018218C0F0-0x000000018218C180
		[IsReadOnly]
		public override int GetHashCode(); // 0x000000018218C180-0x000000018218C190
		[IsReadOnly]
		public override string ToString(); // 0x000000018218C220-0x000000018218C290
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x000000018218C190-0x000000018218C220
		[IsReadOnly]
		public int CompareTo(DiscreteTime other); // 0x000000018218C0E0-0x000000018218C0F0
	}
}
