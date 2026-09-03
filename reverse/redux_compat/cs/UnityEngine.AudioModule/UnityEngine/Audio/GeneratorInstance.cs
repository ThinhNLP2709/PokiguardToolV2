/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine.Audio
{
	public struct GeneratorInstance : IEquatable<GeneratorInstance> // TypeDefIndex: 14929
	{
		// Fields
		internal readonly ProcessorInstance m_ProcessorInstance; // 0x00
	
		// Nested types
		public interface ICapabilities // TypeDefIndex: 14930
		{
			// Properties
			bool isFinite { get; }
			bool isRealtime { get; }
			DiscreteTime? length { get; }
		}
	
		[IsReadOnly]
		public struct Setup // TypeDefIndex: 14931
		{
			// Fields
			public readonly AudioSpeakerMode speakerMode; // 0x00
			public readonly int sampleRate; // 0x04
		}
	
		public struct Properties // TypeDefIndex: 14932
		{
			// Fields
			private byte m_Reserved; // 0x00
		}
	
		public struct Configuration // TypeDefIndex: 14933
		{
			// Fields
			internal Setup Setup; // 0x00
			internal Properties Properties; // 0x08
			internal DiscreteTime ReportedLength; // 0x10
			internal bool IsFinite; // 0x18
			internal bool IsRealtime; // 0x19
			internal bool HasKnownLength; // 0x1A
	
			// Properties
			public bool isRealtime { get; } // 0x0000000181780E10-0x0000000181780E20 
			public DiscreteTime? length { get; } // 0x000000018216CA60-0x000000018216CAB0 
	
			// Methods
			internal static long FramesAndSampleRateToDiscreteTimeTicks(long lengthFrames, uint sampleRate); // 0x000000018216C9B0-0x000000018216CA60
		}
	
		[NativeHeader("Modules/Audio/Public/ScriptableProcessors/ScriptBindings/GeneratorHandle.h")]
		[RequiredByNativeCode]
		internal struct GeneratorHeader // TypeDefIndex: 14934
		{
			// Fields
			internal ProcessorHeader Processor; // 0x00
			private unsafe void* m_Channel; // 0x30
			private unsafe void* m_DSP; // 0x38
			internal Configuration Configuration; // 0x40
		}
	
		// Constructors
		internal unsafe GeneratorInstance(GeneratorHeader* header); // 0x000000018216CDC0-0x000000018216CDF0
	
		// Methods
		public static implicit operator ProcessorInstance([IsReadOnly] in GeneratorInstance generatorInstance); // 0x000000018092E600-0x000000018092E610
		public bool Equals(GeneratorInstance other); // 0x000000018216CD10-0x000000018216CD30
		public override bool Equals(object obj); // 0x000000018216CD30-0x000000018216CDC0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
	}
}
