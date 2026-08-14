namespace UnityEngine.Rendering;

[AttributeUsage(AttributeTargets::Field (256), AllowMultiple = True)]
public class PackingAttribute : Attribute
{
	public String[] displayNames; //Field offset: 0x10
	public Single[] range; //Field offset: 0x18
	public FieldPacking packingScheme; //Field offset: 0x20
	public int offsetInSource; //Field offset: 0x24
	public int sizeInBits; //Field offset: 0x28
	public bool isDirection; //Field offset: 0x2C
	public bool sRGBDisplay; //Field offset: 0x2D
	public bool checkIsNormalized; //Field offset: 0x2E
	public string preprocessor; //Field offset: 0x30

	public PackingAttribute(String[] displayNames, FieldPacking packingScheme = 0, int bitSize = 32, int offsetInSource = 0, float minValue = 0, float maxValue = 1, bool isDirection = false, bool sRGBDisplay = false, bool checkIsNormalized = false, string preprocessor = "") { }

	public PackingAttribute(string displayName = "", FieldPacking packingScheme = 0, int bitSize = 0, int offsetInSource = 0, float minValue = 0, float maxValue = 1, bool isDirection = false, bool sRGBDisplay = false, bool checkIsNormalized = false, string preprocessor = "") { }

}

