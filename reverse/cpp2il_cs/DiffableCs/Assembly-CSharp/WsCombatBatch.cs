//Type is in global namespace

public class WsCombatBatch
{
	public long srvSeq; //Field offset: 0x10
	public string actorUsername; //Field offset: 0x18
	public int totalDamageDisplay; //Field offset: 0x20
	public List<WsCombatStepDTO> steps; //Field offset: 0x28
	public Dictionary<String, Int32> destroyedByTag; //Field offset: 0x30
	public BoardCellDTO[][] board; //Field offset: 0x38

	public bool HasDestroyedTags
	{
		 get { } //Length: 79
	}

	public bool IsBossActor
	{
		 get { } //Length: 67
	}

	public WsCombatBatch() { }

	public bool get_HasDestroyedTags() { }

	public bool get_IsBossActor() { }

}

