/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono
{
	internal class SystemDependencyProvider : ISystemDependencyProvider // TypeDefIndex: 8476
	{
		// Fields
		private static SystemDependencyProvider instance; // 0x00
		private static object syncRoot; // 0x08
		[CompilerGenerated]
		private readonly SystemCertificateProvider _CertificateProvider_k__BackingField; // 0x10
	
		// Properties
		public static SystemDependencyProvider Instance { get; } // 0x0000000181820550-0x00000001818205B0 
		ISystemCertificateProvider ISystemDependencyProvider.CertificateProvider { get; } // 0x0000000180377550-0x0000000180377560 
		public SystemCertificateProvider CertificateProvider { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public X509PalImpl X509Pal { get; } // 0x00000001818205B0-0x0000000181820610 
	
		// Constructors
		private SystemDependencyProvider(); // 0x00000001818204B0-0x0000000181820550
		static SystemDependencyProvider(); // 0x0000000181820440-0x00000001818204B0
	
		// Methods
		internal static void Initialize(); // 0x0000000181820280-0x0000000181820440
	}
}
