namespace UnityEngine.InputSystem.OnScreen;

[AddComponentMenu("Input/On-Screen Button")]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/manual/OnScreen.html#on-screen-buttons")]
public class OnScreenButton : OnScreenControl, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[InputControl(layout = "Button")]
	[SerializeField]
	private string m_ControlPath; //Field offset: 0x38

	protected virtual string controlPathInternal
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public OnScreenButton() { }

	protected virtual string get_controlPathInternal() { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void OnPointerUp(PointerEventData eventData) { }

	protected virtual void set_controlPathInternal(string value) { }

}

