namespace UnityEngine;

public sealed class WaitUntil : CustomYieldInstruction
{
	private readonly Func<Boolean> m_Predicate; //Field offset: 0x10
	private readonly Action m_TimeoutCallback; //Field offset: 0x18
	private readonly WaitTimeoutMode m_TimeoutMode; //Field offset: 0x20
	private readonly double m_MaxExecutionTime; //Field offset: 0x28

	public virtual bool keepWaiting
	{
		 get { } //Length: 181
	}

	public WaitUntil(Func<Boolean> predicate) { }

	public virtual bool get_keepWaiting() { }

	private double GetTime() { }

}

