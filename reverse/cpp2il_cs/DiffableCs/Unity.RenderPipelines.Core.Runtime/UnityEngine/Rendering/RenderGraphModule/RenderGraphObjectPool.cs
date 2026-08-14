namespace UnityEngine.Rendering.RenderGraphModule;

public sealed class RenderGraphObjectPool
{
	private class SharedObjectPool : SharedObjectPoolBase
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c<T> <>9; //Field offset: 0x0
			public static Func<T> <>9__1_0; //Field offset: 0x0

			private static <>c() { }

			public <>c() { }

			internal T <AllocatePool>b__1_0() { }

		}

		private static readonly ObjectPool<T> s_Pool; //Field offset: 0x0

		private static SharedObjectPool`1() { }

		public SharedObjectPool`1() { }

		private static ObjectPool<T> AllocatePool() { }

		public virtual void Clear() { }

		public static T Get() { }

		public static void Release(T toRelease) { }

	}

	private class SharedObjectPoolBase
	{

		public SharedObjectPoolBase() { }

		public override void Clear() { }

	}

	private static DynamicArray<SharedObjectPoolBase> s_AllocatedPools; //Field offset: 0x0
	private Dictionary<ValueTuple`2<Type, Int32>, Stack`1<Object>> m_ArrayPool; //Field offset: 0x10
	private List<ValueTuple`2<Object, ValueTuple`2<Type, Int32>>> m_AllocatedArrays; //Field offset: 0x18
	private List<MaterialPropertyBlock> m_AllocatedMaterialPropertyBlocks; //Field offset: 0x20

	private static RenderGraphObjectPool() { }

	internal RenderGraphObjectPool() { }

	internal void Cleanup() { }

	internal T Get() { }

	public T[] GetTempArray(int size) { }

	public MaterialPropertyBlock GetTempMaterialPropertyBlock() { }

	internal void Release(T value) { }

	internal void ReleaseAllTempAlloc() { }

}

