/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[UsedByNativeCode]
	public struct RectInt : IEquatable<UnityEngine.RectInt>, IFormattable // TypeDefIndex: 7529
	{
		// Fields
		[SerializeField]
		private int m_XMin; // 0x00
		[SerializeField]
		private int m_YMin; // 0x04
		[SerializeField]
		private int m_Width; // 0x08
		[SerializeField]
		private int m_Height; // 0x0C
		private static readonly RectInt kZero; // 0x00
	
		// Properties
		public int x { [IsReadOnly] get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int y { [IsReadOnly] get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public int width { [IsReadOnly] get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public int height { [IsReadOnly] get; set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		public int xMin { [IsReadOnly] get; set; } // 0x00000001821BBC40-0x00000001821BBC60 0x00000001821BBD10-0x00000001821BBD80
		public int yMin { [IsReadOnly] get; set; } // 0x00000001821BBC80-0x00000001821BBCA0 0x00000001821BBD90-0x00000001821BBE00
		public int xMax { [IsReadOnly] get; set; } // 0x00000001821BBC20-0x00000001821BBC40 0x00000001821BBD00-0x00000001821BBD10
		public int yMax { [IsReadOnly] get; set; } // 0x00000001821BBC60-0x00000001821BBC80 0x00000001821BBD80-0x00000001821BBD90
		public static RectInt zero { get; } // 0x00000001821BBCA0-0x00000001821BBD00 
	
		// Constructors
		public RectInt(int xMin, int yMin, int width, int height); // 0x000000018192E480-0x000000018192E4A0
		static RectInt(); // 0x00000001821BBBE0-0x00000001821BBC20
	
		// Methods
		[IsReadOnly]
		public bool Overlaps(RectInt other); // 0x00000001821BB800-0x00000001821BB900
		[IsReadOnly]
		public override string ToString(); // 0x00000001821BBB90-0x00000001821BBBE0
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821BB900-0x00000001821BBB90
		public static bool operator !=(RectInt lhs, RectInt rhs); // 0x00000001815FB160-0x00000001815FB190
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001821BB780-0x00000001821BB800
		[IsReadOnly]
		public override bool Equals(object other); // 0x00000001821BB6B0-0x00000001821BB780
		[IsReadOnly]
		public bool Equals(RectInt other); // 0x00000001815FB130-0x00000001815FB160
		[IsReadOnly]
		public bool Equals([IsReadOnly] in RectInt other); // 0x00000001815FB130-0x00000001815FB160
	}
}
