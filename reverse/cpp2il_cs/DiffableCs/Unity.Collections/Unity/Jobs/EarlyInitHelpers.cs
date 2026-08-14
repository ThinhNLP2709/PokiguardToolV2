namespace Unity.Jobs;

public class EarlyInitHelpers
{
	internal sealed class EarlyInitFunction : MulticastDelegate
	{

		public EarlyInitFunction(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke() { }

	}

	private static List<EarlyInitFunction> s_PendingDelegates; //Field offset: 0x0

	private static EarlyInitHelpers() { }

	public EarlyInitHelpers() { }

	public static void AddEarlyInitFunction(EarlyInitFunction func) { }

	public static void FlushEarlyInits() { }

	public static void JobReflectionDataCreationFailed(Exception ex) { }

}

