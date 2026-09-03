/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.IntegerTime
{
	[Serializable]
	[NativeHeader("Runtime/Input/RationalTime.h")]
	public struct RationalTime // TypeDefIndex: 7387
	{
		// Fields
		[SerializeField]
		private long m_Count; // 0x00
		[SerializeField]
		private TicksPerSecond m_TicksPerSecond; // 0x08
	
		// Properties
		public long Count { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Nested types
		[Serializable]
		public struct TicksPerSecond : IEquatable<TicksPerSecond> // TypeDefIndex: 7388
		{
			// Fields
			[SerializeField]
			private uint m_Numerator; // 0x00
			[SerializeField]
			private uint m_Denominator; // 0x04
			public static readonly TicksPerSecond DefaultTicksPerSecond; // 0x00
			public static readonly TicksPerSecond TicksPerSecond24; // 0x08
			public static readonly TicksPerSecond TicksPerSecond25; // 0x10
			public static readonly TicksPerSecond TicksPerSecond30; // 0x18
			public static readonly TicksPerSecond TicksPerSecond50; // 0x20
			public static readonly TicksPerSecond TicksPerSecond60; // 0x28
			public static readonly TicksPerSecond TicksPerSecond120; // 0x30
			public static readonly TicksPerSecond TicksPerSecond2397; // 0x38
			public static readonly TicksPerSecond TicksPerSecond2425; // 0x40
			public static readonly TicksPerSecond TicksPerSecond2997; // 0x48
			public static readonly TicksPerSecond TicksPerSecond5994; // 0x50
			public static readonly TicksPerSecond TicksPerSecond11988; // 0x58
			internal static readonly TicksPerSecond DiscreteTimeRate; // 0x60
	
			// Constructors
			public TicksPerSecond(uint num, uint den = 1 /* Metadata: 0x0069D18C */); // 0x000000018219AC60-0x000000018219AD40
			static TicksPerSecond(); // 0x000000018219A9A0-0x000000018219AC60
	
			// Methods
			[IsReadOnly]
			public bool Equals(TicksPerSecond rhs); // 0x000000018219A7A0-0x000000018219A7C0
			[IsReadOnly]
			public override bool Equals(object rhs); // 0x000000018219A7C0-0x000000018219A860
			[IsReadOnly]
			public override int GetHashCode(); // 0x000000018219A890-0x000000018219A8F0
			private static void Simplify(ref uint num, ref uint den); // 0x000000018219A8F0-0x000000018219A9A0
			private static uint Gcd(uint a, uint b); // 0x000000018219A860-0x000000018219A890
		}
	
		// Methods
		public static explicit operator DiscreteTime(RationalTime t); // 0x0000000182192430-0x00000001821924F0
	}
}
