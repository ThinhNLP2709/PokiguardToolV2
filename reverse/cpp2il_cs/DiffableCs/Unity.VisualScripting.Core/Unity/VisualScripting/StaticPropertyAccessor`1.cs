namespace Unity.VisualScripting;

public class StaticPropertyAccessor : IOptimizedAccessor
{
	private readonly PropertyInfo propertyInfo; //Field offset: 0x0
	private Func<TProperty> getter; //Field offset: 0x0
	private Action<TProperty> setter; //Field offset: 0x0
	private Type targetType; //Field offset: 0x0

	public StaticPropertyAccessor`1(PropertyInfo propertyInfo) { }

	public override void Compile() { }

	public override object GetValue(object target) { }

	private object GetValueUnsafe(object target) { }

	public override void SetValue(object target, object value) { }

	private void SetValueUnsafe(object target, object value) { }

}

