//Type is in global namespace

public class RankingRewardTier
{
	public long id; //Field offset: 0x10
	public string tierName; //Field offset: 0x18
	public int rankFrom; //Field offset: 0x20
	public int rankTo; //Field offset: 0x24
	public int gold; //Field offset: 0x28
	public int ruby; //Field offset: 0x2C
	public int energy; //Field offset: 0x30
	public int exp; //Field offset: 0x34
	public int starWhite; //Field offset: 0x38
	public int starBlue; //Field offset: 0x3C
	public int starRed; //Field offset: 0x40
	public int wheel; //Field offset: 0x44
	public int wheelDay; //Field offset: 0x48
	public int crystal; //Field offset: 0x4C
	public int eitem1; //Field offset: 0x50
	public int eitem2; //Field offset: 0x54
	public int eitem3; //Field offset: 0x58
	public int eitem4; //Field offset: 0x5C
	public long petId; //Field offset: 0x60
	public long avtId; //Field offset: 0x68
	public long cardId; //Field offset: 0x70
	public string stonesJson; //Field offset: 0x78

	public string DisplayLabel
	{
		 get { } //Length: 171
	}

	public RankingRewardTier() { }

	public string get_DisplayLabel() { }

}

