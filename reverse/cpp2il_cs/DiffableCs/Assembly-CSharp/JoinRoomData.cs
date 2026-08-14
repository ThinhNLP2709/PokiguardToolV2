//Type is in global namespace

public class JoinRoomData
{
	public int id; //Field offset: 0x10
	public string name; //Field offset: 0x18
	public string user; //Field offset: 0x20
	public int gold; //Field offset: 0x28
	public int money; //Field offset: 0x2C
	public int idPet; //Field offset: 0x30
	public int energy; //Field offset: 0x34
	public int energyFull; //Field offset: 0x38
	public int lever; //Field offset: 0x3C
	public int countPass; //Field offset: 0x40
	public int idPetUser; //Field offset: 0x44
	public string thumbnailPetUser; //Field offset: 0x48
	public int playerId; //Field offset: 0x50
	public ImageData[] imageUser; //Field offset: 0x58
	public string namePetEnemy; //Field offset: 0x60
	public ImageData[] imageEnemyPet; //Field offset: 0x68
	public EnemyPetRoom enemyPet; //Field offset: 0x70
	public ChooseCard[] listChooseCard; //Field offset: 0x78
	public ChoosePet[] listChoosePet; //Field offset: 0x80

	public JoinRoomData() { }

}

