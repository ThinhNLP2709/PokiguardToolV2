//Type is in global namespace

public class RoomUIGroup_ManagerPVP : MonoBehaviour
{
	internal static RoomUIGroup_ManagerPVP Instance; //Field offset: 0x0
	private const int MAX_SLOT = 4; //Field offset: 0x0
	[Header("Slots (index 0-1 = Team A, 2-3 = Team B)")]
	public PlayerUISlotPVP[] slots; //Field offset: 0x20

	public RoomUIGroup_ManagerPVP() { }

	private void Awake() { }

	public Sprite LoadAvatar(int avtId) { }

	public Sprite LoadLevelFrame(int level) { }

	public Sprite LoadPetIcon(int petId) { }

	private void ScanSlots() { }

	public void SetPlayers(List<PlayerUIModel> models) { }

}

