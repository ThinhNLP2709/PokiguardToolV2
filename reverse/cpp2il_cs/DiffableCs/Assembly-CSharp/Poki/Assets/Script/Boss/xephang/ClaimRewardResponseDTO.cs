namespace Poki.Assets.Script.Boss.xephang;

public class ClaimRewardResponseDTO
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public RewardDetailDTO reward; //Field offset: 0x20

	public ClaimRewardResponseDTO() { }

}

