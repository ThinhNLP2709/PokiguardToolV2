namespace UnityEngine.InputSystem;

public abstract class InputControl : InputControl
{
	internal InlinedArray<InputProcessor`1<TValue>> m_ProcessorStack; //Field offset: 0x0
	private TValue m_CachedValue; //Field offset: 0x0
	private TValue m_UnprocessedCachedValue; //Field offset: 0x0
	internal bool evaluateProcessorsEveryRead; //Field offset: 0x0

	internal InputProcessor<TValue>[] processors
	{
		internal get { } //Length: 95
	}

	[IsReadOnly]
	internal TValue unprocessedValue
	{
		internal get { } //Length: 217
	}

	[IsReadOnly]
	public TValue value
	{
		 get { } //Length: 259
	}

	public virtual int valueSizeInBytes
	{
		 get { } //Length: 6
	}

	public virtual Type valueType
	{
		 get { } //Length: 56
	}

	protected InputControl`1() { }

	internal virtual void AddProcessor(object processor) { }

	public virtual bool CompareValue(Void* firstStatePtr, Void* secondStatePtr) { }

	private static bool CompareValue(ref TValue firstValue, ref TValue secondValue) { }

	protected virtual void FinishSetup() { }

	internal InputProcessor<TValue>[] get_processors() { }

	internal TValue get_unprocessedValue() { }

	public TValue get_value() { }

	public virtual int get_valueSizeInBytes() { }

	public virtual Type get_valueType() { }

	public void ProcessValue(ref TValue value) { }

	public TValue ProcessValue(TValue value) { }

	public TValue ReadDefaultValue() { }

	public TValue ReadUnprocessedValue() { }

	public abstract TValue ReadUnprocessedValueFromState(Void* statePtr) { }

	public TValue ReadUnprocessedValueFromStateWithCaching(Void* statePtr) { }

	public TValue ReadValue() { }

	public virtual object ReadValueFromBufferAsObject(Void* buffer, int bufferSize) { }

	public TValue ReadValueFromPreviousFrame() { }

	public TValue ReadValueFromState(Void* statePtr) { }

	public virtual object ReadValueFromStateAsObject(Void* statePtr) { }

	public virtual void ReadValueFromStateIntoBuffer(Void* statePtr, Void* bufferPtr, int bufferSize) { }

	public TValue ReadValueFromStateWithCaching(Void* statePtr) { }

	internal TProcessor TryGetProcessor() { }

	public virtual void WriteValueFromBufferIntoState(Void* bufferPtr, int bufferSize, Void* statePtr) { }

	public virtual void WriteValueFromObjectIntoState(object value, Void* statePtr) { }

	public override void WriteValueIntoState(TValue value, Void* statePtr) { }

}

