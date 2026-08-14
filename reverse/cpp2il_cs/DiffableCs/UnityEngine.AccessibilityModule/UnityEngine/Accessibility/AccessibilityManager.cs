namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilityManager.h")]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.AccessibilityModule"})]
internal static class AccessibilityManager
{
	private sealed class ExclusiveLock : IDisposable
	{
		private bool m_Disposed; //Field offset: 0x10

		public ExclusiveLock() { }

		public override void Dispose() { }

		protected virtual void Finalize() { }

		private void InternalDispose() { }

	}

	internal struct NotificationContext
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private AccessibilityNotification <notification>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private bool <isScreenReaderEnabled>k__BackingField; //Field offset: 0x4
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private string <announcement>k__BackingField; //Field offset: 0x8
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private bool <wasAnnouncementSuccessful>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private AccessibilityNode <currentNode>k__BackingField; //Field offset: 0x18
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private AccessibilityNode <nextNode>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private float <fontScale>k__BackingField; //Field offset: 0x28
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private bool <isBoldTextEnabled>k__BackingField; //Field offset: 0x2C
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private bool <isClosedCaptioningEnabled>k__BackingField; //Field offset: 0x2D
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private AccessibilityNotificationContext <nativeContext>k__BackingField; //Field offset: 0x30

		public string announcement
		{
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public AccessibilityNode currentNode
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public float fontScale
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 6
			[CompilerGenerated]
			 set { } //Length: 6
		}

		public bool isBoldTextEnabled
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public bool isClosedCaptioningEnabled
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public bool isScreenReaderEnabled
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public AccessibilityNotificationContext nativeContext
		{
			[CompilerGenerated]
			 set { } //Length: 26
		}

		public AccessibilityNode nextNode
		{
			[CompilerGenerated]
			 set { } //Length: 13
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
			 set { } //Length: 4
		}

		public NotificationContext(ref AccessibilityNotificationContext nativeNotification) { }

		[CompilerGenerated]
		[IsReadOnly]
		public AccessibilityNode get_currentNode() { }

		[CompilerGenerated]
		[IsReadOnly]
		public float get_fontScale() { }

		[CompilerGenerated]
		[IsReadOnly]
		public bool get_isBoldTextEnabled() { }

		[CompilerGenerated]
		[IsReadOnly]
		public bool get_isClosedCaptioningEnabled() { }

		[CompilerGenerated]
		[IsReadOnly]
		public bool get_isScreenReaderEnabled() { }

		[CompilerGenerated]
		[IsReadOnly]
		public AccessibilityNotification get_notification() { }

		[CompilerGenerated]
		public void set_announcement(string value) { }

		[CompilerGenerated]
		public void set_currentNode(AccessibilityNode value) { }

		[CompilerGenerated]
		public void set_fontScale(float value) { }

		[CompilerGenerated]
		public void set_isBoldTextEnabled(bool value) { }

		[CompilerGenerated]
		public void set_isClosedCaptioningEnabled(bool value) { }

		[CompilerGenerated]
		public void set_isScreenReaderEnabled(bool value) { }

		[CompilerGenerated]
		public void set_nativeContext(AccessibilityNotificationContext value) { }

		[CompilerGenerated]
		public void set_nextNode(AccessibilityNode value) { }

		[CompilerGenerated]
		public void set_notification(AccessibilityNotification value) { }

		[CompilerGenerated]
		public void set_wasAnnouncementSuccessful(bool value) { }

	}

	private static Queue<NotificationContext> s_AsyncNotificationContexts; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Boolean> screenReaderStatusChanged; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<AccessibilityNode> nodeFocusChanged; //Field offset: 0x10

	public static event Action<AccessibilityNode> nodeFocusChanged
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public static event Action<Boolean> screenReaderStatusChanged
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	private static AccessibilityManager() { }

	[CompilerGenerated]
	public static void add_nodeFocusChanged(Action<AccessibilityNode> value) { }

	[CompilerGenerated]
	public static void add_screenReaderStatusChanged(Action<Boolean> value) { }

	internal static IDisposable GetExclusiveLock() { }

	[RequiredByNativeCode]
	internal static bool Internal_GetNode(int id, ref AccessibilityNodeData nodeData) { }

	[RequiredByNativeCode]
	private static int Internal_GetNodeIdAt(float x, float y) { }

	[RequiredByNativeCode]
	private static Int32[] Internal_GetRootNodeIds() { }

	[RequiredByNativeCode]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.AccessibilityModule"})]
	internal static void Internal_Initialize() { }

	[RequiredByNativeCode]
	private static void Internal_OnAccessibilityNotificationReceived(ref AccessibilityNotificationContext context) { }

	[RequiredByNativeCode]
	private static void Internal_Update() { }

	internal static bool IsScreenReaderEnabled() { }

	[ThreadSafe]
	private static void Lock() { }

	internal static void QueueNotification(NotificationContext notification) { }

	[CompilerGenerated]
	public static void remove_nodeFocusChanged(Action<AccessibilityNode> value) { }

	[CompilerGenerated]
	public static void remove_screenReaderStatusChanged(Action<Boolean> value) { }

	internal static void SendAccessibilityNotification(in AccessibilityNotificationContext context) { }

	[ThreadSafe]
	private static void Unlock() { }

}

