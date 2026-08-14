namespace UnityEngine.U2D.Animation;

[AddComponentMenu(null)]
internal class Bone : MonoBehaviour
{
	[HideInInspector]
	[SerializeField]
	private string m_Guid; //Field offset: 0x20

	public string guid
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public Bone() { }

	public string get_guid() { }

	public void set_guid(string value) { }

}

