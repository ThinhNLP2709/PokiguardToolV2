namespace TMPro;

public class TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	internal class CharacterSelectionEvent : UnityEvent<Char, Int32>
	{

		public CharacterSelectionEvent() { }

	}

	internal class LineSelectionEvent : UnityEvent<String, Int32, Int32>
	{

		public LineSelectionEvent() { }

	}

	internal class LinkSelectionEvent : UnityEvent<String, String, Int32>
	{

		public LinkSelectionEvent() { }

	}

	internal class SpriteSelectionEvent : UnityEvent<Char, Int32>
	{

		public SpriteSelectionEvent() { }

	}

	internal class WordSelectionEvent : UnityEvent<String, Int32, Int32>
	{

		public WordSelectionEvent() { }

	}

	[SerializeField]
	private CharacterSelectionEvent m_OnCharacterSelection; //Field offset: 0x20
	[SerializeField]
	private SpriteSelectionEvent m_OnSpriteSelection; //Field offset: 0x28
	[SerializeField]
	private WordSelectionEvent m_OnWordSelection; //Field offset: 0x30
	[SerializeField]
	private LineSelectionEvent m_OnLineSelection; //Field offset: 0x38
	[SerializeField]
	private LinkSelectionEvent m_OnLinkSelection; //Field offset: 0x40
	private TMP_Text m_TextComponent; //Field offset: 0x48
	private Camera m_Camera; //Field offset: 0x50
	private Canvas m_Canvas; //Field offset: 0x58
	private int m_selectedLink; //Field offset: 0x60
	private int m_lastCharIndex; //Field offset: 0x64
	private int m_lastWordIndex; //Field offset: 0x68
	private int m_lastLineIndex; //Field offset: 0x6C

	public CharacterSelectionEvent onCharacterSelection
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public LineSelectionEvent onLineSelection
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public LinkSelectionEvent onLinkSelection
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public SpriteSelectionEvent onSpriteSelection
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public WordSelectionEvent onWordSelection
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public TMP_TextEventHandler() { }

	private void Awake() { }

	public CharacterSelectionEvent get_onCharacterSelection() { }

	public LineSelectionEvent get_onLineSelection() { }

	public LinkSelectionEvent get_onLinkSelection() { }

	public SpriteSelectionEvent get_onSpriteSelection() { }

	public WordSelectionEvent get_onWordSelection() { }

	private void LateUpdate() { }

	public override void OnPointerEnter(PointerEventData eventData) { }

	public override void OnPointerExit(PointerEventData eventData) { }

	private void SendOnCharacterSelection(char character, int characterIndex) { }

	private void SendOnLineSelection(string line, int charIndex, int length) { }

	private void SendOnLinkSelection(string linkID, string linkText, int linkIndex) { }

	private void SendOnSpriteSelection(char character, int characterIndex) { }

	private void SendOnWordSelection(string word, int charIndex, int length) { }

	public void set_onCharacterSelection(CharacterSelectionEvent value) { }

	public void set_onLineSelection(LineSelectionEvent value) { }

	public void set_onLinkSelection(LinkSelectionEvent value) { }

	public void set_onSpriteSelection(SpriteSelectionEvent value) { }

	public void set_onWordSelection(WordSelectionEvent value) { }

}

