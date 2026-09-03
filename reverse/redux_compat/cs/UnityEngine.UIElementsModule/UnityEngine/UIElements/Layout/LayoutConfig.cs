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
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Layout
{
	[IsReadOnly]
	internal struct LayoutConfig // TypeDefIndex: 5170
	{
		// Fields
		private readonly LayoutDataAccess m_Access; // 0x00
		private readonly UnmanagedDataHandle m_Handle; // 0x38
	
		// Properties
		public static LayoutConfig Undefined { get; } // 0x0000000182439310-0x0000000182439380 
		public UnmanagedDataHandle Handle { get; } // 0x00000001803272A0-0x00000001803272B0 
		public ref float PointScaleFactor { get; } // 0x00000001824392B0-0x00000001824392E0 
		public ref PanelTransformFlags TransformFlags { get; } // 0x00000001824392E0-0x0000000182439310 
		public LayoutMeasureFunction Measure { get; set; } // 0x0000000182439210-0x00000001824392B0 0x0000000182439380-0x0000000182439400
		public LayoutBaselineFunction Baseline { get; } // 0x0000000182439170-0x0000000182439210 
	
		// Constructors
		internal LayoutConfig(LayoutDataAccess access, UnmanagedDataHandle handle); // 0x0000000182439140-0x0000000182439170
	}
}
