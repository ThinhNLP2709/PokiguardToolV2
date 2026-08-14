//Type is in global namespace

public class Readme : ScriptableObject
{
	internal class Section
	{
		public string heading; //Field offset: 0x10
		public string text; //Field offset: 0x18
		public string linkText; //Field offset: 0x20
		public string url; //Field offset: 0x28

		public Section() { }

	}

	public Texture2D icon; //Field offset: 0x18
	public string title; //Field offset: 0x20
	public Section[] sections; //Field offset: 0x28
	public bool loadedLayout; //Field offset: 0x30

	public Readme() { }

}

