namespace System.Net.Sockets;

public struct IPPacketInformation
{
	private IPAddress address; //Field offset: 0x0
	private int networkInterface; //Field offset: 0x8

	public virtual bool Equals(object comparand) { }

	public virtual int GetHashCode() { }

}

