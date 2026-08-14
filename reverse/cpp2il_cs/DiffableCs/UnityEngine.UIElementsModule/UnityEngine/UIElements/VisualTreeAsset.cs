namespace UnityEngine.UIElements;

[HelpURL("UIE-VisualTree-landing")]
public class VisualTreeAsset : ScriptableObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass76_0
	{
		public VisualElementAsset childVea; //Field offset: 0x10

		public <>c__DisplayClass76_0() { }

		internal bool <CloneSetupRecursively>b__0(SlotUsageEntry u) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass81_0
	{
		public VisualElementAsset asset; //Field offset: 0x0

	}

	[CompilerGenerated]
	private sealed class <get_stylesheets>d__31 : IEnumerable<StyleSheet>, IEnumerable, IEnumerator<StyleSheet>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private StyleSheet <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public VisualTreeAsset <>4__this; //Field offset: 0x28
		private HashSet<StyleSheet> <sent>5__1; //Field offset: 0x30
		private Enumerator<VisualElementAsset> <>s__2; //Field offset: 0x38
		private VisualElementAsset <vea>5__3; //Field offset: 0x50
		private Enumerator<StyleSheet> <>s__4; //Field offset: 0x58
		private StyleSheet <stylesheet>5__5; //Field offset: 0x70
		private Enumerator<String> <>s__6; //Field offset: 0x78
		private string <stylesheetPath>5__7; //Field offset: 0x90
		private StyleSheet <stylesheet>5__8; //Field offset: 0x98

		private override StyleSheet System.Collections.Generic.IEnumerator<UnityEngine.UIElements.StyleSheet>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <get_stylesheets>d__31(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private void <>m__Finally3() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<StyleSheet> System.Collections.Generic.IEnumerable<UnityEngine.UIElements.StyleSheet>.GetEnumerator() { }

		[DebuggerHidden]
		private override StyleSheet System.Collections.Generic.IEnumerator<UnityEngine.UIElements.StyleSheet>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <get_templateDependencies>d__27 : IEnumerable<VisualTreeAsset>, IEnumerable, IEnumerator<VisualTreeAsset>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private VisualTreeAsset <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public VisualTreeAsset <>4__this; //Field offset: 0x28
		private HashSet<VisualTreeAsset> <sent>5__1; //Field offset: 0x30
		private Enumerator<UsingEntry> <>s__2; //Field offset: 0x38
		private UsingEntry <entry>5__3; //Field offset: 0x60
		private VisualTreeAsset <vta>5__4; //Field offset: 0x78

		private override VisualTreeAsset System.Collections.Generic.IEnumerator<UnityEngine.UIElements.VisualTreeAsset>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <get_templateDependencies>d__27(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<VisualTreeAsset> System.Collections.Generic.IEnumerable<UnityEngine.UIElements.VisualTreeAsset>.GetEnumerator() { }

		[DebuggerHidden]
		private override VisualTreeAsset System.Collections.Generic.IEnumerator<UnityEngine.UIElements.VisualTreeAsset>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private struct AssetEntry
	{
		[SerializeField]
		private string m_Path; //Field offset: 0x0
		[SerializeField]
		private string m_TypeFullName; //Field offset: 0x8
		[SerializeField]
		private LazyLoadReference<Object> m_AssetReference; //Field offset: 0x10
		[SerializeField]
		private int m_InstanceID; //Field offset: 0x14
		private Type m_CachedType; //Field offset: 0x18

		public object asset
		{
			 get { } //Length: 99
		}

		public string path
		{
			 get { } //Length: 4
		}

		public Type type
		{
			 get { } //Length: 142
		}

		public AssetEntry(string path, Type type, object asset) { }

		public object get_asset() { }

		public string get_path() { }

		public Type get_type() { }

	}

	public struct SlotDefinition
	{
		[SerializeField]
		public string name; //Field offset: 0x0
		[SerializeField]
		public int insertionPointId; //Field offset: 0x8

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	public struct SlotUsageEntry
	{
		[SerializeField]
		public string slotName; //Field offset: 0x0
		[SerializeField]
		public int assetId; //Field offset: 0x8

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	public struct UsingEntry
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal static readonly IComparer<UsingEntry> comparer; //Field offset: 0x0
		[SerializeField]
		public string alias; //Field offset: 0x0
		[SerializeField]
		public string path; //Field offset: 0x8
		[SerializeField]
		public VisualTreeAsset asset; //Field offset: 0x10

		private static UsingEntry() { }

		public UsingEntry(string alias, string path) { }

	}

	private class UsingEntryComparer : IComparer<UsingEntry>
	{

		public UsingEntryComparer() { }

		public override int Compare(UsingEntry x, UsingEntry y) { }

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	public struct UxmlObjectEntry
	{
		[SerializeField]
		public int parentId; //Field offset: 0x0
		[SerializeField]
		public List<UxmlObjectAsset> uxmlObjectAssets; //Field offset: 0x8

		public UxmlObjectEntry(int parentId, List<UxmlObjectAsset> uxmlObjectAssets) { }

		public UxmlObjectAsset GetField(string fieldName) { }

		public virtual string ToString() { }

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal static string LinkedVEAInTemplatePropertyName; //Field offset: 0x0
	internal static string NoRegisteredFactoryErrorMessage; //Field offset: 0x8
	private static readonly Dictionary<String, VisualElement> s_TemporarySlotInsertionPoints; //Field offset: 0x10
	private static readonly List<Int32> s_VeaIdsPath; //Field offset: 0x18
	[SerializeField]
	private bool m_ImportedWithErrors; //Field offset: 0x18
	[SerializeField]
	private bool m_HasUpdatedUrls; //Field offset: 0x19
	[SerializeField]
	private bool m_ImportedWithWarnings; //Field offset: 0x1A
	[SerializeField]
	private List<UsingEntry> m_Usings; //Field offset: 0x20
	[SerializeField]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal StyleSheet inlineSheet; //Field offset: 0x28
	[SerializeField]
	internal List<VisualElementAsset> m_VisualElementAssets; //Field offset: 0x30
	[SerializeField]
	internal List<TemplateAsset> m_TemplateAssets; //Field offset: 0x38
	[SerializeField]
	private List<UxmlObjectEntry> m_UxmlObjectEntries; //Field offset: 0x40
	[SerializeField]
	private List<Int32> m_UxmlObjectIds; //Field offset: 0x48
	[SerializeField]
	private List<AssetEntry> m_AssetEntries; //Field offset: 0x50
	[SerializeField]
	private List<SlotDefinition> m_Slots; //Field offset: 0x58
	[SerializeField]
	private int m_ContentContainerId; //Field offset: 0x60
	[SerializeField]
	private int m_ContentHash; //Field offset: 0x64

	internal int contentContainerId
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 6
		internal set { } //Length: 4
	}

	public int contentHash
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public internal bool importedWithErrors
	{
		 get { } //Length: 7
		internal set { } //Length: 4
	}

	public internal bool importedWithWarnings
	{
		 get { } //Length: 7
		internal set { } //Length: 4
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool importerWithUpdatedUrls
	{
		internal get { } //Length: 7
		internal set { } //Length: 4
	}

	internal List<SlotDefinition> slots
	{
		internal get { } //Length: 5
	}

	public IEnumerable<StyleSheet> stylesheets
	{
		[IteratorStateMachine(typeof(<get_stylesheets>d__31))]
		 get { } //Length: 113
	}

	internal List<TemplateAsset> templateAssets
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 5
	}

	public IEnumerable<VisualTreeAsset> templateDependencies
	{
		[IteratorStateMachine(typeof(<get_templateDependencies>d__27))]
		 get { } //Length: 884
	}

	internal List<UsingEntry> usings
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 5
	}

	internal List<UxmlObjectEntry> uxmlObjectEntries
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 5
	}

	internal List<Int32> uxmlObjectIds
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 5
	}

	internal List<VisualElementAsset> visualElementAssets
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 5
	}

	private static VisualTreeAsset() { }

	public VisualTreeAsset() { }

	[CompilerGenerated]
	internal static VisualElement <Create>g__CreateError|81_0(ref <>c__DisplayClass81_0 unnamed_param_0) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal UxmlObjectAsset AddUxmlObject(UxmlAsset parent, string fieldUxmlName, string fullTypeName, UxmlNamespaceDefinition xmlNamespace = null) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool AssetEntryExists(string path, Type type) { }

	private static void AssignClassListFromAssetToElement(VisualElementAsset asset, VisualElement element) { }

	private static void AssignStyleSheetFromAssetToElement(VisualElementAsset asset, VisualElement element) { }

	private VisualElement CloneSetupRecursively(VisualElementAsset root, Dictionary<Int32, List`1<VisualElementAsset>> idToChildren, CreationContext context) { }

	public TemplateContainer CloneTree() { }

	public TemplateContainer CloneTree(string bindingPath) { }

	internal void CloneTree(VisualElement target, CreationContext cc) { }

	public void CloneTree(VisualElement target, out int firstElementIndex, out int elementAddedCount) { }

	public void CloneTree(VisualElement target) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void CollectUxmlObjectAssets(UxmlAsset parent, string fieldName, List<UxmlObjectAsset> foundEntries) { }

	internal static int CompareForOrder(VisualElementAsset a, VisualElementAsset b) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal static VisualElement Create(VisualElementAsset asset, CreationContext ctx) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal int get_contentContainerId() { }

	public int get_contentHash() { }

	public bool get_importedWithErrors() { }

	public bool get_importedWithWarnings() { }

	internal bool get_importerWithUpdatedUrls() { }

	internal List<SlotDefinition> get_slots() { }

	[IteratorStateMachine(typeof(<get_stylesheets>d__31))]
	public IEnumerable<StyleSheet> get_stylesheets() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<TemplateAsset> get_templateAssets() { }

	[IteratorStateMachine(typeof(<get_templateDependencies>d__27))]
	public IEnumerable<VisualTreeAsset> get_templateDependencies() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<UsingEntry> get_usings() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<UxmlObjectEntry> get_uxmlObjectEntries() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<Int32> get_uxmlObjectIds() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<VisualElementAsset> get_visualElementAssets() { }

	internal T GetAsset(string path) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal object GetAsset(string path, Type type) { }

	internal Type GetAssetType(string path) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal int GetNextChildSerialNumber() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal int GetNextUxmlAssetId(int parentId) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal UxmlObjectEntry GetUxmlObjectEntry(int id) { }

	internal IBaseUxmlObjectFactory GetUxmlObjectFactory(UxmlObjectAsset uxmlObjectAsset) { }

	internal List<T> GetUxmlObjects(IUxmlAttributes asset, CreationContext cc) { }

	public TemplateContainer Instantiate(string bindingPath) { }

	public TemplateContainer Instantiate() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void RegisterAssetEntry(string path, Type type, object asset) { }

	internal void RegisterUxmlObject(UxmlObjectAsset uxmlObjectAsset) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void RemoveElementAndDependencies(VisualElementAsset asset) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void RemoveUxmlObject(int id, bool onlyIfIsField = false) { }

	private void RemoveUxmlObjectEntryDependencies(int parentId) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal VisualTreeAsset ResolveTemplate(string templateName) { }

	internal void set_contentContainerId(int value) { }

	public void set_contentHash(int value) { }

	internal void set_importedWithErrors(bool value) { }

	internal void set_importedWithWarnings(bool value) { }

	internal void set_importerWithUpdatedUrls(bool value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void SetUxmlObjectAssets(UxmlAsset parent, string fieldName, List<UxmlObjectAsset> entries) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void TransferAssetEntries(VisualTreeAsset otherVta) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool TryGetSlotInsertionPoint(int insertionPointId, out string slotName) { }

	internal bool TryGetUsingEntry(string templateName, out UsingEntry entry) { }

}

