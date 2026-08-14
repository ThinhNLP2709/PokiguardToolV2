namespace Unity.VisualScripting;

public interface IOptimizedAccessor
{

	public void Compile() { }

	public object GetValue(object target) { }

	public void SetValue(object target, object value) { }

}

