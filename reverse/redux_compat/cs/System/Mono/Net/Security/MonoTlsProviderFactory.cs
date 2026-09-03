/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal static class MonoTlsProviderFactory // TypeDefIndex: 8570
	{
		// Fields
		private static object locker; // 0x00
		private static bool initialized; // 0x08
		private static MobileTlsProvider defaultProvider; // 0x10
		private static Dictionary<string, Tuple<Guid, string>> providerRegistration; // 0x18
		private static Dictionary<Guid, MobileTlsProvider> providerCache; // 0x20
		internal static readonly Guid UnityTlsId; // 0x28
		internal static readonly Guid AppleTlsId; // 0x38
		internal static readonly Guid BtlsId; // 0x48
	
		// Constructors
		static MonoTlsProviderFactory(); // 0x000000018181E800-0x000000018181E930
	
		// Methods
		internal static MobileTlsProvider GetProviderInternal(); // 0x000000018181D650-0x000000018181D760
		internal static void InitializeInternal(); // 0x000000018181D7A0-0x000000018181DAE0
		private static MobileTlsProvider LookupProvider(string name, bool throwOnError); // 0x000000018181DFE0-0x000000018181E510
		private static void InitializeProviderRegistration(); // 0x000000018181DAE0-0x000000018181DFE0
		private static void PopulateUnityProviders(); // 0x000000018181E6D0-0x000000018181E800
		private static void PopulateProviders(); // 0x000000018181E510-0x000000018181E6D0
		internal static bool IsBtlsSupported(); // 0x0000000181449F80-0x0000000181449F90
		private static MobileTlsProvider CreateDefaultProviderImpl(); // 0x000000018181D400-0x000000018181D650
		internal static MobileTlsProvider GetProvider(); // 0x000000018181D760-0x000000018181D7A0
	}
}
