namespace Unity.VisualScripting;

public interface IUnitPortDefinition
{

	public bool hideLabel
	{
		 get { } //Length: 0
	}

	public bool isValid
	{
		 get { } //Length: 0
	}

	public string key
	{
		 get { } //Length: 0
	}

	public string label
	{
		 get { } //Length: 0
	}

	public string summary
	{
		 get { } //Length: 0
	}

	public bool get_hideLabel() { }

	public bool get_isValid() { }

	public string get_key() { }

	public string get_label() { }

	public string get_summary() { }

}

