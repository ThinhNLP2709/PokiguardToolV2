namespace DG.Tweening;

public struct Color2
{
	public Color ca; //Field offset: 0x0
	public Color cb; //Field offset: 0x10

	public Color2(Color ca, Color cb) { }

	public static Color2 op_Addition(Color2 c1, Color2 c2) { }

	public static Color2 op_Multiply(Color2 c1, float f) { }

	public static Color2 op_Subtraction(Color2 c1, Color2 c2) { }

}

