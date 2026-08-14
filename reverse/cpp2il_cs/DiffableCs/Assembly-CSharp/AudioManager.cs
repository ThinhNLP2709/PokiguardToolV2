//Type is in global namespace

public class AudioManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <ResetPitchAfterDelay>d__62 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public AudioManager <>4__this; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <ResetPitchAfterDelay>d__62(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private static AudioManager <Instance>k__BackingField; //Field offset: 0x0
	[Header("Audio Sources")]
	public AudioSource bgmSource; //Field offset: 0x20
	public AudioSource sfxSource; //Field offset: 0x28
	[Header("Background Music - 6 Tracks")]
	[Tooltip("Sẽ random 1 trong 6 bài này khi bắt đầu")]
	public AudioClip[] backgroundMusics; //Field offset: 0x30
	[Header("Match Sounds (6 loại viên)")]
	[Tooltip("Thứ tự: xanh, xanhduong, do, tim, trang, vang")]
	public AudioClip[] matchSounds; //Field offset: 0x38
	[Header("Special Sounds")]
	public AudioClip swordClickSound; //Field offset: 0x40
	[Header("Card Effect Sounds")]
	[Tooltip("ATTACK card thường (id=4/5, elementType=ATTACK)")]
	public AudioClip attackSound; //Field offset: 0x48
	[Tooltip("ATTACK_LEGEND / dot-skill sát thương lớn")]
	public AudioClip attackPowerSound; //Field offset: 0x50
	[Tooltip("HP heal (cardID 1/6/7/8, HEALTH)")]
	public AudioClip healSound; //Field offset: 0x58
	[Tooltip("Mana card (cardID 2, MANA)")]
	public AudioClip manaSound; //Field offset: 0x60
	[Tooltip("Power/No card (cardID 3, POWER)")]
	public AudioClip powerSound; //Field offset: 0x68
	[Header("Multiplier / Special Dot Sounds")]
	[Tooltip("Phá viên có multiplier >= 2 (viên có animation sparkle text)")]
	public AudioClip multiplierMatchSound; //Field offset: 0x70
	[Tooltip("Phá viên kim cương vàng (vang Dot)")]
	public AudioClip diamondMatchSound; //Field offset: 0x78
	[Header("Pet Animation Sounds")]
	[Tooltip("key=1: pet đánh thường (vang Dot, không full nộ)")]
	public AudioClip petAttackSound; //Field offset: 0x80
	[Tooltip("key=2: pet đánh full nộ / dame card (vang Dot full power, MEGA, ATTACK card)")]
	public AudioClip petAttackPowerSound; //Field offset: 0x88
	[Tooltip("key=3: pet buff/heal (xanh/xanhduong/do/tim/trang Dot)")]
	public AudioClip petBuffSound; //Field offset: 0x90
	[Tooltip("key=4: pet bị đánh / né")]
	public AudioClip petHurtSound; //Field offset: 0x98
	[Header("Match Result Sounds")]
	[Tooltip("Thắng trận")]
	public AudioClip winSound; //Field offset: 0xA0
	[Tooltip("Thua trận")]
	public AudioClip loseSound; //Field offset: 0xA8
	[Header("Settings")]
	[Range(0, 1)]
	public float bgmVolume; //Field offset: 0xB0
	[Range(0, 1)]
	public float sfxVolume; //Field offset: 0xB4
	[Header("In-Match Mix")]
	[Range(0, 1)]
	[Tooltip("Hệ số nhân BGM khi trong trận (giảm để SFX nổi). 0.4 = 40% setting gốc.")]
	public float inMatchBgmFactor; //Field offset: 0xB8
	[Range(1, 2)]
	[Tooltip("Hệ số nhân SFX khi trong trận (tăng để hiệu ứng rõ). 1.4 = 140% setting gốc, clamp 1.")]
	public float inMatchSfxFactor; //Field offset: 0xBC
	[Header("Debug Info")]
	[SerializeField]
	private int currentBGMIndex; //Field offset: 0xC0
	private int _matchSfxLastFrame; //Field offset: 0xC4
	private int _matchSfxPlaysThisFrame; //Field offset: 0xC8
	private int _petAnimSfxLastFrame; //Field offset: 0xCC
	private int _petAnimSfxLastKey; //Field offset: 0xD0
	private int _animSfxLastFrame; //Field offset: 0xD4
	private int _animSfxPlaysThisFrame; //Field offset: 0xD8
	[Header("Combo Settings")]
	public float comboPitchIncrement; //Field offset: 0xDC
	private int currentCombo; //Field offset: 0xE0

	public private static AudioManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public AudioManager() { }

	private void Awake() { }

	[CompilerGenerated]
	public static AudioManager get_Instance() { }

	public string GetCurrentTrackName() { }

	private int GetSoundIndexFromTag(string tag) { }

	private void LoadAudioSettings() { }

	public void MuteAll() { }

	public void PlayAttackPowerSound() { }

	public void PlayAttackSound() { }

	public void PlayCardSoundByElement(string elementType) { }

	public void PlayCardSoundById(int cardId) { }

	public void PlayDiamondMatchSound() { }

	public void PlayDotAnimationSound(string dotTag, int multiplier) { }

	public void PlayHealSound() { }

	public void PlayLoseSound() { }

	public void PlayManaSound() { }

	public void PlayMatchResultSound(bool playerWon) { }

	public void PlayMatchSound(string dotTag) { }

	public void PlayMatchSoundWithCombo(string dotTag, int comboCount) { }

	public void PlayMultiplierMatchSound() { }

	public void PlayNextBackgroundMusic() { }

	public void PlayPetAnimSound(int key) { }

	public void PlayPowerSound() { }

	public void PlayRandomBackgroundMusic() { }

	private void PlaySfx(AudioClip clip) { }

	public void PlaySwordClickSound() { }

	public void PlayWinSound() { }

	public void ResetCombo() { }

	[IteratorStateMachine(typeof(<ResetPitchAfterDelay>d__62))]
	private IEnumerator ResetPitchAfterDelay(float delay) { }

	[CompilerGenerated]
	private static void set_Instance(AudioManager value) { }

	public void SetBGMVolume(float volume) { }

	public void SetSFXVolume(float volume) { }

	private void SetupAudioSources() { }

	private void Start() { }

	public void StopBackgroundMusic() { }

	public void UnmuteAll() { }

}

