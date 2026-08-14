namespace UnityEngine.U2D.Animation;

internal class TransformAccessJob
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public int id; //Field offset: 0x10

		public <>c__DisplayClass20_0() { }

		internal bool <RemoveTransformsByIds>b__0(Transform t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public int transformId; //Field offset: 0x10

		public <>c__DisplayClass21_0() { }

		internal bool <RemoveTransformById>b__0(Transform t) { }

	}

	internal struct TransformData
	{
		public int transformIndex; //Field offset: 0x0
		public int refCount; //Field offset: 0x4

		public TransformData(int index) { }

	}

	private Transform[] m_Transform; //Field offset: 0x10
	private TransformAccessArray m_TransformAccessArray; //Field offset: 0x18
	private NativeHashMap<Int32, TransformData> m_TransformData; //Field offset: 0x20
	private NativeArray<float4x4> m_TransformMatrix; //Field offset: 0x28
	private bool m_Dirty; //Field offset: 0x38
	private JobHandle m_JobHandle; //Field offset: 0x40

	public NativeHashMap<Int32, TransformData> transformData
	{
		 get { } //Length: 5
	}

	public NativeArray<float4x4> transformMatrix
	{
		 get { } //Length: 11
	}

	public TransformAccessJob() { }

	public void AddTransform(Transform t) { }

	private static void ArrayAdd(ref T[] array, T item) { }

	private static void ArrayRemoveAt(ref T[] array, int index) { }

	public void Destroy() { }

	public NativeHashMap<Int32, TransformData> get_transformData() { }

	public NativeArray<float4x4> get_transformMatrix() { }

	internal string GetDebugLog() { }

	internal void RemoveTransformById(int transformId) { }

	internal void RemoveTransformsByIds(IList<Int32> idsToRemove) { }

	public JobHandle StartLocalToWorldJob() { }

	public JobHandle StartWorldToLocalJob() { }

	private void UpdateTransformIndex() { }

}

