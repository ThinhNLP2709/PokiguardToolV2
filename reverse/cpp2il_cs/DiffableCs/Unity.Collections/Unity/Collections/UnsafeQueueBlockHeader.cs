namespace Unity.Collections;

internal struct UnsafeQueueBlockHeader
{
	public UnsafeQueueBlockHeader* m_NextBlock; //Field offset: 0x0
	public int m_NumItems; //Field offset: 0x8

}

