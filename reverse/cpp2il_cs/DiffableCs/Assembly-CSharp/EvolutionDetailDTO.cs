//Type is in global namespace

public class EvolutionDetailDTO
{
	public long sourcePetId; //Field offset: 0x10
	public string sourcePetName; //Field offset: 0x18
	public int currentLevel; //Field offset: 0x20
	public int requiredLevel; //Field offset: 0x24
	public long targetPetId; //Field offset: 0x28
	public string targetPetName; //Field offset: 0x30
	public int targetMaxLevel; //Field offset: 0x38
	public int currentDefeats; //Field offset: 0x3C
	public int requiredDefeats; //Field offset: 0x40
	public int currentCrystal; //Field offset: 0x44
	public int requiredCrystal; //Field offset: 0x48
	public int currentEItem1; //Field offset: 0x4C
	public int requiredEItem1; //Field offset: 0x50
	public int currentEItem2; //Field offset: 0x54
	public int requiredEItem2; //Field offset: 0x58
	public int currentEItem3; //Field offset: 0x5C
	public int requiredEItem3; //Field offset: 0x60
	public int currentEItem4; //Field offset: 0x64
	public int requiredEItem4; //Field offset: 0x68
	public List<StoneRequirementDTO> stoneRequirements; //Field offset: 0x70
	public List<RequiredPetDTO> requiredPets; //Field offset: 0x78
	public bool canEvolve; //Field offset: 0x80
	public bool hasEvolved; //Field offset: 0x81

	public EvolutionDetailDTO() { }

}

