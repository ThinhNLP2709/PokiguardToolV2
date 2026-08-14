namespace UnityEngine.U2D.Animation;

public interface ISpriteLibraryCategory
{

	public IEnumerable<ISpriteLibraryLabel> labels
	{
		 get { } //Length: 0
	}

	public string name
	{
		 get { } //Length: 0
	}

	public IEnumerable<ISpriteLibraryLabel> get_labels() { }

	public string get_name() { }

}

