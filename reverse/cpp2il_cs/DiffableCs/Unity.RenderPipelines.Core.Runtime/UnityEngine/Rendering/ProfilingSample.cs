namespace UnityEngine.Rendering;

[IgnoredByDeepProfiler]
[Obsolete("Please use ProfilingScope")]
public struct ProfilingSample : IDisposable
{
	private readonly CommandBuffer m_Cmd; //Field offset: 0x0
	private readonly string m_Name; //Field offset: 0x8
	private bool m_Disposed; //Field offset: 0x10
	private CustomSampler m_Sampler; //Field offset: 0x18

	public ProfilingSample(CommandBuffer cmd, string name, CustomSampler sampler = null) { }

	public ProfilingSample(CommandBuffer cmd, string format, object arg) { }

	public ProfilingSample(CommandBuffer cmd, string format, Object[] args) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

}

