/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class MeshGenerator : IMeshGenerator, IDisposable // TypeDefIndex: 5092
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel; // 0x00
		private static readonly ProfilerMarker k_MarkerDrawRectangle; // 0x10
		private static readonly ProfilerMarker k_MarkerDrawBorder; // 0x18
		private static readonly ProfilerMarker k_MarkerDrawVectorImage; // 0x20
		private static readonly ProfilerMarker k_MarkerDrawRectangleRepeat; // 0x28
		private static readonly int k_GradientScaleId; // 0x30
		private MeshGenerationContext m_MeshGenerationContext; // 0x10
		private List<RepeatRectUV>[] m_RepeatRectUVList; // 0x18
		private NativePagedList<BackgroundRepeatInstance> m_BackgroundRepeatInstanceList; // 0x20
		private GCHandlePool m_GCHandlePool; // 0x28
		private NativeArray<TessellationJobParameters> m_JobParameters; // 0x30
		[CompilerGenerated]
		private VisualElement _currentElement_k__BackingField; // 0x40
		[CompilerGenerated]
		private TextJobSystem _textJobSystem_k__BackingField; // 0x48
		private TextInfo m_TextInfo; // 0x50
		private UnityEngine.TextCore.Text.TextGenerationSettings m_Settings; // 0x58
		private NativeTextBuffer m_NativeTextBuffer; // 0x60
		private List<NativeSlice<Vertex>> m_VerticesArray; // 0x78
		private List<NativeSlice<ushort>> m_IndicesArray; // 0x80
		private List<Texture2D> m_Atlases; // 0x88
		private List<float> m_SdfScales; // 0x90
		private List<GlyphRenderMode> m_RenderModes; // 0x98
		private MeshGenerationCallback m_OnMeshGenerationDelegate; // 0xA0
		private List<TessellationJobParameters> m_TesselationJobParameters; // 0xA8
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0xB0
	
		// Properties
		public VisualElement currentElement { [CompilerGenerated] set; } // 0x0000000180378120-0x0000000180378130
		public TextJobSystem textJobSystem { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		internal bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807186D0-0x00000001807186E0 0x0000000180718740-0x0000000180718750
	
		// Nested types
		private struct RepeatRectUV // TypeDefIndex: 5093
		{
			// Fields
			public Rect rect; // 0x00
			public Rect uv; // 0x10
		}
	
		public struct BackgroundRepeatInstance // TypeDefIndex: 5094
		{
			// Fields
			public Rect rect; // 0x00
			public Rect backgroundRepeatRect; // 0x10
			public Rect uv; // 0x20
		}
	
		public struct BorderParams // TypeDefIndex: 5095
		{
			// Fields
			public Rect rect; // 0x00
			public Color playmodeTintColor; // 0x10
			public Color leftColor; // 0x20
			public Color topColor; // 0x30
			public Color rightColor; // 0x40
			public Color bottomColor; // 0x50
			public float leftWidth; // 0x60
			public float topWidth; // 0x64
			public float rightWidth; // 0x68
			public float bottomWidth; // 0x6C
			public Vector2 topLeftRadius; // 0x70
			public Vector2 topRightRadius; // 0x78
			public Vector2 bottomRightRadius; // 0x80
			public Vector2 bottomLeftRadius; // 0x88
			internal ColorId leftColorId; // 0x90
			internal ColorId topColorId; // 0x94
			internal ColorId rightColorId; // 0x98
			internal ColorId bottomColorId; // 0x9C
	
			// Methods
			internal void ToNativeParams(out MeshBuilderNative.NativeBorderParams nativeBorderParams); // 0x000000018241F780-0x000000018241F8A0
		}
	
		public struct RectangleParams // TypeDefIndex: 5096
		{
			// Fields
			public Rect rect; // 0x00
			public Rect uv; // 0x10
			public Color color; // 0x20
			public Rect subRect; // 0x30
			public Rect backgroundRepeatRect; // 0x40
			public NativePagedList<BackgroundRepeatInstance> backgroundRepeatInstanceList; // 0x50
			public int backgroundRepeatInstanceListStartIndex; // 0x58
			public int backgroundRepeatInstanceListEndIndex; // 0x5C
			public BackgroundPosition backgroundPositionX; // 0x60
			public BackgroundPosition backgroundPositionY; // 0x6C
			public BackgroundRepeat backgroundRepeat; // 0x78
			public BackgroundSize backgroundSize; // 0x80
			public Texture texture; // 0x98
			public Sprite sprite; // 0xA0
			public VectorImage vectorImage; // 0xA8
			public ScaleMode scaleMode; // 0xB0
			public Color playmodeTintColor; // 0xB4
			public Vector2 topLeftRadius; // 0xC4
			public Vector2 topRightRadius; // 0xCC
			public Vector2 bottomRightRadius; // 0xD4
			public Vector2 bottomLeftRadius; // 0xDC
			public Vector2 contentSize; // 0xE4
			public Vector2 textureSize; // 0xEC
			public int leftSlice; // 0xF4
			public int topSlice; // 0xF8
			public int rightSlice; // 0xFC
			public int bottomSlice; // 0x100
			public float sliceScale; // 0x104
			internal Rect spriteGeomRect; // 0x108
			public Vector4 rectInset; // 0x118
			internal ColorId colorId; // 0x128
			internal MeshGenerationContext.MeshFlags meshFlags; // 0x12C
			public Vector2 uvTopLeft; // 0x130
			public Vector2 uvTopRight; // 0x138
			public Vector2 uvBottomRight; // 0x140
			public Vector2 uvBottomLeft; // 0x148
			public bool uvCornersValid; // 0x150
	
			// Methods
			private static void AdjustUVsForScaleMode(Rect rect, Rect uv, Texture texture, ScaleMode scaleMode, out Rect rectOut, out Rect uvOut); // 0x0000000182425E70-0x0000000182426070
			private static void AdjustSpriteUVsForScaleMode(Rect containerRect, Rect srcRect, Rect spriteGeomRect, Sprite sprite, ScaleMode scaleMode, out Rect rectOut, out Rect uvOut); // 0x0000000182425820-0x0000000182425E70
			internal static Rect RectIntersection(Rect a, Rect b); // 0x0000000182427600-0x00000001824277D0
			private static Rect ComputeGeomRect(Sprite sprite); // 0x00000001824261B0-0x00000001824262A0
			private static Rect ComputeUVRect(Sprite sprite); // 0x00000001824262A0-0x0000000182426390
			private static Rect ApplyPackingRotation(Rect uv, SpritePackingRotation rotation); // 0x0000000182426070-0x00000001824261B0
			public static RectangleParams MakeTextured(Rect rect, Rect uv, Texture texture, ScaleMode scaleMode, Color playModeTintColor); // 0x0000000182427340-0x00000001824274F0
			public static RectangleParams MakeSprite(Rect containerRect, Rect subRect, Sprite sprite, ScaleMode scaleMode, Color playModeTintColor, bool hasRadius, ref Vector4 slices, bool useForRepeat = false /* Metadata: 0x00660A9D */); // 0x0000000182426450-0x0000000182427340
			public static RectangleParams MakeVectorTextured(Rect rect, Rect uv, VectorImage vectorImage, ScaleMode scaleMode, Color playModeTintColor); // 0x00000001824274F0-0x0000000182427600
			internal bool HasRadius(float epsilon); // 0x0000000182426390-0x0000000182426400
			internal bool HasSlices(float epsilon); // 0x0000000182426400-0x0000000182426450
			internal void ToNativeParams(out MeshBuilderNative.NativeRectParams nativeRectParams); // 0x00000001824277D0-0x0000000182427990
		}
	
		internal struct GradientUVParams // TypeDefIndex: 5097
		{
			// Fields
			public GradientType type; // 0x00
			public float angle; // 0x04
			public Vector2 position; // 0x08
			public BackgroundGradientSize size; // 0x10
			public Rect rect; // 0x14
		}
	
		private struct TessellationJobParameters // TypeDefIndex: 5098
		{
			// Fields
			public bool isBorderJob; // 0x00
			public DrawPhase phase; // 0x01
			public MeshBuilderNative.NativeRectParams rectParams; // 0x08
			public BorderParams borderParams; // 0x140
			public UnsafeMeshGenerationNode node; // 0x1E0
			public IntPtr gradientVI; // 0x1E8
			public GradientUVParams gradientUVs; // 0x1F0
		}
	
		private struct TessellationJob : IJobParallelFor // TypeDefIndex: 5099
		{
			// Fields
			[ReadOnly]
			public TempMeshAllocator allocator; // 0x00
			[ReadOnly]
			public NativeSlice<TessellationJobParameters> jobParameters; // 0x08
	
			// Methods
			public void Execute(int i); // 0x0000000182434C30-0x00000001824352E0
			private T ExtractHandle<T>(IntPtr handlePtr)
				where T : class;
			private void DrawBorder(UnsafeMeshGenerationNode node, ref BorderParams borderParams, DrawPhase phase); // 0x0000000182432F20-0x0000000182433300
			private void DrawRectangle(UnsafeMeshGenerationNode node, ref MeshBuilderNative.NativeRectParams rectParams, Texture tex, DrawPhase phase); // 0x00000001824337A0-0x00000001824340D0
			private void DrawGradientRectangle(UnsafeMeshGenerationNode node, ref MeshBuilderNative.NativeRectParams rectParams, Texture tex, VectorImage gradientVI, GradientUVParams uvp, DrawPhase phase); // 0x0000000182433300-0x00000001824337A0
			private void DrawSprite(UnsafeMeshGenerationNode node, ref MeshBuilderNative.NativeRectParams rectParams, Sprite sprite, DrawPhase phase); // 0x00000001824340D0-0x0000000182434670
			private void DrawVectorImage(UnsafeMeshGenerationNode node, ref MeshBuilderNative.NativeRectParams rectParams, VectorImage vi, DrawPhase phase); // 0x0000000182434670-0x0000000182434C30
		}
	
		// Constructors
		public MeshGenerator(MeshGenerationContext mgc); // 0x000000018241C250-0x000000018241C710
		static MeshGenerator(); // 0x000000018241C0A0-0x000000018241C250
	
		// Methods
		private static Vector2 ConvertBorderRadiusPercentToPoints(Vector2 borderRectSize, Length length); // 0x0000000182416B10-0x0000000182416B70
		public static void GetVisualElementRadii(VisualElement ve, out Vector2 topLeft, out Vector2 bottomLeft, out Vector2 topRight, out Vector2 bottomRight); // 0x000000018241AED0-0x000000018241B120
		public static void AdjustBackgroundSizeForBorders(VisualElement visualElement, ref RectangleParams rectParams); // 0x00000001824163B0-0x0000000182416740
		public void DrawText(List<NativeSlice<Vertex>> vertices, List<NativeSlice<ushort>> indices, List<Material> materials, List<GlyphRenderMode> renderModes, bool usesPerGlyphTextCoreSettings = false /* Metadata: 0x00660A93 */); // 0x000000018241AA20-0x000000018241AED0
		public void DrawText(List<NativeSlice<Vertex>> vertices, List<NativeSlice<ushort>> indices, List<Texture2D> atlases, List<GlyphRenderMode> renderModes, List<float> sdfScales, bool usesPerGlyphTextCoreSettings = false /* Metadata: 0x00660A94 */); // 0x000000018241A7D0-0x000000018241AA20
		internal static Vertex ConvertTextVertexToUIRVertex(ref TextCoreVertex vertex, Vector2 posOffset, float inverseScale, bool isDynamicColor = false /* Metadata: 0x00660A95 */, bool isColorGlyph = false /* Metadata: 0x00660A96 */, bool isTextCore = false /* Metadata: 0x00660A97 */); // 0x00000001823B25A0-0x00000001823B2740
		private void MakeText(Texture texture, NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, bool isSdf, float sdfScale, float sharpness, bool multiChannel, bool usesPerGlyphTextCoreSettings = false /* Metadata: 0x00660A98 */); // 0x000000018241B120-0x000000018241B2C0
		public void DrawRectangle(RectangleParams rectParams, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A99 */); // 0x0000000182419A60-0x000000018241A7D0
		public void DrawGradientRectangle(RectangleParams rectParams, VectorImage gradientVI, BackgroundGradient gradient, Rect gradientRect, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A9A */); // 0x00000001824194A0-0x0000000182419910
		public void DrawBorder(BorderParams borderParams, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A9B */); // 0x00000001824191B0-0x00000001824194A0
		public void DrawRectangleRepeat(RectangleParams rectParams, Rect totalRect, float scaledPixelsPerPoint, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660A9C */); // 0x0000000182419910-0x0000000182419A60
		private void DoDrawRectangleRepeat(ref RectangleParams rectParams, Rect totalRect, float scaledPixelsPerPoint, DrawPhase phase); // 0x0000000182416CE0-0x00000001824191B0
		private void StampRectangleWithSubRect(RectangleParams rectParams, Rect targetRect, Rect totalRect, Rect targetUV, ref NativePagedList<BackgroundRepeatInstance> backgroundRepeatInstanceList, DrawPhase phase); // 0x000000018241B6B0-0x000000018241C0A0
		private static void AdjustSpriteWinding(Vector2[] vertices, ushort[] indices, NativeSlice<ushort> newIndices); // 0x0000000182416740-0x0000000182416B10
		public void ScheduleJobs(MeshGenerationContext mgc); // 0x000000018241B320-0x000000018241B6B0
		private void OnMeshGeneration(MeshGenerationContext ctx, object data); // 0x000000018241B2C0-0x000000018241B320
		public void Dispose(); // 0x0000000182416B70-0x0000000182416C40
		private void Dispose(bool disposing); // 0x0000000182416C40-0x0000000182416CE0
	}
}
