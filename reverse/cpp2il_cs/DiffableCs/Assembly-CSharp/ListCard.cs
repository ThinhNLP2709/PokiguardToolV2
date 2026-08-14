//Type is in global namespace

public class ListCard : MonoBehaviour
{
	public int slCard; //Field offset: 0x20
	public Button cardPrefab; //Field offset: 0x28
	public float spacing; //Field offset: 0x30
	public GameObject onCard; //Field offset: 0x38
	public List<CardInfo> cardInfos; //Field offset: 0x40
	private List<Card> activeCards; //Field offset: 0x48

	public ListCard() { }

	private void InitializeCards() { }

	private void RearrangeCards() { }

	public void RemoveCard(Card cardToRemove) { }

	public void SetCardInfos(List<CardInfo> newCardInfos) { }

	private void Start() { }

}

