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
	public struct BitArray32 : IBitArray // TypeDefIndex: 5734
	{
		// Fields
		[SerializeField]
		private uint data; // 0x00
	
		// Properties
		public uint capacity { get; } // 0x0000000180A2FAE0-0x0000000180A2FAF0 
		public bool allFalse { get; } // 0x00000001819337A0-0x00000001819337B0 
		public bool allTrue { get; } // 0x0000000181EA4390-0x0000000181EA43A0 
		private string humanizedVersion { get; } // 0x0000000181EA44E0-0x0000000181EA4540 
		public string humanizedData { get; } // 0x0000000181EA43A0-0x0000000181EA44E0 
		public bool this[uint index] { get => default; set {} } // 0x0000000181EA4370-0x0000000181EA4390 0x0000000181EA4560-0x0000000181EA4580
	
		// Constructors
		public BitArray32(uint initValue); // 0x0000000180732D50-0x0000000180732D60
		public BitArray32(IEnumerable<uint> bitIndexTrue); // 0x0000000181EA42D0-0x0000000181EA4370
	
		// Methods
		public IBitArray BitAnd(IBitArray other); // 0x0000000181EA40E0-0x0000000181EA4160
		public IBitArray BitOr(IBitArray other); // 0x0000000181EA41B0-0x0000000181EA4230
		public IBitArray BitNot(); // 0x0000000181EA4160-0x0000000181EA41B0
		public static BitArray32 operator ~(BitArray32 a); // 0x0000000181EA4550-0x0000000181EA4560
		public static BitArray32 operator |(BitArray32 a, BitArray32 b); // 0x0000000181EA4540-0x0000000181EA4550
		public static BitArray32 operator &(BitArray32 a, BitArray32 b); // 0x0000000181670130-0x0000000181670140
		public static bool operator ==(BitArray32 a, BitArray32 b); // 0x0000000180A2DD00-0x0000000180A2DD10
		public static bool operator !=(BitArray32 a, BitArray32 b); // 0x0000000181CA6840-0x0000000181CA6850
		public override bool Equals(object obj); // 0x0000000181EA4230-0x0000000181EA42B0
		public override int GetHashCode(); // 0x0000000181EA42B0-0x0000000181EA42D0
	}
}
