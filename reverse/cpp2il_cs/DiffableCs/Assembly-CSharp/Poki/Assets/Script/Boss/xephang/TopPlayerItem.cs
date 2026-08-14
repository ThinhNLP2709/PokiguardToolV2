namespace Poki.Assets.Script.Boss.xephang;

public class TopPlayerItem : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public TopPlayerItem <>4__this; //Field offset: 0x10
		public int value; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <AnimateDamage>b__0(float v) { }

		internal void <AnimateDamage>b__1() { }

	}

	private static readonly Color SelfHighlight; //Field offset: 0x0
	public Text txtTop; //Field offset: 0x20
	public Image imgPet; //Field offset: 0x28
	public Image imgbg; //Field offset: 0x30
	public Text txtName; //Field offset: 0x38
	public Text txtDame; //Field offset: 0x40

	private static TopPlayerItem() { }

	public TopPlayerItem() { }

	private void AnimateDamage(int value) { }

	private void LoadPetAvatar(long petId) { }

	public void SetupTopPlayer(BossRankingPlayerDTO player) { }

	public void SetupTopPlayer(BossRankingPlayerDTO player, bool isSelf) { }

}

