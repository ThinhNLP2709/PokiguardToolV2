namespace Unity.VisualScripting;

public class InstancePropertyAccessor : IOptimizedAccessor
{
	private readonly PropertyInfo propertyInfo; //Field offset: 0x0
	private Func<TTarget, TProperty> getter; //Field offset: 0x0
	private Action<TTarget, TProperty> setter; //Field offset: 0x0

	public InstancePropertyAccessor`2(PropertyInfo propertyInfo) { }

	public override void Compile() { }

	public override object GetValue(object target) { }

	private object GetValueUnsafe(object target) { }

	public override void SetValue(object target, object value) { }

	private void SetValueUnsafe(object target, object value) { }

}

