namespace System.Net.Sockets;

public class SendPacketsElement
{
	internal string m_FilePath; //Field offset: 0x10
	internal Byte[] m_Buffer; //Field offset: 0x18
	internal int m_Offset; //Field offset: 0x20
	internal int m_Count; //Field offset: 0x24
	private bool m_endOfPacket; //Field offset: 0x28

}

