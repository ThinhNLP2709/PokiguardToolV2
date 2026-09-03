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
	public struct BitArray64 : IBitArray // TypeDefIndex: 5735
	{
		// Fields
		[SerializeField]
		private ulong data; // 0x00
	
		// Properties
		public uint capacity { get; } // 0x0000000180A2FB60-0x0000000180A2FB70 
		public bool allFalse { get; } // 0x0000000180E87410-0x0000000180E87420 
		public bool allTrue { get; } // 0x0000000181EA4830-0x0000000181EA4840 
		public string humanizedData { get; } // 0x0000000181EA4840-0x0000000181EA4980 
		public bool this[uint index] { get => default; set {} } // 0x0000000181EA4810-0x0000000181EA4830 0x0000000181EA49B0-0x0000000181EA49D0
	
		// Constructors
		public BitArray64(ulong initValue); // 0x0000000180CBE820-0x0000000180CBE830
		public BitArray64(IEnumerable<uint> bitIndexTrue); // 0x0000000181EA4770-0x0000000181EA4810
	
		// Methods
		public static BitArray64 operator ~(BitArray64 a); // 0x0000000181EA49A0-0x0000000181EA49B0
		public static BitArray64 operator |(BitArray64 a, BitArray64 b); // 0x0000000181EA4990-0x0000000181EA49A0
		public static BitArray64 operator &(BitArray64 a, BitArray64 b); // 0x0000000181EA4980-0x0000000181EA4990
		public IBitArray BitAnd(IBitArray other); // 0x0000000181EA4580-0x0000000181EA4600
		public IBitArray BitOr(IBitArray other); // 0x0000000181EA4650-0x0000000181EA46D0
		public IBitArray BitNot(); // 0x0000000181EA4600-0x0000000181EA4650
		public static bool operator ==(BitArray64 a, BitArray64 b); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool operator !=(BitArray64 a, BitArray64 b); // 0x000000018126B560-0x000000018126B570
		public override bool Equals(object obj); // 0x0000000181EA46D0-0x0000000181EA4750
		public override int GetHashCode(); // 0x0000000181EA4750-0x0000000181EA4770
	}
}
