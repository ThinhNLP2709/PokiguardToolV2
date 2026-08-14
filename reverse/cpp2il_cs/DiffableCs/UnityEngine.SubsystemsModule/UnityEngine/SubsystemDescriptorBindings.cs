namespace UnityEngine;

internal static class SubsystemDescriptorBindings
{

	public static IntPtr Create(IntPtr descriptorPtr) { }

	public static string GetId(IntPtr descriptorPtr) { }

	private static void GetId_Injected(IntPtr descriptorPtr, out ManagedSpanWrapper ret) { }

}

