namespace UnityEngine.InputForUI;

internal class InputEventPartialProvider : IEventProviderImpl
{
	private Event _ev; //Field offset: 0x10
	private OperatingSystemFamily _operatingSystemFamily; //Field offset: 0x18
	private ButtonsState _keyboardButtonsState; //Field offset: 0x1C
	internal EventModifiers _eventModifiers; //Field offset: 0x44
	internal bool _sendNavigationEventOnTabKey; //Field offset: 0x48
	private IDictionary<String, Command> _IMGUICommandToInputForUICommandType; //Field offset: 0x50

	public InputEventPartialProvider() { }

	private DiscreteTime GetTimestamp(in Event ev) { }

	public override void Initialize() { }

	public override void OnFocusChanged(bool focus) { }

	public override bool RequestCurrentState(Type type) { }

	private void SendNextOrPreviousNavigationEventOnTabKeyDownEvent(in Event ev) { }

	public override void Shutdown() { }

	private CommandEvent ToCommandEvent(in Event ev) { }

	private KeyEvent ToKeyEvent(in Event ev) { }

	private TextInputEvent ToTextInputEvent(in Event ev) { }

	public override void Update() { }

	private void UpdateEventModifiers(in Event ev) { }

}

