namespace UnityEngine;

public class ColorGamutUtility
{

	[FreeFunction(IsThreadSafe = True)]
	public static ColorPrimaries GetColorPrimaries(ColorGamut gamut) { }

	[FreeFunction(IsThreadSafe = True)]
	public static TransferFunction GetTransferFunction(ColorGamut gamut) { }

	[FreeFunction(IsThreadSafe = True)]
	public static WhitePoint GetWhitePoint(ColorGamut gamut) { }

}

