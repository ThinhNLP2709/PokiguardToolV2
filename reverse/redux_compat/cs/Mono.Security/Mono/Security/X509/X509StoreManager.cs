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
	public sealed class X509StoreManager // TypeDefIndex: 13830
	{
		// Fields
		private static string _userPath; // 0x00
		private static string _localMachinePath; // 0x08
		private static string _newUserPath; // 0x10
		private static string _newLocalMachinePath; // 0x18
		private static X509Stores _userStore; // 0x20
		private static X509Stores _machineStore; // 0x28
	
		// Properties
		internal static string CurrentUserPath { get; } // 0x0000000181417790-0x00000001814178B0 
		internal static string LocalMachinePath { get; } // 0x0000000181417A90-0x0000000181417BC0 
		internal static string NewCurrentUserPath { get; } // 0x0000000181417DB0-0x0000000181417EE0 
		internal static string NewLocalMachinePath { get; } // 0x0000000181417EE0-0x0000000181418010 
		public static X509Stores CurrentUser { get; } // 0x00000001814178B0-0x0000000181417A90 
		public static X509Stores LocalMachine { get; } // 0x0000000181417BC0-0x0000000181417DB0 
		public static X509CertificateCollection TrustedRootCertificates { get; } // 0x0000000181418010-0x0000000181418490 
	}
}
