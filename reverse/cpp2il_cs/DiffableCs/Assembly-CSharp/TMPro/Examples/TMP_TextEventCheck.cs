namespace TMPro.Examples;

public class TMP_TextEventCheck : MonoBehaviour
{
	public TMP_TextEventHandler TextEventHandler; //Field offset: 0x20
	private TMP_Text m_TextComponent; //Field offset: 0x28

	public TMP_TextEventCheck() { }

	private void OnCharacterSelection(char c, int index) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnLineSelection(string lineText, int firstCharacterIndex, int length) { }

	private void OnLinkSelection(string linkID, string linkText, int linkIndex) { }

	private void OnSpriteSelection(char c, int index) { }

	private void OnWordSelection(string word, int firstCharacterIndex, int length) { }

}

