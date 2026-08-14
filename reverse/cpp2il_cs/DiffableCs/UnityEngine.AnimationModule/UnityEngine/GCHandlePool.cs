namespace UnityEngine;

internal class GCHandlePool
{
	private GCHandle[] m_handles; //Field offset: 0x10
	private int m_current; //Field offset: 0x18

	public GCHandlePool() { }

	public void Free(GCHandle h) { }

}

