namespace UnityEngine.InputSystem.Controls;

public class AxisControl : InputControl<Single>
{
	internal enum Clamp
	{
		None = 0,
		BeforeNormalize = 1,
		AfterNormalize = 2,
		ToConstantBeforeNormalize = 3,
	}

	public Clamp clamp; //Field offset: 0x108
	public float clampMin; //Field offset: 0x10C
	public float clampMax; //Field offset: 0x110
	public float clampConstant; //Field offset: 0x114
	public bool invert; //Field offset: 0x118
	public bool normalize; //Field offset: 0x119
	public float normalizeMin; //Field offset: 0x11C
	public float normalizeMax; //Field offset: 0x120
	public float normalizeZero; //Field offset: 0x124
	public bool scale; //Field offset: 0x128
	public float scaleFactor; //Field offset: 0x12C

	public AxisControl() { }

	protected virtual FourCC CalculateOptimizedControlDataType() { }

	public virtual bool CompareValue(Void* firstStatePtr, Void* secondStatePtr) { }

	public virtual float EvaluateMagnitude(Void* statePtr) { }

	private float EvaluateMagnitude(float value) { }

	protected virtual void FinishSetup() { }

	protected float Preprocess(float value) { }

	public virtual float ReadUnprocessedValueFromState(Void* statePtr) { }

	private float Unpreprocess(float value) { }

	public virtual void WriteValueIntoState(float value, Void* statePtr) { }

}

