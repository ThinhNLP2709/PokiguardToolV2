/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro.Examples
{
	public class Benchmark01 : MonoBehaviour // TypeDefIndex: 2463
	{
		// Fields
		public int BenchmarkType; // 0x20
		public TMP_FontAsset TMProFont; // 0x28
		public Font TextMeshFont; // 0x30
		private TextMeshPro m_textMeshPro; // 0x38
		private TextContainer m_textContainer; // 0x40
		private TextMesh m_textMesh; // 0x48
		private const string label01 = "The <#0050FF>count is: </color>{0}"; // Metadata: 0x005F0DA8
		private const string label02 = "The <color=#0050FF>count is: </color>"; // Metadata: 0x005F0DCB
		private Material m_material01; // 0x50
		private Material m_material02; // 0x58
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Start_d__10 : IEnumerator<object> // TypeDefIndex: 2464
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Benchmark01 __4__this; // 0x20
			private int _i_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Start_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180B7FFD0-0x0000000180B80AB0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B80AB0-0x0000000180B80AF0
		}
	
		// Constructors
		public Benchmark01(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		[IteratorStateMachine(typeof(_Start_d__10))]
		private IEnumerator Start(); // 0x0000000180B7FF30-0x0000000180B7FFD0
	}
}
