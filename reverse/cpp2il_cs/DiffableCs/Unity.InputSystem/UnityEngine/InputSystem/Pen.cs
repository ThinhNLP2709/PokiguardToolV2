namespace UnityEngine.InputSystem;

[DefaultMember("Item")]
[InputControlLayout(stateType = typeof(PenState), isGenericTypeOfDevice = True)]
public class Pen : Pointer
{
	[CompilerGenerated]
	private static Pen <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ButtonControl <tip>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private ButtonControl <eraser>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private ButtonControl <firstBarrelButton>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private ButtonControl <secondBarrelButton>k__BackingField; //Field offset: 0x1D8
	[CompilerGenerated]
	private ButtonControl <thirdBarrelButton>k__BackingField; //Field offset: 0x1E0
	[CompilerGenerated]
	private ButtonControl <fourthBarrelButton>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private ButtonControl <inRange>k__BackingField; //Field offset: 0x1F0
	[CompilerGenerated]
	private Vector2Control <tilt>k__BackingField; //Field offset: 0x1F8
	[CompilerGenerated]
	private AxisControl <twist>k__BackingField; //Field offset: 0x200

	public internal static Pen current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		internal set { } //Length: 81
	}

	public ButtonControl eraser
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl firstBarrelButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl fourthBarrelButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl inRange
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl Item
	{
		 get { } //Length: 272
	}

	public ButtonControl secondBarrelButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl thirdBarrelButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Vector2Control tilt
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl tip
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public AxisControl twist
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Pen() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public static Pen get_current() { }

	[CompilerGenerated]
	public ButtonControl get_eraser() { }

	[CompilerGenerated]
	public ButtonControl get_firstBarrelButton() { }

	[CompilerGenerated]
	public ButtonControl get_fourthBarrelButton() { }

	[CompilerGenerated]
	public ButtonControl get_inRange() { }

	public ButtonControl get_Item(PenButton button) { }

	[CompilerGenerated]
	public ButtonControl get_secondBarrelButton() { }

	[CompilerGenerated]
	public ButtonControl get_thirdBarrelButton() { }

	[CompilerGenerated]
	public Vector2Control get_tilt() { }

	[CompilerGenerated]
	public ButtonControl get_tip() { }

	[CompilerGenerated]
	public AxisControl get_twist() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	internal static void set_current(Pen value) { }

	[CompilerGenerated]
	protected void set_eraser(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_firstBarrelButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_fourthBarrelButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_inRange(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_secondBarrelButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_thirdBarrelButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_tilt(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_tip(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_twist(AxisControl value) { }

}

