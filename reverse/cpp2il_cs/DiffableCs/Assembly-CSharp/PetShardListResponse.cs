//Type is in global namespace

public class PetShardListResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public int maxStar; //Field offset: 0x20
	public int exchangeCost; //Field offset: 0x24
	public PetShardDTO[] shards; //Field offset: 0x28

	public PetShardListResponse() { }

}

