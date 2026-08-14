namespace UnityEngine.InputSystem.Controls;

[InputControlLayout(stateType = typeof(TouchState))]
public class TouchControl : InputControl<TouchState>
{
	[CompilerGenerated]
	private TouchPressControl <press>k__BackingField; //Field offset: 0x170
	[CompilerGenerated]
	private IntegerControl <displayIndex>k__BackingField; //Field offset: 0x178
	[CompilerGenerated]
	private IntegerControl <touchId>k__BackingField; //Field offset: 0x180
	[CompilerGenerated]
	private Vector2Control <position>k__BackingField; //Field offset: 0x188
	[CompilerGenerated]
	private DeltaControl <delta>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private AxisControl <pressure>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private Vector2Control <radius>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private TouchPhaseControl <phase>k__BackingField; //Field offset: 0x1A8
	[CompilerGenerated]
	private ButtonControl <indirectTouch>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private ButtonControl <tap>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private IntegerControl <tapCount>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private DoubleControl <startTime>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private Vector2Control <startPosition>k__BackingField; //Field offset: 0x1D0

	public DeltaControl delta
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public IntegerControl displayIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl indirectTouch
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public bool isInProgress
	{
		 get { } //Length: 96
	}

	public TouchPhaseControl phase
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Vector2Control position
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public TouchPressControl press
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public AxisControl pressure
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Vector2Control radius
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Vector2Control startPosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public DoubleControl startTime
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl tap
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public IntegerControl tapCount
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public IntegerControl touchId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public TouchControl() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public DeltaControl get_delta() { }

	[CompilerGenerated]
	public IntegerControl get_displayIndex() { }

	[CompilerGenerated]
	public ButtonControl get_indirectTouch() { }

	public bool get_isInProgress() { }

	[CompilerGenerated]
	public TouchPhaseControl get_phase() { }

	[CompilerGenerated]
	public Vector2Control get_position() { }

	[CompilerGenerated]
	public TouchPressControl get_press() { }

	[CompilerGenerated]
	public AxisControl get_pressure() { }

	[CompilerGenerated]
	public Vector2Control get_radius() { }

	[CompilerGenerated]
	public Vector2Control get_startPosition() { }

	[CompilerGenerated]
	public DoubleControl get_startTime() { }

	[CompilerGenerated]
	public ButtonControl get_tap() { }

	[CompilerGenerated]
	public IntegerControl get_tapCount() { }

	[CompilerGenerated]
	public IntegerControl get_touchId() { }

	public virtual TouchState ReadUnprocessedValueFromState(Void* statePtr) { }

	[CompilerGenerated]
	public void set_delta(DeltaControl value) { }

	[CompilerGenerated]
	public void set_displayIndex(IntegerControl value) { }

	[CompilerGenerated]
	public void set_indirectTouch(ButtonControl value) { }

	[CompilerGenerated]
	public void set_phase(TouchPhaseControl value) { }

	[CompilerGenerated]
	public void set_position(Vector2Control value) { }

	[CompilerGenerated]
	public void set_press(TouchPressControl value) { }

	[CompilerGenerated]
	public void set_pressure(AxisControl value) { }

	[CompilerGenerated]
	public void set_radius(Vector2Control value) { }

	[CompilerGenerated]
	public void set_startPosition(Vector2Control value) { }

	[CompilerGenerated]
	public void set_startTime(DoubleControl value) { }

	[CompilerGenerated]
	public void set_tap(ButtonControl value) { }

	[CompilerGenerated]
	public void set_tapCount(IntegerControl value) { }

	[CompilerGenerated]
	public void set_touchId(IntegerControl value) { }

	public virtual void WriteValueIntoState(TouchState value, Void* statePtr) { }

}

