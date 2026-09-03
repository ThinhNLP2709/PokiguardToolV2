/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.UTess
{
	internal struct IntersectionCompare : IComparer<int2> // TypeDefIndex: 14981
	{
		// Fields
		public Array<double2> points; // 0x00
		public Array<int2> edges; // 0x20
		public unsafe fixed /* 0x00000000-0x00000000 */ double xvasort[0]; // 0x40
		public unsafe fixed /* 0x00000000-0x00000000 */ double xvbsort[0]; // 0x60
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _xvasort_e__FixedBuffer // TypeDefIndex: 14982
		{
			// Fields
			public double FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _xvbsort_e__FixedBuffer // TypeDefIndex: 14983
		{
			// Fields
			public double FixedElementField; // 0x00
		}
	
		// Methods
		public int Compare(int2 a, int2 b); // 0x0000000181C32620-0x0000000181C32910
	}
}
