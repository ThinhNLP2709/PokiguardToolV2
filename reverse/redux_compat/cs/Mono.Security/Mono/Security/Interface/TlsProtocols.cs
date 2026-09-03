/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Interface
{
	[Flags]
	public enum TlsProtocols // TypeDefIndex: 13876
	{
		Zero = 0,
		Tls10Server = 64,
		Tls10Client = 128,
		Tls10 = 192,
		Tls11Server = 256,
		Tls11Client = 512,
		Tls11 = 768,
		Tls12Server = 1024,
		Tls12Client = 2048,
		Tls12 = 3072,
		Tls13Server = 4096,
		ServerMask = 5440,
		Tls13Client = 8192,
		ClientMask = 10880,
		Tls13 = 12288
	}
}
