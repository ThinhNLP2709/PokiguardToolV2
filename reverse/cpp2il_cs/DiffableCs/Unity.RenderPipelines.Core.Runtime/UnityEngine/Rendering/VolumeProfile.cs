namespace UnityEngine.Rendering;

public sealed class VolumeProfile : ScriptableObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<VolumeComponent> <>9__2_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <OnEnable>b__2_0(VolumeComponent x) { }

	}

	public List<VolumeComponent> components; //Field offset: 0x18
	public bool isDirty; //Field offset: 0x20

	public VolumeProfile() { }

	public T Add(bool overrides = false) { }

	public VolumeComponent Add(Type type, bool overrides = false) { }

	internal int GetComponentListHashCode() { }

	public virtual int GetHashCode() { }

	public bool Has() { }

	public bool Has(Type type) { }

	public bool HasSubclassOf(Type type) { }

	internal void OnDisable() { }

	private void OnEnable() { }

	public void Remove() { }

	public void Remove(Type type) { }

	public void Reset() { }

	internal void Sanitize() { }

	public bool TryGet(out T component) { }

	public bool TryGet(Type type, out T component) { }

	public bool TryGetAllSubclassOf(Type type, List<T> result) { }

	public bool TryGetSubclassOf(Type type, out T component) { }

}

