namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class ObjectParameter : VolumeParameter<T>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0
		public static Func<FieldInfo, Boolean> <>9__9_0; //Field offset: 0x0
		public static Func<FieldInfo, Int32> <>9__9_1; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal bool <set_value>b__9_0(FieldInfo t) { }

		internal int <set_value>b__9_1(FieldInfo t) { }

	}

	[CompilerGenerated]
	private ReadOnlyCollection<VolumeParameter> <parameters>k__BackingField; //Field offset: 0x0

	public virtual bool overrideState
	{
		 get { } //Length: 3
		 set { } //Length: 5
	}

	internal ReadOnlyCollection<VolumeParameter> parameters
	{
		[CompilerGenerated]
		internal get { } //Length: 38
		[CompilerGenerated]
		private set { } //Length: 99
	}

	public virtual T value
	{
		 get { } //Length: 169
		 set { } //Length: 1494
	}

	public ObjectParameter`1(T value) { }

	[CompilerGenerated]
	private VolumeParameter <set_value>b__9_2(FieldInfo t) { }

	public virtual bool get_overrideState() { }

	[CompilerGenerated]
	internal ReadOnlyCollection<VolumeParameter> get_parameters() { }

	public virtual T get_value() { }

	internal virtual void Interp(VolumeParameter from, VolumeParameter to, float t) { }

	public virtual void set_overrideState(bool value) { }

	[CompilerGenerated]
	private void set_parameters(ReadOnlyCollection<VolumeParameter> value) { }

	public virtual void set_value(T value) { }

}

