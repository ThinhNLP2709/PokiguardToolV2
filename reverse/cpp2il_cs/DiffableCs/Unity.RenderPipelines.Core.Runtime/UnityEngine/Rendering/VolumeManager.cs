namespace UnityEngine.Rendering;

public sealed class VolumeManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ValueTuple`2<String, Type>, String> <>9__16_0; //Field offset: 0x8
		public static Predicate<VolumeProfile> <>9__49_0; //Field offset: 0x10
		public static Predicate<Volume> <>9__71_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal VolumeManager <.cctor>b__74_0() { }

		internal string <BuildVolumeComponentDisplayList>b__16_0(ValueTuple<String, Type> i) { }

		internal bool <GetVolumes>b__71_0(Volume v) { }

		internal bool <SetCustomDefaultProfiles>b__49_0(VolumeProfile x) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass58_0
	{
		public List<VolumeComponent> componentsDefaultStateList; //Field offset: 0x0

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass58_1
	{
		public VolumeComponent profileComponent; //Field offset: 0x10

		public <>c__DisplayClass58_1() { }

		internal bool <EvaluateVolumeDefaultState>b__1(VolumeComponent x) { }

	}

	private static readonly ProfilerMarker k_ProfilerMarkerUpdate; //Field offset: 0x0
	private static readonly ProfilerMarker k_ProfilerMarkerReplaceData; //Field offset: 0x8
	private static readonly ProfilerMarker k_ProfilerMarkerEvaluateVolumeDefaultState; //Field offset: 0x10
	private static readonly Lazy<VolumeManager> s_Instance; //Field offset: 0x18
	private static readonly Dictionary<Type, List`1<ValueTuple`2<String, Type>>> s_SupportedVolumeComponentsForRenderPipeline; //Field offset: 0x20
	[CompilerGenerated]
	private VolumeStack <stack>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Type[] <baseComponentTypeArray>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private VolumeProfile <globalDefaultProfile>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private VolumeProfile <qualityDefaultProfile>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private ReadOnlyCollection<VolumeProfile> <customDefaultProfiles>k__BackingField; //Field offset: 0x30
	private readonly VolumeCollection m_VolumeCollection; //Field offset: 0x38
	private VolumeComponent[] m_ComponentsDefaultState; //Field offset: 0x40
	internal VolumeParameter[] m_ParametersDefaultState; //Field offset: 0x48
	private readonly List<Collider> m_TempColliders; //Field offset: 0x50
	private VolumeStack m_DefaultStack; //Field offset: 0x58
	private readonly List<VolumeStack> m_CreatedVolumeStacks; //Field offset: 0x60
	[CompilerGenerated]
	private bool <isInitialized>k__BackingField; //Field offset: 0x68

	public internal Type[] baseComponentTypeArray
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	[Obsolete("Please use baseComponentTypeArray instead.")]
	public IEnumerable<Type> baseComponentTypes
	{
		 get { } //Length: 5
	}

	public private ReadOnlyCollection<VolumeProfile> customDefaultProfiles
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private VolumeProfile globalDefaultProfile
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public static VolumeManager instance
	{
		 get { } //Length: 112
	}

	public private bool isInitialized
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private VolumeProfile qualityDefaultProfile
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public VolumeStack stack
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private static VolumeManager() { }

	internal VolumeManager() { }

	[CompilerGenerated]
	internal static void <EvaluateVolumeDefaultState>g__ApplyDefaultProfile|58_0(VolumeProfile profile, ref <>c__DisplayClass58_0 unnamed_param_1) { }

	private List<ValueTuple`2<String, Type>> BuildVolumeComponentDisplayList(Type[] types) { }

	[Conditional("UNITY_EDITOR")]
	public void CheckDefaultVolumeState() { }

	[Conditional("UNITY_EDITOR")]
	public void CheckStack(VolumeStack stack) { }

	private bool CheckUpdateRequired(VolumeStack stack) { }

	public VolumeStack CreateStack() { }

	public void Deinitialize() { }

	public void DestroyStack(VolumeStack stack) { }

	internal void EvaluateVolumeDefaultState() { }

	[CompilerGenerated]
	public Type[] get_baseComponentTypeArray() { }

	public IEnumerable<Type> get_baseComponentTypes() { }

	[CompilerGenerated]
	public ReadOnlyCollection<VolumeProfile> get_customDefaultProfiles() { }

	[CompilerGenerated]
	public VolumeProfile get_globalDefaultProfile() { }

	public static VolumeManager get_instance() { }

	[CompilerGenerated]
	public bool get_isInitialized() { }

	[CompilerGenerated]
	public VolumeProfile get_qualityDefaultProfile() { }

	[CompilerGenerated]
	public VolumeStack get_stack() { }

	public VolumeComponent GetVolumeComponentDefaultState(Type volumeComponentType) { }

	internal List<ValueTuple`2<String, Type>> GetVolumeComponentsForDisplay(Type currentPipelineAssetType) { }

	public Volume[] GetVolumes(LayerMask layerMask) { }

	private List<Volume> GrabVolumes(LayerMask mask) { }

	public void Initialize(VolumeProfile globalDefaultVolumeProfile = null, VolumeProfile qualityDefaultVolumeProfile = null) { }

	internal void InitializeVolumeComponents() { }

	public bool IsComponentActiveInMask(LayerMask layerMask) { }

	private bool IsSupportedByObsoleteVolumeComponentMenuForRenderPipeline(Type t, Type pipelineAssetType) { }

	private static bool IsVolumeRenderedByCamera(Volume volume, Camera camera) { }

	internal void LoadBaseTypes(Type pipelineAssetType) { }

	public void OnVolumeComponentChanged(VolumeComponent component) { }

	public void OnVolumeProfileChanged(VolumeProfile profile) { }

	private void OverrideData(VolumeStack stack, List<VolumeComponent> components, float interpFactor) { }

	[Obsolete("Please use the Register without a given layer index #from(6000.0)", False)]
	public void Register(Volume volume, int layer) { }

	public void Register(Volume volume) { }

	internal void ReplaceData(VolumeStack stack) { }

	public void ResetMainStack() { }

	[CompilerGenerated]
	internal void set_baseComponentTypeArray(Type[] value) { }

	[CompilerGenerated]
	private void set_customDefaultProfiles(ReadOnlyCollection<VolumeProfile> value) { }

	[CompilerGenerated]
	private void set_globalDefaultProfile(VolumeProfile value) { }

	[CompilerGenerated]
	private void set_isInitialized(bool value) { }

	[CompilerGenerated]
	private void set_qualityDefaultProfile(VolumeProfile value) { }

	[CompilerGenerated]
	public void set_stack(VolumeStack value) { }

	public void SetCustomDefaultProfiles(List<VolumeProfile> profiles) { }

	public void SetGlobalDefaultProfile(VolumeProfile profile) { }

	internal void SetLayerDirty(int layer) { }

	public void SetQualityDefaultProfile(VolumeProfile profile) { }

	public void Unregister(Volume volume) { }

	[Obsolete("Please use the Register without a given layer index #from(6000.0)", False)]
	public void Unregister(Volume volume, int layer) { }

	public void Update(Transform trigger, LayerMask layerMask) { }

	public void Update(VolumeStack stack, Transform trigger, LayerMask layerMask) { }

	internal void UpdateVolumeLayer(Volume volume, int prevLayer, int newLayer) { }

}

