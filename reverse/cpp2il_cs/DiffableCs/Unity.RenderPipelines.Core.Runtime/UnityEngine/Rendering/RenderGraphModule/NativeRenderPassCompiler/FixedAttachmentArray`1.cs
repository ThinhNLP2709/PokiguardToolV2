namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DefaultMember("Item")]
public struct FixedAttachmentArray
{
	public static FixedAttachmentArray<DataType> Empty; //Field offset: 0x0
	public const int MaxAttachments = 8; //Field offset: 0x0
	private DataType a0; //Field offset: 0x0
	private DataType a1; //Field offset: 0x0
	private DataType a2; //Field offset: 0x0
	private DataType a3; //Field offset: 0x0
	private DataType a4; //Field offset: 0x0
	private DataType a5; //Field offset: 0x0
	private DataType a6; //Field offset: 0x0
	private DataType a7; //Field offset: 0x0
	private int activeAttachments; //Field offset: 0x0

	public DataType Item
	{
		 get { } //Length: 8
	}

	public int size
	{
		 get { } //Length: 4
	}

	private static FixedAttachmentArray`1() { }

	public FixedAttachmentArray`1(int numAttachments) { }

	public FixedAttachmentArray`1(DataType[] attachments) { }

	public FixedAttachmentArray`1(NativeArray<DataType> attachments) { }

	public int Add(in DataType data) { }

	public void Clear() { }

	public DataType get_Item(int index) { }

	public int get_size() { }

}

