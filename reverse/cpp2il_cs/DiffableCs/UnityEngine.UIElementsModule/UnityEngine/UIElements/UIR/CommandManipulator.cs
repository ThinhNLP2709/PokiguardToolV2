namespace UnityEngine.UIElements.UIR;

[Extension]
internal static class CommandManipulator
{

	public static void DisableElementRendering(RenderChain renderChain, VisualElement ve, bool renderingDisabled) { }

	private static void FindHeadCommandInsertionPoint(VisualElement ve, out RenderChainCommand prev, out RenderChainCommand next) { }

	private static void FindTailCommandInsertionPoint(VisualElement ve, out RenderChainCommand prev, out RenderChainCommand next) { }

	private static void InjectCommandInBetween(RenderChain renderChain, RenderChainCommand cmd, RenderChainCommand prev, RenderChainCommand next) { }

	[Extension]
	private static bool IsParentOrAncestorOf(VisualElement ve, VisualElement child) { }

	private static void RemoveChain(RenderChain renderChain, RenderChainCommand first, RenderChainCommand last) { }

	private static void RemoveSingleCommand(RenderChain renderChain, VisualElement ve, RenderChainCommand cmd) { }

	public static void ReplaceCommands(RenderChain renderChain, VisualElement ve, EntryProcessor processor) { }

	public static void ResetCommands(RenderChain renderChain, VisualElement ve) { }

}

