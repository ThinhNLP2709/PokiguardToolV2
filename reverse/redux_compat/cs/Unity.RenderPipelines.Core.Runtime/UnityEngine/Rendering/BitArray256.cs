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
	public struct BitArray256 : IBitArray // TypeDefIndex: 5737
	{
		// Fields
		[SerializeField]
		private ulong data1; // 0x00
		[SerializeField]
		private ulong data2; // 0x08
		[SerializeField]
		private ulong data3; // 0x10
		[SerializeField]
		private ulong data4; // 0x18
	
		// Properties
		public uint capacity { get; } // 0x0000000180A2FB90-0x0000000180A2FBA0 
		public bool allFalse { get; } // 0x0000000181EA3BD0-0x0000000181EA3BF0 
		public bool allTrue { get; } // 0x0000000181EA3BF0-0x0000000181EA3C10 
		public string humanizedData { get; } // 0x0000000181EA3C10-0x0000000181EA3F20 
		public bool this[uint index] { get => default; set {} } // 0x0000000181EA3B80-0x0000000181EA3BD0 0x0000000181EA4050-0x0000000181EA40E0
	
		// Constructors
		public BitArray256(ulong initValue1, ulong initValue2, ulong initValue3, ulong initValue4); // 0x0000000181EA3A60-0x0000000181EA3A80
		public BitArray256(IEnumerable<uint> bitIndexTrue); // 0x0000000181EA3A80-0x0000000181EA3B80
	
		// Methods
		public static BitArray256 operator ~(BitArray256 a); // 0x0000000181EA4020-0x0000000181EA4050
		public static BitArray256 operator |(BitArray256 a, BitArray256 b); // 0x0000000181EA3F60-0x0000000181EA3FA0
		public static BitArray256 operator &(BitArray256 a, BitArray256 b); // 0x0000000181EA3F20-0x0000000181EA3F60
		public IBitArray BitAnd(IBitArray other); // 0x0000000181EA35E0-0x0000000181EA3710
		public IBitArray BitOr(IBitArray other); // 0x0000000181EA37B0-0x0000000181EA38E0
		public IBitArray BitNot(); // 0x0000000181EA3710-0x0000000181EA37B0
		public static bool operator ==(BitArray256 a, BitArray256 b); // 0x0000000181EA3FA0-0x0000000181EA3FE0
		public static bool operator !=(BitArray256 a, BitArray256 b); // 0x0000000181EA3FE0-0x0000000181EA4020
		public override bool Equals(object obj); // 0x0000000181EA38E0-0x0000000181EA39E0
		public override int GetHashCode(); // 0x0000000181EA39E0-0x0000000181EA3A60
	}
}
