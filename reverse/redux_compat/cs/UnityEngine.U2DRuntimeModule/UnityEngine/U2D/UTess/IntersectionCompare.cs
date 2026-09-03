/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Mathematics;
using UnityEngine;

// Image 38: UnityEngine.U2DRuntimeModule.dll - Assembly: UnityEngine.U2DRuntimeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15050-15086

namespace UnityEngine.U2D.UTess
{
	internal struct IntersectionCompare : IComparer<int2> // TypeDefIndex: 15075
	{
		// Fields
		public Array<double2> points; // 0x00
		public Array<int2> edges; // 0x20
		public unsafe fixed /* 0x00000000-0x00000000 */ double xvasort[0]; // 0x40
		public unsafe fixed /* 0x00000000-0x00000000 */ double xvbsort[0]; // 0x60
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _xvasort_e__FixedBuffer // TypeDefIndex: 15076
		{
			// Fields
			public double FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _xvbsort_e__FixedBuffer // TypeDefIndex: 15077
		{
			// Fields
			public double FixedElementField; // 0x00
		}
	
		// Methods
		public int Compare(int2 a, int2 b); // 0x0000000182355F30-0x0000000182356220
	}
}
