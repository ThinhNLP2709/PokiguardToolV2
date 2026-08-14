namespace UnityEngine.Bindings;

[IsByRefLike]
[IsReadOnly]
[Obsolete("Types with embedded references are not supported in this version of your compiler.", True)]
[VisibleToOtherModules]
internal struct ManagedSpanWrapper
{
	public readonly Void* begin; //Field offset: 0x0
	public readonly int length; //Field offset: 0x8

	public ManagedSpanWrapper(Void* begin, int length) { }

}

