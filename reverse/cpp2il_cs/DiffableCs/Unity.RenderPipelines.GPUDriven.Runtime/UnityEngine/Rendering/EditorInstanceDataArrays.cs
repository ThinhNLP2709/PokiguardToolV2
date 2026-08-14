namespace UnityEngine.Rendering;

internal struct EditorInstanceDataArrays : IDataArrays
{
	[IsReadOnly]
	public struct ReadOnly
	{

		public ReadOnly(in CPUInstanceData instanceData) { }

	}


	public override void Dispose() { }

	public override void Grow(int newCapacity) { }

	public override void Initialize(int initCapacity) { }

	public override void Remove(int index, int lastIndex) { }

	public override void SetDefault(int index) { }

}

