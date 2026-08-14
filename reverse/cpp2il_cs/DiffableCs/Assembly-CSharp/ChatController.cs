//Type is in global namespace

public class ChatController : MonoBehaviour
{
	public TMP_InputField ChatInputField; //Field offset: 0x20
	public TMP_Text ChatDisplayOutput; //Field offset: 0x28
	public Scrollbar ChatScrollbar; //Field offset: 0x30

	public ChatController() { }

	private void AddToChatOutput(string newText) { }

	private void OnDisable() { }

	private void OnEnable() { }

}

