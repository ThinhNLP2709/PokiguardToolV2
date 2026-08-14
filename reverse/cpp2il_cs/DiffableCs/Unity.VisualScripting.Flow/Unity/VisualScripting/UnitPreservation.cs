namespace Unity.VisualScripting;

public sealed class UnitPreservation : IPoolable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<UnitPreservation> <>9__8_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal UnitPreservation <Preserve>b__8_0() { }

	}

	private struct UnitPortPreservation
	{
		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_0
		{
			public string key; //Field offset: 0x10

			public <>c__DisplayClass4_0() { }

			internal bool <GetOrCreateInput>b__0(IUnitInputPort p) { }

			internal bool <GetOrCreateInput>b__1(IUnitInputPort p) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass5_0
		{
			public string key; //Field offset: 0x10

			public <>c__DisplayClass5_0() { }

			internal bool <GetOrCreateOutput>b__0(IUnitOutputPort p) { }

			internal bool <GetOrCreateOutput>b__1(IUnitOutputPort p) { }

		}

		public readonly IUnit unit; //Field offset: 0x0
		public readonly string key; //Field offset: 0x8

		public UnitPortPreservation(IUnitPort port) { }

		public UnitPortPreservation(IUnit unit, string key) { }

		public IUnitPort GetOrCreateInput(out InvalidInput newInvalidInput) { }

		public IUnitPort GetOrCreateOutput(out InvalidOutput newInvalidOutput) { }

	}

	private readonly Dictionary<String, Object> defaultValues; //Field offset: 0x10
	private readonly Dictionary<String, List`1<UnitPortPreservation>> inputConnections; //Field offset: 0x18
	private readonly Dictionary<String, List`1<UnitPortPreservation>> outputConnections; //Field offset: 0x20
	private bool disposed; //Field offset: 0x28

	private UnitPreservation() { }

	public static UnitPreservation Preserve(IUnit unit) { }

	private void RestoreConnection(UnitPortPreservation sourcePreservation, UnitPortPreservation destinationPreservation) { }

	public void RestoreTo(IUnit unit) { }

	private override void Unity.VisualScripting.IPoolable.Free() { }

	private override void Unity.VisualScripting.IPoolable.New() { }

}

