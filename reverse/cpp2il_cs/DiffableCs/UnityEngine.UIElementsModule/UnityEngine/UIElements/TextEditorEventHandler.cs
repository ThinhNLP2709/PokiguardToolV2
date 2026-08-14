namespace UnityEngine.UIElements;

internal class TextEditorEventHandler
{
	protected TextElement textElement; //Field offset: 0x10
	protected TextEditingUtilities editingUtilities; //Field offset: 0x18

	protected TextEditorEventHandler(TextElement textElement, TextEditingUtilities editingUtilities) { }

	public override void HandleEventBubbleUp(EventBase evt) { }

	public override void RegisterCallbacksOnTarget(VisualElement target) { }

	public override void UnregisterCallbacksFromTarget(VisualElement target) { }

}

