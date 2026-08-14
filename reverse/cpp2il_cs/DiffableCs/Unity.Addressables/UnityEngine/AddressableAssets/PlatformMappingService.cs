namespace UnityEngine.AddressableAssets;

public class PlatformMappingService
{
	internal static readonly Dictionary<RuntimePlatform, AddressablesPlatform> s_RuntimeTargetMapping; //Field offset: 0x0

	private static PlatformMappingService() { }

	public PlatformMappingService() { }

	internal static AddressablesPlatform GetAddressablesPlatformInternal(RuntimePlatform platform) { }

	internal static string GetAddressablesPlatformPathInternal(RuntimePlatform platform) { }

	public static string GetPlatformPathSubFolder() { }

}

