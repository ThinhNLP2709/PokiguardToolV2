namespace UnityEngine.Rendering;

public sealed class ListChangedEventHandler : MulticastDelegate
{

	public ListChangedEventHandler`1(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(ObservableList<T> sender, ListChangedEventArgs<T> e, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(ObservableList<T> sender, ListChangedEventArgs<T> e) { }

}

