/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.AssemblyManagement
{
	[NullableContext(1)]
	internal interface ICurrentAssemblyLoadContext // TypeDefIndex: 14898
	{
		// Fields
		[CompilerGenerated]
		[Nullable(2)]
		private static ICurrentAssemblyLoadContext _Instance_k__BackingField; // 0x00
	
		// Properties
		[Nullable(2)]
		ICurrentAssemblyLoadContext Instance { [NullableContext(2)] [CompilerGenerated] get; [NullableContext(2)] [CompilerGenerated] internal set; } // 0x0000000182064BD0-0x0000000182064C10 0x0000000182064C10-0x0000000182064C70
	
		// Methods
		IReadOnlyList<Assembly> GetLoadedAssemblies();
		Assembly LoadFromPath(string assemblyPath);
		Assembly LoadFromStream(Stream assemblyStream, [Nullable(2)] Stream symbolsStream);
		bool IsAssemblyInUserCodeALC(Assembly assembly);
	}
}
