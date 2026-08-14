namespace UnityEngine.TextCore;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct TextSpan
{
	public int startIndex; //Field offset: 0x0
	public int length; //Field offset: 0x4
	public IntPtr fontAsset; //Field offset: 0x8
	public int fontSize; //Field offset: 0x10
	public Color32 color; //Field offset: 0x14
	public FontStyles fontStyle; //Field offset: 0x18
	public TextFontWeight fontWeight; //Field offset: 0x1C
	public int linkID; //Field offset: 0x20

	public virtual string ToString() { }

}

