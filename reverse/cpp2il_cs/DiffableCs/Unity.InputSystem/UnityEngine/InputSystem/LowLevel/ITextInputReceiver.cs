namespace UnityEngine.InputSystem.LowLevel;

public interface ITextInputReceiver
{

	public void OnIMECompositionChanged(IMECompositionString compositionString) { }

	public void OnTextInput(char character) { }

}

