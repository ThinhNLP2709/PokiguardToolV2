namespace Unity.VisualScripting;

public interface IProxyableNotifyCollectionChanged
{

	public bool ProxyCollectionChange
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public void AfterAdd(T item) { }

	public void AfterRemove(T item) { }

	public void BeforeAdd(T item) { }

	public void BeforeRemove(T item) { }

	public bool get_ProxyCollectionChange() { }

	public void set_ProxyCollectionChange(bool value) { }

}

