namespace Unity.VisualScripting.Dependencies.NCalc;

public sealed class EvaluateParameterHandler : MulticastDelegate
{

	public EvaluateParameterHandler(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(Flow flow, string name, ParameterArgs args, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(Flow flow, string name, ParameterArgs args) { }

}

