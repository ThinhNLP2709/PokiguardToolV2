namespace UnityEngine.Rendering;

internal sealed class OnCullingCompleteCallback : MulticastDelegate
{

	public OnCullingCompleteCallback(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(JobHandle jobHandle, in BatchCullingContext cullingContext, in BatchCullingOutput cullingOutput, AsyncCallback callback, object object) { }

	public override void EndInvoke(in BatchCullingContext cullingContext, in BatchCullingOutput cullingOutput, IAsyncResult result) { }

	public override void Invoke(JobHandle jobHandle, in BatchCullingContext cullingContext, in BatchCullingOutput cullingOutput) { }

}

