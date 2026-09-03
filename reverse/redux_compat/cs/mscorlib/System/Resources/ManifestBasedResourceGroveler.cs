/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Resources
{
	internal class ManifestBasedResourceGroveler : IResourceGroveler // TypeDefIndex: 3261
	{
		// Fields
		private ResourceManager.ResourceManagerMediator _mediator; // 0x10
	
		// Constructors
		public ManifestBasedResourceGroveler(ResourceManager.ResourceManagerMediator mediator); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal static CultureInfo GetNeutralResourcesLanguage(Assembly a, ref UltimateResourceFallbackLocation fallbackLocation); // 0x000000018150DA70-0x000000018150DD40
		private static bool GetNeutralResourcesLanguageAttribute(Assembly assembly, ref string cultureName, ref short fallbackLocation); // 0x000000018150D9E0-0x000000018150DA70
	}
}
