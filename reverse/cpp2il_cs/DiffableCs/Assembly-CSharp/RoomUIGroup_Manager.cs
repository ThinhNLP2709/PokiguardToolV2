//Type is in global namespace

public class RoomUIGroup_Manager : MonoBehaviour
{
	internal static RoomUIGroup_Manager Instance; //Field offset: 0x0
	private const int MAX_SLOT = 3; //Field offset: 0x0
	private static readonly Dictionary<String, Sprite> _spriteCache; //Field offset: 0x8
	public PlayerUISlot[] slots; //Field offset: 0x20

	private static RoomUIGroup_Manager() { }

	public RoomUIGroup_Manager() { }

	private void Awake() { }

	[ContextMenu("UpdateSlots")]
	public void CallUpdate() { }

	public Sprite LoadAvatar(int avtId) { }

	private static Sprite LoadCached(string path) { }

	public Sprite LoadLevelFrame(int level) { }

	public Sprite LoadPetIcon(int petId) { }

	private void ScanSlots() { }

	public void SetPlayers(List<PlayerUIModel> models) { }

}

