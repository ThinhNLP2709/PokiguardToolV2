namespace UnityEngine.UIElements.UIR;

internal class EntryRecorder
{
	private EntryPool m_EntryPool; //Field offset: 0x10

	public EntryRecorder(EntryPool entryPool) { }

	private static void Append(Entry parentEntry, Entry entry) { }

	private static void AppendMeshEntry(Entry parentEntry, Entry entry) { }

	public void BeginStencilMask(Entry parentEntry) { }

	public void BlitAndPopRenderTexture(Entry parentEntry) { }

	public void CutRenderChain(Entry parentEntry) { }

	public void DrawChildren(Entry parentEntry) { }

	public void DrawGradients(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, VectorImage gradientsOwner) { }

	public void DrawImmediate(Entry parentEntry, Action callback, bool cullingEnabled) { }

	public void DrawMesh(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, Texture texture, bool skipAtlas) { }

	public void DrawRasterText(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, Texture texture, bool multiChannel) { }

	public void DrawSdfText(Entry parentEntry, NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, Texture texture, float scale, float sharpness) { }

	public void EndStencilMask(Entry parentEntry) { }

	public Entry InsertPlaceholder(Entry parentEntry) { }

	public void PopClippingRect(Entry parentEntry) { }

	public void PopDefaultMaterial(Entry parentEntry) { }

	public void PopGroupMatrix(Entry parentEntry) { }

	public void PopScissors(Entry parentEntry) { }

	public void PopStencilMask(Entry parentEntry) { }

	public void PushClippingRect(Entry parentEntry) { }

	public void PushDefaultMaterial(Entry parentEntry, Material material) { }

	public void PushGroupMatrix(Entry parentEntry) { }

	public void PushRenderTexture(Entry parentEntry) { }

	public void PushScissors(Entry parentEntry) { }

}

