/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono
{
	internal static class DependencyInjector // TypeDefIndex: 2070
	{
		// Fields
		private static object locker; // 0x00
		private static ISystemDependencyProvider systemDependency; // 0x08
	
		// Properties
		internal static ISystemDependencyProvider SystemProvider { get; } // 0x000000018142E610-0x000000018142E910 
	
		// Constructors
		static DependencyInjector(); // 0x000000018142E5A0-0x000000018142E610
	
		// Methods
		internal static void Register(ISystemDependencyProvider provider); // 0x000000018142E440-0x000000018142E5A0
		private static ISystemDependencyProvider ReflectionLoad(); // 0x000000018142E320-0x000000018142E440
	}
}
