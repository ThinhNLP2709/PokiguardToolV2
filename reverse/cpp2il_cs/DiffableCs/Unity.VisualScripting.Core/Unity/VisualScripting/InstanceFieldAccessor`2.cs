namespace Unity.VisualScripting;

public class InstanceFieldAccessor : IOptimizedAccessor
{
	private readonly FieldInfo fieldInfo; //Field offset: 0x0
	private Func<TTarget, TField> getter; //Field offset: 0x0
	private Action<TTarget, TField> setter; //Field offset: 0x0

	public InstanceFieldAccessor`2(FieldInfo fieldInfo) { }

	[CompilerGenerated]
	private TField <Compile>b__4_0(TTarget instance) { }

	[CompilerGenerated]
	private void <Compile>b__4_1(TTarget instance, TField value) { }

	public override void Compile() { }

	public override object GetValue(object target) { }

	private object GetValueUnsafe(object target) { }

	public override void SetValue(object target, object value) { }

	private void SetValueUnsafe(object target, object value) { }

}

