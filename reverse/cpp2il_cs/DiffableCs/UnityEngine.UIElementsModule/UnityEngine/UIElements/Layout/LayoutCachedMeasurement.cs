namespace UnityEngine.UIElements.Layout;

internal struct LayoutCachedMeasurement
{
	public static LayoutCachedMeasurement Default; //Field offset: 0x0
	public float AvailableWidth; //Field offset: 0x0
	public float AvailableHeight; //Field offset: 0x4
	public float ParentWidth; //Field offset: 0x8
	public float ParentHeight; //Field offset: 0xC
	public LayoutMeasureMode WidthMeasureMode; //Field offset: 0x10
	public LayoutMeasureMode HeightMeasureMode; //Field offset: 0x14
	public float ComputedWidth; //Field offset: 0x18
	public float ComputedHeight; //Field offset: 0x1C

	private static LayoutCachedMeasurement() { }

}

