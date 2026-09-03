/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = true)]
	[Conditional("UNITY_EDITOR")]
	public class PipelineHelpURLAttribute : HelpURLAttribute // TypeDefIndex: 5534
	{
		// Fields
		[CompilerGenerated]
		private readonly string _pipelineName_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly string _pageName_k__BackingField; // 0x30
		[CompilerGenerated]
		private readonly string _pageHash_k__BackingField; // 0x38
	
		// Properties
		private string pipelineName { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		private string pageName { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
		private string pageHash { [CompilerGenerated] get; } // 0x00000001803272A0-0x00000001803272B0 
		public override string URL { get; } // 0x00000001815B1550-0x00000001815B1570 
	
		// Constructors
		public PipelineHelpURLAttribute(string pipelineName, string pageName, string pageHash = "" /* Metadata: 0x006615E6 */); // 0x0000000181E54010-0x0000000181E54080
	}
}
