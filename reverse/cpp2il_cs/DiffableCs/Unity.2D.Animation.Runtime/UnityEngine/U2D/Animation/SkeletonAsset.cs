namespace UnityEngine.U2D.Animation;

public class SkeletonAsset : ScriptableObject
{
	[SerializeField]
	private SpriteBone[] m_SpriteBones; //Field offset: 0x18

	public SkeletonAsset() { }

	public SpriteBone[] GetSpriteBones() { }

	public void SetSpriteBones(SpriteBone[] spriteBones) { }

}

