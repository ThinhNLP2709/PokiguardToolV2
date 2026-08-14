namespace UnityEngine.InputSystem;

[InputControlLayout(stateType = typeof(PointerState), isGenericTypeOfDevice = True)]
public class Pointer : InputDevice, IInputStateCallbackReceiver
{
	[CompilerGenerated]
	private static Pointer <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Vector2Control <position>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private DeltaControl <delta>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private Vector2Control <radius>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private AxisControl <pressure>k__BackingField; //Field offset: 0x1A8
	[CompilerGenerated]
	private ButtonControl <press>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private IntegerControl <displayIndex>k__BackingField; //Field offset: 0x1B8

	public internal static Pointer current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		internal set { } //Length: 81
	}

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

	public Vector2Control position
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl press
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

	public Pointer() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public static Pointer get_current() { }

	[CompilerGenerated]
	public DeltaControl get_delta() { }

	[CompilerGenerated]
	public IntegerControl get_displayIndex() { }

	[CompilerGenerated]
	public Vector2Control get_position() { }

	[CompilerGenerated]
	public ButtonControl get_press() { }

	[CompilerGenerated]
	public AxisControl get_pressure() { }

	[CompilerGenerated]
	public Vector2Control get_radius() { }

	public virtual void MakeCurrent() { }

	protected void OnNextUpdate() { }

	protected virtual void OnRemoved() { }

	protected void OnStateEvent(InputEventPtr eventPtr) { }

	[CompilerGenerated]
	internal static void set_current(Pointer value) { }

	[CompilerGenerated]
	protected void set_delta(DeltaControl value) { }

	[CompilerGenerated]
	protected void set_displayIndex(IntegerControl value) { }

	[CompilerGenerated]
	protected void set_position(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_press(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_pressure(AxisControl value) { }

	[CompilerGenerated]
	protected void set_radius(Vector2Control value) { }

	private override bool UnityEngine.InputSystem.LowLevel.IInputStateCallbackReceiver.GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset) { }

	private override void UnityEngine.InputSystem.LowLevel.IInputStateCallbackReceiver.OnNextUpdate() { }

	private override void UnityEngine.InputSystem.LowLevel.IInputStateCallbackReceiver.OnStateEvent(InputEventPtr eventPtr) { }

}

