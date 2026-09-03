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
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal interface IMeshGenerator // TypeDefIndex: 5091
	{
		// Properties
		VisualElement currentElement { set; }
		TextJobSystem textJobSystem { get; }
	
		// Methods
		void DrawText(List<NativeSlice<Vertex>> vertices, List<NativeSlice<ushort>> indices, List<Texture2D> atlases, List<GlyphRenderMode> renderModes, List<float> sdfScales, bool usesPerGlyphTextCoreSettings = false /* Metadata: 0x00660A8D */);
		void DrawText(List<NativeSlice<Vertex>> vertices, List<NativeSlice<ushort>> indices, List<Material> materials, List<GlyphRenderMode> renderModes, bool usesPerGlyphTextCoreSettings = false /* Metadata: 0x00660A8E */);
		void DrawRectangle(MeshGenerator.RectangleParams rectParams, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A8F */);
		void DrawGradientRectangle(MeshGenerator.RectangleParams rectParams, VectorImage gradientVI, BackgroundGradient gradient, Rect gradientRect, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A90 */);
		void DrawBorder(MeshGenerator.BorderParams borderParams, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A91 */);
		void DrawRectangleRepeat(MeshGenerator.RectangleParams rectParams, Rect totalRect, float scaledPixelsPerPoint, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A92 */);
		void ScheduleJobs(MeshGenerationContext mgc);
	}
}
