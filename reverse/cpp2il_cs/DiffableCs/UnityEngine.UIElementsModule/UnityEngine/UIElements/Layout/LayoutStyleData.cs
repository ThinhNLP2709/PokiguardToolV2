namespace UnityEngine.UIElements.Layout;

[NativeHeader("Modules/UIElements/Core/Layout/Native/LayoutModel.h")]
[RequiredByNativeCode]
internal struct LayoutStyleData
{
	public static LayoutStyleData Default; //Field offset: 0x0
	public LayoutDirection Direction; //Field offset: 0x0
	public LayoutFlexDirection FlexDirection; //Field offset: 0x4
	public LayoutJustify JustifyContent; //Field offset: 0x8
	public LayoutAlign AlignContent; //Field offset: 0xC
	public LayoutAlign AlignItems; //Field offset: 0x10
	public LayoutAlign AlignSelf; //Field offset: 0x14
	public LayoutPositionType PositionType; //Field offset: 0x18
	public float AspectRatio; //Field offset: 0x1C
	public LayoutWrap FlexWrap; //Field offset: 0x20
	public LayoutOverflow Overflow; //Field offset: 0x24
	public LayoutDisplay Display; //Field offset: 0x28
	public float FlexGrow; //Field offset: 0x2C
	public float FlexShrink; //Field offset: 0x30
	public LayoutValue FlexBasis; //Field offset: 0x34
	public FixedBuffer9<LayoutValue> border; //Field offset: 0x3C
	public FixedBuffer9<LayoutValue> position; //Field offset: 0x84
	public FixedBuffer9<LayoutValue> margin; //Field offset: 0xCC
	public FixedBuffer9<LayoutValue> padding; //Field offset: 0x114
	public FixedBuffer2<LayoutValue> maxDimensions; //Field offset: 0x15C
	public FixedBuffer2<LayoutValue> minDimensions; //Field offset: 0x16C
	public FixedBuffer2<LayoutValue> dimensions; //Field offset: 0x17C

	private static LayoutStyleData() { }

}

