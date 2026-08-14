namespace Unity.Collections;

internal class UnsafeQueueBlockPool
{
	private static readonly SharedStatic<IntPtr> Data; //Field offset: 0x0

	private static UnsafeQueueBlockPool() { }

	public UnsafeQueueBlockPool() { }

	[BurstDiscard]
	private static void AppDomainOnDomainUnload() { }

	internal static UnsafeQueueBlockPoolData* GetQueueBlockPool() { }

	private static void OnDomainUnload(object sender, EventArgs e) { }

}

