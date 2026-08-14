namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilityNotificationContext.h")]
[NativeHeader("Modules/Accessibility/Bindings/AccessibilityNotificationContext.bindings.h")]
[NativeType(CodegenOptions::Custom (1), "MonoAccessibilityNotificationContext")]
[RequiredByNativeCode]
internal struct AccessibilityNotificationContext
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AccessibilityNotification <notification>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly bool <isScreenReaderEnabled>k__BackingField; //Field offset: 0x4
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <announcement>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly bool <wasAnnouncementSuccessful>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly int <currentNodeId>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <nextNodeId>k__BackingField; //Field offset: 0x18

	public string announcement
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
	}

	public int currentNodeId
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
	}

	public bool isScreenReaderEnabled
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
	}

	public int nextNodeId
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public AccessibilityNotification notification
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 3
		[CompilerGenerated]
		 set { } //Length: 3
	}

	public bool wasAnnouncementSuccessful
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
	}

	[CompilerGenerated]
	[IsReadOnly]
	public string get_announcement() { }

	[CompilerGenerated]
	[IsReadOnly]
	public int get_currentNodeId() { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_isScreenReaderEnabled() { }

	[CompilerGenerated]
	[IsReadOnly]
	public int get_nextNodeId() { }

	[CompilerGenerated]
	[IsReadOnly]
	public AccessibilityNotification get_notification() { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_wasAnnouncementSuccessful() { }

	[CompilerGenerated]
	public void set_nextNodeId(int value) { }

	[CompilerGenerated]
	public void set_notification(AccessibilityNotification value) { }

}

