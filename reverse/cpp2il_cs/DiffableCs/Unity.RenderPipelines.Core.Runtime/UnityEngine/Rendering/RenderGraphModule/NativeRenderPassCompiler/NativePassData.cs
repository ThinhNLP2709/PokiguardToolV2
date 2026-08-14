namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal struct NativePassData
{
	public FixedAttachmentArray<LoadAudit> loadAudit; //Field offset: 0x0
	public FixedAttachmentArray<StoreAudit> storeAudit; //Field offset: 0x44
	public PassBreakAudit breakAudit; //Field offset: 0xC8
	public FixedAttachmentArray<PassFragmentData> fragments; //Field offset: 0xD0
	public FixedAttachmentArray<NativePassAttachment> attachments; //Field offset: 0x194
	public int firstGraphPass; //Field offset: 0x298
	public int lastGraphPass; //Field offset: 0x29C
	public int numGraphPasses; //Field offset: 0x2A0
	public int firstNativeSubPass; //Field offset: 0x2A4
	public int numNativeSubPasses; //Field offset: 0x2A8
	public int width; //Field offset: 0x2AC
	public int height; //Field offset: 0x2B0
	public int volumeDepth; //Field offset: 0x2B4
	public int samples; //Field offset: 0x2B8
	public bool hasDepth; //Field offset: 0x2BC
	public bool hasFoveatedRasterization; //Field offset: 0x2BD

	public NativePassData(ref PassData pass, CompilerContextData ctx) { }

	public static PassBreakAudit CanMerge(CompilerContextData contextData, int activeNativePassId, int passIdToMerge) { }

	private static bool CanMergeNativeSubPass(CompilerContextData contextData, NativePassData nativePass, PassData passToMerge) { }

	public void Clear() { }

	[IsReadOnly]
	public void GetGraphPassNames(CompilerContextData ctx, DynamicArray<Name> dest) { }

	[IsReadOnly]
	public ReadOnlySpan<PassData> GraphPasses(CompilerContextData ctx) { }

	[IsReadOnly]
	public bool IsValid() { }

	public static void SetPassStatesForNativePass(CompilerContextData contextData, int nativePassId) { }

	public static PassBreakAudit TryMerge(CompilerContextData contextData, int activeNativePassId, int passIdToMerge) { }

	public static void TryMergeNativeSubPass(CompilerContextData contextData, ref NativePassData nativePass, ref PassData passToMerge) { }

	private static void UpdateNativeSubPassesAttachments(CompilerContextData contextData, ref NativePassData nativePass) { }

}

