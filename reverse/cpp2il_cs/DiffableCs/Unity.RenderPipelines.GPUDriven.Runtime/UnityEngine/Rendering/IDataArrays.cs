namespace UnityEngine.Rendering;

internal interface IDataArrays
{

	public void Dispose() { }

	public void Grow(int newCapacity) { }

	public void Initialize(int initCapacity) { }

	public void Remove(int index, int lastIndex) { }

	public void SetDefault(int index) { }

}

