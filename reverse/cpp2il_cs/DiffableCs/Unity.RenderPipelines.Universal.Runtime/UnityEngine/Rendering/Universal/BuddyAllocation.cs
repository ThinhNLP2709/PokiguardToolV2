namespace UnityEngine.Rendering.Universal;

internal struct BuddyAllocation
{
	public int level; //Field offset: 0x0
	public int index; //Field offset: 0x4

	public uint2 index2D
	{
		 get { } //Length: 10
	}

	public BuddyAllocation(int level, int index) { }

	public uint2 get_index2D() { }

}

