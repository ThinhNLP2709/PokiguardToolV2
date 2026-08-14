namespace UnityEngine.UIElements.Layout;

internal struct LayoutState
{
	public IntPtr measureFunctionCallback; //Field offset: 0x0
	public IntPtr baselineFunctionCallback; //Field offset: 0x8
	public IntPtr unusedExceptionPointer; //Field offset: 0x10
	public uint depth; //Field offset: 0x18
	public uint currentGenerationCount; //Field offset: 0x1C
	public bool error; //Field offset: 0x20

	public static LayoutState Default
	{
		 get { } //Length: 114
	}

	public static LayoutState get_Default() { }

}

