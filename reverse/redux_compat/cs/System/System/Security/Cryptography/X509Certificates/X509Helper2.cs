/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Security.X509;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	internal static class X509Helper2 // TypeDefIndex: 8797
	{
		// Methods
		[MonoTODO("Investigate replacement; see comments in source.")]
		internal static X509Certificate GetMonoCertificate(X509Certificate2 certificate); // 0x0000000181BA0F90-0x0000000181BA10B0
		internal static X509ChainImpl CreateChainImpl(bool useMachineContext); // 0x0000000181BA0EC0-0x0000000181BA0F20
		public static bool IsValid(X509ChainImpl impl); // 0x00000001814CE2F0-0x00000001814CE310
		internal static void ThrowIfContextInvalid(X509ChainImpl impl); // 0x0000000181BA10B0-0x0000000181BA1100
		internal static Exception GetInvalidChainContextException(); // 0x0000000181BA0F20-0x0000000181BA0F90
	}
}
