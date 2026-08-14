namespace UnityEngine.Rendering;

public struct StencilState : IEquatable<StencilState>
{
	private byte m_Enabled; //Field offset: 0x0
	private byte m_ReadMask; //Field offset: 0x1
	private byte m_WriteMask; //Field offset: 0x2
	private byte m_Padding; //Field offset: 0x3
	private byte m_CompareFunctionFront; //Field offset: 0x4
	private byte m_PassOperationFront; //Field offset: 0x5
	private byte m_FailOperationFront; //Field offset: 0x6
	private byte m_ZFailOperationFront; //Field offset: 0x7
	private byte m_CompareFunctionBack; //Field offset: 0x8
	private byte m_PassOperationBack; //Field offset: 0x9
	private byte m_FailOperationBack; //Field offset: 0xA
	private byte m_ZFailOperationBack; //Field offset: 0xB

	public CompareFunction compareFunctionBack
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public CompareFunction compareFunctionFront
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public static StencilState defaultValue
	{
		 get { } //Length: 132
	}

	public bool enabled
	{
		 get { } //Length: 76
		 set { } //Length: 88
	}

	public StencilOp failOperationBack
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public StencilOp failOperationFront
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public StencilOp passOperationBack
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public StencilOp passOperationFront
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public byte readMask
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public byte writeMask
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public StencilOp zFailOperationBack
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public StencilOp zFailOperationFront
	{
		 get { } //Length: 7
		 set { } //Length: 4
	}

	public StencilState(bool enabled = true, byte readMask = 255, byte writeMask = 255, CompareFunction compareFunction = 8, StencilOp passOperation = 0, StencilOp failOperation = 0, StencilOp zFailOperation = 0) { }

	public StencilState(bool enabled, byte readMask, byte writeMask, CompareFunction compareFunctionFront, StencilOp passOperationFront, StencilOp failOperationFront, StencilOp zFailOperationFront, CompareFunction compareFunctionBack, StencilOp passOperationBack, StencilOp failOperationBack, StencilOp zFailOperationBack) { }

	public override bool Equals(StencilState other) { }

	public virtual bool Equals(object obj) { }

	public CompareFunction get_compareFunctionBack() { }

	public CompareFunction get_compareFunctionFront() { }

	public static StencilState get_defaultValue() { }

	public bool get_enabled() { }

	public StencilOp get_failOperationBack() { }

	public StencilOp get_failOperationFront() { }

	public StencilOp get_passOperationBack() { }

	public StencilOp get_passOperationFront() { }

	public byte get_readMask() { }

	public byte get_writeMask() { }

	public StencilOp get_zFailOperationBack() { }

	public StencilOp get_zFailOperationFront() { }

	public virtual int GetHashCode() { }

	public void set_compareFunctionBack(CompareFunction value) { }

	public void set_compareFunctionFront(CompareFunction value) { }

	public void set_enabled(bool value) { }

	public void set_failOperationBack(StencilOp value) { }

	public void set_failOperationFront(StencilOp value) { }

	public void set_passOperationBack(StencilOp value) { }

	public void set_passOperationFront(StencilOp value) { }

	public void set_readMask(byte value) { }

	public void set_writeMask(byte value) { }

	public void set_zFailOperationBack(StencilOp value) { }

	public void set_zFailOperationFront(StencilOp value) { }

	public void SetCompareFunction(CompareFunction value) { }

	public void SetFailOperation(StencilOp value) { }

	public void SetPassOperation(StencilOp value) { }

	public void SetZFailOperation(StencilOp value) { }

}

