namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerWidget : MonoBehaviour
{
	[HideInInspector]
	public Color colorDefault; //Field offset: 0x20
	[HideInInspector]
	public Color colorSelected; //Field offset: 0x30
	[CompilerGenerated]
	private DebugUIHandlerWidget <parentUIHandler>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private DebugUIHandlerWidget <previousUIHandler>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private DebugUIHandlerWidget <nextUIHandler>k__BackingField; //Field offset: 0x50
	protected Widget m_Widget; //Field offset: 0x58

	public DebugUIHandlerWidget nextUIHandler
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public DebugUIHandlerWidget parentUIHandler
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public DebugUIHandlerWidget previousUIHandler
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public DebugUIHandlerWidget() { }

	protected T CastWidget() { }

	[CompilerGenerated]
	public DebugUIHandlerWidget get_nextUIHandler() { }

	[CompilerGenerated]
	public DebugUIHandlerWidget get_parentUIHandler() { }

	[CompilerGenerated]
	public DebugUIHandlerWidget get_previousUIHandler() { }

	internal Widget GetWidget() { }

	public override DebugUIHandlerWidget Next() { }

	public override void OnAction() { }

	public override void OnDecrement(bool fast) { }

	public override void OnDeselection() { }

	protected override void OnEnable() { }

	public override void OnIncrement(bool fast) { }

	public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	public override DebugUIHandlerWidget Previous() { }

	[CompilerGenerated]
	public void set_nextUIHandler(DebugUIHandlerWidget value) { }

	[CompilerGenerated]
	public void set_parentUIHandler(DebugUIHandlerWidget value) { }

	[CompilerGenerated]
	public void set_previousUIHandler(DebugUIHandlerWidget value) { }

	internal override void SetWidget(Widget widget) { }

}

