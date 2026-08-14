namespace UnityEngine.Accessibility;

public static class AssistiveSupport
{
	public class NotificationDispatcher : IAccessibilityNotificationDispatcher
	{

		public NotificationDispatcher() { }

		private static void Send(in AccessibilityNotificationContext context) { }

		public override void SendScreenChanged(AccessibilityNode nodeToFocus = null) { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<AccessibilityNode> nodeFocusChanged; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Boolean> screenReaderStatusChanged; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static bool <isScreenReaderEnabled>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static readonly IAccessibilityNotificationDispatcher <notificationDispatcher>k__BackingField; //Field offset: 0x18
	private static ServiceManager s_ServiceManager; //Field offset: 0x20

	public static AccessibilityHierarchy activeHierarchy
	{
		 get { } //Length: 96
	}

	public private static bool isScreenReaderEnabled
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 84
	}

	public static IAccessibilityNotificationDispatcher notificationDispatcher
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	private static AssistiveSupport() { }

	public static AccessibilityHierarchy get_activeHierarchy() { }

	[CompilerGenerated]
	public static bool get_isScreenReaderEnabled() { }

	[CompilerGenerated]
	public static IAccessibilityNotificationDispatcher get_notificationDispatcher() { }

	internal static T GetService() { }

	internal static void Initialize() { }

	private static void NodeFocusChanged(AccessibilityNode currentNode) { }

	private static void ScreenReaderStatusChanged(bool screenReaderEnabled) { }

	[CompilerGenerated]
	private static void set_isScreenReaderEnabled(bool value) { }

}

