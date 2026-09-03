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

namespace Mono.Security.X509
{
	[Serializable]
	[Flags]
	public enum X509ChainStatusFlags // TypeDefIndex: 13826
	{
		NoError = 0,
		NotTimeValid = 1,
		NotTimeNested = 2,
		NotSignatureValid = 8,
		UntrustedRoot = 32,
		InvalidBasicConstraints = 1024,
		PartialChain = 65536
	}
}
