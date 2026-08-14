//Type is in global namespace

public class WsCombatStepDTO
{
	public string kind; //Field offset: 0x10
	public string source; //Field offset: 0x18
	public string target; //Field offset: 0x20
	public int amount; //Field offset: 0x28
	public string stealType; //Field offset: 0x30
	public Dictionary<String, Int32> after; //Field offset: 0x38
	public int idx; //Field offset: 0x40

	public WsCombatStepDTO() { }

}

