/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 41: UnityEngine.UIModule.dll - Assembly: UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15192-15207

namespace UnityEngine
{
	[NativeClass("UI::CanvasRenderer", PersistentTypeId = 222)]
	[NativeHeader("Modules/UI/CanvasRenderer.h")]
	[UIModuleHelpURL("class-CanvasRenderer")]
	public sealed class CanvasRenderer : Component // TypeDefIndex: 15198
	{
		// Fields
		[CompilerGenerated]
		private bool _isMask_k__BackingField; // 0x18
	
		// Properties
		public bool hasPopInstruction { get; set; } // 0x000000018257C3A0-0x000000018257C400 0x000000018257C8E0-0x000000018257C940
		public int materialCount { get; set; } // 0x000000018257C4E0-0x000000018257C540 0x000000018257C980-0x000000018257C9E0
		public int popMaterialCount { get; set; } // 0x000000018257C580-0x000000018257C5E0 0x000000018257CA20-0x000000018257CA80
		public int absoluteDepth { get; } // 0x000000018257C060-0x000000018257C0C0 
		public bool hasMoved { get; } // 0x000000018257C300-0x000000018257C360 
		public bool cullTransparentMesh { get; set; } // 0x000000018257C1C0-0x000000018257C220 0x000000018257C780-0x000000018257C7E0
		[NativeProperty("RectClipping", false, TargetType.Function)]
		public bool hasRectClipping { get; } // 0x000000018257C440-0x000000018257C4A0 
		[NativeProperty("Depth", false, TargetType.Function)]
		public int relativeDepth { get; } // 0x000000018257C620-0x000000018257C680 
		[NativeProperty("ShouldCull", false, TargetType.Function)]
		public bool cull { get; set; } // 0x000000018257C260-0x000000018257C2C0 0x000000018257C830-0x000000018257C890
		[Obsolete("isMask is no longer supported.See EnableClipping for vertex clipping configuration", false)]
		public bool isMask { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		public Vector2 clippingSoftness { get; set; } // 0x000000018257C110-0x000000018257C180 0x000000018257C6D0-0x000000018257C730
	
		// Constructors
		public CanvasRenderer(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public void SetColor(Color color); // 0x0000000182579FB0-0x000000018257A010
		public Color GetColor(); // 0x00000001825796B0-0x0000000182579720
		public void EnableRectClipping(Rect rect); // 0x0000000182579590-0x00000001825795F0
		public void DisableRectClipping(); // 0x00000001825794E0-0x0000000182579540
		public void SetMaterial(Material material, int index); // 0x000000018257A210-0x000000018257A2A0
		public Material GetMaterial(int index); // 0x0000000182579890-0x0000000182579930
		public void SetPopMaterial(Material material, int index); // 0x000000018257A3D0-0x000000018257A460
		public Material GetPopMaterial(int index); // 0x0000000182579A40-0x0000000182579AE0
		public void SetTexture(Texture texture); // 0x000000018257A740-0x000000018257A7C0
		public int GetSecondaryTextureCount(); // 0x0000000182579B20-0x0000000182579B80
		public void SetSecondaryTextureCount(int size); // 0x000000018257A4A0-0x000000018257A500
		public string GetSecondaryTextureName(int index); // 0x0000000182579BD0-0x0000000182579CD0
		public Texture2D GetSecondaryTexture(int index); // 0x0000000182579D10-0x0000000182579DB0
		public void SetSecondaryTexture(int index, string name, Texture2D texture); // 0x000000018257A560-0x000000018257A6F0
		public void SetAlphaTexture(Texture texture); // 0x0000000182579E00-0x0000000182579E80
		public void SetMesh(Mesh mesh); // 0x000000018257A2F0-0x000000018257A370
		public Mesh GetMesh(); // 0x0000000182579970-0x0000000182579A00
		public void Clear(); // 0x00000001825786B0-0x0000000182578710
		public float GetAlpha(); // 0x00000001825795F0-0x0000000182579660
		public void SetAlpha(float alpha); // 0x0000000182579E80-0x0000000182579F60
		public float GetInheritedAlpha(); // 0x0000000182579760-0x00000001825797C0
		public void SetMaterial(Material material, Texture texture); // 0x000000018257A070-0x000000018257A210
		public Material GetMaterial(); // 0x0000000182579800-0x0000000182579890
		public static void SplitUIVertexStreams(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector3> normals, List<Vector4> tangents, List<int> indices); // 0x000000018257BEF0-0x000000018257C020
		public static void SplitUIVertexStreams(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents, List<int> indices); // 0x000000018257BC40-0x000000018257BD40
		public static void SplitUIVertexStreams(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents, List<Vector4> prevPositions, List<int> indices); // 0x000000018257BD40-0x000000018257BEF0
		public static void CreateUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector3> normals, List<Vector4> tangents, List<int> indices); // 0x0000000182578E10-0x0000000182578F30
		public static void CreateUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents, List<int> indices); // 0x0000000182579370-0x00000001825794A0
		public static void CreateUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents, List<Vector4> prevPositions, List<int> indices); // 0x0000000182578F30-0x0000000182579370
		public static void AddUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector3> normals, List<Vector4> tangents); // 0x0000000182578350-0x0000000182578470
		public static void AddUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents); // 0x0000000182578580-0x0000000182578670
		public static void AddUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents, List<Vector4> prevPositions); // 0x0000000182578470-0x0000000182578580
		[Obsolete("UI System now uses meshes.Generate a mesh and use \'SetMesh\' instead", false)]
		public void SetVertices(List<UIVertex> vertices); // 0x000000018257B0E0-0x000000018257B150
		[Obsolete("UI System now uses meshes.Generate a mesh and use \'SetMesh\' instead", false)]
		public void SetVertices(UIVertex[] vertices, int size); // 0x000000018257A7C0-0x000000018257B0E0
		private static void SplitIndicesStreamsInternal(List<UIVertex> verts, List<int> indices); // 0x000000018257B150-0x000000018257B200
		[StaticAccessor("UI", StaticAccessorType.DoubleColon)]
		private static void SplitUIVertexStreamsInternal(ReadOnlySpan<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents, List<Vector4> prevPositions); // 0x000000018257B270-0x000000018257BC40
		[StaticAccessor("UI", StaticAccessorType.DoubleColon)]
		private static void CreateUIVertexStreamInternal(List<UIVertex> verts, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Color32> colors, ReadOnlySpan<Vector4> uv0S, ReadOnlySpan<Vector4> uv1S, ReadOnlySpan<Vector4> uv2S, ReadOnlySpan<Vector4> uv3S, ReadOnlySpan<Vector3> normals, ReadOnlySpan<Vector4> tangents, ReadOnlySpan<Vector4> prevPositions, ReadOnlySpan<int> indices); // 0x0000000182578780-0x0000000182578E10
		private static bool get_hasPopInstruction_Injected(IntPtr _unity_self); // 0x000000018257C360-0x000000018257C3A0
		private static void set_hasPopInstruction_Injected(IntPtr _unity_self, bool value); // 0x000000018257C890-0x000000018257C8E0
		private static int get_materialCount_Injected(IntPtr _unity_self); // 0x000000018257C4A0-0x000000018257C4E0
		private static void set_materialCount_Injected(IntPtr _unity_self, int value); // 0x000000018257C940-0x000000018257C980
		private static int get_popMaterialCount_Injected(IntPtr _unity_self); // 0x000000018257C540-0x000000018257C580
		private static void set_popMaterialCount_Injected(IntPtr _unity_self, int value); // 0x000000018257C9E0-0x000000018257CA20
		private static int get_absoluteDepth_Injected(IntPtr _unity_self); // 0x000000018257C020-0x000000018257C060
		private static bool get_hasMoved_Injected(IntPtr _unity_self); // 0x000000018257C2C0-0x000000018257C300
		private static bool get_cullTransparentMesh_Injected(IntPtr _unity_self); // 0x000000018257C180-0x000000018257C1C0
		private static void set_cullTransparentMesh_Injected(IntPtr _unity_self, bool value); // 0x000000018257C730-0x000000018257C780
		private static bool get_hasRectClipping_Injected(IntPtr _unity_self); // 0x000000018257C400-0x000000018257C440
		private static int get_relativeDepth_Injected(IntPtr _unity_self); // 0x000000018257C5E0-0x000000018257C620
		private static bool get_cull_Injected(IntPtr _unity_self); // 0x000000018257C220-0x000000018257C260
		private static void set_cull_Injected(IntPtr _unity_self, bool value); // 0x000000018257C7E0-0x000000018257C830
		private static void SetColor_Injected(IntPtr _unity_self, in Color color); // 0x0000000182579F60-0x0000000182579FB0
		private static void GetColor_Injected(IntPtr _unity_self, ); // 0x0000000182579660-0x00000001825796B0
		private static void EnableRectClipping_Injected(IntPtr _unity_self, in Rect rect); // 0x0000000182579540-0x0000000182579590
		private static void get_clippingSoftness_Injected(IntPtr _unity_self, ); // 0x000000018257C0C0-0x000000018257C110
		private static void set_clippingSoftness_Injected(IntPtr _unity_self, in Vector2 value); // 0x000000018257C680-0x000000018257C6D0
		private static void DisableRectClipping_Injected(IntPtr _unity_self); // 0x00000001825794A0-0x00000001825794E0
		private static void SetMaterial_Injected(IntPtr _unity_self, IntPtr material, int index); // 0x000000018257A010-0x000000018257A070
		private static IntPtr GetMaterial_Injected(IntPtr _unity_self, int index); // 0x00000001825797C0-0x0000000182579800
		private static void SetPopMaterial_Injected(IntPtr _unity_self, IntPtr material, int index); // 0x000000018257A370-0x000000018257A3D0
		private static IntPtr GetPopMaterial_Injected(IntPtr _unity_self, int index); // 0x0000000182579A00-0x0000000182579A40
		private static void SetTexture_Injected(IntPtr _unity_self, IntPtr texture); // 0x000000018257A6F0-0x000000018257A740
		private static int GetSecondaryTextureCount_Injected(IntPtr _unity_self); // 0x0000000182579AE0-0x0000000182579B20
		private static void SetSecondaryTextureCount_Injected(IntPtr _unity_self, int size); // 0x000000018257A460-0x000000018257A4A0
		private static void GetSecondaryTextureName_Injected(IntPtr _unity_self, int index, ); // 0x0000000182579B80-0x0000000182579BD0
		private static IntPtr GetSecondaryTexture_Injected(IntPtr _unity_self, int index); // 0x0000000182579CD0-0x0000000182579D10
		private static void SetSecondaryTexture_Injected(IntPtr _unity_self, int index, ref ManagedSpanWrapper name, IntPtr texture); // 0x000000018257A500-0x000000018257A560
		private static void SetAlphaTexture_Injected(IntPtr _unity_self, IntPtr texture); // 0x0000000182579DB0-0x0000000182579E00
		private static void SetMesh_Injected(IntPtr _unity_self, IntPtr mesh); // 0x000000018257A2A0-0x000000018257A2F0
		private static IntPtr GetMesh_Injected(IntPtr _unity_self); // 0x0000000182579930-0x0000000182579970
		private static void Clear_Injected(IntPtr _unity_self); // 0x0000000182578670-0x00000001825786B0
		private static float GetInheritedAlpha_Injected(IntPtr _unity_self); // 0x0000000182579720-0x0000000182579760
		private static void SplitUIVertexStreamsInternal_Injected(ref ManagedSpanWrapper verts, ref BlittableListWrapper positions, ref BlittableListWrapper colors, ref BlittableListWrapper uv0S, ref BlittableListWrapper uv1S, ref BlittableListWrapper uv2S, ref BlittableListWrapper uv3S, ref BlittableListWrapper normals, ref BlittableListWrapper tangents, ref BlittableListWrapper prevPositions); // 0x000000018257B200-0x000000018257B270
		private static void CreateUIVertexStreamInternal_Injected(ref BlittableListWrapper verts, ref ManagedSpanWrapper positions, ref ManagedSpanWrapper colors, ref ManagedSpanWrapper uv0S, ref ManagedSpanWrapper uv1S, ref ManagedSpanWrapper uv2S, ref ManagedSpanWrapper uv3S, ref ManagedSpanWrapper normals, ref ManagedSpanWrapper tangents, ref ManagedSpanWrapper prevPositions, ref ManagedSpanWrapper indices); // 0x0000000182578710-0x0000000182578780
	}
}
