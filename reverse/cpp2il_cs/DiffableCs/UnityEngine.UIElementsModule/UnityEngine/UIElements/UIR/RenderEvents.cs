namespace UnityEngine.UIElements.UIR;

internal static class RenderEvents
{
	private static readonly ProfilerMarker k_NudgeVerticesMarker; //Field offset: 0x0
	private static readonly float VisibilityTreshold; //Field offset: 0x8

	private static RenderEvents() { }

	internal static uint DepthFirstOnChildAdded(RenderChain renderChain, VisualElement parent, VisualElement ve, int index, bool resetState) { }

	internal static uint DepthFirstOnChildRemoving(RenderChain renderChain, VisualElement ve) { }

	private static void DepthFirstOnClippingChanged(RenderChain renderChain, VisualElement parent, VisualElement ve, uint dirtyID, bool hierarchical, bool isRootOfChange, bool isPendingHierarchicalRepaint, bool inheritedClipRectIDChanged, bool inheritedMaskingChanged, UIRenderDevice device, ref ChainBuilderStats stats) { }

	private static void DepthFirstOnOpacityChanged(RenderChain renderChain, float parentCompositeOpacity, VisualElement ve, uint dirtyID, bool hierarchical, ref ChainBuilderStats stats, bool isDoingFullVertexRegeneration = false) { }

	private static void DepthFirstOnTransformOrSizeChanged(RenderChain renderChain, VisualElement parent, VisualElement ve, uint dirtyID, UIRenderDevice device, bool isAncestorOfChangeSkinned, bool transformChanged, ref ChainBuilderStats stats) { }

	private static ClipMethod DetermineSelfClipMethod(RenderChain renderChain, VisualElement ve) { }

	private static Vector4 GetClipRectIDClipInfo(VisualElement ve) { }

	private static VisualElement GetLastDeepestChild(VisualElement ve) { }

	private static Matrix4x4 GetTransformIDTransformInfo(VisualElement ve) { }

	private static bool InitColorIDs(RenderChain renderChain, VisualElement ve) { }

	internal static bool NeedsColorID(VisualElement ve) { }

	internal static bool NeedsTextCoreSettings(VisualElement ve) { }

	private static bool NeedsTransformID(VisualElement ve) { }

	private static bool NudgeVerticesToNewSpace(VisualElement ve, RenderChain renderChain, UIRenderDevice device) { }

	private static void OnColorChanged(RenderChain renderChain, VisualElement ve, uint dirtyID, ref ChainBuilderStats stats) { }

	private static void PrepareNudgeVertices(VisualElement ve, UIRenderDevice device, MeshHandle mesh, out IntPtr src, out IntPtr dst, out int count) { }

	internal static void ProcessOnClippingChanged(RenderChain renderChain, VisualElement ve, uint dirtyID, ref ChainBuilderStats stats) { }

	internal static void ProcessOnColorChanged(RenderChain renderChain, VisualElement ve, uint dirtyID, ref ChainBuilderStats stats) { }

	internal static void ProcessOnOpacityChanged(RenderChain renderChain, VisualElement ve, uint dirtyID, ref ChainBuilderStats stats) { }

	internal static void ProcessOnTransformOrSizeChanged(RenderChain renderChain, VisualElement ve, uint dirtyID, ref ChainBuilderStats stats) { }

	public static void SetColorValues(RenderChain renderChain, VisualElement ve) { }

	private static bool UpdateLocalFlipsWinding(VisualElement ve) { }

	public static bool UpdateTextCoreSettings(RenderChain renderChain, VisualElement ve) { }

	private static void UpdateZeroScaling(VisualElement ve) { }

}

