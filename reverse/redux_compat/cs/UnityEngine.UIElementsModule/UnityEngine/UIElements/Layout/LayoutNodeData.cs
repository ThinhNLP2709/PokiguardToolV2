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
	internal struct LayoutNodeData // TypeDefIndex: 5196
	{
		// Fields
		public static LayoutNodeData Default; // 0x00
		public FixedBuffer2<Length> ResolvedDimensions; // 0x00
		public UnmanagedDataHandle Config; // 0x10
		public UnmanagedDataHandle Parent; // 0x18
		public UnmanagedDataHandle FirstChild; // 0x20
		public UnmanagedDataHandle NextSibling; // 0x28
		public UnmanagedDataHandle PrevSiblingRing; // 0x30
		private UnmanagedDataHandle NextLayoutChild; // 0x38
		private FlexStatus Status; // 0x40
		private float TargetSize; // 0x44
		public int LineIndex; // 0x48
		public IntPtr TextGenerationInfoPtr; // 0x50
	
		// Properties
		public bool HasNewLayout { get; set; } // 0x000000018243C4D0-0x000000018243C4E0 0x000000018243C500-0x000000018243C520
		public bool IsDirty { get; set; } // 0x000000018243C4E0-0x000000018243C4F0 0x000000018243C520-0x000000018243C540
		public bool UsesMeasure { get; set; } // 0x000000018243C4F0-0x000000018243C500 0x000000018243C560-0x000000018243C580
		public bool UsesBaseline { set; } // 0x000000018243C540-0x000000018243C560
	
		// Nested types
		[Flags]
		internal enum FlexStatus // TypeDefIndex: 5197
		{
			IsDirty = 1,
			HasNewLayout = 4,
			Fixed = 8,
			MinViolation = 16,
			MaxViolation = 32,
			DependsOnParentSize = 64,
			UsesMeasure = 128,
			UsesBaseline = 256
		}
	
		// Constructors
		static LayoutNodeData(); // 0x000000018243C420-0x000000018243C4D0
	}
}
