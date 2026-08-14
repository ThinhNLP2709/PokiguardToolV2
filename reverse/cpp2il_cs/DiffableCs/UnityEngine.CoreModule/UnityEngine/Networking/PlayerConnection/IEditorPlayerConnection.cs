namespace UnityEngine.Networking.PlayerConnection;

public interface IEditorPlayerConnection
{

	public void Register(Guid messageId, UnityAction<MessageEventArgs> callback) { }

	public void RegisterConnection(UnityAction<Int32> callback) { }

	public void RegisterDisconnection(UnityAction<Int32> callback) { }

	public void Send(Guid messageId, Byte[] data) { }

}

