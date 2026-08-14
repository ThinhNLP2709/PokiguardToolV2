//Type is in global namespace

public class ClaimQuestResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public List<QuestRewardData> rewards; //Field offset: 0x20
	public UserUpdateData userUpdate; //Field offset: 0x28

	public ClaimQuestResponse() { }

}

