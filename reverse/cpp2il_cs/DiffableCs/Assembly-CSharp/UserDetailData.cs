//Type is in global namespace

public class UserDetailData
{
	public long userId; //Field offset: 0x10
	public string userName; //Field offset: 0x18
	public int level; //Field offset: 0x20
	public long currentPetId; //Field offset: 0x28
	public long avtId; //Field offset: 0x30
	public int totalCombatPower; //Field offset: 0x38
	public int rank; //Field offset: 0x3C
	public PetDetailInfo currentPet; //Field offset: 0x40
	public List<UserPetInfo> allPets; //Field offset: 0x48
	public List<StoneInfo> stones; //Field offset: 0x50
	public int weaponImageId; //Field offset: 0x58
	public string weaponRarity; //Field offset: 0x60

	public UserDetailData() { }

}

