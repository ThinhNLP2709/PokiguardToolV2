namespace UnityEngine.Rendering.Universal;

[DefaultMember("Item")]
internal struct ShaderBitArray
{
	private const int k_BitsPerElement = 32; //Field offset: 0x0
	private const int k_ElementShift = 5; //Field offset: 0x0
	private const int k_ElementMask = 31; //Field offset: 0x0
	private Single[] m_Data; //Field offset: 0x0

	public int bitCapacity
	{
		 get { } //Length: 22
	}

	public Single[] data
	{
		 get { } //Length: 4
	}

	public int elemLength
	{
		 get { } //Length: 16
	}

	public bool Item
	{
		 get { } //Length: 74
		 set { } //Length: 84
	}

	public void Clear() { }

	public int get_bitCapacity() { }

	public Single[] get_data() { }

	public int get_elemLength() { }

	public bool get_Item(int index) { }

	private void GetElementIndexAndBitOffset(int index, out int elemIndex, out int bitOffset) { }

	public void Resize(int bitCount) { }

	public void set_Item(int index, bool value) { }

	public virtual string ToString() { }

}

