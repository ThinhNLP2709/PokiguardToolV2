namespace UnityEngine.UIElements;

[UxmlObject]
public abstract class Binding
{
	internal const string k_UpdateTriggerTooltip = "This informs the binding system of whether the binding object should be updated on every frame, when a change occurs in the source or on every frame if change detection is impossible, and when explicitly marked as dirty."; //Field offset: 0x0
	private bool m_Dirty; //Field offset: 0x10
	private BindingUpdateTrigger m_UpdateTrigger; //Field offset: 0x14
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <property>k__BackingField; //Field offset: 0x18

	public bool isDirty
	{
		 get { } //Length: 5
	}

	[CreateProperty]
	public BindingUpdateTrigger updateTrigger
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	internal void ClearDirty() { }

	public bool get_isDirty() { }

	public BindingUpdateTrigger get_updateTrigger() { }

	public void MarkDirty() { }

	protected private override void OnActivated(in BindingActivationContext context) { }

	protected private override void OnDataSourceChanged(in DataSourceContextChanged context) { }

	protected private override void OnDeactivated(in BindingActivationContext context) { }

	public static void ResetPanelLogLevel(IPanel panel) { }

	public void set_updateTrigger(BindingUpdateTrigger value) { }

	public static void SetGlobalLogLevel(BindingLogLevel logLevel) { }

	public static void SetPanelLogLevel(IPanel panel, BindingLogLevel logLevel) { }

}

