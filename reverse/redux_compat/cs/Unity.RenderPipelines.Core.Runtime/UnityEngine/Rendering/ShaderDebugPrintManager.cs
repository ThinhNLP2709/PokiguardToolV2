/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public sealed class ShaderDebugPrintManager // TypeDefIndex: 5517
	{
		// Fields
		private static readonly ShaderDebugPrintManager s_Instance; // 0x00
		private const int k_FramesInFlight = 4; // Metadata: 0x00661591
		private const int k_MaxBufferElements = 16384; // Metadata: 0x00661592
		private List<GraphicsBuffer> m_OutputBuffers; // 0x10
		private List<AsyncGPUReadbackRequest> m_ReadbackRequests; // 0x18
		private Action<AsyncGPUReadbackRequest> m_BufferReadCompleteAction; // 0x20
		private int m_FrameCounter; // 0x28
		private bool m_FrameCleared; // 0x2C
		private string m_OutputLine; // 0x30
		private Action<string> m_OutputAction; // 0x38
		private static readonly int m_ShaderPropertyIDInputMouse; // 0x08
		private static readonly int m_ShaderPropertyIDInputFrame; // 0x0C
		private static readonly int m_shaderDebugOutputData; // 0x10
		private const uint k_TypeHasTag = 128; // Metadata: 0x00661596
	
		// Properties
		public static ShaderDebugPrintManager instance { get; } // 0x0000000181E71190-0x0000000181E711E0 
		public string outputLine { get; } // 0x000000018031E110-0x000000018031E120 
		public Action<string> outputAction { set; } // 0x000000018033E850-0x000000018033E860
	
		// Nested types
		private static class Profiling // TypeDefIndex: 5518
		{
			// Fields
			public static readonly ProfilingSampler BufferReadComplete; // 0x00
	
			// Constructors
			static Profiling(); // 0x0000000181E6F540-0x0000000181E6F5E0
		}
	
		private enum DebugValueType // TypeDefIndex: 5519
		{
			TypeUint = 1,
			TypeInt = 2,
			TypeFloat = 3,
			TypeUint2 = 4,
			TypeInt2 = 5,
			TypeFloat2 = 6,
			TypeUint3 = 7,
			TypeInt3 = 8,
			TypeFloat3 = 9,
			TypeUint4 = 10,
			TypeInt4 = 11,
			TypeFloat4 = 12,
			TypeBool = 13
		}
	
		// Constructors
		private ShaderDebugPrintManager(); // 0x0000000181E70EA0-0x0000000181E71190
		static ShaderDebugPrintManager(); // 0x0000000181E70DB0-0x0000000181E70EA0
	
		// Methods
		private int DebugValueTypeToElemSize(DebugValueType type); // 0x0000000181E708A0-0x0000000181E70910
		public void SetShaderDebugPrintInputConstants(CommandBuffer cmd, ShaderDebugPrintInput input); // 0x0000000181E70C80-0x0000000181E70DB0
		public void SetShaderDebugPrintBindings(CommandBuffer cmd); // 0x0000000181E70A90-0x0000000181E70C80
		private void ClearShaderDebugPrintBuffer(); // 0x0000000181E707C0-0x0000000181E708A0
		private void BufferReadComplete(AsyncGPUReadbackRequest request); // 0x0000000181E6F9F0-0x0000000181E707C0
		public void EndFrame(); // 0x0000000181E70960-0x0000000181E709F0
		public void PrintImmediate(); // 0x0000000181E709F0-0x0000000181E70A90
		public void DefaultOutput(string line); // 0x0000000181E70910-0x0000000181E70960
	}
}
