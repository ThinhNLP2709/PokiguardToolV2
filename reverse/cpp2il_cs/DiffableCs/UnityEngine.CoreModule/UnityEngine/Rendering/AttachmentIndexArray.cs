namespace UnityEngine.Rendering;

[DefaultMember("Item")]
public struct AttachmentIndexArray
{
	public static AttachmentIndexArray Emtpy; //Field offset: 0x0
	private int a0; //Field offset: 0x0
	private int a1; //Field offset: 0x4
	private int a2; //Field offset: 0x8
	private int a3; //Field offset: 0xC
	private int a4; //Field offset: 0x10
	private int a5; //Field offset: 0x14
	private int a6; //Field offset: 0x18
	private int a7; //Field offset: 0x1C
	private int activeAttachments; //Field offset: 0x20

	public int Item
	{
		 get { } //Length: 281
		 set { } //Length: 282
	}

	public int Length
	{
		 get { } //Length: 6
	}

	private static AttachmentIndexArray() { }

	public AttachmentIndexArray(int numAttachments) { }

	public int get_Item(int index) { }

	public int get_Length() { }

	public void set_Item(int index, int value) { }

}

