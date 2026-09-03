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
	internal struct LayoutCachedMeasurement // TypeDefIndex: 5186
	{
		// Fields
		public static LayoutCachedMeasurement Default; // 0x00
		public float AvailableWidth; // 0x00
		public float AvailableHeight; // 0x04
		public float ParentWidth; // 0x08
		public float ParentHeight; // 0x0C
		public LayoutMeasureMode WidthMeasureMode; // 0x10
		public LayoutMeasureMode HeightMeasureMode; // 0x14
		public float ComputedWidth; // 0x18
		public float ComputedHeight; // 0x1C
		private unsafe void* m_NextMeasurementCachePtr; // 0x20
	
		// Properties
		public unsafe LayoutCachedMeasurement* NextMeasurementCache { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		static LayoutCachedMeasurement(); // 0x0000000182438F20-0x0000000182438F90
	
		// Methods
		[IsReadOnly]
		public override string ToString(); // 0x0000000182438B70-0x0000000182438F20
	}
}
