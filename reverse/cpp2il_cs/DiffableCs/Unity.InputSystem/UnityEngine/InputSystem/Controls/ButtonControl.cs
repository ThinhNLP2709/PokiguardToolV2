namespace UnityEngine.InputSystem.Controls;

public class ButtonControl : AxisControl
{
	internal static float s_GlobalDefaultButtonPressPoint; //Field offset: 0x0
	internal const float kMinButtonPressPoint = 0.0001; //Field offset: 0x0
	internal static float s_GlobalDefaultButtonReleaseThreshold; //Field offset: 0x4
	private bool m_NeedsToCheckFramePress; //Field offset: 0x130
	private uint m_UpdateCountLastPressed; //Field offset: 0x134
	private uint m_UpdateCountLastReleased; //Field offset: 0x138
	private bool m_LastUpdateWasPress; //Field offset: 0x13C
	[CompilerGenerated]
	private bool <needsToCheckFramePress>k__BackingField; //Field offset: 0x13D
	public float pressPoint; //Field offset: 0x140

	public bool isPressed
	{
		 get { } //Length: 94
	}

	internal bool needsToCheckFramePress
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public float pressPointOrDefault
	{
		 get { } //Length: 86
	}

	public bool wasPressedThisFrame
	{
		 get { } //Length: 251
	}

	public bool wasReleasedThisFrame
	{
		 get { } //Length: 242
	}

	public ButtonControl() { }

	private void BeginTestingForFramePresses(bool currentlyPressed, bool pressedLastFrame) { }

	public bool get_isPressed() { }

	[CompilerGenerated]
	internal bool get_needsToCheckFramePress() { }

	public float get_pressPointOrDefault() { }

	public bool get_wasPressedThisFrame() { }

	public bool get_wasReleasedThisFrame() { }

	public bool IsValueConsideredPressed(float value) { }

	[CompilerGenerated]
	private void set_needsToCheckFramePress(bool value) { }

	internal void UpdateWasPressed() { }

}

