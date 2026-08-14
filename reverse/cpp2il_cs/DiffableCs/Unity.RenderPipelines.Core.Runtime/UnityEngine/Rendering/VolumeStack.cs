namespace UnityEngine.Rendering;

public sealed class VolumeStack : IDisposable
{
	internal readonly Dictionary<Type, VolumeComponent> components; //Field offset: 0x10
	internal VolumeParameter[] parameters; //Field offset: 0x18
	internal bool requiresReset; //Field offset: 0x20
	internal bool requiresResetForAllProperties; //Field offset: 0x21
	[CompilerGenerated]
	private bool <isValid>k__BackingField; //Field offset: 0x22

	public private bool isValid
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	internal VolumeStack() { }

	internal void Clear() { }

	public override void Dispose() { }

	[CompilerGenerated]
	public bool get_isValid() { }

	public T GetComponent() { }

	public VolumeComponent GetComponent(Type type) { }

	internal void Reload(Type[] componentTypes) { }

	[CompilerGenerated]
	private void set_isValid(bool value) { }

}

