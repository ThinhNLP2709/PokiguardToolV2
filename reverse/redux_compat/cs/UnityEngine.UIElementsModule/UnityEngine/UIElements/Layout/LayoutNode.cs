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
	internal struct LayoutNode : IEquatable<LayoutNode> // TypeDefIndex: 5179
	{
		// Fields
		private readonly LayoutDataAccess m_Access; // 0x00
		private readonly UnmanagedDataHandle m_Handle; // 0x38
	
		// Properties
		public float LayoutX { get; } // 0x000000018243DEC0-0x000000018243DF00 
		public float LayoutY { get; } // 0x000000018243DF00-0x000000018243DF40 
		public float LayoutRight { get; } // 0x000000018243DE40-0x000000018243DE80 
		public float LayoutBottom { get; } // 0x000000018243DB00-0x000000018243DB40 
		public float LayoutWidth { get; } // 0x000000018243DE80-0x000000018243DEC0 
		public float LayoutHeight { get; } // 0x000000018243DB40-0x000000018243DB80 
		public float LayoutMarginLeft { get; } // 0x000000018243DBC0-0x000000018243DC30 
		public float LayoutMarginTop { get; } // 0x000000018243DCA0-0x000000018243DCE0 
		public float LayoutMarginRight { get; } // 0x000000018243DC30-0x000000018243DCA0 
		public float LayoutMarginBottom { get; } // 0x000000018243DB80-0x000000018243DBC0 
		public float LayoutPaddingLeft { get; } // 0x000000018243DD20-0x000000018243DD90 
		public float LayoutPaddingTop { get; } // 0x000000018243DE00-0x000000018243DE40 
		public float LayoutPaddingRight { get; } // 0x000000018243DD90-0x000000018243DE00 
		public float LayoutPaddingBottom { get; } // 0x000000018243DCE0-0x000000018243DD20 
		public float LayoutBorderLeft { get; } // 0x000000018243D9E0-0x000000018243DA50 
		public float LayoutBorderTop { get; } // 0x000000018243DAC0-0x000000018243DB00 
		public float LayoutBorderRight { get; } // 0x000000018243DA50-0x000000018243DAC0 
		public float LayoutBorderBottom { get; } // 0x000000018243D9A0-0x000000018243D9E0 
		public float ComputedFlexBasis { get; } // 0x000000018243D770-0x000000018243D7B0 
		public static LayoutNode Undefined { get; } // 0x000000018243DFF0-0x000000018243E060 
		public bool IsUndefined { get; } // 0x000000018243D950-0x000000018243D9A0 
		public UnmanagedDataHandle Handle { get; } // 0x00000001803272A0-0x00000001803272B0 
		public ref LayoutComputedData Layout { get; } // 0x000000018243DF40-0x000000018243DF70 
		[IsReadOnly]
		private ref LayoutData ReadOnlyStyle { get; } // 0x000000018243DF70-0x000000018243DFF0 
		internal ref LayoutCacheData Cache { get; } // 0x000000018243D740-0x000000018243D770 
		internal unsafe VisualElementTransformData* VisualElementTransformDataPtr { get; } // 0x000000018243E100-0x000000018243E130 
		internal unsafe VisualElementSelectorData* VisualElementSelectorDataPtr { get; } // 0x000000018243E0D0-0x000000018243E100 
		internal ref ComputedStyle ComputedStyle { get; } // 0x000000018243D7B0-0x000000018243D7E0 
		public bool IsDirty { get; } // 0x000000018243D8E0-0x000000018243D950 
		public bool HasNewLayout { get; set; } // 0x000000018243D870-0x000000018243D8E0 0x000000018243E380-0x000000018243E410
		public bool UsesMeasure { get; set; } // 0x000000018243E060-0x000000018243E0D0 0x000000018243E450-0x000000018243E4E0
		internal IntPtr TextGenerationInfoPtr { set; } // 0x000000018243E410-0x000000018243E450
		public LayoutConfig Config { get; set; } // 0x000000018243D7E0-0x000000018243D870 0x000000018243E340-0x000000018243E380
	
		// Constructors
		internal LayoutNode(LayoutDataAccess access, UnmanagedDataHandle handle); // 0x0000000182439140-0x0000000182439170
	
		// Methods
		public Rect GetLayoutRect(); // 0x000000018243CCB0-0x000000018243CD70
		public Vector2 GetLayoutSize(); // 0x000000018243CD70-0x000000018243CE10
		public Vector2 GetLayoutPosition(); // 0x000000018243CC10-0x000000018243CCB0
		private unsafe float GetLayoutValue(float* buffer, LayoutLayoutEdge edge); // 0x000000018243CE10-0x000000018243CEB0
		public void AddChild(LayoutNode child); // 0x000000018243C580-0x000000018243C760
		public void InsertBefore(LayoutNode nextChild, LayoutNode child); // 0x000000018243CEB0-0x000000018243D1C0
		public void RemoveChild(LayoutNode child); // 0x000000018243D350-0x000000018243D650
		public void Clear(); // 0x000000018243C990-0x000000018243CA90
		public void MarkDirty(); // 0x000000018243D1C0-0x000000018243D2E0
		public void MarkLayoutSeen(); // 0x000000018243D2E0-0x000000018243D350
		public void SoftReset(); // 0x000000018243D650-0x000000018243D740
		public bool Equals(LayoutNode other); // 0x000000018243CA90-0x000000018243CB00
		public override bool Equals(object obj); // 0x000000018243CB00-0x000000018243CBC0
		public override int GetHashCode(); // 0x000000018243CBC0-0x000000018243CC10
		public static bool operator ==(LayoutNode lhs, LayoutNode rhs); // 0x000000018243E130-0x000000018243E220
		public static bool operator !=(LayoutNode lhs, LayoutNode rhs); // 0x000000018243E220-0x000000018243E340
		public void CalculateLayout(float width = 0F / 0F /* Metadata: 0x00660AF6 */, float height = 0F / 0F /* Metadata: 0x00660AFA */); // 0x000000018243C760-0x000000018243C990
	}
}
