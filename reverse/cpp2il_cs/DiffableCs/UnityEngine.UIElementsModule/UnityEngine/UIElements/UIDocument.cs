namespace UnityEngine.UIElements;

[AddComponentMenu("UI Toolkit/UI Document")]
[DefaultExecutionOrder(-100)]
[DisallowMultipleComponent]
[ExecuteAlways]
[HelpURL("UIE-get-started-with-runtime-ui")]
public sealed class UIDocument : MonoBehaviour
{
	public enum WorldSpaceSizeMode
	{
		Dynamic = 0,
		Fixed = 1,
	}

	internal const string k_RootStyleClassName = "unity-ui-document__root"; //Field offset: 0x0
	internal const string k_VisualElementNameSuffix = "-container"; //Field offset: 0x0
	private const int k_DefaultSortingOrder = 0; //Field offset: 0x0
	private static int s_CurrentUIDocumentCounter; //Field offset: 0x0
	internal readonly int m_UIDocumentCreationIndex; //Field offset: 0x20
	[SerializeField]
	private PanelSettings m_PanelSettings; //Field offset: 0x28
	private PanelSettings m_PreviousPanelSettings; //Field offset: 0x30
	[SerializeField]
	private UIDocument m_ParentUI; //Field offset: 0x38
	private UIDocumentList m_ChildrenContent; //Field offset: 0x40
	private List<UIDocument> m_ChildrenContentCopy; //Field offset: 0x48
	[SerializeField]
	private VisualTreeAsset sourceAsset; //Field offset: 0x50
	private VisualElement m_RootVisualElement; //Field offset: 0x58
	private RuntimePanel m_RuntimePanel; //Field offset: 0x60
	private int m_FirstChildInsertIndex; //Field offset: 0x68
	[SerializeField]
	private float m_SortingOrder; //Field offset: 0x6C
	[SerializeField]
	private WorldSpaceSizeMode m_WorldSpaceSizeMode; //Field offset: 0x70
	[SerializeField]
	private float m_WorldSpaceWidth; //Field offset: 0x74
	[SerializeField]
	private float m_WorldSpaceHeight; //Field offset: 0x78
	private bool m_RootHasWorldTransform; //Field offset: 0x7C

	internal int firstChildInserIndex
	{
		internal get { } //Length: 4
	}

	public PanelSettings panelSettings
	{
		 get { } //Length: 7
		 set { } //Length: 716
	}

	public private UIDocument parentUI
	{
		 get { } //Length: 5
		private set { } //Length: 13
	}

	private float pixelsPerUnit
	{
		private get { } //Length: 29
	}

	public VisualElement rootVisualElement
	{
		 get { } //Length: 7
	}

	public IRuntimePanel runtimePanel
	{
		 get { } //Length: 26
	}

	public float sortingOrder
	{
		 get { } //Length: 6
		 set { } //Length: 25
	}

	public VisualTreeAsset visualTreeAsset
	{
		 get { } //Length: 7
		 set { } //Length: 37
	}

	internal WorldSpaceSizeMode worldSpaceSizeMode
	{
		internal get { } //Length: 4
	}

	private UIDocument() { }

	private void AddChildAndInsertContentToVisualTree(UIDocument child) { }

	private void AddOrRemoveRendererComponent() { }

	private void AddRootVisualElementToTree() { }

	internal void ApplySortingOrder() { }

	private void Awake() { }

	private void ClearTransform() { }

	private void ComputeTransform(Transform transform, out Matrix4x4 matrix) { }

	private UIDocument FindUIDocumentParent() { }

	internal int get_firstChildInserIndex() { }

	public PanelSettings get_panelSettings() { }

	public UIDocument get_parentUI() { }

	private float get_pixelsPerUnit() { }

	public VisualElement get_rootVisualElement() { }

	public IRuntimePanel get_runtimePanel() { }

	public float get_sortingOrder() { }

	public VisualTreeAsset get_visualTreeAsset() { }

	internal WorldSpaceSizeMode get_worldSpaceSizeMode() { }

	private void LateUpdate() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnTransformChildrenChanged() { }

	private void OnTransformParentChanged() { }

	internal void ReactToHierarchyChanged() { }

	private void RecreateUI() { }

	private void RemoveChild(UIDocument child) { }

	private void RemoveFromHierarchy() { }

	internal void Reset() { }

	private void ResolveRuntimePanel() { }

	public void set_panelSettings(PanelSettings value) { }

	private void set_parentUI(UIDocument value) { }

	public void set_sortingOrder(float value) { }

	public void set_visualTreeAsset(VisualTreeAsset value) { }

	private static void SetNoTransform(VisualElement visualElement) { }

	private void SetTransform() { }

	private void SetupFromHierarchy() { }

	private void SetupRootClassList() { }

	private void UpdateCutRenderChainFlag() { }

	private void UpdateRenderer() { }

	private void UpdateWorldSpaceSize() { }

}

