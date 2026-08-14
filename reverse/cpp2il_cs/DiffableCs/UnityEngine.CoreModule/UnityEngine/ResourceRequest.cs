namespace UnityEngine;

[RequiredByNativeCode]
public class ResourceRequest : AsyncOperation
{
	public static class BindingsMarshaller
	{

		public static ResourceRequest ConvertToManaged(IntPtr ptr) { }

	}

	internal string m_Path; //Field offset: 0x20
	internal Type m_Type; //Field offset: 0x28

	public object asset
	{
		 get { } //Length: 20
	}

	protected ResourceRequest(IntPtr ptr) { }

	public object get_asset() { }

	protected override object GetResult() { }

}

