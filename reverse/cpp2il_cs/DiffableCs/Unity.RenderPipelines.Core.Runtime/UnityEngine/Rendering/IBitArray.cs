namespace UnityEngine.Rendering;

[DefaultMember("Item")]
public interface IBitArray
{

	public bool allFalse
	{
		 get { } //Length: 0
	}

	public bool allTrue
	{
		 get { } //Length: 0
	}

	public uint capacity
	{
		 get { } //Length: 0
	}

	public string humanizedData
	{
		 get { } //Length: 0
	}

	public bool Item
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IBitArray BitAnd(IBitArray other) { }

	public IBitArray BitNot() { }

	public IBitArray BitOr(IBitArray other) { }

	public bool get_allFalse() { }

	public bool get_allTrue() { }

	public uint get_capacity() { }

	public string get_humanizedData() { }

	public bool get_Item(uint index) { }

	public void set_Item(uint index, bool value) { }

}

