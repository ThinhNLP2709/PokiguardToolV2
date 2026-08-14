namespace UnityEngine.Experimental.Rendering;

internal class XRLayoutStack : IDisposable
{
	private readonly Stack<XRLayout> m_Stack; //Field offset: 0x10

	public XRLayout top
	{
		 get { } //Length: 68
	}

	public XRLayoutStack() { }

	public override void Dispose() { }

	public XRLayout get_top() { }

	public XRLayout New() { }

	public void Release() { }

}

