namespace UnityEngine.UIElements.UIR;

internal class Entry
{
	public EntryType type; //Field offset: 0x10
	public EntryFlags flags; //Field offset: 0x12
	public NativeSlice<Vertex> vertices; //Field offset: 0x18
	public NativeSlice<UInt16> indices; //Field offset: 0x28
	public Texture texture; //Field offset: 0x38
	public float textScale; //Field offset: 0x40
	public float fontSharpness; //Field offset: 0x44
	public VectorImage gradientsOwner; //Field offset: 0x48
	public Material material; //Field offset: 0x50
	public Action immediateCallback; //Field offset: 0x58
	public Entry nextSibling; //Field offset: 0x60
	public Entry firstChild; //Field offset: 0x68
	public Entry lastChild; //Field offset: 0x70

	public Entry() { }

}

