namespace UnityEngine;

[NativeHeader("Modules/IMGUI/GUILayoutUtility.bindings.h")]
public class GUILayoutUtility
{
	[DebuggerDisplay("id={id}, groups={layoutGroups.Count}")]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	public sealed class LayoutCache
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private int <id>k__BackingField; //Field offset: 0x10
		public GUILayoutGroup topLevel; //Field offset: 0x18
		internal GenericStack layoutGroups; //Field offset: 0x20
		internal GUILayoutGroup windows; //Field offset: 0x28

		private int id
		{
			[CompilerGenerated]
			private set { } //Length: 4
		}

		public LayoutCache(int instanceID = -1) { }

		public void ResetCursor() { }

		[CompilerGenerated]
		private void set_id(int value) { }

	}

	private static readonly Dictionary<Int32, LayoutCache> s_StoredLayouts; //Field offset: 0x0
	private static readonly Dictionary<Int32, LayoutCache> s_StoredWindows; //Field offset: 0x8
	internal static LayoutCache current; //Field offset: 0x10
	internal static readonly Rect kDummyRect; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static int <unbalancedgroupscount>k__BackingField; //Field offset: 0x28
	private static GUIStyle s_SpaceStyle; //Field offset: 0x30

	internal static GUIStyle spaceStyle
	{
		internal get { } //Length: 371
	}

	internal static int unbalancedgroupscount
	{
		[CompilerGenerated]
		internal get { } //Length: 78
		[CompilerGenerated]
		internal set { } //Length: 83
	}

	private static GUILayoutUtility() { }

	internal static void Begin(int instanceID) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void BeginContainer(LayoutCache cache) { }

	internal static GUILayoutGroup BeginLayoutArea(GUIStyle style, Type layoutType) { }

	internal static GUILayoutGroup BeginLayoutGroup(GUIStyle style, GUILayoutOption[] options, Type layoutType) { }

	internal static void BeginWindow(int windowID, GUIStyle style, GUILayoutOption[] options) { }

	private static GUILayoutGroup CreateGUILayoutGroupInstanceOfType(Type LayoutType) { }

	private static Rect DoGetRect(float minWidth, float maxWidth, float minHeight, float maxHeight, GUIStyle style, GUILayoutOption[] options) { }

	private static Rect DoGetRect(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	internal static void EndLayoutArea() { }

	internal static void EndLayoutGroup() { }

	internal static GUIStyle get_spaceStyle() { }

	[CompilerGenerated]
	internal static int get_unbalancedgroupscount() { }

	internal static LayoutCache GetLayoutCache(int instanceID, bool isWindow) { }

	public static Rect GetRect(float width, float height, GUIStyle style, GUILayoutOption[] options) { }

	public static Rect GetRect(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	private static Rect Internal_GetWindowRect(int windowID) { }

	private static void Internal_GetWindowRect_Injected(int windowID, out Rect ret) { }

	private static void Internal_MoveWindow(int windowID, Rect r) { }

	private static void Internal_MoveWindow_Injected(int windowID, in Rect r) { }

	internal static void Layout() { }

	internal static void LayoutFreeGroup(GUILayoutGroup toplevel) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void LayoutFromContainer(float w, float h) { }

	internal static void LayoutFromEditorWindow() { }

	private static void LayoutSingleGroup(GUILayoutGroup i) { }

	internal static void RemoveSelectedIdList(int instanceID, bool isWindow) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static LayoutCache SelectIDList(int instanceID, bool isWindow) { }

	[CompilerGenerated]
	internal static void set_unbalancedgroupscount(int value) { }

}

