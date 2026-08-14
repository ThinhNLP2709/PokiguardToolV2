namespace UnityEngine.UIElements;

internal interface IPanelRenderer
{

	public bool forceGammaRendering
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public uint vertexBudget
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool get_forceGammaRendering() { }

	public uint get_vertexBudget() { }

	public void Render() { }

	public void Reset() { }

	public void set_forceGammaRendering(bool value) { }

	public void set_vertexBudget(uint value) { }

}

