namespace UnityEngine;

internal static class BeforeRenderHelper
{
	private struct OrderBlock
	{
		internal int order; //Field offset: 0x0
		internal UnityAction callback; //Field offset: 0x8

	}

	private static List<OrderBlock> s_OrderBlocks; //Field offset: 0x0

	private static BeforeRenderHelper() { }

	private static int GetUpdateOrder(UnityAction callback) { }

	public static void Invoke() { }

	public static void RegisterCallback(UnityAction callback) { }

	public static void UnregisterCallback(UnityAction callback) { }

}

