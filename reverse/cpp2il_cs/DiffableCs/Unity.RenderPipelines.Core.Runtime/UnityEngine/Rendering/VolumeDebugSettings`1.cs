namespace UnityEngine.Rendering;

public abstract class VolumeDebugSettings : IVolumeDebugSettings
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0
		public static Func<Volume, Boolean> <>9__34_0; //Field offset: 0x0
		public static Func<FieldInfo, Boolean> <>9__36_0; //Field offset: 0x0
		public static Func<Type, Boolean> <>9__43_0; //Field offset: 0x0
		public static Func<Type, Boolean> <>9__43_1; //Field offset: 0x0
		public static Func<Type, String> <>9__43_2; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal bool <get_componentTypes>b__43_0(Type t) { }

		internal bool <get_componentTypes>b__43_1(Type t) { }

		internal string <get_componentTypes>b__43_2(Type t) { }

		internal bool <GetStates>b__36_0(FieldInfo t) { }

		internal bool <GetVolumes>b__34_0(Volume v) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public Type value; //Field offset: 0x0

		public <>c__DisplayClass22_0() { }

		internal bool <set_selectedComponentType>b__0(ValueTuple<String, Type> t) { }

	}

	private static List<Type> s_ComponentTypes; //Field offset: 0x0
	[CompilerGenerated]
	private static List<T> <additionalCameraDatas>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private int <selectedComponent>k__BackingField; //Field offset: 0x0
	protected int m_SelectedCameraIndex; //Field offset: 0x0
	private Camera[] m_CamerasArray; //Field offset: 0x0
	private List<Camera> m_Cameras; //Field offset: 0x0
	[CompilerGenerated]
	private readonly Type <targetRenderPipeline>k__BackingField; //Field offset: 0x0
	private Single[] weights; //Field offset: 0x0
	private Volume[] volumes; //Field offset: 0x0
	private VolumeParameter[2] savedStates; //Field offset: 0x0

	[Obsolete("Cameras are auto registered/unregistered, use property cameras", False)]
	protected private static List<T> additionalCameraDatas
	{
		[CompilerGenerated]
		 get { } //Length: 161
		[CompilerGenerated]
		private set { } //Length: 229
	}

	public override IEnumerable<Camera> cameras
	{
		 get { } //Length: 444
	}

	[Obsolete("Please use volumeComponentsPathAndType instead, and get the second element of the tuple", False)]
	public static List<Type> componentTypes
	{
		 get { } //Length: 2134
	}

	public override Camera selectedCamera
	{
		 get { } //Length: 170
	}

	public override int selectedCameraIndex
	{
		 get { } //Length: 166
		 set { } //Length: 159
	}

	public abstract LayerMask selectedCameraLayerMask
	{
		 get { } //Length: 0
	}

	public abstract Vector3 selectedCameraPosition
	{
		 get { } //Length: 0
	}

	public abstract VolumeStack selectedCameraVolumeStack
	{
		 get { } //Length: 0
	}

	public override int selectedComponent
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override Type selectedComponentType
	{
		 get { } //Length: 139
		 set { } //Length: 299
	}

	[Obsolete("This property is obsolete and kept only for not breaking user code. VolumeDebugSettings will use current pipeline when it needs to gather volume component types and paths. #from(23.2)", False)]
	public override Type targetRenderPipeline
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public List<ValueTuple`2<String, Type>> volumeComponentsPathAndType
	{
		 get { } //Length: 134
	}

	private static VolumeDebugSettings`1() { }

	protected VolumeDebugSettings`1() { }

	private bool ChangedStates(VolumeParameter[2] newStates) { }

	[Obsolete("Please use componentPathAndType instead, and get the first element of the tuple", False)]
	public static string ComponentDisplayName(Type component) { }

	private float ComputeWeight(Volume volume, Vector3 triggerPos) { }

	[CompilerGenerated]
	protected static List<T> get_additionalCameraDatas() { }

	public override IEnumerable<Camera> get_cameras() { }

	public static List<Type> get_componentTypes() { }

	public override Camera get_selectedCamera() { }

	public override int get_selectedCameraIndex() { }

	public abstract LayerMask get_selectedCameraLayerMask() { }

	public abstract Vector3 get_selectedCameraPosition() { }

	public abstract VolumeStack get_selectedCameraVolumeStack() { }

	[CompilerGenerated]
	public override int get_selectedComponent() { }

	public override Type get_selectedComponentType() { }

	[CompilerGenerated]
	public override Type get_targetRenderPipeline() { }

	public List<ValueTuple`2<String, Type>> get_volumeComponentsPathAndType() { }

	internal VolumeParameter GetParameter(FieldInfo field) { }

	internal VolumeParameter GetParameter(VolumeComponent component, FieldInfo field) { }

	internal VolumeParameter GetParameter(Volume volume, FieldInfo field) { }

	private VolumeParameter[2] GetStates() { }

	public override Volume[] GetVolumes() { }

	public override float GetVolumeWeight(Volume volume) { }

	public override bool RefreshVolumes(Volume[] newVolumes) { }

	[Obsolete("Cameras are auto registered/unregistered", False)]
	public static void RegisterCamera(T additionalCamera) { }

	[CompilerGenerated]
	private static void set_additionalCameraDatas(List<T> value) { }

	public override void set_selectedCameraIndex(int value) { }

	[CompilerGenerated]
	public override void set_selectedComponent(int value) { }

	public override void set_selectedComponentType(Type value) { }

	[Obsolete("Cameras are auto registered/unregistered", False)]
	public static void UnRegisterCamera(T additionalCamera) { }

	public override bool VolumeHasInfluence(Volume volume) { }

}

