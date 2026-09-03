/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEngine.Scripting;
using UnityEngine.U2D;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[ExcludeFromPreset]
	[NativeClass("Sprite", PersistentTypeId = 213)]
	[NativeHeader("Runtime/Graphics/SpriteUtility.h")]
	[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
	[NativeHeader("Runtime/2D/Common/ScriptBindings/SpritesMarshalling.h")]
	[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
	public sealed class Sprite : Object // TypeDefIndex: 7470
	{
		// Properties
		public Bounds bounds { get; } // 0x000000018219A040-0x000000018219A0B0 
		public Rect rect { get; } // 0x000000018219A360-0x000000018219A3D0 
		public Vector4 border { get; } // 0x0000000182199F80-0x0000000182199FF0 
		public Texture2D texture { get; } // 0x000000018219A530-0x000000018219A5C0 
		internal uint extrude { get; } // 0x000000018219A0F0-0x000000018219A150 
		public float pixelsPerUnit { [NativeMethod("GetPixelsToUnits")] get; } // 0x000000018219A2B0-0x000000018219A310 
		public float spriteAtlasTextureScale { [NativeMethod("GetSpriteAtlasTextureScale")] get; } // 0x000000018219A410-0x000000018219A470 
		public Texture2D associatedAlphaSplitTexture { [NativeMethod("GetAlphaTexture")] get; } // 0x0000000182199E00-0x0000000182199E90 
		public Vector2 pivot { [NativeMethod("GetPivotInPixels")] get; } // 0x000000018219A200-0x000000018219A270 
		public bool packed { get; } // 0x000000018219A150-0x000000018219A1B0 
		public SpritePackingMode packingMode { get; } // 0x0000000182197EA0-0x0000000182197F00 
		public SpritePackingRotation packingRotation { get; } // 0x0000000182197F40-0x0000000182197FA0 
		public Rect textureRect { get; } // 0x000000018219A470-0x000000018219A4F0 
		public Vector2 textureRectOffset { get; } // 0x0000000182199050-0x00000001821990C0 
		public Vector2[] vertices { [FreeFunction("SpriteAccessLegacy::GetSpriteVertices", HasExplicitThis = true)] get; } // 0x000000018219A740-0x000000018219A7A0 
		public ushort[] triangles { [FreeFunction("SpriteAccessLegacy::GetSpriteIndices", HasExplicitThis = true)] get; } // 0x000000018219A600-0x000000018219A660 
		public Vector2[] uv { [FreeFunction("SpriteAccessLegacy::GetSpriteUVs", HasExplicitThis = true)] get; } // 0x000000018219A6A0-0x000000018219A700 
		public int blendShapeCount { [NativeMethod("GetBlendShapeChannelCount")] get; } // 0x0000000182199ED0-0x0000000182199F30 
	
		// Constructors
		[RequiredByNativeCode]
		private Sprite(); // 0x0000000182199D70-0x0000000182199DC0
	
		// Methods
		internal int GetPackingMode(); // 0x0000000182197EA0-0x0000000182197F00
		internal int GetPackingRotation(); // 0x0000000182197F40-0x0000000182197FA0
		internal int GetPacked(); // 0x0000000182197E00-0x0000000182197E60
		internal Rect GetTextureRect(); // 0x0000000182199110-0x0000000182199180
		internal Vector2 GetTextureRectOffset(); // 0x0000000182199050-0x00000001821990C0
		internal Vector4 GetInnerUVs(); // 0x0000000182197C90-0x0000000182197D00
		internal Vector4 GetOuterUVs(); // 0x0000000182197D50-0x0000000182197DC0
		internal Vector4 GetPadding(); // 0x0000000182197FF0-0x0000000182198060
		[FreeFunction("SpritesBindings::CreateSpriteWithoutTextureScripting")]
		internal static Sprite CreateSpriteWithoutTextureScripting(Rect rect, Vector2 pivot, float pixelsToUnits, Texture2D texture); // 0x00000001821965A0-0x0000000182196630
		[FreeFunction("SpritesBindings::CreateSprite")]
		private static Sprite CreateSpriteInternal(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape, SecondarySpriteTexture[] secondaryTexture); // 0x0000000182196460-0x0000000182196530
		internal static Sprite CreateSprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape, SecondarySpriteTexture[] secondaryTexture); // 0x0000000182196630-0x00000001821967E0
		internal Texture2D GetSecondaryTexture(int index); // 0x0000000182198E70-0x0000000182198F10
		public int GetSecondaryTextureCount(); // 0x0000000182198DD0-0x0000000182198E30
		[FreeFunction("SpritesBindings::GetSecondaryTextures", HasExplicitThis = true)]
		public int GetSecondaryTextures([NotNull] out SecondarySpriteTexture[] secondaryTexture); // 0x0000000182198F60-0x0000000182199000
		public int GetPhysicsOutlineCount(); // 0x00000001821980A0-0x0000000182198100
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromDocs]
		[Obsolete("Sprite.GetPhysicsShapeCount is deprecated. Use Sprite.GetPhysicsOutlineCount instead (UnityUpgradable) -> GetPhysicsOutlineCount()", false)]
		public int GetPhysicsShapeCount(); // 0x00000001821980A0-0x0000000182198100
		public uint GetScriptableObjectsCount(); // 0x0000000182198C40-0x0000000182198CA0
		[FreeFunction("SpritesBindings::GetScriptableObjects", HasExplicitThis = true)]
		public uint GetScriptableObjects([NotNull] out ScriptableObject[] scriptableObjects); // 0x0000000182198CF0-0x0000000182198D90
		public bool AddScriptableObject([NotNull] ScriptableObject obj); // 0x0000000182196280-0x0000000182196340
		public bool RemoveScriptableObjectAt(uint i); // 0x0000000182199A60-0x0000000182199AC0
		public bool SetScriptableObjectAt([NotNull] ScriptableObject obj, uint i); // 0x0000000182199B20-0x0000000182199BF0
		public int GetPhysicsOutlinePointCount(int outlineIndex); // 0x0000000182198300-0x0000000182198450
		[NativeMethod("GetPhysicsOutlinePointCount")]
		private int Internal_GetPhysicsOutlinePointCount(int outlineIndex); // 0x00000001821991C0-0x0000000182199220
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromDocs]
		[Obsolete("Sprite.GetPhysicsShapePointCount is deprecated. Use Sprite.GetPhysicsOutlinePointCount instead (UnityUpgradable) -> GetPhysicsOutlinePointCount(*)", false)]
		public int GetPhysicsShapePointCount(int shapeIndex); // 0x0000000182198800-0x0000000182198950
		public int GetPhysicsOutline(int outlineIndex, List<Vector2> physicsOutline); // 0x0000000182198540-0x0000000182198670
		public ReadOnlySpan<Vector2> GetPhysicsOutline(int outlineIndex); // 0x0000000182198670-0x0000000182198800
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromDocs]
		[Obsolete("Sprite.GetPhysicsShape is deprecated. Use Sprite.GetPhysicsOutline instead (UnityUpgradable) -> GetPhysicsOutline(*)", false)]
		public int GetPhysicsShape(int shapeIndex, List<Vector2> physicsShape); // 0x0000000182198950-0x0000000182198A70
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromDocs]
		[Obsolete("Sprite.GetPhysicsShape is deprecated. Use Sprite.GetPhysicsOutline instead (UnityUpgradable) -> GetPhysicsOutline(*)", false)]
		public ReadOnlySpan<Vector2> GetPhysicsShape(int shapeIndex); // 0x0000000182198A70-0x0000000182198C00
		[FreeFunction("SpritesBindings::GetPhysicsOutline", ThrowsException = true)]
		private static void GetPhysicsOutlineImpl(Sprite sprite, int outlineIndex, [NotNull] List<Vector2> physicsOutline); // 0x0000000182198150-0x0000000182198300
		[FreeFunction("SpritesBindings::GetPhysicsOutline", ThrowsException = true)]
		private static ReadOnlySpan<Vector2> GetPhysicsOutlineSpanImpl(Sprite sprite, int outlineIndex); // 0x00000001821984A0-0x0000000182198540
		public void OverridePhysicsOutline(IList<Vector2[]> physicsOutlines); // 0x00000001821994F0-0x0000000182199930
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromDocs]
		[Obsolete("Sprite.OverridePhysicsShape is deprecated. Use Sprite.OverridePhysicsOutline instead (UnityUpgradable) -> OverridePhysicsOutline(*)", false)]
		public void OverridePhysicsShape(IList<Vector2[]> physicsShapes); // 0x0000000182199A10-0x0000000182199A20
		[FreeFunction("SpritesBindings::OverridePhysicsOutlineCount")]
		private static void OverridePhysicsOutlineCount(Sprite sprite, int physicsOutlineCount); // 0x0000000182199440-0x0000000182199490
		[FreeFunction("SpritesBindings::OverridePhysicsOutline", ThrowsException = true)]
		private static void OverridePhysicsOutline(Sprite sprite, [NotNull] Vector2[] physicsOutline, int index); // 0x0000000182199930-0x0000000182199A10
		[FreeFunction("SpritesBindings::OverrideGeometry", HasExplicitThis = true)]
		public void OverrideGeometry([NotNull] Vector2[] vertices, [NotNull] ushort[] triangles); // 0x0000000182199280-0x0000000182199400
		[FreeFunction(Name = "SpritesBindings::ClearBlendShapes", HasExplicitThis = true)]
		public void ClearBlendShapes(); // 0x0000000182196380-0x00000001821963E0
		[FreeFunction(Name = "SpritesBindings::GetBlendShapeName", HasExplicitThis = true, ThrowsException = true)]
		public string GetBlendShapeName(int shapeIndex); // 0x0000000182197B40-0x0000000182197C40
		[FreeFunction(Name = "SpritesBindings::GetBlendShapeIndex", HasExplicitThis = true, ThrowsException = true)]
		internal int GetBlendShapeIndexInternal(string blendShapeName); // 0x00000001821978F0-0x0000000182197A70
		public int GetBlendShapeIndex(string blendShapeName); // 0x0000000182197A70-0x0000000182197AF0
		[FreeFunction(Name = "SpritesBindings::GetBlendShapeFrameCount", HasExplicitThis = true, ThrowsException = true)]
		public int GetBlendShapeFrameCount(int shapeIndex); // 0x0000000182197540-0x00000001821975A0
		[FreeFunction(Name = "SpritesBindings::GetBlendShapeFrameWeight", HasExplicitThis = true, ThrowsException = true)]
		public float GetBlendShapeFrameWeight(int shapeIndex, int frameIndex); // 0x00000001821976B0-0x0000000182197720
		[FreeFunction(Name = "SpritesBindings::AddBlendShape", HasExplicitThis = true, ThrowsException = true)]
		internal int AddBlendShapeInternal(string shapeName); // 0x0000000182196030-0x00000001821961B0
		public int AddBlendShape(string shapeName); // 0x00000001821961B0-0x0000000182196230
		[FreeFunction(Name = "SpritesBindings::AddBlendShapeFrame", HasExplicitThis = true, ThrowsException = true)]
		private int AddBlendShapeFrame_Internal(int shapeIndex, float frameWeight, IntPtr vertices, int vertexCount); // 0x0000000182195EB0-0x0000000182195F30
		public int AddBlendShapeFrame(int shapeIndex, float frameWeight, NativeArray<SpriteBlendShapeVertex> vertices); // 0x0000000182195F30-0x0000000182195FE0
		[FreeFunction(Name = "SpritesBindings::GetBlendShapeFrameVertexCount", HasExplicitThis = true, ThrowsException = true)]
		public int GetBlendShapeFrameVertexCount(int shapeIndex, int frameIndex); // 0x00000001821975F0-0x0000000182197660
		[FreeFunction(Name = "SpritesBindings::GetBlendShapeFrame", HasExplicitThis = true, ThrowsException = true)]
		private void GetBlendShapeFrame_Internal(int shapeIndex, int frameIndex, IntPtr outVertices, int outVertexCount); // 0x0000000182197780-0x0000000182197800
		public void GetBlendShapeFrame(int shapeIndex, int frameIndex, NativeArray<SpriteBlendShapeVertex> outVertices); // 0x0000000182197800-0x00000001821978A0
		[FreeFunction(Name = "SpritesBindings::UpdateBlendShapeFrame", HasExplicitThis = true, ThrowsException = true)]
		private void UpdateBlendShapeFrame_Internal(int shapeIndex, int frameIndex, IntPtr vertices, int vertexCount); // 0x0000000182199C50-0x0000000182199CD0
		public void UpdateBlendShapeFrame(int shapeIndex, int frameIndex, NativeArray<SpriteBlendShapeVertex> vertices); // 0x0000000182199CD0-0x0000000182199D70
		[FreeFunction(Name = "SpritesBindings::GetBlendShapeBufferPtr", HasExplicitThis = true, ThrowsException = true)]
		private GraphicsBuffer GetBlendShapeBufferImpl(int layout); // 0x00000001821971B0-0x0000000182197230
		public GraphicsBuffer GetBlendShapeBuffer(BlendShapeBufferLayout layout); // 0x0000000182197230-0x00000001821973A0
		public GraphicsBuffer GetBlendShapeBuffer(); // 0x00000001821973A0-0x0000000182197500
		[VisibleToOtherModules]
		internal static Sprite Create(Rect rect, Vector2 pivot, float pixelsToUnits, Texture2D texture); // 0x0000000182197070-0x0000000182197100
		internal static Sprite Create(Rect rect, Vector2 pivot, float pixelsToUnits); // 0x0000000182196A00-0x0000000182196A80
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape); // 0x0000000182196990-0x0000000182196A00
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape, SecondarySpriteTexture[] secondaryTextures); // 0x0000000182196A80-0x0000000182197070
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border); // 0x00000001821967E0-0x0000000182196840
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType); // 0x0000000182196840-0x00000001821968B0
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude); // 0x0000000182197100-0x0000000182197170
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit); // 0x0000000182196920-0x0000000182196990
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot); // 0x00000001821968B0-0x0000000182196920
		private static int GetPackingMode_Injected(IntPtr _unity_self); // 0x0000000182197E60-0x0000000182197EA0
		private static int GetPackingRotation_Injected(IntPtr _unity_self); // 0x0000000182197F00-0x0000000182197F40
		private static int GetPacked_Injected(IntPtr _unity_self); // 0x0000000182197DC0-0x0000000182197E00
		private static void GetTextureRect_Injected(IntPtr _unity_self, ); // 0x00000001821990C0-0x0000000182199110
		private static void GetTextureRectOffset_Injected(IntPtr _unity_self, ); // 0x0000000182199000-0x0000000182199050
		private static void GetInnerUVs_Injected(IntPtr _unity_self, ); // 0x0000000182197C40-0x0000000182197C90
		private static void GetOuterUVs_Injected(IntPtr _unity_self, ); // 0x0000000182197D00-0x0000000182197D50
		private static void GetPadding_Injected(IntPtr _unity_self, ); // 0x0000000182197FA0-0x0000000182197FF0
		private static IntPtr CreateSpriteWithoutTextureScripting_Injected(in Rect rect, in Vector2 pivot, float pixelsToUnits, IntPtr texture); // 0x0000000182196530-0x00000001821965A0
		private static IntPtr CreateSpriteInternal_Injected(IntPtr texture, in Rect rect, in Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, in Vector4 border, bool generateFallbackPhysicsShape, SecondarySpriteTexture[] secondaryTexture); // 0x00000001821963E0-0x0000000182196460
		private static void get_bounds_Injected(IntPtr _unity_self, ); // 0x0000000182199FF0-0x000000018219A040
		private static void get_rect_Injected(IntPtr _unity_self, ); // 0x000000018219A310-0x000000018219A360
		private static void get_border_Injected(IntPtr _unity_self, ); // 0x0000000182199F30-0x0000000182199F80
		private static IntPtr get_texture_Injected(IntPtr _unity_self); // 0x000000018219A4F0-0x000000018219A530
		private static uint get_extrude_Injected(IntPtr _unity_self); // 0x000000018219A0B0-0x000000018219A0F0
		private static IntPtr GetSecondaryTexture_Injected(IntPtr _unity_self, int index); // 0x0000000182198E30-0x0000000182198E70
		private static int GetSecondaryTextureCount_Injected(IntPtr _unity_self); // 0x0000000182198D90-0x0000000182198DD0
		private static int GetSecondaryTextures_Injected(IntPtr _unity_self, out SecondarySpriteTexture[] secondaryTexture); // 0x0000000182198F10-0x0000000182198F60
		private static float get_pixelsPerUnit_Injected(IntPtr _unity_self); // 0x000000018219A270-0x000000018219A2B0
		private static float get_spriteAtlasTextureScale_Injected(IntPtr _unity_self); // 0x000000018219A3D0-0x000000018219A410
		private static IntPtr get_associatedAlphaSplitTexture_Injected(IntPtr _unity_self); // 0x0000000182199DC0-0x0000000182199E00
		private static void get_pivot_Injected(IntPtr _unity_self, ); // 0x000000018219A1B0-0x000000018219A200
		private static Vector2[] get_vertices_Injected(IntPtr _unity_self); // 0x000000018219A700-0x000000018219A740
		private static ushort[] get_triangles_Injected(IntPtr _unity_self); // 0x000000018219A5C0-0x000000018219A600
		private static Vector2[] get_uv_Injected(IntPtr _unity_self); // 0x000000018219A660-0x000000018219A6A0
		private static int GetPhysicsOutlineCount_Injected(IntPtr _unity_self); // 0x0000000182198060-0x00000001821980A0
		private static uint GetScriptableObjectsCount_Injected(IntPtr _unity_self); // 0x0000000182198C00-0x0000000182198C40
		private static uint GetScriptableObjects_Injected(IntPtr _unity_self, out ScriptableObject[] scriptableObjects); // 0x0000000182198CA0-0x0000000182198CF0
		private static bool AddScriptableObject_Injected(IntPtr _unity_self, IntPtr obj); // 0x0000000182196230-0x0000000182196280
		private static bool RemoveScriptableObjectAt_Injected(IntPtr _unity_self, uint i); // 0x0000000182199A20-0x0000000182199A60
		private static bool SetScriptableObjectAt_Injected(IntPtr _unity_self, IntPtr obj, uint i); // 0x0000000182199AC0-0x0000000182199B20
		private static int Internal_GetPhysicsOutlinePointCount_Injected(IntPtr _unity_self, int outlineIndex); // 0x0000000182199180-0x00000001821991C0
		private static void GetPhysicsOutlineImpl_Injected(IntPtr sprite, int outlineIndex, ref BlittableListWrapper physicsOutline); // 0x0000000182198100-0x0000000182198150
		private static void GetPhysicsOutlineSpanImpl_Injected(IntPtr sprite, int outlineIndex, ); // 0x0000000182198450-0x00000001821984A0
		private static void OverridePhysicsOutlineCount_Injected(IntPtr sprite, int physicsOutlineCount); // 0x0000000182199400-0x0000000182199440
		private static void OverridePhysicsOutline_Injected(IntPtr sprite, ref ManagedSpanWrapper physicsOutline, int index); // 0x0000000182199490-0x00000001821994F0
		private static void OverrideGeometry_Injected(IntPtr _unity_self, ref ManagedSpanWrapper vertices, ref ManagedSpanWrapper triangles); // 0x0000000182199220-0x0000000182199280
		private static int get_blendShapeCount_Injected(IntPtr _unity_self); // 0x0000000182199E90-0x0000000182199ED0
		private static void ClearBlendShapes_Injected(IntPtr _unity_self); // 0x0000000182196340-0x0000000182196380
		private static void GetBlendShapeName_Injected(IntPtr _unity_self, int shapeIndex, ); // 0x0000000182197AF0-0x0000000182197B40
		private static int GetBlendShapeIndexInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper blendShapeName); // 0x00000001821978A0-0x00000001821978F0
		private static int GetBlendShapeFrameCount_Injected(IntPtr _unity_self, int shapeIndex); // 0x0000000182197500-0x0000000182197540
		private static float GetBlendShapeFrameWeight_Injected(IntPtr _unity_self, int shapeIndex, int frameIndex); // 0x0000000182197660-0x00000001821976B0
		private static int AddBlendShapeInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper shapeName); // 0x0000000182195FE0-0x0000000182196030
		private static int AddBlendShapeFrame_Internal_Injected(IntPtr _unity_self, int shapeIndex, float frameWeight, IntPtr vertices, int vertexCount); // 0x0000000182195E50-0x0000000182195EB0
		private static int GetBlendShapeFrameVertexCount_Injected(IntPtr _unity_self, int shapeIndex, int frameIndex); // 0x00000001821975A0-0x00000001821975F0
		private static void GetBlendShapeFrame_Internal_Injected(IntPtr _unity_self, int shapeIndex, int frameIndex, IntPtr outVertices, int outVertexCount); // 0x0000000182197720-0x0000000182197780
		private static void UpdateBlendShapeFrame_Internal_Injected(IntPtr _unity_self, int shapeIndex, int frameIndex, IntPtr vertices, int vertexCount); // 0x0000000182199BF0-0x0000000182199C50
		private static IntPtr GetBlendShapeBufferImpl_Injected(IntPtr _unity_self, int layout); // 0x0000000182197170-0x00000001821971B0
	}
}
