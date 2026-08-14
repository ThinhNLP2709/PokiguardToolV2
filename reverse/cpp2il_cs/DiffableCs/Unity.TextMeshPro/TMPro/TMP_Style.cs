namespace TMPro;

public class TMP_Style
{
	internal static TMP_Style k_NormalStyle; //Field offset: 0x0
	[SerializeField]
	private string m_Name; //Field offset: 0x10
	[SerializeField]
	private int m_HashCode; //Field offset: 0x18
	[SerializeField]
	private string m_OpeningDefinition; //Field offset: 0x20
	[SerializeField]
	private string m_ClosingDefinition; //Field offset: 0x28
	[SerializeField]
	private UInt32[] m_OpeningTagArray; //Field offset: 0x30
	[SerializeField]
	private UInt32[] m_ClosingTagArray; //Field offset: 0x38

	public int hashCode
	{
		 get { } //Length: 4
		 set { } //Length: 9
	}

	public string name
	{
		 get { } //Length: 5
		 set { } //Length: 62
	}

	public static TMP_Style NormalStyle
	{
		 get { } //Length: 214
	}

	public string styleClosingDefinition
	{
		 get { } //Length: 5
	}

	public UInt32[] styleClosingTagArray
	{
		 get { } //Length: 5
	}

	public string styleOpeningDefinition
	{
		 get { } //Length: 5
	}

	public UInt32[] styleOpeningTagArray
	{
		 get { } //Length: 5
	}

	internal TMP_Style(string styleName, string styleOpeningDefinition, string styleClosingDefinition) { }

	public int get_hashCode() { }

	public string get_name() { }

	public static TMP_Style get_NormalStyle() { }

	public string get_styleClosingDefinition() { }

	public UInt32[] get_styleClosingTagArray() { }

	public string get_styleOpeningDefinition() { }

	public UInt32[] get_styleOpeningTagArray() { }

	public void RefreshStyle() { }

	public void set_hashCode(int value) { }

	public void set_name(string value) { }

}

