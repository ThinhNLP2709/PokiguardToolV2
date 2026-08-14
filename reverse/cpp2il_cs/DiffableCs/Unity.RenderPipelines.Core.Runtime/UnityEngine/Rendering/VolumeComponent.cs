namespace UnityEngine.Rendering;

public class VolumeComponent : ScriptableObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<FieldInfo, Int32> <>9__10_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <FindParameters>b__10_0(FieldInfo t) { }

	}

	internal sealed class Indent : PropertyAttribute
	{
		public readonly int relativeAmount; //Field offset: 0x18

		public Indent(int relativeAmount = 1) { }

	}

	public bool active; //Field offset: 0x18
	[CompilerGenerated]
	private string <displayName>k__BackingField; //Field offset: 0x20
	internal readonly List<VolumeParameter> parameterList; //Field offset: 0x28
	private ReadOnlyCollection<VolumeParameter> m_ParameterReadOnlyCollection; //Field offset: 0x30

	public string displayName
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public ReadOnlyCollection<VolumeParameter> parameters
	{
		 get { } //Length: 96
	}

	public VolumeComponent() { }

	public bool AnyPropertiesIsOverridden() { }

	internal static void FindParameters(object o, List<VolumeParameter> parameters, Func<FieldInfo, Boolean> filter = null) { }

	[CompilerGenerated]
	public string get_displayName() { }

	public ReadOnlyCollection<VolumeParameter> get_parameters() { }

	public virtual int GetHashCode() { }

	protected override void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	public override void Override(VolumeComponent state, float interpFactor) { }

	public void Release() { }

	[CompilerGenerated]
	protected void set_displayName(string value) { }

	public void SetAllOverridesTo(bool state) { }

	internal void SetOverridesTo(IEnumerable<VolumeParameter> enumerable, bool state) { }

}

