namespace Unity.VisualScripting;

[AttributeUsage(2432, AllowMultiple = False, Inherited = True)]
public sealed class InspectorTextAreaAttribute : Attribute
{
	private Nullable<Single> _minLines; //Field offset: 0x10
	private Nullable<Single> _maxLines; //Field offset: 0x18

	public bool hasMaxLines
	{
		 get { } //Length: 57
	}

	public bool hasMinLines
	{
		 get { } //Length: 57
	}

	public float maxLines
	{
		 get { } //Length: 59
		 set { } //Length: 94
	}

	public float minLines
	{
		 get { } //Length: 59
		 set { } //Length: 94
	}

	public InspectorTextAreaAttribute() { }

	public bool get_hasMaxLines() { }

	public bool get_hasMinLines() { }

	public float get_maxLines() { }

	public float get_minLines() { }

	public void set_maxLines(float value) { }

	public void set_minLines(float value) { }

}

