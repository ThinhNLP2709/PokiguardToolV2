//Type is in global namespace

public static class MatchPreloadCache
{
	public static bool IsReady; //Field offset: 0x0
	public static PetUserDTO uPetsMatch; //Field offset: 0x8
	public static PetUserDTO ePetsMatch; //Field offset: 0x10
	public static UserDTO userInfo; //Field offset: 0x18

	public static void Clear() { }

	public static void Mark(PetUserDTO myPet, PetUserDTO enemyPet, UserDTO user) { }

}

