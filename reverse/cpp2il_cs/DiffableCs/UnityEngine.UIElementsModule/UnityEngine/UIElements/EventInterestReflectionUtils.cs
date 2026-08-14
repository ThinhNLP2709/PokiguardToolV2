namespace UnityEngine.UIElements;

internal static class EventInterestReflectionUtils
{
	private struct DefaultEventInterests
	{
		public int DefaultActionCategories; //Field offset: 0x0
		public int DefaultActionAtTargetCategories; //Field offset: 0x4
		public int HandleEventTrickleDownCategories; //Field offset: 0x8
		public int HandleEventBubbleUpCategories; //Field offset: 0xC

	}

	private static readonly Dictionary<Type, DefaultEventInterests> s_DefaultEventInterests; //Field offset: 0x0
	private static readonly Dictionary<Type, EventCategory> s_EventCategories; //Field offset: 0x8

	private static EventInterestReflectionUtils() { }

	private static int ComputeDefaultEventInterests(Type elementType, string methodName) { }

	internal static void GetDefaultEventInterests(Type elementType, out int defaultActionCategories, out int defaultActionAtTargetCategories, out int handleEventTrickleDownCategories, out int handleEventBubbleUpCategories) { }

	internal static EventCategory GetEventCategory(Type eventType) { }

}

