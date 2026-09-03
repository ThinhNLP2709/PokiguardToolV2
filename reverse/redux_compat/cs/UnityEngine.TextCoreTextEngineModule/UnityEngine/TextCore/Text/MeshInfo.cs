/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.TextCore.LowLevel;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct MeshInfo // TypeDefIndex: 12652
	{
		// Fields
		public int vertexCount; // 0x00
		public TextCoreVertex[] vertexData; // 0x08
		public Material material; // 0x10
		[Ignore]
		public int vertexBufferSize; // 0x18
		[Ignore]
		public bool applySDF; // 0x1C
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal GlyphRenderMode glyphRenderMode; // 0x20
	
		// Constructors
		public MeshInfo(int size, bool isIMGUI); // 0x0000000182305E70-0x0000000182305F20
	
		// Methods
		internal void ResizeMeshInfo(int size, bool isIMGUI); // 0x0000000182305E00-0x0000000182305E70
		internal void Clear(bool uploadChanges); // 0x0000000182305DB0-0x0000000182305E00
		internal void ClearUnusedVertices(); // 0x0000000182305D60-0x0000000182305DB0
	}
}
