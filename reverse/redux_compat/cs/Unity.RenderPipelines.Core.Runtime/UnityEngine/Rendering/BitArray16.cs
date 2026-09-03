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
	public struct BitArray16 : IBitArray // TypeDefIndex: 5733
	{
		// Fields
		[SerializeField]
		private ushort data; // 0x00
	
		// Properties
		public uint capacity { get; } // 0x00000001808F5E70-0x00000001808F5E80 
		public bool allFalse { get; } // 0x000000018123ACC0-0x000000018123ACD0 
		public bool allTrue { get; } // 0x0000000181EA3440-0x0000000181EA3450 
		public string humanizedData { get; } // 0x0000000181EA3450-0x0000000181EA3590 
		public bool this[uint index] { get => default; set {} } // 0x0000000181EA3420-0x0000000181EA3440 0x0000000181EA35C0-0x0000000181EA35E0
	
		// Constructors
		public BitArray16(ushort initValue); // 0x000000018123B250-0x000000018123B260
		public BitArray16(IEnumerable<uint> bitIndexTrue); // 0x0000000181EA3380-0x0000000181EA3420
	
		// Methods
		public static BitArray16 operator ~(BitArray16 a); // 0x0000000181EA35B0-0x0000000181EA35C0
		public static BitArray16 operator |(BitArray16 a, BitArray16 b); // 0x0000000181EA35A0-0x0000000181EA35B0
		public static BitArray16 operator &(BitArray16 a, BitArray16 b); // 0x0000000181EA3590-0x0000000181EA35A0
		public IBitArray BitAnd(IBitArray other); // 0x0000000181EA3190-0x0000000181EA3210
		public IBitArray BitOr(IBitArray other); // 0x0000000181EA3260-0x0000000181EA32E0
		public IBitArray BitNot(); // 0x0000000181EA3210-0x0000000181EA3260
		public static bool operator ==(BitArray16 a, BitArray16 b); // 0x0000000181C88C20-0x0000000181C88C30
		public static bool operator !=(BitArray16 a, BitArray16 b); // 0x0000000181C88C70-0x0000000181C88C80
		public override bool Equals(object obj); // 0x0000000181EA32E0-0x0000000181EA3360
		public override int GetHashCode(); // 0x0000000181EA3360-0x0000000181EA3380
	}
}
