namespace UnityEngine.InputSystem.EnhancedTouch;

public class Finger
{
	[CompilerGenerated]
	private readonly Touchscreen <screen>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly int <index>k__BackingField; //Field offset: 0x18
	internal readonly InputStateHistory<TouchState> m_StateHistory; //Field offset: 0x20

	public Touch currentTouch
	{
		 get { } //Length: 576
	}

	public int index
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public bool isActive
	{
		 get { } //Length: 159
	}

	public Touch lastTouch
	{
		 get { } //Length: 229
	}

	public Touchscreen screen
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public Vector2 screenPosition
	{
		 get { } //Length: 313
	}

	public TouchHistory touchHistory
	{
		 get { } //Length: 117
	}

	internal Finger(Touchscreen screen, int index, InputUpdateType updateMask) { }

	private Touch FindTouch(uint uniqueId) { }

	public Touch get_currentTouch() { }

	[CompilerGenerated]
	public int get_index() { }

	public bool get_isActive() { }

	public Touch get_lastTouch() { }

	[CompilerGenerated]
	public Touchscreen get_screen() { }

	public Vector2 get_screenPosition() { }

	public TouchHistory get_touchHistory() { }

	internal TouchHistory GetTouchHistory(Touch touch) { }

	private void OnTouchRecorded(Record record) { }

	private static bool ShouldRecordTouch(InputControl control, double time, InputEventPtr eventPtr) { }

}

