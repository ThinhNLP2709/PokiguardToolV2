namespace UnityEngine.U2D.Animation;

internal class SpriteSkinContainer : ScriptableObject
{
	[CompilerGenerated]
	private static Action<SpriteSkin> onAddedSpriteSkin; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<SpriteSkin> onRemovedSpriteSkin; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<SpriteSkin> onBoneTransformChanged; //Field offset: 0x10
	private static SpriteSkinContainer s_Instance; //Field offset: 0x18
	private List<SpriteSkin> m_SpriteSkin; //Field offset: 0x18

	public static event Action<SpriteSkin> onAddedSpriteSkin
	{
		[CompilerGenerated]
		 add { } //Length: 215
		[CompilerGenerated]
		 remove { } //Length: 215
	}

	public static event Action<SpriteSkin> onBoneTransformChanged
	{
		[CompilerGenerated]
		 add { } //Length: 223
		[CompilerGenerated]
		 remove { } //Length: 223
	}

	public static event Action<SpriteSkin> onRemovedSpriteSkin
	{
		[CompilerGenerated]
		 add { } //Length: 223
		[CompilerGenerated]
		 remove { } //Length: 223
	}

	public static SpriteSkinContainer instance
	{
		 get { } //Length: 297
	}

	public IReadOnlyList<SpriteSkin> spriteSkins
	{
		 get { } //Length: 5
	}

	public SpriteSkinContainer() { }

	[CompilerGenerated]
	public static void add_onAddedSpriteSkin(Action<SpriteSkin> value) { }

	[CompilerGenerated]
	public static void add_onBoneTransformChanged(Action<SpriteSkin> value) { }

	[CompilerGenerated]
	public static void add_onRemovedSpriteSkin(Action<SpriteSkin> value) { }

	public void AddSpriteSkin(SpriteSkin spriteSkin) { }

	public void BoneTransformsChanged(SpriteSkin spriteSkin) { }

	public static SpriteSkinContainer get_instance() { }

	public IReadOnlyList<SpriteSkin> get_spriteSkins() { }

	[CompilerGenerated]
	public static void remove_onAddedSpriteSkin(Action<SpriteSkin> value) { }

	[CompilerGenerated]
	public static void remove_onBoneTransformChanged(Action<SpriteSkin> value) { }

	[CompilerGenerated]
	public static void remove_onRemovedSpriteSkin(Action<SpriteSkin> value) { }

	public void RemoveSpriteSkin(SpriteSkin spriteSkin) { }

}

