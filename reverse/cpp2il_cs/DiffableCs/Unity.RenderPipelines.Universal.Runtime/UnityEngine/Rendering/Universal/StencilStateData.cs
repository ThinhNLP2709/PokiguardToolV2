namespace UnityEngine.Rendering.Universal;

public class StencilStateData
{
	public bool overrideStencilState; //Field offset: 0x10
	public int stencilReference; //Field offset: 0x14
	public CompareFunction stencilCompareFunction; //Field offset: 0x18
	public StencilOp passOperation; //Field offset: 0x1C
	public StencilOp failOperation; //Field offset: 0x20
	public StencilOp zFailOperation; //Field offset: 0x24

	public StencilStateData() { }

}

