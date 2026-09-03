/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIRMeshBuilder.bindings.h")]
	internal static class MeshBuilderNative // TypeDefIndex: 4253
	{
		// Nested types
		public struct NativeColorId // TypeDefIndex: 4254
		{
			// Fields
			public int isValid; // 0x00
			public ushort id; // 0x04
			private ushort _pad; // 0x06
		}
	
		public struct NativeBorderParams // TypeDefIndex: 4255
		{
			// Fields
			public Rect rect; // 0x00
			public Color leftColor; // 0x10
			public Color topColor; // 0x20
			public Color rightColor; // 0x30
			public Color bottomColor; // 0x40
			public float leftWidth; // 0x50
			public float topWidth; // 0x54
			public float rightWidth; // 0x58
			public float bottomWidth; // 0x5C
			public Vector2 topLeftRadius; // 0x60
			public Vector2 topRightRadius; // 0x68
			public Vector2 bottomRightRadius; // 0x70
			public Vector2 bottomLeftRadius; // 0x78
			internal NativeColorId leftColorId; // 0x80
			internal NativeColorId topColorId; // 0x88
			internal NativeColorId rightColorId; // 0x90
			internal NativeColorId bottomColorId; // 0x98
		}
	
		public struct NativeRectParams // TypeDefIndex: 4256
		{
			// Fields
			public Rect rect; // 0x00
			public Rect subRect; // 0x10
			public Rect uv; // 0x20
			public Color color; // 0x30
			public IntPtr backgroundRepeatInstanceList; // 0x40
			public int backgroundRepeatInstanceListStartIndex; // 0x48
			public int backgroundRepeatInstanceListEndIndex; // 0x4C
			public Vector2 topLeftRadius; // 0x50
			public Vector2 topRightRadius; // 0x58
			public Vector2 bottomRightRadius; // 0x60
			public Vector2 bottomLeftRadius; // 0x68
			public Rect backgroundRepeatRect; // 0x70
			public IntPtr texture; // 0x80
			public IntPtr sprite; // 0x88
			public IntPtr vectorImage; // 0x90
			public IntPtr spriteTexture; // 0x98
			public IntPtr spriteVertices; // 0xA0
			public IntPtr spriteUVs; // 0xA8
			public IntPtr spriteTriangles; // 0xB0
			public Rect spriteGeomRect; // 0xB8
			public Vector2 contentSize; // 0xC8
			public Vector2 textureSize; // 0xD0
			public float texturePixelsPerPoint; // 0xD8
			public int leftSlice; // 0xDC
			public int topSlice; // 0xE0
			public int rightSlice; // 0xE4
			public int bottomSlice; // 0xE8
			public float sliceScale; // 0xEC
			public Vector4 rectInset; // 0xF0
			public NativeColorId colorId; // 0x100
			public int meshFlags; // 0x108
			public ScaleMode scaleMode; // 0x10C
			public Vector2 uvTopLeft; // 0x110
			public Vector2 uvTopRight; // 0x118
			public Vector2 uvBottomRight; // 0x120
			public Vector2 uvBottomLeft; // 0x128
			public int uvCornersValid; // 0x130
		}
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		public static MeshWriteDataInterface MakeBorder(ref NativeBorderParams borderParams); // 0x00000001824B4150-0x00000001824B41B0
		[NativeMethod(IsThreadSafe = true)]
		public static MeshWriteDataInterface MakeSolidRect(ref NativeRectParams rectParams); // 0x00000001824B4200-0x00000001824B4260
		[NativeMethod(IsThreadSafe = true)]
		public static MeshWriteDataInterface MakeTexturedRect(ref NativeRectParams rectParams); // 0x00000001824B42B0-0x00000001824B4310
		[NativeMethod(IsThreadSafe = true)]
		public static MeshWriteDataInterface MakeVectorGraphicsStretchBackground(Vertex[] svgVertices, ushort[] svgIndices, float svgWidth, float svgHeight, Rect targetRect, Rect sourceUV, ScaleMode scaleMode, Color tint, NativeColorId colorId); // 0x00000001824B4540-0x00000001824B46A0
		[NativeMethod(IsThreadSafe = true)]
		public static MeshWriteDataInterface MakeVectorGraphics9SliceBackground(Vertex[] svgVertices, ushort[] svgIndices, float svgWidth, float svgHeight, Rect targetRect, Vector4 sliceLTRB, Color tint, NativeColorId colorId); // 0x00000001824B4380-0x00000001824B44D0
		private static void MakeBorder_Injected(ref NativeBorderParams borderParams, ); // 0x00000001824B4100-0x00000001824B4150
		private static void MakeSolidRect_Injected(ref NativeRectParams rectParams, ); // 0x00000001824B41B0-0x00000001824B4200
		private static void MakeTexturedRect_Injected(ref NativeRectParams rectParams, ); // 0x00000001824B4260-0x00000001824B42B0
		private static void MakeVectorGraphicsStretchBackground_Injected(ref ManagedSpanWrapper svgVertices, ref ManagedSpanWrapper svgIndices, float svgWidth, float svgHeight, in Rect targetRect, in Rect sourceUV, ScaleMode scaleMode, in Color tint, in NativeColorId colorId, ); // 0x00000001824B44D0-0x00000001824B4540
		private static void MakeVectorGraphics9SliceBackground_Injected(ref ManagedSpanWrapper svgVertices, ref ManagedSpanWrapper svgIndices, float svgWidth, float svgHeight, in Rect targetRect, in Vector4 sliceLTRB, in Color tint, in NativeColorId colorId, ); // 0x00000001824B4310-0x00000001824B4380
	}
}
