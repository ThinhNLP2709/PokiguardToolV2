namespace Unity.VisualScripting;

public abstract class ReflectedCloner : Cloner<Object>
{
	private readonly Dictionary<Type, MemberInfo[]> accessors; //Field offset: 0x10
	private readonly Dictionary<Type, IOptimizedAccessor[]> optimizedAccessors; //Field offset: 0x18

	protected ReflectedCloner() { }

	public virtual void FillClone(Type type, ref object clone, object original, CloningContext context) { }

	private MemberInfo[] GetAccessors(Type type) { }

	protected override IEnumerable<MemberInfo> GetMembers(Type type) { }

	private IOptimizedAccessor[] GetOptimizedAccessors(Type type) { }

	public virtual bool Handles(Type type) { }

	protected override bool IncludeField(FieldInfo field) { }

	protected override bool IncludeProperty(PropertyInfo property) { }

}

