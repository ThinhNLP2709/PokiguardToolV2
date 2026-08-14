namespace Unity.VisualScripting;

public class StaticFieldAccessor : IOptimizedAccessor
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public TField constant; //Field offset: 0x0

		public <>c__DisplayClass5_0() { }

		internal TField <Compile>b__2() { }

	}

	private readonly FieldInfo fieldInfo; //Field offset: 0x0
	private Func<TField> getter; //Field offset: 0x0
	private Action<TField> setter; //Field offset: 0x0
	private Type targetType; //Field offset: 0x0

	public StaticFieldAccessor`1(FieldInfo fieldInfo) { }

	[CompilerGenerated]
	private TField <Compile>b__5_0() { }

	[CompilerGenerated]
	private void <Compile>b__5_1(TField value) { }

	public override void Compile() { }

	public override object GetValue(object target) { }

	private object GetValueUnsafe(object target) { }

	public override void SetValue(object target, object value) { }

	private void SetValueUnsafe(object target, object value) { }

}

