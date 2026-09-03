/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct RendererListParams : IEquatable<UnityEngine.Rendering.RendererListParams> // TypeDefIndex: 8421
	{
		// Fields
		public static readonly RendererListParams Invalid; // 0x00
		public CullingResults cullingResults; // 0x00
		public DrawingSettings drawSettings; // 0x10
		public FilteringSettings filteringSettings; // 0xF0
		public ShaderTagId tagName; // 0x110
		public bool isPassTagName; // 0x114
		public NativeArray<ShaderTagId>? tagValues; // 0x118
		public NativeArray<RenderStateBlock>? stateBlocks; // 0x130
	
		// Properties
		internal int numStateBlocks { get; } // 0x00000001822652F0-0x0000000182265320 
		internal IntPtr stateBlocksPtr { get; } // 0x0000000182265320-0x0000000182265360 
		internal IntPtr tagsValuePtr { get; } // 0x0000000182265360-0x00000001822653A0 
	
		// Constructors
		public RendererListParams(CullingResults cullingResults, DrawingSettings drawSettings, FilteringSettings filteringSettings); // 0x00000001822651C0-0x00000001822652F0
	
		// Methods
		internal void Validate(); // 0x0000000182264D10-0x00000001822651C0
		public bool Equals(RendererListParams other); // 0x00000001822643D0-0x0000000182264BF0
		public override bool Equals(object obj); // 0x00000001822642A0-0x00000001822643D0
		public override int GetHashCode(); // 0x0000000182264BF0-0x0000000182264D10
	}
}
