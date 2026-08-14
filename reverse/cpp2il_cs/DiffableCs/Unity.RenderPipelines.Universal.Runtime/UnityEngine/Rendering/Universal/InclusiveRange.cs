namespace UnityEngine.Rendering.Universal;

internal struct InclusiveRange
{
	public short start; //Field offset: 0x0
	public short end; //Field offset: 0x2

	public static InclusiveRange empty
	{
		 get { } //Length: 13
	}

	public bool isEmpty
	{
		 get { } //Length: 11
	}

	public InclusiveRange(short startEnd) { }

	public InclusiveRange(short start, short end) { }

	public void Clamp(short min, short max) { }

	public bool Contains(short index) { }

	public void Expand(short index) { }

	public static InclusiveRange get_empty() { }

	public bool get_isEmpty() { }

	public static InclusiveRange Merge(InclusiveRange a, InclusiveRange b) { }

	public virtual string ToString() { }

}

