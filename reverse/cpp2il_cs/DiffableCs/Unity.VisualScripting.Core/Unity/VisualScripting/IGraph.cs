namespace Unity.VisualScripting;

public interface IGraph : IDisposable, IPrewarmable, IAotStubbable, ISerializationDepender, ISerializationCallbackReceiver
{

	public MergedGraphElementCollection elements
	{
		 get { } //Length: 0
	}

	public Vector2 pan
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string summary
	{
		 get { } //Length: 0
	}

	public string title
	{
		 get { } //Length: 0
	}

	public float zoom
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IGraphData CreateData() { }

	public IGraphDebugData CreateDebugData() { }

	public MergedGraphElementCollection get_elements() { }

	public Vector2 get_pan() { }

	public string get_summary() { }

	public string get_title() { }

	public float get_zoom() { }

	public void Instantiate(GraphReference instance) { }

	public void set_pan(Vector2 value) { }

	public void set_zoom(float value) { }

	public void Uninstantiate(GraphReference instance) { }

}

