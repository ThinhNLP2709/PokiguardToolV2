namespace Unity.VisualScripting;

public sealed class CloningContext : IPoolable, IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<CloningContext> <>9__15_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal CloningContext <New>b__15_0() { }

	}

	[CompilerGenerated]
	private readonly Dictionary<Object, Object> <clonings>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private ICloner <fallbackCloner>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private bool <tryPreserveInstances>k__BackingField; //Field offset: 0x20
	private bool disposed; //Field offset: 0x21

	public Dictionary<Object, Object> clonings
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public private ICloner fallbackCloner
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private bool tryPreserveInstances
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 1011
	}

	public CloningContext() { }

	public override void Dispose() { }

	[CompilerGenerated]
	public Dictionary<Object, Object> get_clonings() { }

	[CompilerGenerated]
	public ICloner get_fallbackCloner() { }

	[CompilerGenerated]
	public bool get_tryPreserveInstances() { }

	public static CloningContext New(ICloner fallbackCloner, bool tryPreserveInstances) { }

	[CompilerGenerated]
	private void set_fallbackCloner(ICloner value) { }

	[CompilerGenerated]
	private void set_tryPreserveInstances(bool value) { }

	private override void Unity.VisualScripting.IPoolable.Free() { }

	private override void Unity.VisualScripting.IPoolable.New() { }

}

