//Type is in global namespace

public class PetRewardDataDTO
{
	public long petId; //Field offset: 0x10
	public int levelDisplay; //Field offset: 0x18
	public int requestAttack; //Field offset: 0x1C
	public int expGain; //Field offset: 0x20
	public Nullable<Int32> goldBonus; //Field offset: 0x24
	public List<StoneRewardInfo> stoneRewards; //Field offset: 0x30
	public Nullable<Int32> stoneCardDrop; //Field offset: 0x38
	public bool receivedPet; //Field offset: 0x40
	public int newLevel; //Field offset: 0x44
	public int currentExp; //Field offset: 0x48
	public int expToNextLevel; //Field offset: 0x4C
	public Nullable<Int32> eItem1Drop; //Field offset: 0x50
	public Nullable<Int32> eItem2Drop; //Field offset: 0x58
	public Nullable<Int32> eItem3Drop; //Field offset: 0x60
	public Nullable<Int32> eItem4Drop; //Field offset: 0x68
	public Nullable<Int32> crystalDrop; //Field offset: 0x70
	public Nullable<Int32> e1Drop; //Field offset: 0x78
	public Nullable<Int32> e2Drop; //Field offset: 0x80
	public Nullable<Int32> e3Drop; //Field offset: 0x88
	public Nullable<Int64> itemAvtDrop; //Field offset: 0x90
	public Nullable<Int32> itemAvtDropAmount; //Field offset: 0xA0

	public PetRewardDataDTO() { }

}

