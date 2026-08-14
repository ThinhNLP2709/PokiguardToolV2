namespace Unity.VisualScripting;

public interface IGraphNest : IAotStubbable
{

	public IGraph embed
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IGraph graph
	{
		 get { } //Length: 0
	}

	public Type graphType
	{
		 get { } //Length: 0
	}

	public bool hasBackgroundEmbed
	{
		 get { } //Length: 0
	}

	public IMacro macro
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Type macroType
	{
		 get { } //Length: 0
	}

	public IGraphNester nester
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public GraphSource source
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IGraph get_embed() { }

	public IGraph get_graph() { }

	public Type get_graphType() { }

	public bool get_hasBackgroundEmbed() { }

	public IMacro get_macro() { }

	public Type get_macroType() { }

	public IGraphNester get_nester() { }

	public GraphSource get_source() { }

	public void set_embed(IGraph value) { }

	public void set_macro(IMacro value) { }

	public void set_nester(IGraphNester value) { }

	public void set_source(GraphSource value) { }

}

