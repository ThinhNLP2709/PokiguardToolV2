/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Audio;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine.Audio
{
	[NativeHeader("Modules/Audio/Public/ScriptableProcessors/ScriptBindings/ScriptableProcessor.bindings.h")]
	[RequiredByNativeCode]
	public struct ControlContext // TypeDefIndex: 14927
	{
		// Fields
		private unsafe ControlHeader* m_Header; // 0x00
		internal Handle m_Handle; // 0x08
	
		// Properties
		internal unsafe ControlHeader* Header { [IsReadOnly] get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		internal unsafe ControlContext(void* headerThatShouldBeOfResourceType); // 0x000000018216CBF0-0x000000018216CC30
	
		// Methods
		[IsReadOnly]
		public bool Exists(ProcessorInstance processorInstance); // 0x000000018216CAF0-0x000000018216CB50
		public GeneratorInstance.Configuration GetConfiguration(GeneratorInstance generatorInstance); // 0x000000018216CB50-0x000000018216CBF0
		[RequiredByNativeCode(GenerateProxy = true)]
		internal static void CleanupHeader(ref ControlHeader header); // 0x000000018216CAB0-0x000000018216CAF0
	}
}
