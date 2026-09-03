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
	public sealed class TlsException : Exception // TypeDefIndex: 13874
	{
		// Fields
		private Alert alert; // 0x90
	
		// Constructors
		public TlsException(Alert alert); // 0x000000018142A120-0x000000018142A1E0
		public TlsException(Alert alert, string message); // 0x0000000181429F20-0x0000000181429F80
		public TlsException(AlertDescription description); // 0x000000018142A030-0x000000018142A120
		public TlsException(AlertDescription description, string message); // 0x0000000181429F80-0x000000018142A030
	}
}
