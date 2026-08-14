namespace UnityEngine.InputSystem.LowLevel;

internal struct TouchscreenState : IInputStateTypeInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <primaryTouchData>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <touchData>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int MaxTouches = 10; //Field offset: 0x0
	internal const int kTouchDataOffset = 56; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 56)]
	[InputControl(name = "primaryTouch", displayName = "Primary Touch", layout = "Touch", synthetic = True)]
	[InputControl(name = "primaryTouch/tap", usage = "PrimaryAction")]
	[InputControl(name = "position", useStateFrom = "primaryTouch/position")]
	[InputControl(name = "delta", useStateFrom = "primaryTouch/delta", layout = "Delta")]
	[InputControl(name = "pressure", useStateFrom = "primaryTouch/pressure")]
	[InputControl(name = "radius", useStateFrom = "primaryTouch/radius")]
	[InputControl(name = "press", useStateFrom = "primaryTouch/phase", layout = "TouchPress", synthetic = True, usages = new IL2CPP_TYPE_STRING[] {})]
	[InputControl(name = "displayIndex", useStateFrom = "primaryTouch/displayIndex", format = "BYTE")]
	public <primaryTouchData>e__FixedBuffer primaryTouchData; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 560)]
	[InputControl(layout = "Touch", name = "touch", displayName = "Touch", arraySize = 10)]
	public <touchData>e__FixedBuffer touchData; //Field offset: 0x38

	public override FourCC format
	{
		 get { } //Length: 58
	}

	public static FourCC Format
	{
		 get { } //Length: 58
	}

	public TouchState* primaryTouch
	{
		 get { } //Length: 4
	}

	public TouchState* touches
	{
		 get { } //Length: 5
	}

	public override FourCC get_format() { }

	public static FourCC get_Format() { }

	public TouchState* get_primaryTouch() { }

	public TouchState* get_touches() { }

}

