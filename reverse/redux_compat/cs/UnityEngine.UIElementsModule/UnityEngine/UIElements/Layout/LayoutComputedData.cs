/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Layout
{
	internal struct LayoutComputedData // TypeDefIndex: 5187
	{
		// Fields
		public unsafe fixed /* 0x00000000-0x00000000 */ float Position[0]; // 0x00
		public unsafe fixed /* 0x00000000-0x00000000 */ float Dimensions[0]; // 0x10
		public unsafe fixed /* 0x00000000-0x00000000 */ float Margin[0]; // 0x18
		public unsafe fixed /* 0x00000000-0x00000000 */ float Border[0]; // 0x30
		public unsafe fixed /* 0x00000000-0x00000000 */ float Padding[0]; // 0x48
		public LayoutDirection Direction; // 0x60
		public uint ComputedFlexBasisGeneration; // 0x64
		public float ComputedFlexBasis; // 0x68
		public bool HadOverflow; // 0x6C
		public uint GenerationCount; // 0x70
		public LayoutDirection LastParentDirection; // 0x74
		public float LastPointScaleFactor; // 0x78
		public unsafe fixed /* 0x00000000-0x00000000 */ float MeasuredDimensions[0]; // 0x7C
	
		// Properties
		public static LayoutComputedData Default { get; } // 0x0000000182438FA0-0x0000000182439130 
		public unsafe float* MarginBuffer { get; } // 0x0000000181DE9910-0x0000000181DE9920 
		public unsafe float* BorderBuffer { get; } // 0x0000000182438F90-0x0000000182438FA0 
		public unsafe float* PaddingBuffer { get; } // 0x0000000181F70B30-0x0000000181F70B40 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _Border_e__FixedBuffer // TypeDefIndex: 5188
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _Dimensions_e__FixedBuffer // TypeDefIndex: 5189
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _Margin_e__FixedBuffer // TypeDefIndex: 5190
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _MeasuredDimensions_e__FixedBuffer // TypeDefIndex: 5191
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _Padding_e__FixedBuffer // TypeDefIndex: 5192
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _Position_e__FixedBuffer // TypeDefIndex: 5193
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	}
}
