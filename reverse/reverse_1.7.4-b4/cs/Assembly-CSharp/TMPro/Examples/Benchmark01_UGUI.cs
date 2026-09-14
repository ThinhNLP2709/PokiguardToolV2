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
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace TMPro.Examples
{
	public class Benchmark01_UGUI : MonoBehaviour // TypeDefIndex: 2472
	{
		// Fields
		public int BenchmarkType; // 0x20
		public Canvas canvas; // 0x28
		public TMP_FontAsset TMProFont; // 0x30
		public Font TextMeshFont; // 0x38
		private TextMeshProUGUI m_textMeshPro; // 0x40
		private UnityEngine.UI.Text m_textMesh; // 0x48
		private const string label01 = "The <#0050FF>count is: </color>"; // Metadata: 0x005F2208
		private const string label02 = "The <color=#0050FF>count is: </color>"; // Metadata: 0x005F2228
		private Material m_material01; // 0x50
		private Material m_material02; // 0x58
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Start_d__10 : IEnumerator<object> // TypeDefIndex: 2473
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Benchmark01_UGUI __4__this; // 0x20
			private int _i_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Start_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180B8DFB0-0x0000000180B8E7A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B8E7A0-0x0000000180B8E7E0
		}
	
		// Constructors
		public Benchmark01_UGUI(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		[IteratorStateMachine(typeof(_Start_d__10))]
		private IEnumerator Start(); // 0x0000000180B8DF10-0x0000000180B8DFB0
	}
}
