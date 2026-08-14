namespace Unity.VisualScripting;

public sealed class ReflectionFieldAccessor : IOptimizedAccessor
{
	private readonly FieldInfo fieldInfo; //Field offset: 0x10

	public ReflectionFieldAccessor(FieldInfo fieldInfo) { }

	public override void Compile() { }

	public override object GetValue(object target) { }

	public override void SetValue(object target, object value) { }

}

