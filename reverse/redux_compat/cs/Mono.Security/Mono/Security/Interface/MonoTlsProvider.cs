/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Interface
{
	public abstract class MonoTlsProvider // TypeDefIndex: 13871
	{
		// Properties
		public abstract Guid ID { get; }
		public abstract string Name { get; }
		public abstract bool SupportsSslStream { get; }
		public abstract bool SupportsConnectionInfo { get; }
		public abstract bool SupportsMonoExtensions { get; }
		public abstract SslProtocols SupportedProtocols { get; }
		internal abstract bool SupportsCleanShutdown { get; }
	
		// Constructors
		internal MonoTlsProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
