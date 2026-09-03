/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance.Provider
{
	public sealed class AdaptivePerformanceSubsystemDescriptor : SubsystemDescriptorWithProvider<UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystem, UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystem.APProvider> // TypeDefIndex: 14220
	{
		// Nested types
		public struct Cinfo // TypeDefIndex: 14221
		{
			// Fields
			[CompilerGenerated]
			private string _id_k__BackingField; // 0x00
			[CompilerGenerated]
			private Type _providerType_k__BackingField; // 0x08
			[CompilerGenerated]
			private Type _subsystemTypeOverride_k__BackingField; // 0x10
			[CompilerGenerated]
			private Type _subsystemImplementationType_k__BackingField; // 0x18
	
			// Properties
			public string id { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
			public Type providerType { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
			public Type subsystemTypeOverride { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		}
	
		// Constructors
		public AdaptivePerformanceSubsystemDescriptor(Cinfo cinfo); // 0x000000018213E920-0x000000018213E980
	
		// Methods
		public static AdaptivePerformanceSubsystemDescriptor RegisterDescriptor(Cinfo cinfo); // 0x000000018213E6E0-0x000000018213E920
	}
}
