namespace UnityEngine;

[RequiredByNativeCode]
internal struct AnimationEventBlittable : IDisposable
{
	[ThreadStatic]
	private static GCHandlePool s_handlePool; //Field offset: 0x80000000
	internal float m_Time; //Field offset: 0x0
	internal IntPtr m_FunctionName; //Field offset: 0x8
	internal IntPtr m_StringParameter; //Field offset: 0x10
	internal IntPtr m_ObjectReferenceParameter; //Field offset: 0x18
	internal float m_FloatParameter; //Field offset: 0x20
	internal int m_IntParameter; //Field offset: 0x24
	internal int m_MessageOptions; //Field offset: 0x28
	internal AnimationEventSource m_Source; //Field offset: 0x2C
	internal IntPtr m_StateSender; //Field offset: 0x30
	internal AnimatorStateInfo m_AnimatorStateInfo; //Field offset: 0x38
	internal AnimatorClipInfo m_AnimatorClipInfo; //Field offset: 0x5C

	public override void Dispose() { }

	[RequiredByNativeCode]
	internal static AnimationEvent PointerToAnimationEvent(IntPtr animationEventBlittable) { }

	internal static AnimationEvent ToAnimationEvent(AnimationEventBlittable animationEventBlittable) { }

}

