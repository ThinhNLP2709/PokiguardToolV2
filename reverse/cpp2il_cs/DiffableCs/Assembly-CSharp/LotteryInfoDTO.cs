//Type is in global namespace

public class LotteryInfoDTO
{
	public int freeTicketsRemaining; //Field offset: 0x10
	public int totalTicketsUsed; //Field offset: 0x14
	public List<Int32> selectedNumbers; //Field offset: 0x18
	public string nextDrawTime; //Field offset: 0x20
	public LotteryResultDTO lastResult; //Field offset: 0x28
	public bool canClaim; //Field offset: 0x30
	public List<PrizeDTO> prizes; //Field offset: 0x38

	public LotteryInfoDTO() { }

}

