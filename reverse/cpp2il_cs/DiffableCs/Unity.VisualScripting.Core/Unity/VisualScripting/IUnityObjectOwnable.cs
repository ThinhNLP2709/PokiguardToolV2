namespace Unity.VisualScripting;

public interface IUnityObjectOwnable
{

	public object owner
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public object get_owner() { }

	public void set_owner(object value) { }

}

