namespace UnityEngine.UIElements.Layout;

[IsReadOnly]
internal struct LayoutConfig
{
	private readonly LayoutDataAccess m_Access; //Field offset: 0x0
	private readonly LayoutHandle m_Handle; //Field offset: 0x28

	public LayoutHandle Handle
	{
		 get { } //Length: 5
	}

	public float PointScaleFactor
	{
		 get { } //Length: 12
	}

	public static LayoutConfig Undefined
	{
		 get { } //Length: 44
	}

	internal LayoutConfig(LayoutDataAccess access, LayoutHandle handle) { }

	public LayoutHandle get_Handle() { }

	public float get_PointScaleFactor() { }

	public static LayoutConfig get_Undefined() { }

}

