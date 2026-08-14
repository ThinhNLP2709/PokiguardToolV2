//Type is in global namespace

public static class FusionGhostFx
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public GameObject aura; //Field offset: 0x10
		public SpriteRenderer auraSr; //Field offset: 0x18
		public Vector3 auraBase; //Field offset: 0x20

		public <>c__DisplayClass16_0() { }

		internal void <BuildAura>b__0(float k) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public FusionGhostFxNode marker; //Field offset: 0x10
		public int boundPetId; //Field offset: 0x18

		public <>c__DisplayClass17_0() { }

		internal void <BuildGhost>b__0(float k) { }

		internal void <BuildGhost>b__1(AnimationClip[] clips) { }

	}

	private const string NODE_NAME = "FusionGhostFx"; //Field offset: 0x0
	private const string DEAD_NODE_NAME = "FusionGhostFx_dead"; //Field offset: 0x0
	private const int FX_ORDER_BELOW_HOST = 1; //Field offset: 0x0
	private const float AURA_Z_TOWARD_CAM = -1; //Field offset: 0x0
	private const float GHOST_Z_TOWARD_CAM = -2; //Field offset: 0x0
	private const float GHOST_ALPHA = 0.55; //Field offset: 0x0
	private const float GHOST_HEIGHT_SCALE = 1.45; //Field offset: 0x0
	private const float GHOST_CENTER_LIFT = 0.3; //Field offset: 0x0
	private const float GHOST_BREATH = 0.04; //Field offset: 0x0
	private const float AURA_HEIGHT_SCALE = 1; //Field offset: 0x0
	private const float AURA_ALPHA_MIN = 0.45; //Field offset: 0x0
	private const float AURA_ALPHA_MAX = 0.85; //Field offset: 0x0
	private const float AURA_SPIN_SECONDS = 12; //Field offset: 0x0
	private const float FALLBACK_SPRITE_UNITS = 0.8; //Field offset: 0x0

	private static void ApplyGhostClips(FusionGhostFxNode marker, AnimationClip[] clips) { }

	public static void Bind(SpriteRenderer host, int petId) { }

	private static void BuildAura(FusionGhostFxNode marker, GameObject go, SpriteRenderer host, float hostUnits, int order) { }

	private static void BuildGhost(FusionGhostFxNode marker, GameObject go, SpriteRenderer host, int petId, float hostUnits, int order) { }

	public static void Clear(SpriteRenderer host) { }

	private static FusionGhostFxNode FindNode(Transform host) { }

	private static void SetLocalHeight(Transform t, Sprite sprite, float targetUnits) { }

}

