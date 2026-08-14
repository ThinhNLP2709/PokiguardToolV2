namespace UnityEngine.Rendering.Universal;

internal class UniversalRenderPipelineDebugDisplayStats : DebugDisplayStats<URPProfileId>
{
	private DebugFrameTiming m_DebugFrameTiming; //Field offset: 0x30
	private List<URPProfileId> m_RecordedSamplers; //Field offset: 0x38

	public UniversalRenderPipelineDebugDisplayStats() { }

	[CompilerGenerated]
	private bool <RegisterDebugUI>b__4_0() { }

	[CompilerGenerated]
	private void <RegisterDebugUI>b__4_1(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebugUI>b__4_2() { }

	[CompilerGenerated]
	private void <RegisterDebugUI>b__4_3(bool value) { }

	public virtual void DisableProfilingRecorders() { }

	public virtual void EnableProfilingRecorders() { }

	public virtual void RegisterDebugUI(List<Widget> list) { }

	public virtual void Update() { }

}

