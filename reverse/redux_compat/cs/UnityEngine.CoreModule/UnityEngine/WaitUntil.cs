/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	public sealed class WaitUntil : CustomYieldInstruction // TypeDefIndex: 7796
	{
		// Fields
		private readonly Func<bool> m_Predicate; // 0x10
		private readonly Action m_TimeoutCallback; // 0x18
		private readonly WaitTimeoutMode m_TimeoutMode; // 0x20
		private readonly double m_MaxExecutionTime; // 0x28
	
		// Properties
		public override bool keepWaiting { get; } // 0x00000001822292E0-0x00000001822293A0 
	
		// Constructors
		public WaitUntil(Func<bool> predicate); // 0x00000001822292A0-0x00000001822292E0
	
		// Methods
		private double GetTime(); // 0x0000000182229240-0x00000001822292A0
	}
}
