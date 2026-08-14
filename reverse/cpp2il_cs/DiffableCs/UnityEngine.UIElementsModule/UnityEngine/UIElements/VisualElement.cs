namespace UnityEngine.UIElements;

[DefaultMember("Item")]
public class VisualElement : Focusable, IResolvedStyle, IStylePropertyAnimations, ITransform, ITransitionAnimations, IExperimentalFeatures, IVisualElementScheduler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass507_0
	{
		public VisualElement <>4__this; //Field offset: 0x10
		public StyleValues to; //Field offset: 0x18

		public <>c__DisplayClass507_0() { }

		internal StyleValues <UnityEngine.UIElements.Experimental.ITransitionAnimations.Start>b__0(VisualElement e) { }

	}

	private abstract class BaseVisualElementScheduledItem : ScheduledItem, IVisualElementScheduledItem
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private VisualElement <element>k__BackingField; //Field offset: 0x38
		public bool isScheduled; //Field offset: 0x40
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private bool <isActive>k__BackingField; //Field offset: 0x41
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private bool <isDetaching>k__BackingField; //Field offset: 0x42
		private readonly EventCallback<AttachToPanelEvent> m_OnAttachToPanelCallback; //Field offset: 0x48
		private readonly EventCallback<DetachFromPanelEvent> m_OnDetachFromPanelCallback; //Field offset: 0x50

		public private override VisualElement element
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 13
		}

		public private override bool isActive
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 4
		}

		public private bool isDetaching
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 4
		}

		protected BaseVisualElementScheduledItem(VisualElement handler) { }

		public bool CanBeActivated() { }

		public override IVisualElementScheduledItem Every(long intervalMs) { }

		public override void ExecuteLater(long delayMs) { }

		[CompilerGenerated]
		public override VisualElement get_element() { }

		[CompilerGenerated]
		public override bool get_isActive() { }

		[CompilerGenerated]
		public bool get_isDetaching() { }

		private void OnElementAttachToPanelCallback(AttachToPanelEvent evt) { }

		private void OnElementDetachFromPanelCallback(DetachFromPanelEvent evt) { }

		internal virtual void OnItemUnscheduled() { }

		public void OnPanelActivate() { }

		public void OnPanelDeactivate() { }

		public override void Pause() { }

		public override void Resume() { }

		private void SendActivation() { }

		private void SendDeactivation() { }

		[CompilerGenerated]
		private void set_element(VisualElement value) { }

		[CompilerGenerated]
		private void set_isActive(bool value) { }

		[CompilerGenerated]
		private void set_isDetaching(bool value) { }

		private void SetActive(bool action) { }

		public override IVisualElementScheduledItem StartingIn(long delayMs) { }

		public override IVisualElementScheduledItem Until(Func<Boolean> stopCondition) { }

	}

	public class CustomStyleAccess : ICustomStyle
	{
		private Dictionary<String, StylePropertyValue> m_CustomProperties; //Field offset: 0x10
		private float m_DpiScaling; //Field offset: 0x18

		public CustomStyleAccess() { }

		private static void LogCustomPropertyWarning(string propertyName, StyleValueType valueType, StylePropertyValue customProp) { }

		public void SetContext(Dictionary<String, StylePropertyValue> customProperties, float dpiScaling) { }

		public override bool TryGetValue(CustomStyleProperty<Single> property, out float value) { }

		public override bool TryGetValue(CustomStyleProperty<Int32> property, out int value) { }

		public override bool TryGetValue(CustomStyleProperty<Color> property, out Color value) { }

		public override bool TryGetValue(CustomStyleProperty<Texture2D> property, out Texture2D value) { }

		public override bool TryGetValue(CustomStyleProperty<Sprite> property, out Sprite value) { }

		public override bool TryGetValue(CustomStyleProperty<VectorImage> property, out VectorImage value) { }

		public override bool TryGetValue(CustomStyleProperty<String> property, out string value) { }

		private bool TryGetValue(string propertyName, StyleValueType valueType, out StylePropertyValue customProp) { }

	}

	[DefaultMember("Item")]
	internal struct Hierarchy
	{
		private const string k_InvalidHierarchyChangeMsg = "Cannot modify VisualElement hierarchy during layout calculation"; //Field offset: 0x0
		private readonly VisualElement m_Owner; //Field offset: 0x0

		public int childCount
		{
			 get { } //Length: 71
		}

		internal List<VisualElement> children
		{
			internal get { } //Length: 29
		}

		public VisualElement Item
		{
			 get { } //Length: 92
		}

		public VisualElement parent
		{
			 get { } //Length: 29
		}

		internal Hierarchy(VisualElement element) { }

		public void Add(VisualElement child) { }

		internal void BringToFront(VisualElement child) { }

		public IEnumerable<VisualElement> Children() { }

		public void Clear() { }

		public VisualElement ElementAt(int index) { }

		public virtual bool Equals(object obj) { }

		public bool Equals(Hierarchy other) { }

		public int get_childCount() { }

		internal List<VisualElement> get_children() { }

		public VisualElement get_Item(int key) { }

		public VisualElement get_parent() { }

		public virtual int GetHashCode() { }

		public int IndexOf(VisualElement element) { }

		public void Insert(int index, VisualElement child) { }

		private void MoveChildElement(VisualElement child, int currentIndex, int nextIndex) { }

		public static bool op_Equality(Hierarchy x, Hierarchy y) { }

		internal void PlaceBehind(VisualElement child, VisualElement over) { }

		private void PutChildAtIndex(VisualElement child, int index) { }

		private void ReleaseChildList() { }

		public void Remove(VisualElement child) { }

		public void RemoveAt(int index) { }

		private void RemoveChildAtIndex(int index) { }

		internal void SendToBack(VisualElement child) { }

		private void SetParent(VisualElement value) { }

	}

	internal enum MeasureMode
	{
		Undefined = 0,
		Exactly = 1,
		AtMost = 2,
	}

	public enum RenderTargetMode
	{
		None = 0,
		NoColorConversion = 1,
		LinearToGamma = 2,
		GammaToLinear = 3,
	}

	private class SimpleScheduledItem : VisualElementScheduledItem<Action>
	{

		public SimpleScheduledItem(VisualElement handler, Action updateEvent) { }

		public virtual void PerformTimerUpdate(TimerState state) { }

	}

	private class TimerStateScheduledItem : VisualElementScheduledItem<Action`1<TimerState>>
	{

		public TimerStateScheduledItem(VisualElement handler, Action<TimerState> updateEvent) { }

		public virtual void PerformTimerUpdate(TimerState state) { }

	}

	public class TypeData
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private readonly Type <type>k__BackingField; //Field offset: 0x10
		private string m_FullTypeName; //Field offset: 0x18
		private string m_TypeName; //Field offset: 0x20

		public string fullTypeName
		{
			 get { } //Length: 83
		}

		public Type type
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		public string typeName
		{
			 get { } //Length: 198
		}

		public TypeData(Type type) { }

		public string get_fullTypeName() { }

		[CompilerGenerated]
		public Type get_type() { }

		public string get_typeName() { }

	}

	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<VisualElement, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		protected UxmlStringAttributeDescription m_Name; //Field offset: 0x18
		private UxmlBoolAttributeDescription m_EnabledSelf; //Field offset: 0x20
		private UxmlStringAttributeDescription m_ViewDataKey; //Field offset: 0x28
		protected UxmlEnumAttributeDescription<PickingMode> m_PickingMode; //Field offset: 0x30
		private UxmlStringAttributeDescription m_Tooltip; //Field offset: 0x38
		private UxmlEnumAttributeDescription<UsageHints> m_UsageHints; //Field offset: 0x40
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private UxmlIntAttributeDescription <focusIndex>k__BackingField; //Field offset: 0x48
		private UxmlIntAttributeDescription m_TabIndex; //Field offset: 0x50
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private UxmlBoolAttributeDescription <focusable>k__BackingField; //Field offset: 0x58
		private UxmlStringAttributeDescription m_Class; //Field offset: 0x60
		private UxmlStringAttributeDescription m_ContentContainer; //Field offset: 0x68
		private UxmlStringAttributeDescription m_Style; //Field offset: 0x70
		private UxmlAssetAttributeDescription<Object> m_DataSource; //Field offset: 0x78
		private UxmlStringAttributeDescription m_DataSourcePath; //Field offset: 0x80

		protected UxmlBoolAttributeDescription focusable
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		protected UxmlIntAttributeDescription focusIndex
		{
			[CompilerGenerated]
			 get { } //Length: 5
		}

		public UxmlTraits() { }

		[CompilerGenerated]
		protected UxmlBoolAttributeDescription get_focusable() { }

		[CompilerGenerated]
		protected UxmlIntAttributeDescription get_focusIndex() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	private abstract class VisualElementScheduledItem : BaseVisualElementScheduledItem
	{
		public ActionType updateEvent; //Field offset: 0x0

		public VisualElementScheduledItem`1(VisualElement handler, ActionType upEvent) { }

	}

	private static uint s_NextId; //Field offset: 0x0
	internal const string k_RootVisualContainerName = "rootVisualContainer"; //Field offset: 0x0
	private const VisualElementFlags worldTransformInverseDirtyDependencies = 3; //Field offset: 0x0
	private const VisualElementFlags worldBoundingBoxDirtyDependencies = 25; //Field offset: 0x0
	private static List<String> s_EmptyClassList; //Field offset: 0x8
	internal static readonly PropertyName userDataPropertyKey; //Field offset: 0x10
	public static readonly string disabledUssClassName; //Field offset: 0x18
	internal static readonly Rect s_InfiniteRect; //Field offset: 0x20
	private static readonly ProfilerMarker k_GenerateVisualContentMarker; //Field offset: 0x30
	private static Material s_runtimeMaterial; //Field offset: 0x38
	internal static readonly BindingId childCountProperty; //Field offset: 0x40
	internal static readonly BindingId contentRectProperty; //Field offset: 0xD8
	internal static readonly BindingId dataSourcePathProperty; //Field offset: 0x170
	internal static readonly BindingId dataSourceProperty; //Field offset: 0x208
	internal static readonly BindingId disablePlayModeTintProperty; //Field offset: 0x2A0
	internal static readonly BindingId enabledInHierarchyProperty; //Field offset: 0x338
	internal static readonly BindingId enabledSelfProperty; //Field offset: 0x3D0
	internal static readonly BindingId layoutProperty; //Field offset: 0x468
	internal static readonly BindingId languageDirectionProperty; //Field offset: 0x500
	internal static readonly BindingId localBoundProperty; //Field offset: 0x598
	internal static readonly BindingId nameProperty; //Field offset: 0x630
	internal static readonly BindingId panelProperty; //Field offset: 0x6C8
	internal static readonly BindingId pickingModeProperty; //Field offset: 0x760
	internal static readonly BindingId styleSheetsProperty; //Field offset: 0x7F8
	internal static readonly BindingId tooltipProperty; //Field offset: 0x890
	internal static readonly BindingId usageHintsProperty; //Field offset: 0x928
	internal static readonly BindingId userDataProperty; //Field offset: 0x9C0
	internal static readonly BindingId viewDataKeyProperty; //Field offset: 0xA58
	internal static readonly BindingId visibleProperty; //Field offset: 0xAF0
	internal static readonly BindingId visualTreeAssetSourceProperty; //Field offset: 0xB88
	internal static readonly BindingId worldBoundProperty; //Field offset: 0xC20
	internal static readonly BindingId worldTransformProperty; //Field offset: 0xCB8
	private static uint s_NextParentVersion; //Field offset: 0xD50
	private static readonly List<VisualElement> s_EmptyList; //Field offset: 0xD58
	internal static CustomStyleAccess s_CustomStyleAccess; //Field offset: 0xD60
	private static readonly Regex s_InternalStyleSheetPath; //Field offset: 0xD68
	internal static readonly PropertyName tooltipPropertyKey; //Field offset: 0xD70
	private static readonly Dictionary<Type, TypeData> s_TypeData; //Field offset: 0xD78
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <UnityEngine.UIElements.IStylePropertyAnimations.runningAnimationCount>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <UnityEngine.UIElements.IStylePropertyAnimations.completedAnimationCount>k__BackingField; //Field offset: 0x34
	private string m_Name; //Field offset: 0x38
	private List<String> m_ClassList; //Field offset: 0x40
	private Dictionary<PropertyName, Object> m_PropertyBag; //Field offset: 0x48
	internal VisualElementFlags m_Flags; //Field offset: 0x50
	private string m_ViewDataKey; //Field offset: 0x58
	private RenderHints m_RenderHints; //Field offset: 0x60
	internal Rect lastLayout; //Field offset: 0x64
	internal Rect lastPseudoPadding; //Field offset: 0x74
	internal RenderChainVEData renderChainData; //Field offset: 0x88
	internal bool shouldCutRenderChain; //Field offset: 0x1B8
	internal UIRenderer uiRenderer; //Field offset: 0x1C0
	private Rect m_Layout; //Field offset: 0x1C8
	private Rect m_BoundingBox; //Field offset: 0x1D8
	private Rect m_WorldBoundingBox; //Field offset: 0x1E8
	private Matrix4x4 m_WorldTransformCache; //Field offset: 0x1F8
	private Matrix4x4 m_WorldTransformInverseCache; //Field offset: 0x238
	private Rect m_WorldClip; //Field offset: 0x278
	private Rect m_WorldClipMinusGroup; //Field offset: 0x288
	private bool m_WorldClipIsInfinite; //Field offset: 0x298
	internal PseudoStates triggerPseudoMask; //Field offset: 0x29C
	internal PseudoStates dependencyPseudoMask; //Field offset: 0x2A0
	private PseudoStates m_PseudoStates; //Field offset: 0x2A4
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <containedPointerIds>k__BackingField; //Field offset: 0x2A8
	private PickingMode m_PickingMode; //Field offset: 0x2AC
	private LayoutNode m_LayoutNode; //Field offset: 0x2B0
	internal ComputedStyle m_Style; //Field offset: 0x2E0
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal StyleVariableContext variableContext; //Field offset: 0x330
	internal int inheritedStylesHash; //Field offset: 0x338
	internal readonly uint controlid; //Field offset: 0x33C
	internal int imguiContainerDescendantCount; //Field offset: 0x340
	private bool m_EnabledSelf; //Field offset: 0x344
	private LanguageDirection m_LanguageDirection; //Field offset: 0x348
	private LanguageDirection m_LocalLanguageDirection; //Field offset: 0x34C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<MeshGenerationContext> <generateVisualContent>k__BackingField; //Field offset: 0x350
	private RenderTargetMode m_SubRenderTargetMode; //Field offset: 0x358
	private Material m_defaultMaterial; //Field offset: 0x360
	private List<IValueAnimationUpdate> m_RunningAnimations; //Field offset: 0x368
	private object m_DataSource; //Field offset: 0x370
	private PropertyPath m_DataSourcePath; //Field offset: 0x378
	private List<Binding> m_Bindings; //Field offset: 0x408
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Type <dataSourceType>k__BackingField; //Field offset: 0x410
	private readonly int m_TrickleDownHandleEventCategories; //Field offset: 0x418
	private readonly int m_BubbleUpHandleEventCategories; //Field offset: 0x41C
	private int m_BubbleUpEventCallbackCategories; //Field offset: 0x420
	private int m_TrickleDownEventCallbackCategories; //Field offset: 0x424
	private int m_EventInterestSelfCategories; //Field offset: 0x428
	private int m_CachedEventInterestParentCategories; //Field offset: 0x42C
	private uint m_NextParentCachedVersion; //Field offset: 0x430
	private uint m_NextParentRequiredVersion; //Field offset: 0x434
	private VisualElement m_CachedNextParentWithEventInterests; //Field offset: 0x438
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly Hierarchy <hierarchy>k__BackingField; //Field offset: 0x440
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <isRootVisualContainer>k__BackingField; //Field offset: 0x448
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <cacheAsBitmap>k__BackingField; //Field offset: 0x449
	private VisualElement m_PhysicalParent; //Field offset: 0x450
	private VisualElement m_LogicalParent; //Field offset: 0x458
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<VisualElement> elementAdded; //Field offset: 0x460
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<VisualElement> elementRemoved; //Field offset: 0x468
	private List<VisualElement> m_Children; //Field offset: 0x470
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private BaseVisualElementPanel <elementPanel>k__BackingField; //Field offset: 0x478
	private VisualTreeAsset m_VisualTreeAssetSource; //Field offset: 0x480
	internal InlineStyleAccess inlineStyleAccess; //Field offset: 0x488
	internal ResolvedStyleAccess resolvedStyleAccess; //Field offset: 0x490
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<StyleSheet> styleSheetList; //Field offset: 0x498
	private TypeData m_TypeData; //Field offset: 0x4A0

	internal event Action<VisualElement> elementAdded
	{
		[CompilerGenerated]
		internal add { } //Length: 186
		[CompilerGenerated]
		internal remove { } //Length: 186
	}

	internal event Action<VisualElement> elementRemoved
	{
		[CompilerGenerated]
		internal add { } //Length: 186
		[CompilerGenerated]
		internal remove { } //Length: 186
	}

	internal bool areAncestorsAndSelfDisplayed
	{
		internal get { } //Length: 9
		internal set { } //Length: 113
	}

	internal Rect boundingBox
	{
		internal get { } //Length: 66
	}

	private Rect boundingBoxInParentSpace
	{
		private get { } //Length: 81
	}

	public virtual bool canGrabFocus
	{
		 get { } //Length: 261
	}

	[CreateProperty(ReadOnly = True)]
	public int childCount
	{
		 get { } //Length: 112
	}

	internal List<String> classList
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 177
	}

	internal ComputedStyle computedStyle
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 8
	}

	internal int containedPointerIds
	{
		[CompilerGenerated]
		internal get { } //Length: 7
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	public override VisualElement contentContainer
	{
		 get { } //Length: 6
	}

	[CreateProperty(ReadOnly = True)]
	public Rect contentRect
	{
		 get { } //Length: 737
	}

	public ICustomStyle customStyle
	{
		 get { } //Length: 142
	}

	[CreateProperty]
	public object dataSource
	{
		 get { } //Length: 8
		 set { } //Length: 224
	}

	[CreateProperty]
	public PropertyPath dataSourcePath
	{
		 get { } //Length: 105
		 set { } //Length: 531
	}

	internal Material defaultMaterial
	{
		internal get { } //Length: 10
	}

	internal bool disableClipping
	{
		internal get { } //Length: 9
		internal set { } //Length: 45
	}

	[CreateProperty]
	public bool disablePlayModeTint
	{
		 get { } //Length: 5
		 set { } //Length: 3
	}

	internal bool disableRendering
	{
		internal get { } //Length: 9
		internal set { } //Length: 86
	}

	internal BaseVisualElementPanel elementPanel
	{
		[CompilerGenerated]
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[CreateProperty(ReadOnly = True)]
	public bool enabledInHierarchy
	{
		 get { } //Length: 16
	}

	[CreateProperty]
	public bool enabledSelf
	{
		 get { } //Length: 8
		 set { } //Length: 142
	}

	internal bool enableViewDataPersistence
	{
		internal get { } //Length: 9
	}

	internal int eventInterestParentCategories
	{
		internal get { } //Length: 59
	}

	public IExperimentalFeatures experimental
	{
		 get { } //Length: 6
	}

	public virtual FocusController focusController
	{
		 get { } //Length: 209
	}

	internal string fullTypeName
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 35
	}

	public Action<MeshGenerationContext> generateVisualContent
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	internal bool hasCompletedAnimations
	{
		internal get { } //Length: 78
	}

	internal bool hasDefaultRotationAndScale
	{
		internal get { } //Length: 250
	}

	internal bool hasInlineStyle
	{
		internal get { } //Length: 12
	}

	internal bool hasRunningAnimations
	{
		internal get { } //Length: 78
	}

	public Hierarchy hierarchy
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal bool isBoundingBoxDirty
	{
		internal get { } //Length: 9
		internal set { } //Length: 43
	}

	internal bool isCompositeRoot
	{
		internal get { } //Length: 9
		internal set { } //Length: 45
	}

	internal bool isEventInterestParentCategoriesDirty
	{
		internal get { } //Length: 9
		internal set { } //Length: 43
	}

	internal bool isLayoutManual
	{
		internal get { } //Length: 9
		private set { } //Length: 43
	}

	private bool isParentEnabledInHierarchy
	{
		private get { } //Length: 103
	}

	internal bool isRootVisualContainer
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal bool isWorldBoundingBoxDirty
	{
		internal set { } //Length: 43
	}

	internal bool isWorldBoundingBoxOrDependenciesDirty
	{
		internal get { } //Length: 8
	}

	internal bool isWorldClipDirty
	{
		internal get { } //Length: 9
		internal set { } //Length: 43
	}

	internal bool isWorldTransformDirty
	{
		internal get { } //Length: 7
		internal set { } //Length: 43
	}

	internal bool isWorldTransformInverseDirty
	{
		internal set { } //Length: 43
	}

	internal bool isWorldTransformInverseOrDependenciesDirty
	{
		internal get { } //Length: 8
	}

	public VisualElement Item
	{
		 get { } //Length: 139
	}

	[CreateProperty]
	public LanguageDirection languageDirection
	{
		 get { } //Length: 7
		 set { } //Length: 137
	}

	[CreateProperty(ReadOnly = True)]
	public internal Rect layout
	{
		 get { } //Length: 205
		internal set { } //Length: 2132
	}

	internal LayoutNode layoutNode
	{
		internal get { } //Length: 10
	}

	[CreateProperty(ReadOnly = True)]
	public Rect localBound
	{
		 get { } //Length: 131
	}

	internal LanguageDirection localLanguageDirection
	{
		internal get { } //Length: 7
		internal set { } //Length: 259
	}

	[CreateProperty]
	public string name
	{
		 get { } //Length: 7
		 set { } //Length: 186
	}

	internal VisualElement nextParentWithEventInterests
	{
		internal get { } //Length: 469
	}

	protected Rect paddingRect
	{
		 get { } //Length: 446
	}

	[CreateProperty(ReadOnly = True)]
	public IPanel panel
	{
		 get { } //Length: 10
	}

	public VisualElement parent
	{
		 get { } //Length: 10
	}

	[CreateProperty]
	public PickingMode pickingMode
	{
		 get { } //Length: 7
		 set { } //Length: 164
	}

	internal Color playModeTintColor
	{
		internal get { } //Length: 57
	}

	private Vector3 positionWithLayout
	{
		private get { } //Length: 142
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal PseudoStates pseudoStates
	{
		internal get { } //Length: 9
		internal set { } //Length: 130
	}

	internal Rect rect
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 88
	}

	internal RenderHints renderHints
	{
		internal get { } //Length: 6
		internal set { } //Length: 97
	}

	internal bool requireMeasureFunction
	{
		internal get { } //Length: 9
		internal set { } //Length: 244
	}

	[CreateProperty]
	public IResolvedStyle resolvedStyle
	{
		 get { } //Length: 133
	}

	public float scaledPixelsPerPoint
	{
		 get { } //Length: 159
	}

	[Obsolete("scaledPixelsPerPoint_noChecks is deprecated. Use scaledPixelsPerPoint instead.")]
	internal float scaledPixelsPerPoint_noChecks
	{
		internal get { } //Length: 95
	}

	public IVisualElementScheduler schedule
	{
		 get { } //Length: 6
	}

	[CreateProperty]
	public IStyle style
	{
		 get { } //Length: 121
	}

	internal IStylePropertyAnimations styleAnimation
	{
		internal get { } //Length: 4
	}

	internal bool styleInitialized
	{
		internal get { } //Length: 9
		internal set { } //Length: 45
	}

	[CreateProperty(ReadOnly = True)]
	public VisualElementStyleSheetSet styleSheets
	{
		 get { } //Length: 39
	}

	internal RenderTargetMode subRenderTargetMode
	{
		internal get { } //Length: 9
	}

	[CreateProperty]
	public string tooltip
	{
		 get { } //Length: 137
		 set { } //Length: 559
	}

	public ITransform transform
	{
		 get { } //Length: 6
	}

	private TypeData typeData
	{
		private get { } //Length: 342
	}

	internal string typeName
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 35
	}

	private override ITransitionAnimations UnityEngine.UIElements.IExperimentalFeatures.animation
	{
		private get { } //Length: 6
	}

	private override Align UnityEngine.UIElements.IResolvedStyle.alignContent
	{
		private get { } //Length: 79
	}

	private override Align UnityEngine.UIElements.IResolvedStyle.alignItems
	{
		private get { } //Length: 82
	}

	private override Align UnityEngine.UIElements.IResolvedStyle.alignSelf
	{
		private get { } //Length: 82
	}

	private override Color UnityEngine.UIElements.IResolvedStyle.backgroundColor
	{
		private get { } //Length: 209
	}

	private override Background UnityEngine.UIElements.IResolvedStyle.backgroundImage
	{
		private get { } //Length: 217
	}

	private override BackgroundPosition UnityEngine.UIElements.IResolvedStyle.backgroundPositionX
	{
		private get { } //Length: 217
	}

	private override BackgroundPosition UnityEngine.UIElements.IResolvedStyle.backgroundPositionY
	{
		private get { } //Length: 217
	}

	private override BackgroundRepeat UnityEngine.UIElements.IResolvedStyle.backgroundRepeat
	{
		private get { } //Length: 203
	}

	private override BackgroundSize UnityEngine.UIElements.IResolvedStyle.backgroundSize
	{
		private get { } //Length: 215
	}

	private override Color UnityEngine.UIElements.IResolvedStyle.borderBottomColor
	{
		private get { } //Length: 209
	}

	private override float UnityEngine.UIElements.IResolvedStyle.borderBottomLeftRadius
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.borderBottomRightRadius
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.borderBottomWidth
	{
		private get { } //Length: 82
	}

	private override Color UnityEngine.UIElements.IResolvedStyle.borderLeftColor
	{
		private get { } //Length: 209
	}

	private override float UnityEngine.UIElements.IResolvedStyle.borderLeftWidth
	{
		private get { } //Length: 82
	}

	private override Color UnityEngine.UIElements.IResolvedStyle.borderRightColor
	{
		private get { } //Length: 209
	}

	private override float UnityEngine.UIElements.IResolvedStyle.borderRightWidth
	{
		private get { } //Length: 82
	}

	private override Color UnityEngine.UIElements.IResolvedStyle.borderTopColor
	{
		private get { } //Length: 209
	}

	private override float UnityEngine.UIElements.IResolvedStyle.borderTopLeftRadius
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.borderTopRightRadius
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.borderTopWidth
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.bottom
	{
		private get { } //Length: 82
	}

	private override Color UnityEngine.UIElements.IResolvedStyle.color
	{
		private get { } //Length: 209
	}

	private override DisplayStyle UnityEngine.UIElements.IResolvedStyle.display
	{
		private get { } //Length: 82
	}

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.flexBasis
	{
		private get { } //Length: 82
	}

	private override FlexDirection UnityEngine.UIElements.IResolvedStyle.flexDirection
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.flexGrow
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.flexShrink
	{
		private get { } //Length: 82
	}

	private override Wrap UnityEngine.UIElements.IResolvedStyle.flexWrap
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.fontSize
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.height
	{
		private get { } //Length: 82
	}

	private override Justify UnityEngine.UIElements.IResolvedStyle.justifyContent
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.left
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.letterSpacing
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.marginBottom
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.marginLeft
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.marginRight
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.marginTop
	{
		private get { } //Length: 82
	}

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.maxHeight
	{
		private get { } //Length: 82
	}

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.maxWidth
	{
		private get { } //Length: 82
	}

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.minHeight
	{
		private get { } //Length: 82
	}

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.minWidth
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.opacity
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.paddingBottom
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.paddingLeft
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.paddingRight
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.paddingTop
	{
		private get { } //Length: 82
	}

	private override Position UnityEngine.UIElements.IResolvedStyle.position
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.right
	{
		private get { } //Length: 82
	}

	private override Rotate UnityEngine.UIElements.IResolvedStyle.rotate
	{
		private get { } //Length: 219
	}

	private override Scale UnityEngine.UIElements.IResolvedStyle.scale
	{
		private get { } //Length: 209
	}

	private override TextOverflow UnityEngine.UIElements.IResolvedStyle.textOverflow
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.top
	{
		private get { } //Length: 82
	}

	private override Vector3 UnityEngine.UIElements.IResolvedStyle.transformOrigin
	{
		private get { } //Length: 217
	}

	private override IEnumerable<TimeValue> UnityEngine.UIElements.IResolvedStyle.transitionDelay
	{
		private get { } //Length: 82
	}

	private override IEnumerable<TimeValue> UnityEngine.UIElements.IResolvedStyle.transitionDuration
	{
		private get { } //Length: 82
	}

	private override IEnumerable<StylePropertyName> UnityEngine.UIElements.IResolvedStyle.transitionProperty
	{
		private get { } //Length: 82
	}

	private override IEnumerable<EasingFunction> UnityEngine.UIElements.IResolvedStyle.transitionTimingFunction
	{
		private get { } //Length: 82
	}

	private override Vector3 UnityEngine.UIElements.IResolvedStyle.translate
	{
		private get { } //Length: 217
	}

	private override Color UnityEngine.UIElements.IResolvedStyle.unityBackgroundImageTintColor
	{
		private get { } //Length: 209
	}

	private override EditorTextRenderingMode UnityEngine.UIElements.IResolvedStyle.unityEditorTextRenderingMode
	{
		private get { } //Length: 82
	}

	private override Font UnityEngine.UIElements.IResolvedStyle.unityFont
	{
		private get { } //Length: 203
	}

	private override FontDefinition UnityEngine.UIElements.IResolvedStyle.unityFontDefinition
	{
		private get { } //Length: 209
	}

	private override FontStyle UnityEngine.UIElements.IResolvedStyle.unityFontStyleAndWeight
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.unityParagraphSpacing
	{
		private get { } //Length: 82
	}

	private override int UnityEngine.UIElements.IResolvedStyle.unitySliceBottom
	{
		private get { } //Length: 82
	}

	private override int UnityEngine.UIElements.IResolvedStyle.unitySliceLeft
	{
		private get { } //Length: 82
	}

	private override int UnityEngine.UIElements.IResolvedStyle.unitySliceRight
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.unitySliceScale
	{
		private get { } //Length: 82
	}

	private override int UnityEngine.UIElements.IResolvedStyle.unitySliceTop
	{
		private get { } //Length: 82
	}

	private override TextAnchor UnityEngine.UIElements.IResolvedStyle.unityTextAlign
	{
		private get { } //Length: 82
	}

	private override TextGeneratorType UnityEngine.UIElements.IResolvedStyle.unityTextGenerator
	{
		private get { } //Length: 82
	}

	private override Color UnityEngine.UIElements.IResolvedStyle.unityTextOutlineColor
	{
		private get { } //Length: 209
	}

	private override float UnityEngine.UIElements.IResolvedStyle.unityTextOutlineWidth
	{
		private get { } //Length: 82
	}

	private override TextOverflowPosition UnityEngine.UIElements.IResolvedStyle.unityTextOverflowPosition
	{
		private get { } //Length: 82
	}

	private override Visibility UnityEngine.UIElements.IResolvedStyle.visibility
	{
		private get { } //Length: 82
	}

	private override WhiteSpace UnityEngine.UIElements.IResolvedStyle.whiteSpace
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.width
	{
		private get { } //Length: 82
	}

	private override float UnityEngine.UIElements.IResolvedStyle.wordSpacing
	{
		private get { } //Length: 82
	}

	private override int UnityEngine.UIElements.IStylePropertyAnimations.completedAnimationCount
	{
		[CompilerGenerated]
		private get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	private override int UnityEngine.UIElements.IStylePropertyAnimations.runningAnimationCount
	{
		[CompilerGenerated]
		private get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	private override Vector3 UnityEngine.UIElements.ITransform.position
	{
		private get { } //Length: 231
		private set { } //Length: 397
	}

	private override Vector3 UnityEngine.UIElements.ITransform.scale
	{
		private get { } //Length: 280
	}

	[CreateProperty]
	public UsageHints usageHints
	{
		 get { } //Length: 45
		 set { } //Length: 536
	}

	[CreateProperty]
	public object userData
	{
		 get { } //Length: 158
		 set { } //Length: 325
	}

	[CreateProperty]
	public string viewDataKey
	{
		 get { } //Length: 5
		 set { } //Length: 200
	}

	[CreateProperty]
	public bool visible
	{
		 get { } //Length: 88
		 set { } //Length: 372
	}

	[CreateProperty(ReadOnly = True)]
	public internal VisualTreeAsset visualTreeAssetSource
	{
		 get { } //Length: 8
		internal set { } //Length: 19
	}

	[CreateProperty(ReadOnly = True)]
	public Rect worldBound
	{
		 get { } //Length: 253
	}

	internal Rect worldBoundingBox
	{
		internal get { } //Length: 177
	}

	internal Rect worldClip
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 66
	}

	internal bool worldClipIsInfinite
	{
		internal get { } //Length: 52
	}

	internal Rect worldClipMinusGroup
	{
		internal get { } //Length: 66
	}

	[CreateProperty(ReadOnly = True)]
	public Matrix4x4 worldTransform
	{
		 get { } //Length: 107
	}

	internal Matrix4x4 worldTransformInverse
	{
		internal get { } //Length: 126
	}

	internal Matrix4x4 worldTransformRef
	{
		internal get { } //Length: 48
	}

	private static VisualElement() { }

	public VisualElement() { }

	public void Add(VisualElement child) { }

	[CompilerGenerated]
	internal void add_elementAdded(Action<VisualElement> value) { }

	[CompilerGenerated]
	internal void add_elementRemoved(Action<VisualElement> value) { }

	internal void AddEventCallbackCategories(int eventCategories, TrickleDown trickleDown) { }

	internal void AddStyleSheetPath(string sheetPath) { }

	public void AddToClassList(string className) { }

	private void AssignMeasureFunction() { }

	private static void AssignStyleValues(VisualElement ve, StyleValues src) { }

	private void AttachDataSource() { }

	public void BringToFront() { }

	internal static Rect CalculateConservativeRect(ref Matrix4x4 matrix, Rect rect) { }

	private void ChangeIMGUIContainerCount(int delta) { }

	private static void CheckUserKeyArgument(PropertyName key) { }

	public IEnumerable<VisualElement> Children() { }

	public bool ClassListContains(string cls) { }

	public void Clear() { }

	internal void ClearManualLayout() { }

	internal bool ClearProperty(PropertyName key) { }

	private Rect CombineClipRects(Rect rect, Rect parentRect) { }

	internal static Rect ComputeAAAlignedBound(Rect position, Matrix4x4 mat) { }

	public bool Contains(VisualElement child) { }

	public override bool ContainsPoint(Vector2 localPoint) { }

	private void CreateBindingRequests() { }

	private void DetachDataSource() { }

	private void DirtyNextParentWithEventInterests() { }

	protected private override Vector2 DoMeasure(float desiredWidth, MeasureMode widthMode, float desiredHeight, MeasureMode heightMode) { }

	public VisualElement ElementAt(int index) { }

	internal VisualElement ElementAtTreePath(List<Int32> childIndexes) { }

	public void EnableInClassList(string className, bool enable) { }

	internal void EnsureWorldTransformAndClipUpToDate() { }

	protected virtual void Finalize() { }

	private void FinalizeLayout() { }

	public VisualElement FindCommonAncestor(VisualElement other) { }

	internal bool FindElementInTree(VisualElement element, List<Int32> outChildIndexes) { }

	public virtual void Focus() { }

	private void GatherAllChildren(List<VisualElement> elements) { }

	internal bool get_areAncestorsAndSelfDisplayed() { }

	internal Rect get_boundingBox() { }

	private Rect get_boundingBoxInParentSpace() { }

	public virtual bool get_canGrabFocus() { }

	public int get_childCount() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<String> get_classList() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal ComputedStyle get_computedStyle() { }

	[CompilerGenerated]
	internal int get_containedPointerIds() { }

	public override VisualElement get_contentContainer() { }

	public Rect get_contentRect() { }

	public ICustomStyle get_customStyle() { }

	public object get_dataSource() { }

	public PropertyPath get_dataSourcePath() { }

	internal Material get_defaultMaterial() { }

	internal bool get_disableClipping() { }

	public bool get_disablePlayModeTint() { }

	internal bool get_disableRendering() { }

	[CompilerGenerated]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal BaseVisualElementPanel get_elementPanel() { }

	public bool get_enabledInHierarchy() { }

	public bool get_enabledSelf() { }

	internal bool get_enableViewDataPersistence() { }

	internal int get_eventInterestParentCategories() { }

	public IExperimentalFeatures get_experimental() { }

	public virtual FocusController get_focusController() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal string get_fullTypeName() { }

	[CompilerGenerated]
	public Action<MeshGenerationContext> get_generateVisualContent() { }

	internal bool get_hasCompletedAnimations() { }

	internal bool get_hasDefaultRotationAndScale() { }

	internal bool get_hasInlineStyle() { }

	internal bool get_hasRunningAnimations() { }

	[CompilerGenerated]
	public Hierarchy get_hierarchy() { }

	internal bool get_isBoundingBoxDirty() { }

	internal bool get_isCompositeRoot() { }

	internal bool get_isEventInterestParentCategoriesDirty() { }

	internal bool get_isLayoutManual() { }

	private bool get_isParentEnabledInHierarchy() { }

	[CompilerGenerated]
	internal bool get_isRootVisualContainer() { }

	internal bool get_isWorldBoundingBoxOrDependenciesDirty() { }

	internal bool get_isWorldClipDirty() { }

	internal bool get_isWorldTransformDirty() { }

	internal bool get_isWorldTransformInverseOrDependenciesDirty() { }

	public VisualElement get_Item(int key) { }

	public LanguageDirection get_languageDirection() { }

	public Rect get_layout() { }

	internal LayoutNode get_layoutNode() { }

	public Rect get_localBound() { }

	internal LanguageDirection get_localLanguageDirection() { }

	public string get_name() { }

	internal VisualElement get_nextParentWithEventInterests() { }

	protected Rect get_paddingRect() { }

	public IPanel get_panel() { }

	public VisualElement get_parent() { }

	public PickingMode get_pickingMode() { }

	internal Color get_playModeTintColor() { }

	private Vector3 get_positionWithLayout() { }

	internal PseudoStates get_pseudoStates() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal Rect get_rect() { }

	internal RenderHints get_renderHints() { }

	internal bool get_requireMeasureFunction() { }

	public IResolvedStyle get_resolvedStyle() { }

	public float get_scaledPixelsPerPoint() { }

	internal float get_scaledPixelsPerPoint_noChecks() { }

	public IVisualElementScheduler get_schedule() { }

	public IStyle get_style() { }

	internal IStylePropertyAnimations get_styleAnimation() { }

	internal bool get_styleInitialized() { }

	public VisualElementStyleSheetSet get_styleSheets() { }

	internal RenderTargetMode get_subRenderTargetMode() { }

	public string get_tooltip() { }

	public ITransform get_transform() { }

	private TypeData get_typeData() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal string get_typeName() { }

	public UsageHints get_usageHints() { }

	public object get_userData() { }

	public string get_viewDataKey() { }

	public bool get_visible() { }

	public VisualTreeAsset get_visualTreeAssetSource() { }

	public Rect get_worldBound() { }

	internal Rect get_worldBoundingBox() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal Rect get_worldClip() { }

	internal bool get_worldClipIsInfinite() { }

	internal Rect get_worldClipMinusGroup() { }

	public Matrix4x4 get_worldTransform() { }

	internal Matrix4x4 get_worldTransformInverse() { }

	internal Matrix4x4 get_worldTransformRef() { }

	private VisualElementAnimationSystem GetAnimationSystem() { }

	internal bool GetCachedNextParentWithEventInterests(out VisualElement nextParent) { }

	internal List<String> GetClassesForIteration() { }

	public T GetFirstAncestorOfType() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal VisualElement GetFirstAncestorWhere(Predicate<VisualElement> predicate) { }

	public T GetFirstOfType() { }

	internal void GetFullHierarchicalViewDataKey(StringBuilder key) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal string GetFullHierarchicalViewDataKey() { }

	internal VisualElement GetNextElementDepthFirst() { }

	internal T GetOrCreateViewData(object existing, string key) { }

	private Nullable<Single> GetParentSizeForLengthConversion(StylePropertyId id, int subPropertyIndex = 0) { }

	internal void GetPivotedMatrixWithLayout(out Matrix4x4 result) { }

	internal VisualElement GetPreviousElementDepthFirst() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal object GetProperty(PropertyName key) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal VisualElement GetRoot() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal VisualElement GetRootVisualContainer() { }

	private IStylePropertyAnimationSystem GetStylePropertyAnimationSystem() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal override Rect GetTooltipRect() { }

	internal bool HasBubbleUpEventCallbacks(int eventCategories) { }

	internal bool HasBubbleUpEventInterests(int eventCategories) { }

	internal bool HasBubbleUpHandleEvent(int eventCategories) { }

	private void HasChangedPanel(BaseVisualElementPanel prevPanel) { }

	internal bool HasParentEventInterests(EventCategory eventCategory) { }

	internal bool HasParentEventInterests(int eventCategories) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool HasProperty(PropertyName key) { }

	internal bool HasSelfEventInterests(EventCategory eventCategory) { }

	internal bool HasSelfEventInterests(int eventCategories) { }

	internal bool HasTrickleDownEventCallbacks(int eventCategories) { }

	internal bool HasTrickleDownEventInterests(int eventCategories) { }

	internal bool HasTrickleDownHandleEvent(int eventCategories) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void IncrementVersion(VersionChangeType changeType) { }

	public int IndexOf(VisualElement element) { }

	public void Insert(int index, VisualElement element) { }

	internal void InvokeGenerateVisualContent(MeshGenerationContext mgc) { }

	internal void InvokeHierarchyChanged(HierarchyChangeType changeType) { }

	private static bool IsPartOfCapturedChain(VisualElement self, in IEventHandler capturingElement) { }

	public void MarkDirtyRepaint() { }

	internal void MarkRenderHintsClean() { }

	internal static float Max(float a, float b, float c, float d) { }

	internal static void Measure(VisualElement ve, ref LayoutNode node, float width, LayoutMeasureMode widthMode, float height, LayoutMeasureMode heightMode, out LayoutSize result) { }

	internal static float Min(float a, float b, float c, float d) { }

	internal static void MultiplyMatrix34(ref Matrix4x4 lhs, ref Matrix4x4 rhs, out Matrix4x4 res) { }

	internal static Vector2 MultiplyMatrix44Point2(ref Matrix4x4 lhs, Vector2 point) { }

	internal static Vector2 MultiplyVector2(ref Matrix4x4 lhs, Vector2 vector) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal override void OnViewDataReady() { }

	internal static void OrderMinMaxRect(ref Rect rect) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void OverwriteFromViewData(object obj, string key) { }

	public void PlaceBehind(VisualElement sibling) { }

	private void ProcessBindingRequests() { }

	private void PropagateCachedNextParentWithEventInterests(VisualElement nextParent, VisualElement stopParent) { }

	private void PropagateEnabledToChildren(bool value) { }

	private StyleValues ReadCurrentValues(VisualElement ve, StyleValues targetValuesToRead) { }

	internal void RegisterAnimation(IValueAnimationUpdate anim) { }

	private void RegisterRunningAnimations() { }

	public void Remove(VisualElement element) { }

	[CompilerGenerated]
	internal void remove_elementAdded(Action<VisualElement> value) { }

	[CompilerGenerated]
	internal void remove_elementRemoved(Action<VisualElement> value) { }

	public void RemoveFromClassList(string className) { }

	public void RemoveFromHierarchy() { }

	private void RemoveMeasureFunction() { }

	internal StyleFloat ResolveLengthValue(Length length, bool isRow) { }

	private Quaternion ResolveRotation() { }

	private Vector3 ResolveScale() { }

	internal Vector3 ResolveTransformOrigin() { }

	internal Vector3 ResolveTranslate() { }

	internal VisualElement RetargetElement(VisualElement retargetAgainst) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void SaveViewData() { }

	internal virtual void SendEvent(EventBase e, DispatchMode dispatchMode) { }

	public virtual void SendEvent(EventBase e) { }

	public void SendToBack() { }

	internal void set_areAncestorsAndSelfDisplayed(bool value) { }

	[CompilerGenerated]
	internal void set_containedPointerIds(int value) { }

	public void set_dataSource(object value) { }

	public void set_dataSourcePath(PropertyPath value) { }

	internal void set_disableClipping(bool value) { }

	public void set_disablePlayModeTint(bool value) { }

	internal void set_disableRendering(bool value) { }

	[CompilerGenerated]
	private void set_elementPanel(BaseVisualElementPanel value) { }

	public void set_enabledSelf(bool value) { }

	[CompilerGenerated]
	public void set_generateVisualContent(Action<MeshGenerationContext> value) { }

	internal void set_isBoundingBoxDirty(bool value) { }

	internal void set_isCompositeRoot(bool value) { }

	internal void set_isEventInterestParentCategoriesDirty(bool value) { }

	private void set_isLayoutManual(bool value) { }

	[CompilerGenerated]
	internal void set_isRootVisualContainer(bool value) { }

	internal void set_isWorldBoundingBoxDirty(bool value) { }

	internal void set_isWorldClipDirty(bool value) { }

	internal void set_isWorldTransformDirty(bool value) { }

	internal void set_isWorldTransformInverseDirty(bool value) { }

	public void set_languageDirection(LanguageDirection value) { }

	internal void set_layout(Rect value) { }

	internal void set_localLanguageDirection(LanguageDirection value) { }

	public void set_name(string value) { }

	public void set_pickingMode(PickingMode value) { }

	internal void set_pseudoStates(PseudoStates value) { }

	internal void set_renderHints(RenderHints value) { }

	internal void set_requireMeasureFunction(bool value) { }

	internal void set_styleInitialized(bool value) { }

	public void set_tooltip(string value) { }

	public void set_usageHints(UsageHints value) { }

	public void set_userData(object value) { }

	public void set_viewDataKey(string value) { }

	public void set_visible(bool value) { }

	internal void set_visualTreeAssetSource(VisualTreeAsset value) { }

	internal void SetAsNextParentWithEventInterests() { }

	internal void SetComputedStyle(ref ComputedStyle newStyle) { }

	public void SetEnabled(bool value) { }

	private bool SetEnabledFromHierarchyPrivate(bool state) { }

	internal void SetInlineRule(StyleSheet sheet, StyleRule rule) { }

	internal void SetPanel(BaseVisualElementPanel p) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void SetProperty(PropertyName key, object value) { }

	private void SetPropertyInternal(PropertyName key, object value) { }

	internal void SetTooltip(TooltipEvent e) { }

	internal bool ShouldClip() { }

	private ValueAnimation<StyleValues> Start(Func<VisualElement, StyleValues> fromValueGetter, StyleValues to, int durationMs) { }

	private static ValueAnimation<T> StartAnimation(ValueAnimation<T> anim, Func<VisualElement, T> fromValueGetter, T to, int durationMs, Action<VisualElement, T> onValueChanged) { }

	private Rect SubstractBorderPadding(Rect worldRect) { }

	public virtual string ToString() { }

	private void TrackSource(object previous, object current) { }

	internal static void TransformAlignedRect(ref Matrix4x4 matrix, ref Rect rect) { }

	private void TransformAlignedRectToParentSpace(ref Rect rect) { }

	private static void TranslateMatrix34(ref Matrix4x4 lhs, Vector3 rhs, out Matrix4x4 res) { }

	private static void TranslateMatrix34InPlace(ref Matrix4x4 lhs, Vector3 rhs) { }

	internal bool TryConvertBackgroundSizeUnits(ref BackgroundSize from, ref BackgroundSize to) { }

	internal bool TryConvertLengthUnits(StylePropertyId id, ref Length from, ref Length to, int subPropertyIndex = 0) { }

	internal bool TryConvertTransformOriginUnits(ref TransformOrigin from, ref TransformOrigin to) { }

	internal bool TryConvertTranslateUnits(ref Translate from, ref Translate to) { }

	public bool TryGetBinding(BindingId bindingId, out Binding binding) { }

	private override ValueAnimation<StyleValues> UnityEngine.UIElements.Experimental.ITransitionAnimations.Start(StyleValues to, int durationMs) { }

	private override ITransitionAnimations UnityEngine.UIElements.IExperimentalFeatures.get_animation() { }

	private override Align UnityEngine.UIElements.IResolvedStyle.get_alignContent() { }

	private override Align UnityEngine.UIElements.IResolvedStyle.get_alignItems() { }

	private override Align UnityEngine.UIElements.IResolvedStyle.get_alignSelf() { }

	private override Color UnityEngine.UIElements.IResolvedStyle.get_backgroundColor() { }

	private override Background UnityEngine.UIElements.IResolvedStyle.get_backgroundImage() { }

	private override BackgroundPosition UnityEngine.UIElements.IResolvedStyle.get_backgroundPositionX() { }

	private override BackgroundPosition UnityEngine.UIElements.IResolvedStyle.get_backgroundPositionY() { }

	private override BackgroundRepeat UnityEngine.UIElements.IResolvedStyle.get_backgroundRepeat() { }

	private override BackgroundSize UnityEngine.UIElements.IResolvedStyle.get_backgroundSize() { }

	private override Color UnityEngine.UIElements.IResolvedStyle.get_borderBottomColor() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_borderBottomLeftRadius() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_borderBottomRightRadius() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_borderBottomWidth() { }

	private override Color UnityEngine.UIElements.IResolvedStyle.get_borderLeftColor() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_borderLeftWidth() { }

	private override Color UnityEngine.UIElements.IResolvedStyle.get_borderRightColor() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_borderRightWidth() { }

	private override Color UnityEngine.UIElements.IResolvedStyle.get_borderTopColor() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_borderTopLeftRadius() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_borderTopRightRadius() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_borderTopWidth() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_bottom() { }

	private override Color UnityEngine.UIElements.IResolvedStyle.get_color() { }

	private override DisplayStyle UnityEngine.UIElements.IResolvedStyle.get_display() { }

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.get_flexBasis() { }

	private override FlexDirection UnityEngine.UIElements.IResolvedStyle.get_flexDirection() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_flexGrow() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_flexShrink() { }

	private override Wrap UnityEngine.UIElements.IResolvedStyle.get_flexWrap() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_fontSize() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_height() { }

	private override Justify UnityEngine.UIElements.IResolvedStyle.get_justifyContent() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_left() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_letterSpacing() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_marginBottom() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_marginLeft() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_marginRight() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_marginTop() { }

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.get_maxHeight() { }

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.get_maxWidth() { }

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.get_minHeight() { }

	private override StyleFloat UnityEngine.UIElements.IResolvedStyle.get_minWidth() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_opacity() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_paddingBottom() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_paddingLeft() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_paddingRight() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_paddingTop() { }

	private override Position UnityEngine.UIElements.IResolvedStyle.get_position() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_right() { }

	private override Rotate UnityEngine.UIElements.IResolvedStyle.get_rotate() { }

	private override Scale UnityEngine.UIElements.IResolvedStyle.get_scale() { }

	private override TextOverflow UnityEngine.UIElements.IResolvedStyle.get_textOverflow() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_top() { }

	private override Vector3 UnityEngine.UIElements.IResolvedStyle.get_transformOrigin() { }

	private override IEnumerable<TimeValue> UnityEngine.UIElements.IResolvedStyle.get_transitionDelay() { }

	private override IEnumerable<TimeValue> UnityEngine.UIElements.IResolvedStyle.get_transitionDuration() { }

	private override IEnumerable<StylePropertyName> UnityEngine.UIElements.IResolvedStyle.get_transitionProperty() { }

	private override IEnumerable<EasingFunction> UnityEngine.UIElements.IResolvedStyle.get_transitionTimingFunction() { }

	private override Vector3 UnityEngine.UIElements.IResolvedStyle.get_translate() { }

	private override Color UnityEngine.UIElements.IResolvedStyle.get_unityBackgroundImageTintColor() { }

	private override EditorTextRenderingMode UnityEngine.UIElements.IResolvedStyle.get_unityEditorTextRenderingMode() { }

	private override Font UnityEngine.UIElements.IResolvedStyle.get_unityFont() { }

	private override FontDefinition UnityEngine.UIElements.IResolvedStyle.get_unityFontDefinition() { }

	private override FontStyle UnityEngine.UIElements.IResolvedStyle.get_unityFontStyleAndWeight() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_unityParagraphSpacing() { }

	private override int UnityEngine.UIElements.IResolvedStyle.get_unitySliceBottom() { }

	private override int UnityEngine.UIElements.IResolvedStyle.get_unitySliceLeft() { }

	private override int UnityEngine.UIElements.IResolvedStyle.get_unitySliceRight() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_unitySliceScale() { }

	private override int UnityEngine.UIElements.IResolvedStyle.get_unitySliceTop() { }

	private override TextAnchor UnityEngine.UIElements.IResolvedStyle.get_unityTextAlign() { }

	private override TextGeneratorType UnityEngine.UIElements.IResolvedStyle.get_unityTextGenerator() { }

	private override Color UnityEngine.UIElements.IResolvedStyle.get_unityTextOutlineColor() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_unityTextOutlineWidth() { }

	private override TextOverflowPosition UnityEngine.UIElements.IResolvedStyle.get_unityTextOverflowPosition() { }

	private override Visibility UnityEngine.UIElements.IResolvedStyle.get_visibility() { }

	private override WhiteSpace UnityEngine.UIElements.IResolvedStyle.get_whiteSpace() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_width() { }

	private override float UnityEngine.UIElements.IResolvedStyle.get_wordSpacing() { }

	private override void UnityEngine.UIElements.IStylePropertyAnimations.CancelAllAnimations() { }

	private override void UnityEngine.UIElements.IStylePropertyAnimations.CancelAnimation(StylePropertyId id) { }

	[CompilerGenerated]
	private override int UnityEngine.UIElements.IStylePropertyAnimations.get_completedAnimationCount() { }

	[CompilerGenerated]
	private override int UnityEngine.UIElements.IStylePropertyAnimations.get_runningAnimationCount() { }

	private override void UnityEngine.UIElements.IStylePropertyAnimations.GetAllAnimations(List<StylePropertyId> outPropertyIds) { }

	[CompilerGenerated]
	private override void UnityEngine.UIElements.IStylePropertyAnimations.set_completedAnimationCount(int value) { }

	[CompilerGenerated]
	private override void UnityEngine.UIElements.IStylePropertyAnimations.set_runningAnimationCount(int value) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, Font from, Font to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, FontDefinition from, FontDefinition to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, BackgroundRepeat from, BackgroundRepeat to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, BackgroundPosition from, BackgroundPosition to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, TransformOrigin from, TransformOrigin to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, Rotate from, Rotate to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, Translate from, Translate to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, Scale from, Scale to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, float from, float to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, int from, int to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, TextShadow from, TextShadow to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, Length from, Length to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, Color from, Color to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, BackgroundSize from, BackgroundSize to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.Start(StylePropertyId id, Background from, Background to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override bool UnityEngine.UIElements.IStylePropertyAnimations.StartEnum(StylePropertyId id, int from, int to, int durationMs, int delayMs, Func<Single, Single> easingCurve) { }

	private override void UnityEngine.UIElements.IStylePropertyAnimations.UpdateAnimation(StylePropertyId id) { }

	private override Vector3 UnityEngine.UIElements.ITransform.get_position() { }

	private override Vector3 UnityEngine.UIElements.ITransform.get_scale() { }

	private override void UnityEngine.UIElements.ITransform.set_position(Vector3 value) { }

	private override IVisualElementScheduledItem UnityEngine.UIElements.IVisualElementScheduler.Execute(Action<TimerState> timerUpdateEvent) { }

	private override IVisualElementScheduledItem UnityEngine.UIElements.IVisualElementScheduler.Execute(Action updateEvent) { }

	internal void UnregisterAnimation(IValueAnimationUpdate anim) { }

	private void UnregisterRunningAnimations() { }

	internal void UpdateBoundingBox() { }

	internal void UpdateCursorStyle(long eventType) { }

	private void UpdateEventInterestParentCategories() { }

	private void UpdateEventInterestSelfCategories() { }

	internal void UpdateHoverPseudoState() { }

	internal void UpdateHoverPseudoStateAfterCaptureChange(int pointerId) { }

	internal void UpdateWorldBoundingBox() { }

	private void UpdateWorldClip() { }

	internal void UpdateWorldTransform() { }

	internal void UpdateWorldTransformInverse() { }

	private void WillChangePanel(BaseVisualElementPanel destinationPanel) { }

}

