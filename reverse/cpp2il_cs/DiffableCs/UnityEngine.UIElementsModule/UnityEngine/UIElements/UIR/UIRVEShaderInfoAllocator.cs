namespace UnityEngine.UIElements.UIR;

internal class UIRVEShaderInfoAllocator
{
	private static readonly Vector2Int identityTransformTexel; //Field offset: 0x0
	private static readonly Vector2Int infiniteClipRectTexel; //Field offset: 0x8
	private static readonly Vector2Int fullOpacityTexel; //Field offset: 0x10
	private static readonly Vector2Int clearColorTexel; //Field offset: 0x18
	private static readonly Vector2Int defaultTextCoreSettingsTexel; //Field offset: 0x20
	private static readonly Matrix4x4 identityTransformValue; //Field offset: 0x28
	private static readonly Vector4 identityTransformRow0Value; //Field offset: 0x68
	private static readonly Vector4 identityTransformRow1Value; //Field offset: 0x78
	private static readonly Vector4 identityTransformRow2Value; //Field offset: 0x88
	private static readonly Vector4 infiniteClipRectValue; //Field offset: 0x98
	private static readonly Vector4 fullOpacityValue; //Field offset: 0xA8
	private static readonly Vector4 clearColorValue; //Field offset: 0xB8
	private static readonly TextCoreSettings defaultTextCoreSettingsValue; //Field offset: 0xC8
	public static readonly BMPAlloc identityTransform; //Field offset: 0x108
	public static readonly BMPAlloc infiniteClipRect; //Field offset: 0x110
	public static readonly BMPAlloc fullOpacity; //Field offset: 0x118
	public static readonly BMPAlloc clearColor; //Field offset: 0x120
	public static readonly BMPAlloc defaultTextCoreSettings; //Field offset: 0x128
	private static int s_DefaultShaderInfoTextureRefCount; //Field offset: 0x130
	private static Texture2D s_DefaultShaderInfoTexture; //Field offset: 0x138
	private BaseShaderInfoStorage m_Storage; //Field offset: 0x10
	private BitmapAllocator32 m_TransformAllocator; //Field offset: 0x18
	private BitmapAllocator32 m_ClipRectAllocator; //Field offset: 0x38
	private BitmapAllocator32 m_OpacityAllocator; //Field offset: 0x58
	private BitmapAllocator32 m_ColorAllocator; //Field offset: 0x78
	private BitmapAllocator32 m_TextSettingsAllocator; //Field offset: 0x98
	private bool m_StorageReallyCreated; //Field offset: 0xB8
	private ColorSpace m_ColorSpace; //Field offset: 0xBC

	public Texture atlas
	{
		 get { } //Length: 136
	}

	private static int pageHeight
	{
		private get { } //Length: 8
	}

	private static int pageWidth
	{
		private get { } //Length: 69
	}

	private static UIRVEShaderInfoAllocator() { }

	public UIRVEShaderInfoAllocator(ColorSpace colorSpace) { }

	private static void AcquireDefaultShaderInfoTexture() { }

	public BMPAlloc AllocClipRect() { }

	public BMPAlloc AllocColor() { }

	public BMPAlloc AllocOpacity() { }

	public BMPAlloc AllocTextCoreSettings(TextCoreSettings settings) { }

	private static Vector2Int AllocToTexelCoord(ref BitmapAllocator32 allocator, BMPAlloc alloc) { }

	public BMPAlloc AllocTransform() { }

	private static bool AtlasRectMatchesPage(ref BitmapAllocator32 allocator, BMPAlloc defAlloc, RectInt atlasRect) { }

	public Color32 ClipRectAllocToVertexData(BMPAlloc alloc) { }

	public Color32 ColorAllocToVertexData(BMPAlloc alloc) { }

	public void Dispose() { }

	public void FreeClipRect(BMPAlloc alloc) { }

	public void FreeColor(BMPAlloc alloc) { }

	public void FreeOpacity(BMPAlloc alloc) { }

	public void FreeTextCoreSettings(BMPAlloc alloc) { }

	public void FreeTransform(BMPAlloc alloc) { }

	public Texture get_atlas() { }

	private static int get_pageHeight() { }

	private static int get_pageWidth() { }

	public void IssuePendingStorageChanges() { }

	public Color32 OpacityAllocToVertexData(BMPAlloc alloc) { }

	private void ReallyCreateStorage() { }

	private static void ReleaseDefaultShaderInfoTexture() { }

	public void SetClipRectValue(BMPAlloc alloc, Vector4 clipRect) { }

	public void SetColorValue(BMPAlloc alloc, Color color) { }

	public void SetOpacityValue(BMPAlloc alloc, float opacity) { }

	public void SetTextCoreSettingValue(BMPAlloc alloc, TextCoreSettings settings) { }

	public void SetTransformValue(BMPAlloc alloc, Matrix4x4 xform) { }

	public Color32 TextCoreSettingsToVertexData(BMPAlloc alloc) { }

	public Color32 TransformAllocToVertexData(BMPAlloc alloc) { }

}

