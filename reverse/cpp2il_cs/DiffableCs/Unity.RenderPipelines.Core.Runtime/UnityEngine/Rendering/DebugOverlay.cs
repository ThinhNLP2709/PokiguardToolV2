namespace UnityEngine.Rendering;

public class DebugOverlay
{
	[CompilerGenerated]
	private int <x>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <y>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private int <overlaySize>k__BackingField; //Field offset: 0x18
	private int m_InitialPositionX; //Field offset: 0x1C
	private int m_ScreenWidth; //Field offset: 0x20

	public private int overlaySize
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int x
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int y
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public DebugOverlay() { }

	[CompilerGenerated]
	public int get_overlaySize() { }

	[CompilerGenerated]
	public int get_x() { }

	[CompilerGenerated]
	public int get_y() { }

	public Rect Next(float aspect = 1) { }

	[CompilerGenerated]
	private void set_overlaySize(int value) { }

	[CompilerGenerated]
	private void set_x(int value) { }

	[CompilerGenerated]
	private void set_y(int value) { }

	public void SetViewport(CommandBuffer cmd) { }

	public void StartOverlay(int initialX, int initialY, int overlaySize, int screenWidth) { }

}

