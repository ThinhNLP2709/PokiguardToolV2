namespace UnityEngine.Rendering;

public static class ColorSpaceUtils
{
	public static readonly float3x3 Rec709ToRec2020Mat; //Field offset: 0x0
	public static readonly float3x3 Rec709ToP3D65Mat; //Field offset: 0x24
	public static readonly float3x3 Rec2020ToRec709Mat; //Field offset: 0x48
	public static readonly float3x3 Rec2020ToP3D65Mat; //Field offset: 0x6C
	public static readonly float3x3 P3D65ToRec2020Mat; //Field offset: 0x90

	private static ColorSpaceUtils() { }

}

