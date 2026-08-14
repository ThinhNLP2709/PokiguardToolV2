namespace Unity.VisualScripting;

public interface INotifiedCollectionItem
{

	public void AfterAdd() { }

	public void AfterRemove() { }

	public void BeforeAdd() { }

	public void BeforeRemove() { }

}

