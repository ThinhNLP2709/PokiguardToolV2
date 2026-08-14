//Type is in global namespace

public class EnergyInfoDTO
{
	public int currentEnergy; //Field offset: 0x10
	public int maxEnergy; //Field offset: 0x14
	public long secondsUntilNextRegen; //Field offset: 0x18
	public string lastUpdateTime; //Field offset: 0x20

	public EnergyInfoDTO() { }

}

