/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
	public struct BitArray128 : IBitArray // TypeDefIndex: 5736
	{
		// Fields
		[SerializeField]
		private ulong data1; // 0x00
		[SerializeField]
		private ulong data2; // 0x08
	
		// Properties
		public uint capacity { get; } // 0x0000000180A2FCF0-0x0000000180A2FD00 
		public bool allFalse { get; } // 0x0000000181EA2E80-0x0000000181EA2EA0 
		public bool allTrue { get; } // 0x0000000181EA2EA0-0x0000000181EA2EC0 
		public string humanizedData { get; } // 0x0000000181EA2EC0-0x0000000181EA30A0 
		public bool this[uint index] { get => default; set {} } // 0x0000000181EA2E50-0x0000000181EA2E80 0x0000000181EA3140-0x0000000181EA3190
	
		// Constructors
		public BitArray128(ulong initValue1, ulong initValue2); // 0x0000000180C13E40-0x0000000180C13E50
		public BitArray128(IEnumerable<uint> bitIndexTrue); // 0x0000000181EA2D90-0x0000000181EA2E50
	
		// Methods
		public static BitArray128 operator ~(BitArray128 a); // 0x0000000181EA3120-0x0000000181EA3140
		public static BitArray128 operator |(BitArray128 a, BitArray128 b); // 0x0000000181EA30C0-0x0000000181EA30E0
		public static BitArray128 operator &(BitArray128 a, BitArray128 b); // 0x0000000181EA30A0-0x0000000181EA30C0
		public IBitArray BitAnd(IBitArray other); // 0x0000000181EA2B00-0x0000000181EA2BA0
		public IBitArray BitOr(IBitArray other); // 0x0000000181EA2C00-0x0000000181EA2CA0
		public IBitArray BitNot(); // 0x0000000181EA2BA0-0x0000000181EA2C00
		public static bool operator ==(BitArray128 a, BitArray128 b); // 0x0000000181EA30E0-0x0000000181EA3100
		public static bool operator !=(BitArray128 a, BitArray128 b); // 0x0000000181EA3100-0x0000000181EA3120
		public override bool Equals(object obj); // 0x0000000181EA2CA0-0x0000000181EA2D50
		public override int GetHashCode(); // 0x0000000181EA2D50-0x0000000181EA2D90
	}
}
