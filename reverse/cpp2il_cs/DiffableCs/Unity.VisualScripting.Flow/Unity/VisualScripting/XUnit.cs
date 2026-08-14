namespace Unity.VisualScripting;

[Extension]
public static class XUnit
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public Type outputType; //Field offset: 0x10

		public <>c__DisplayClass0_0() { }

		internal bool <CompatibleValueInput>b__0(ValueInput valueInput) { }

		internal int <CompatibleValueInput>b__1(ValueInput valueInput) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public Type inputType; //Field offset: 0x10

		public <>c__DisplayClass1_0() { }

		internal bool <CompatibleValueOutput>b__0(ValueOutput valueOutput) { }

		internal int <CompatibleValueOutput>b__1(ValueOutput valueOutput) { }

	}


	[Extension]
	public static ValueInput CompatibleValueInput(IUnit unit, Type outputType) { }

	[Extension]
	public static ValueOutput CompatibleValueOutput(IUnit unit, Type inputType) { }

}

