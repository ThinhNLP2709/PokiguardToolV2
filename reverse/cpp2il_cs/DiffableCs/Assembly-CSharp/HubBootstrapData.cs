//Type is in global namespace

public class HubBootstrapData
{
	public UserDTO user; //Field offset: 0x10
	public EnergyInfoDTO energy; //Field offset: 0x18
	public long giftCount; //Field offset: 0x20
	public List<GiftDTO> pendingGifts; //Field offset: 0x28
	public List<QuestData> dailyQuests; //Field offset: 0x30
	public ThongBaoListData notifications; //Field offset: 0x38
	public List<PetLibDTO> petLibrary; //Field offset: 0x40
	public long serverTime; //Field offset: 0x48

	public HubBootstrapData() { }

}

