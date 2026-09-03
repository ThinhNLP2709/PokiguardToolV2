/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	public class PlatformMappingService // TypeDefIndex: 14084
	{
		// Fields
		internal static readonly Dictionary<RuntimePlatform, AddressablesPlatform> s_RuntimeTargetMapping; // 0x00
	
		// Constructors
		public PlatformMappingService(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static PlatformMappingService(); // 0x0000000181C7E590-0x0000000181C7E7D0
	
		// Methods
		internal static AddressablesPlatform GetAddressablesPlatformInternal(RuntimePlatform platform); // 0x0000000181C7E240-0x0000000181C7E300
		internal static string GetAddressablesPlatformPathInternal(RuntimePlatform platform); // 0x0000000181C7E300-0x0000000181C7E420
		public static string GetPlatformPathSubFolder(); // 0x0000000181C7E420-0x0000000181C7E590
	}
}
