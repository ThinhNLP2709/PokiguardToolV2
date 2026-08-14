namespace UnityEngine.InputSystem.Controls;

public class DpadControl : Vector2Control
{
	public enum ButtonBits
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3,
	}

	[InputControlLayout(hideInUI = True)]
	internal class DpadAxisControl : AxisControl
	{
		[CompilerGenerated]
		private int <component>k__BackingField; //Field offset: 0x130

		public int component
		{
			[CompilerGenerated]
			 get { } //Length: 7
			[CompilerGenerated]
			 set { } //Length: 7
		}

		public DpadAxisControl() { }

		protected virtual void FinishSetup() { }

		[CompilerGenerated]
		public int get_component() { }

		public virtual float ReadUnprocessedValueFromState(Void* statePtr) { }

		[CompilerGenerated]
		public void set_component(int value) { }

	}

	[CompilerGenerated]
	private ButtonControl <up>k__BackingField; //Field offset: 0x120
	[CompilerGenerated]
	private ButtonControl <down>k__BackingField; //Field offset: 0x128
	[CompilerGenerated]
	private ButtonControl <left>k__BackingField; //Field offset: 0x130
	[CompilerGenerated]
	private ButtonControl <right>k__BackingField; //Field offset: 0x138

	[InputControl(bit = 1, displayName = "Down")]
	public ButtonControl down
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(bit = 2, displayName = "Left")]
	public ButtonControl left
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(bit = 3, displayName = "Right")]
	public ButtonControl right
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "x", layout = "DpadAxis", useStateFrom = "right", synthetic = True)]
	[InputControl(name = "y", layout = "DpadAxis", useStateFrom = "up", synthetic = True)]
	[InputControl(bit = 0, displayName = "Up")]
	public ButtonControl up
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public DpadControl() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_down() { }

	[CompilerGenerated]
	public ButtonControl get_left() { }

	[CompilerGenerated]
	public ButtonControl get_right() { }

	[CompilerGenerated]
	public ButtonControl get_up() { }

	public static Vector2 MakeDpadVector(bool up, bool down, bool left, bool right, bool normalize = true) { }

	public static Vector2 MakeDpadVector(float up, float down, float left, float right) { }

	public virtual Vector2 ReadUnprocessedValueFromState(Void* statePtr) { }

	[CompilerGenerated]
	public void set_down(ButtonControl value) { }

	[CompilerGenerated]
	public void set_left(ButtonControl value) { }

	[CompilerGenerated]
	public void set_right(ButtonControl value) { }

	[CompilerGenerated]
	public void set_up(ButtonControl value) { }

	public virtual void WriteValueIntoState(Vector2 value, Void* statePtr) { }

}

