//Type is in global namespace

public static class PetAnimatorBinder
{
	private const string ICON_PATH = "Image/IconsPet/"; //Field offset: 0x0
	private static readonly String[] IDLE_CLIP_NAMES; //Field offset: 0x0

	private static PetAnimatorBinder() { }

	private static void ApplyController(Animator animator, AnimatorOverrideController controller) { }

	public static void ApplyStaticFallback(Animator animator, string petId, Image image = null, SpriteRenderer renderer = null) { }

	public static bool Bind(Animator animator, AnimationClip[] clips, string debugLabel = null) { }

	public static bool Bind(Animator animator, AnimationClip[] clips, out bool complete, string debugLabel = null) { }

	public static bool BindOrFallback(Animator animator, AnimationClip[] clips, string petId, Image fallbackImage = null, SpriteRenderer fallbackRenderer = null) { }

	public static bool BindSingle(Animator animator, string clipName, AnimationClip clip) { }

	private static bool HasIntParam(Animator animator, string name) { }

	public static RuntimeAnimatorController ResolveBase(Animator animator) { }

}

