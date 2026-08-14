namespace UnityEngine.Rendering;

public sealed class ListChangedEventArgs : EventArgs
{
	public readonly int index; //Field offset: 0x0
	public readonly T item; //Field offset: 0x0

	public ListChangedEventArgs`1(int index, T item) { }

}

