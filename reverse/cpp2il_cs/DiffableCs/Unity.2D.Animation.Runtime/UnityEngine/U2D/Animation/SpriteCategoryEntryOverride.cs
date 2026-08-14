namespace UnityEngine.U2D.Animation;

internal class SpriteCategoryEntryOverride : SpriteCategoryEntry
{
	[SerializeField]
	private bool m_FromMain; //Field offset: 0x28
	[SerializeField]
	private Sprite m_SpriteOverride; //Field offset: 0x30

	public bool fromMain
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public Sprite spriteOverride
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public SpriteCategoryEntryOverride() { }

	public bool get_fromMain() { }

	public Sprite get_spriteOverride() { }

	public void set_fromMain(bool value) { }

	public void set_spriteOverride(Sprite value) { }

}

