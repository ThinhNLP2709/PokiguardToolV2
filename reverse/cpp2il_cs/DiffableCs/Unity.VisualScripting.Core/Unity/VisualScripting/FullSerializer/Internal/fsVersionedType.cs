namespace Unity.VisualScripting.FullSerializer.Internal;

public struct fsVersionedType
{
	public fsVersionedType[] Ancestors; //Field offset: 0x0
	public string VersionString; //Field offset: 0x8
	public Type ModelType; //Field offset: 0x10

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

	public object Migrate(object ancestorInstance) { }

	public static bool op_Equality(fsVersionedType a, fsVersionedType b) { }

	public static bool op_Inequality(fsVersionedType a, fsVersionedType b) { }

	public virtual string ToString() { }

}

