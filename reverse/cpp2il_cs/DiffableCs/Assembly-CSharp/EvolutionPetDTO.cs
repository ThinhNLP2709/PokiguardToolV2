//Type is in global namespace

public class EvolutionPetDTO
{
	public long sourcePetId; //Field offset: 0x10
	public string sourcePetName; //Field offset: 0x18
	public long targetPetId; //Field offset: 0x20
	public string targetPetName; //Field offset: 0x28
	public bool canEvolve; //Field offset: 0x30
	public bool hasEvolved; //Field offset: 0x31

	public EvolutionPetDTO() { }

}

