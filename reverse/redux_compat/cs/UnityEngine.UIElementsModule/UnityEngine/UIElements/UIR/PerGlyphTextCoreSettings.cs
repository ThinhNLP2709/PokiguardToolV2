/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class PerGlyphTextCoreSettings // TypeDefIndex: 5117
	{
		// Fields
		private readonly RenderTreeManager m_Owner; // 0x10
		private RenderData m_Rd; // 0x18
		private List<NativeSlice<Vertex>> m_Verts; // 0x20
		private TextCoreSettings m_Baseline; // 0x28
		private bool m_OomWarned; // 0x68
	
		// Constructors
		public PerGlyphTextCoreSettings(RenderTreeManager owner); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public void Begin(RenderData rd, List<NativeSlice<Vertex>> verts, [IsReadOnly] in TextCoreSettings baseline); // 0x0000000182425230-0x00000001824252B0
		public bool End(); // 0x00000001824252B0-0x0000000182425340
		public void Reset(RenderData rd); // 0x0000000182425690-0x0000000182425820
		public void FreeAllocs(ExtraRenderData extraData); // 0x0000000182425340-0x00000001824254A0
		internal static bool InvokePostProcessVertices(PerGlyphTextCoreSettings perGlyphTcs, TextElement textElement, RenderData rd, List<NativeSlice<Vertex>> vertices, [IsReadOnly] in TextElement.GlyphsEnumerable glyphs); // 0x00000001824254A0-0x0000000182425690
	}
}
