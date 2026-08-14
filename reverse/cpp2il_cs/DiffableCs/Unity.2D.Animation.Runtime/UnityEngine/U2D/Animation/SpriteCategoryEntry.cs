namespace UnityEngine.U2D.Animation;

[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
internal class SpriteCategoryEntry : INameHash, ISpriteLibraryLabel
{
	[SerializeField]
	private string m_Name; //Field offset: 0x10
	[HideInInspector]
	[SerializeField]
	private int m_Hash; //Field offset: 0x18
	[SerializeField]
	private Sprite m_Sprite; //Field offset: 0x20

	public override int hash
	{
		 get { } //Length: 4
	}

	public override string name
	{
		 get { } //Length: 5
		 set { } //Length: 143
	}

	public override Sprite sprite
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public SpriteCategoryEntry() { }

	public override int get_hash() { }

	public override string get_name() { }

	public override Sprite get_sprite() { }

	public override void set_name(string value) { }

	public void set_sprite(Sprite value) { }

	public void UpdateHash() { }

}

