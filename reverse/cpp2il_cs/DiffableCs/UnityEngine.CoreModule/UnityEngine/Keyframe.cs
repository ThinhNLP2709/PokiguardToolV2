namespace UnityEngine;

[RequiredByNativeCode]
public struct Keyframe
{
	private float m_Time; //Field offset: 0x0
	private float m_Value; //Field offset: 0x4
	private float m_InTangent; //Field offset: 0x8
	private float m_OutTangent; //Field offset: 0xC
	private int m_WeightedMode; //Field offset: 0x10
	private float m_InWeight; //Field offset: 0x14
	private float m_OutWeight; //Field offset: 0x18

	public float inTangent
	{
		 get { } //Length: 8
		 set { } //Length: 6
	}

	public float inWeight
	{
		 get { } //Length: 8
		 set { } //Length: 6
	}

	public float outTangent
	{
		 get { } //Length: 8
		 set { } //Length: 6
	}

	public float outWeight
	{
		 get { } //Length: 8
		 set { } //Length: 6
	}

	[Obsolete("Use AnimationUtility.SetKeyLeftTangentMode, AnimationUtility.SetKeyRightTangentMode, AnimationUtility.GetKeyLeftTangentMode or AnimationUtility.GetKeyRightTangentMode instead.")]
	public int tangentMode
	{
		 get { } //Length: 5
		 set { } //Length: 3
	}

	internal int tangentModeInternal
	{
		internal get { } //Length: 5
		internal set { } //Length: 3
	}

	public float time
	{
		 get { } //Length: 7
		 set { } //Length: 5
	}

	public float value
	{
		 get { } //Length: 8
		 set { } //Length: 6
	}

	public WeightedMode weightedMode
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public Keyframe(float time, float value) { }

	public Keyframe(float time, float value, float inTangent, float outTangent) { }

	public float get_inTangent() { }

	public float get_inWeight() { }

	public float get_outTangent() { }

	public float get_outWeight() { }

	public int get_tangentMode() { }

	internal int get_tangentModeInternal() { }

	public float get_time() { }

	public float get_value() { }

	public WeightedMode get_weightedMode() { }

	public void set_inTangent(float value) { }

	public void set_inWeight(float value) { }

	public void set_outTangent(float value) { }

	public void set_outWeight(float value) { }

	public void set_tangentMode(int value) { }

	internal void set_tangentModeInternal(int value) { }

	public void set_time(float value) { }

	public void set_value(float value) { }

	public void set_weightedMode(WeightedMode value) { }

}

