//Type is in global namespace

public static class PetSlotLoadingFx
{
	private const string CHILD_NAME = "PetLoadingFx"; //Field offset: 0x0
	private const string CONTROLLER_PATH = "amt/loadCtl"; //Field offset: 0x0
	private const float SPINNER_WORLD_SCALE = 2; //Field offset: 0x0
	private static RuntimeAnimatorController _controller; //Field offset: 0x0
	private static bool _controllerMissingLogged; //Field offset: 0x8

	public static void Hide(SpriteRenderer petRenderer) { }

	private static RuntimeAnimatorController LoadController() { }

	private static GameObject Resolve(SpriteRenderer petRenderer, bool create) { }

	public static void Show(SpriteRenderer petRenderer) { }

}

