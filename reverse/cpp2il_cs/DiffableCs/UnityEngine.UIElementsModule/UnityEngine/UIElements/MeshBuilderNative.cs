namespace UnityEngine.UIElements;

[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIRMeshBuilder.bindings.h")]
internal static class MeshBuilderNative
{
	internal struct NativeBorderParams
	{
		public Rect rect; //Field offset: 0x0
		public Color leftColor; //Field offset: 0x10
		public Color topColor; //Field offset: 0x20
		public Color rightColor; //Field offset: 0x30
		public Color bottomColor; //Field offset: 0x40
		public float leftWidth; //Field offset: 0x50
		public float topWidth; //Field offset: 0x54
		public float rightWidth; //Field offset: 0x58
		public float bottomWidth; //Field offset: 0x5C
		public Vector2 topLeftRadius; //Field offset: 0x60
		public Vector2 topRightRadius; //Field offset: 0x68
		public Vector2 bottomRightRadius; //Field offset: 0x70
		public Vector2 bottomLeftRadius; //Field offset: 0x78
		internal NativeColorPage leftColorPage; //Field offset: 0x80
		internal NativeColorPage topColorPage; //Field offset: 0x88
		internal NativeColorPage rightColorPage; //Field offset: 0x90
		internal NativeColorPage bottomColorPage; //Field offset: 0x98

	}

	internal struct NativeColorPage
	{
		public int isValid; //Field offset: 0x0
		public Color32 pageAndID; //Field offset: 0x4

	}

	internal struct NativeRectParams
	{
		public Rect rect; //Field offset: 0x0
		public Rect subRect; //Field offset: 0x10
		public Rect uv; //Field offset: 0x20
		public Color color; //Field offset: 0x30
		public ScaleMode scaleMode; //Field offset: 0x40
		public IntPtr backgroundRepeatInstanceList; //Field offset: 0x48
		public int backgroundRepeatInstanceListStartIndex; //Field offset: 0x50
		public int backgroundRepeatInstanceListEndIndex; //Field offset: 0x54
		public Vector2 topLeftRadius; //Field offset: 0x58
		public Vector2 topRightRadius; //Field offset: 0x60
		public Vector2 bottomRightRadius; //Field offset: 0x68
		public Vector2 bottomLeftRadius; //Field offset: 0x70
		public Rect backgroundRepeatRect; //Field offset: 0x78
		public IntPtr texture; //Field offset: 0x88
		public IntPtr sprite; //Field offset: 0x90
		public IntPtr vectorImage; //Field offset: 0x98
		public IntPtr spriteTexture; //Field offset: 0xA0
		public IntPtr spriteVertices; //Field offset: 0xA8
		public IntPtr spriteUVs; //Field offset: 0xB0
		public IntPtr spriteTriangles; //Field offset: 0xB8
		public Rect spriteGeomRect; //Field offset: 0xC0
		public Vector2 contentSize; //Field offset: 0xD0
		public Vector2 textureSize; //Field offset: 0xD8
		public float texturePixelsPerPoint; //Field offset: 0xE0
		public int leftSlice; //Field offset: 0xE4
		public int topSlice; //Field offset: 0xE8
		public int rightSlice; //Field offset: 0xEC
		public int bottomSlice; //Field offset: 0xF0
		public float sliceScale; //Field offset: 0xF4
		public Vector4 rectInset; //Field offset: 0xF8
		public NativeColorPage colorPage; //Field offset: 0x108
		public int meshFlags; //Field offset: 0x110

	}


	[ThreadSafe]
	public static MeshWriteDataInterface MakeBorder(NativeBorderParams borderParams, float posZ) { }

	private static void MakeBorder_Injected(in NativeBorderParams borderParams, float posZ, out MeshWriteDataInterface ret) { }

	[ThreadSafe]
	public static MeshWriteDataInterface MakeSolidRect(NativeRectParams rectParams, float posZ) { }

	private static void MakeSolidRect_Injected(in NativeRectParams rectParams, float posZ, out MeshWriteDataInterface ret) { }

	[ThreadSafe]
	public static MeshWriteDataInterface MakeTexturedRect(NativeRectParams rectParams, float posZ) { }

	private static void MakeTexturedRect_Injected(in NativeRectParams rectParams, float posZ, out MeshWriteDataInterface ret) { }

	[ThreadSafe]
	public static MeshWriteDataInterface MakeVectorGraphics9SliceBackground(Vertex[] svgVertices, UInt16[] svgIndices, float svgWidth, float svgHeight, Rect targetRect, Vector4 sliceLTRB, Color tint, NativeColorPage colorPage) { }

	private static void MakeVectorGraphics9SliceBackground_Injected(ref ManagedSpanWrapper svgVertices, ref ManagedSpanWrapper svgIndices, float svgWidth, float svgHeight, in Rect targetRect, in Vector4 sliceLTRB, in Color tint, in NativeColorPage colorPage, out MeshWriteDataInterface ret) { }

	[ThreadSafe]
	public static MeshWriteDataInterface MakeVectorGraphicsStretchBackground(Vertex[] svgVertices, UInt16[] svgIndices, float svgWidth, float svgHeight, Rect targetRect, Rect sourceUV, ScaleMode scaleMode, Color tint, NativeColorPage colorPage) { }

	private static void MakeVectorGraphicsStretchBackground_Injected(ref ManagedSpanWrapper svgVertices, ref ManagedSpanWrapper svgIndices, float svgWidth, float svgHeight, in Rect targetRect, in Rect sourceUV, ScaleMode scaleMode, in Color tint, in NativeColorPage colorPage, out MeshWriteDataInterface ret) { }

}

