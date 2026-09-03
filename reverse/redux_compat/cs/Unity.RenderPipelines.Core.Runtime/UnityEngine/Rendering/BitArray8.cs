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
	public struct BitArray8 : IBitArray // TypeDefIndex: 5732
	{
		// Fields
		[SerializeField]
		private byte data; // 0x00
	
		// Properties
		public uint capacity { get; } // 0x0000000180740830-0x0000000180740840 
		public bool allFalse { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public bool allTrue { get; } // 0x0000000181EA4C80-0x0000000181EA4C90 
		public string humanizedData { get; } // 0x0000000181EA4C90-0x0000000181EA4D70 
		public bool this[uint index] { get => default; set {} } // 0x0000000181EA4C60-0x0000000181EA4C80 0x0000000181EA4DC0-0x0000000181EA4DE0
	
		// Constructors
		public BitArray8(byte initValue); // 0x0000000180F21780-0x0000000180F21790
		public BitArray8(IEnumerable<uint> bitIndexTrue); // 0x0000000181EA4BC0-0x0000000181EA4C60
	
		// Methods
		public static BitArray8 operator ~(BitArray8 a); // 0x0000000181EA4DB0-0x0000000181EA4DC0
		public static BitArray8 operator |(BitArray8 a, BitArray8 b); // 0x0000000181EA4D80-0x0000000181EA4D90
		public static BitArray8 operator &(BitArray8 a, BitArray8 b); // 0x0000000181EA4D70-0x0000000181EA4D80
		public IBitArray BitAnd(IBitArray other); // 0x0000000181EA49D0-0x0000000181EA4A50
		public IBitArray BitOr(IBitArray other); // 0x0000000181EA4AA0-0x0000000181EA4B20
		public IBitArray BitNot(); // 0x0000000181EA4A50-0x0000000181EA4AA0
		public static bool operator ==(BitArray8 a, BitArray8 b); // 0x0000000181EA4D90-0x0000000181EA4DA0
		public static bool operator !=(BitArray8 a, BitArray8 b); // 0x0000000181EA4DA0-0x0000000181EA4DB0
		public override bool Equals(object obj); // 0x0000000181EA4B20-0x0000000181EA4BA0
		public override int GetHashCode(); // 0x0000000181EA4BA0-0x0000000181EA4BC0
	}
}
