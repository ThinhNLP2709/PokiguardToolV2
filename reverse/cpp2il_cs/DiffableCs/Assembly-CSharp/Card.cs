//Type is in global namespace

public class Card : MonoBehaviour
{
	public int idCard; //Field offset: 0x20
	public string idCardUser; //Field offset: 0x28
	public string cardDetail; //Field offset: 0x30
	public int value; //Field offset: 0x38
	public int lever; //Field offset: 0x3C
	public int conditionUse; //Field offset: 0x40
	private Active active; //Field offset: 0x48
	private ListCard listCard; //Field offset: 0x50
	private CardFight cardFight; //Field offset: 0x58
	private Button btn; //Field offset: 0x60
	private Board board; //Field offset: 0x68
	private string url; //Field offset: 0x70
	public Image cardImage; //Field offset: 0x78

	public Card() { }

	private string GetCardTypeName() { }

	public void Initialize(int id, int level = 1) { }

	public void Initialize(CardInfo cardInfo) { }

	public void OnClickCard() { }

	public void Setup(ListCard listCardReference) { }

	private void Start() { }

}

