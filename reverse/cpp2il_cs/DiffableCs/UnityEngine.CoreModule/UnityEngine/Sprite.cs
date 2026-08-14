namespace UnityEngine;

[ExcludeFromPreset]
[NativeHeader("Runtime/2D/Common/ScriptBindings/SpritesMarshalling.h")]
[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
[NativeHeader("Runtime/Graphics/SpriteUtility.h")]
[NativeType("Runtime/Graphics/SpriteFrame.h")]
public sealed class Sprite : object
{

	public Texture2D associatedAlphaSplitTexture
	{
		[NativeMethod("GetAlphaTexture")]
		 get { } //Length: 144
	}

	public Vector4 border
	{
		 get { } //Length: 142
	}

	public Bounds bounds
	{
		 get { } //Length: 148
	}

	public bool packed
	{
		 get { } //Length: 124
	}

	public SpritePackingRotation packingRotation
	{
		 get { } //Length: 118
	}

	public Vector2 pivot
	{
		[NativeMethod("GetPivotInPixels")]
		 get { } //Length: 135
	}

	public float pixelsPerUnit
	{
		[NativeMethod("GetPixelsToUnits")]
		 get { } //Length: 118
	}

	public Rect rect
	{
		 get { } //Length: 142
	}

	public Texture2D texture
	{
		 get { } //Length: 144
	}

	public UInt16[] triangles
	{
		[FreeFunction("SpriteAccessLegacy::GetSpriteIndices", HasExplicitThis = True)]
		 get { } //Length: 118
	}

	public Vector2[] uv
	{
		[FreeFunction("SpriteAccessLegacy::GetSpriteUVs", HasExplicitThis = True)]
		 get { } //Length: 118
	}

	public Vector2[] vertices
	{
		[FreeFunction("SpriteAccessLegacy::GetSpriteVertices", HasExplicitThis = True)]
		 get { } //Length: 118
	}

	[RequiredByNativeCode]
	private Sprite() { }

	public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot) { }

	public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit) { }

	public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude) { }

	public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType) { }

	public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border) { }

	public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape) { }

	public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape, SecondarySpriteTexture[] secondaryTextures) { }

	[FreeFunction("SpritesBindings::CreateSprite", ThrowsException = True)]
	internal static Sprite CreateSprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape, SecondarySpriteTexture[] secondaryTexture) { }

	private static IntPtr CreateSprite_Injected(IntPtr texture, in Rect rect, in Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, in Vector4 border, bool generateFallbackPhysicsShape, SecondarySpriteTexture[] secondaryTexture) { }

	[NativeMethod("GetAlphaTexture")]
	public Texture2D get_associatedAlphaSplitTexture() { }

	private static IntPtr get_associatedAlphaSplitTexture_Injected(IntPtr _unity_self) { }

	public Vector4 get_border() { }

	private static void get_border_Injected(IntPtr _unity_self, out Vector4 ret) { }

	public Bounds get_bounds() { }

	private static void get_bounds_Injected(IntPtr _unity_self, out Bounds ret) { }

	public bool get_packed() { }

	public SpritePackingRotation get_packingRotation() { }

	[NativeMethod("GetPivotInPixels")]
	public Vector2 get_pivot() { }

	private static void get_pivot_Injected(IntPtr _unity_self, out Vector2 ret) { }

	[NativeMethod("GetPixelsToUnits")]
	public float get_pixelsPerUnit() { }

	private static float get_pixelsPerUnit_Injected(IntPtr _unity_self) { }

	public Rect get_rect() { }

	private static void get_rect_Injected(IntPtr _unity_self, out Rect ret) { }

	public Texture2D get_texture() { }

	private static IntPtr get_texture_Injected(IntPtr _unity_self) { }

	[FreeFunction("SpriteAccessLegacy::GetSpriteIndices", HasExplicitThis = True)]
	public UInt16[] get_triangles() { }

	private static UInt16[] get_triangles_Injected(IntPtr _unity_self) { }

	[FreeFunction("SpriteAccessLegacy::GetSpriteUVs", HasExplicitThis = True)]
	public Vector2[] get_uv() { }

	private static Vector2[] get_uv_Injected(IntPtr _unity_self) { }

	[FreeFunction("SpriteAccessLegacy::GetSpriteVertices", HasExplicitThis = True)]
	public Vector2[] get_vertices() { }

	private static Vector2[] get_vertices_Injected(IntPtr _unity_self) { }

	internal Vector4 GetInnerUVs() { }

	private static void GetInnerUVs_Injected(IntPtr _unity_self, out Vector4 ret) { }

	internal Vector4 GetOuterUVs() { }

	private static void GetOuterUVs_Injected(IntPtr _unity_self, out Vector4 ret) { }

	internal int GetPacked() { }

	private static int GetPacked_Injected(IntPtr _unity_self) { }

	internal int GetPackingRotation() { }

	private static int GetPackingRotation_Injected(IntPtr _unity_self) { }

	internal Vector4 GetPadding() { }

	private static void GetPadding_Injected(IntPtr _unity_self, out Vector4 ret) { }

}

