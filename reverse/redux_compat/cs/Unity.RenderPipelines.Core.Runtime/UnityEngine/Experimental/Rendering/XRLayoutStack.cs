/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	internal class XRLayoutStack : IDisposable // TypeDefIndex: 5311
	{
		// Fields
		private readonly Stack<XRLayout> m_Stack; // 0x10
	
		// Properties
		public bool hasLayout { get; } // 0x0000000180BDBE60-0x0000000180BDBE80 
		public XRLayout top { get; } // 0x0000000181E2AF40-0x0000000181E2AF90 
	
		// Constructors
		public XRLayoutStack(); // 0x0000000181E2AEC0-0x0000000181E2AF40
	
		// Methods
		public XRLayout New(); // 0x0000000181E2AC20-0x0000000181E2ACC0
		public void Release(); // 0x0000000181E2ACC0-0x0000000181E2AEC0
		public void Dispose(); // 0x0000000181E2ABB0-0x0000000181E2AC20
	}
}
