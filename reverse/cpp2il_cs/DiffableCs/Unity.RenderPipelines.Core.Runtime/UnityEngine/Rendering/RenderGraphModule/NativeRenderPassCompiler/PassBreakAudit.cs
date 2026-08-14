namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

[DebuggerDisplay("{reason} : {breakPass}")]
internal struct PassBreakAudit
{
	public static readonly String[] BreakReasonMessages; //Field offset: 0x0
	public PassBreakReason reason; //Field offset: 0x0
	public int breakPass; //Field offset: 0x4

	private static PassBreakAudit() { }

	public PassBreakAudit(PassBreakReason reason, int breakPass) { }

}

