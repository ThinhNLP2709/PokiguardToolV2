namespace UnityEngine.Bindings;

[IsByRefLike]
[Obsolete("Types with embedded references are not supported in this version of your compiler.", True)]
[VisibleToOtherModules]
internal struct BlittableListWrapper
{
	private BlittableArrayWrapper arrayWrapper; //Field offset: 0x0
	private int listSize; //Field offset: 0x10

	public BlittableListWrapper(BlittableArrayWrapper arrayWrapper, int listSize) { }

	internal void Unmarshal(List<T> list) { }

}

