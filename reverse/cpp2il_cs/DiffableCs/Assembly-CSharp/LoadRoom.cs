//Type is in global namespace

public class LoadRoom : MonoBehaviour
{
	public GameObject animationBoss; //Field offset: 0x20
	public Image pet; //Field offset: 0x28
	public Image user; //Field offset: 0x30
	public TextMeshProUGUI nameEnemyPet; //Field offset: 0x38
	public TextMeshProUGUI nameUser; //Field offset: 0x40
	public TextMeshProUGUI energy; //Field offset: 0x48
	public TextMeshProUGUI countPass; //Field offset: 0x50
	public TextMeshProUGUI lever; //Field offset: 0x58
	public Text gold; //Field offset: 0x60
	public Text money; //Field offset: 0x68
	public Texture2D fallbackTexture; //Field offset: 0x70
	public int nguoiChoi; //Field offset: 0x78
	public int petUser; //Field offset: 0x7C
	public int petEnemy; //Field offset: 0x80

	public LoadRoom() { }

	public void LoadRoomData(JoinRoomData joinRoomData) { }

}

