namespace UnityEngine.Rendering.RenderGraphModule;

public struct BufferDesc
{
	public int count; //Field offset: 0x0
	public int stride; //Field offset: 0x4
	public string name; //Field offset: 0x8
	public Target target; //Field offset: 0x10
	public UsageFlags usageFlags; //Field offset: 0x14

	public BufferDesc(int count, int stride) { }

	public BufferDesc(int count, int stride, Target target) { }

	public virtual int GetHashCode() { }

}

