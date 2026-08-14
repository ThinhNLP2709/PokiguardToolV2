namespace UnityEngine.Rendering;

[DebuggerDisplay("Size = {size} Capacity = {capacity}")]
public class DynamicString : DynamicArray<Char>
{

	public DynamicString() { }

	public DynamicString(string s) { }

	public DynamicString(int capacity) { }

	public void Append(string s) { }

	public void Append(DynamicString s) { }

	public virtual string ToString() { }

}

