namespace Unity.VisualScripting;

public sealed class ReflectionPropertyAccessor : IOptimizedAccessor
{
	private readonly PropertyInfo propertyInfo; //Field offset: 0x10

	public ReflectionPropertyAccessor(PropertyInfo propertyInfo) { }

	public override void Compile() { }

	public override object GetValue(object target) { }

	public override void SetValue(object target, object value) { }

}

