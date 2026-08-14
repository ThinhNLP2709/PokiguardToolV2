namespace UnityEngine.UIElements;

internal class TextEditingManipulator
{
	private readonly TextElement m_TextElement; //Field offset: 0x10
	private TextEditorEventHandler m_EditingEventHandler; //Field offset: 0x18
	internal TextEditingUtilities editingUtilities; //Field offset: 0x20
	private bool m_TouchScreenTextFieldInitialized; //Field offset: 0x28
	private IVisualElementScheduledItem m_HardwareKeyboardPoller; //Field offset: 0x30

	internal TextEditorEventHandler editingEventHandler
	{
		internal get { } //Length: 5
		internal set { } //Length: 113
	}

	private bool touchScreenTextFieldChanged
	{
		private get { } //Length: 145
	}

	public TextEditingManipulator(TextElement textElement) { }

	[CompilerGenerated]
	private void <OnFocusInEvent>b__14_0() { }

	internal TextEditorEventHandler get_editingEventHandler() { }

	private bool get_touchScreenTextFieldChanged() { }

	internal void HandleEventBubbleUp(EventBase evt) { }

	private void InitTextEditorEventHandler() { }

	private void OnFocusInEvent() { }

	private void OnFocusOutEvent() { }

	public void Reset() { }

	internal void set_editingEventHandler(TextEditorEventHandler value) { }

}

