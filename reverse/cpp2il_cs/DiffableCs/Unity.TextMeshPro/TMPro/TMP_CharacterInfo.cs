namespace TMPro;

[DebuggerDisplay("Unicode '{character}'  ({((uint)character).ToString(\"X\")})")]
public struct TMP_CharacterInfo
{
	public TMP_TextElementType elementType; //Field offset: 0x0
	public char character; //Field offset: 0x4
	public int index; //Field offset: 0x8
	public int stringLength; //Field offset: 0xC
	public TMP_TextElement textElement; //Field offset: 0x10
	public Glyph alternativeGlyph; //Field offset: 0x18
	public TMP_FontAsset fontAsset; //Field offset: 0x20
	public Material material; //Field offset: 0x28
	public int materialReferenceIndex; //Field offset: 0x30
	public bool isUsingAlternateTypeface; //Field offset: 0x34
	public float pointSize; //Field offset: 0x38
	public int lineNumber; //Field offset: 0x3C
	public int pageNumber; //Field offset: 0x40
	public int vertexIndex; //Field offset: 0x44
	public TMP_Vertex vertex_BL; //Field offset: 0x48
	public TMP_Vertex vertex_TL; //Field offset: 0x70
	public TMP_Vertex vertex_TR; //Field offset: 0x98
	public TMP_Vertex vertex_BR; //Field offset: 0xC0
	public Vector3 topLeft; //Field offset: 0xE8
	public Vector3 bottomLeft; //Field offset: 0xF4
	public Vector3 topRight; //Field offset: 0x100
	public Vector3 bottomRight; //Field offset: 0x10C
	public float origin; //Field offset: 0x118
	public float xAdvance; //Field offset: 0x11C
	public float ascender; //Field offset: 0x120
	public float baseLine; //Field offset: 0x124
	public float descender; //Field offset: 0x128
	internal float adjustedAscender; //Field offset: 0x12C
	internal float adjustedDescender; //Field offset: 0x130
	internal float adjustedHorizontalAdvance; //Field offset: 0x134
	public float aspectRatio; //Field offset: 0x138
	public float scale; //Field offset: 0x13C
	public Color32 color; //Field offset: 0x140
	public Color32 underlineColor; //Field offset: 0x144
	public int underlineVertexIndex; //Field offset: 0x148
	public Color32 strikethroughColor; //Field offset: 0x14C
	public int strikethroughVertexIndex; //Field offset: 0x150
	public Color32 highlightColor; //Field offset: 0x154
	public HighlightState highlightState; //Field offset: 0x158
	public FontStyles style; //Field offset: 0x16C
	public bool isVisible; //Field offset: 0x170

}

