namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct EventModifiers
{
	[Flags]
	internal enum Modifiers
	{
		LeftShift = 1,
		RightShift = 2,
		Shift = 3,
		LeftCtrl = 4,
		RightCtrl = 8,
		Ctrl = 12,
		LeftAlt = 16,
		RightAlt = 32,
		Alt = 48,
		LeftMeta = 64,
		RightMeta = 128,
		Meta = 192,
		CapsLock = 256,
		Numlock = 512,
		FunctionKey = 1024,
		Numeric = 2048,
	}

	private uint _state; //Field offset: 0x0

	public bool isAltPressed
	{
		 get { } //Length: 7
	}

	public bool isCapsLockEnabled
	{
		 get { } //Length: 10
	}

	public bool isCtrlPressed
	{
		 get { } //Length: 7
	}

	public bool isFunctionKeyPressed
	{
		 get { } //Length: 10
	}

	public bool isMetaPressed
	{
		 get { } //Length: 10
	}

	public bool isNumericPressed
	{
		 get { } //Length: 10
	}

	public bool isShiftPressed
	{
		 get { } //Length: 7
	}

	private static void Append(ref string str, string value) { }

	public bool get_isAltPressed() { }

	public bool get_isCapsLockEnabled() { }

	public bool get_isCtrlPressed() { }

	public bool get_isFunctionKeyPressed() { }

	public bool get_isMetaPressed() { }

	public bool get_isNumericPressed() { }

	public bool get_isShiftPressed() { }

	public bool IsPressed(Modifiers mod) { }

	public void Reset() { }

	public void SetPressed(Modifiers modifier, bool pressed) { }

	public virtual string ToString() { }

}

