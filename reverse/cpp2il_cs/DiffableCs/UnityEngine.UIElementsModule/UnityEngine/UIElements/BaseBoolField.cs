namespace UnityEngine.UIElements;

public abstract class BaseBoolField : BaseField<Boolean>
{
	internal static readonly BindingId textProperty; //Field offset: 0x0
	internal static readonly BindingId toggleOnLabelClickProperty; //Field offset: 0x98
	protected Label m_Label; //Field offset: 0x528
	protected private readonly VisualElement m_CheckMark; //Field offset: 0x530
	internal readonly Clickable m_Clickable; //Field offset: 0x538
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <toggleOnLabelClick>k__BackingField; //Field offset: 0x540
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <toggleOnTextClick>k__BackingField; //Field offset: 0x541
	private string m_OriginalText; //Field offset: 0x548

	internal bool acceptClicksIfDisabled
	{
		internal set { } //Length: 124
	}

	[CreateProperty]
	public string text
	{
		 get { } //Length: 47
		 set { } //Length: 262
	}

	[CreateProperty]
	public bool toggleOnLabelClick
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool toggleOnTextClick
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	private static BaseBoolField() { }

	public BaseBoolField(string label) { }

	public string get_text() { }

	[CompilerGenerated]
	public bool get_toggleOnLabelClick() { }

	[CompilerGenerated]
	internal bool get_toggleOnTextClick() { }

	protected override void InitLabel() { }

	private void OnClickEvent(EventBase evt) { }

	private void OnNavigationSubmit(NavigationSubmitEvent evt) { }

	internal virtual void RegisterEditingCallbacks() { }

	internal void set_acceptClicksIfDisabled(bool value) { }

	public void set_text(string value) { }

	[CompilerGenerated]
	public void set_toggleOnLabelClick(bool value) { }

	[CompilerGenerated]
	internal void set_toggleOnTextClick(bool value) { }

	public virtual void SetValueWithoutNotify(bool newValue) { }

	private bool ShouldIgnoreClick(Vector3 position) { }

	protected override void ToggleValue() { }

	internal virtual void UnregisterEditingCallbacks() { }

	protected virtual void UpdateMixedValueContent() { }

}

