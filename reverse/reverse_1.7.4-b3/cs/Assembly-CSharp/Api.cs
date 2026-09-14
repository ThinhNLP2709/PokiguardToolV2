/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class Api : MonoBehaviour // TypeDefIndex: 2191
{
	// Fields
	public string keyRandom; // 0x20
	public int idGroupPetEnemy; // 0x28
	public int idPetEnemy; // 0x2C
	public bool typeAward; // 0x30
	public ResponseDataPet responseDataPet; // 0x38
	public List<ResponseDataAward> responseDataAward; // 0x40

	// Nested types
	[CompilerGenerated]
	private sealed class _GetRequest_d__6 : IEnumerator<object> // TypeDefIndex: 2192
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int idUser; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _GetRequest_d__6(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A86720-0x0000000180A867C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A867C0-0x0000000180A86800
	}

	[CompilerGenerated]
	private sealed class _PostRequest_d__7 : IEnumerator<object> // TypeDefIndex: 2193
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PostRequest_d__7(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A86800-0x0000000180A86880
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A86880-0x0000000180A868C0
	}

	[CompilerGenerated]
	private sealed class _StartMatch_d__9 : IEnumerator<object> // TypeDefIndex: 2194
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _StartMatch_d__9(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A868C0-0x0000000180A86940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A86940-0x0000000180A86980
	}

	[CompilerGenerated]
	private sealed class _UpdateEnergyAPI_d__8 : IEnumerator<object> // TypeDefIndex: 2195
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpdateEnergyAPI_d__8(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A86980-0x0000000180A86A00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A86A00-0x0000000180A86A40
	}

	// Constructors
	public Api(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[IteratorStateMachine(typeof(_GetRequest_d__6))]
	public IEnumerator GetRequest(int idUser); // 0x0000000180A865A0-0x0000000180A865F0
	[IteratorStateMachine(typeof(_PostRequest_d__7))]
	public IEnumerator PostRequest(string codeV, int idGroupPetV, int idPetV, int idUserV); // 0x0000000180A865F0-0x0000000180A86630
	[IteratorStateMachine(typeof(_UpdateEnergyAPI_d__8))]
	public IEnumerator UpdateEnergyAPI(int idUser, int type); // 0x0000000180A86630-0x0000000180A86670
	[IteratorStateMachine(typeof(_StartMatch_d__9))]
	public IEnumerator StartMatch(int idUser, int idPetUser, int idEnemyPet, string listCardUserId); // 0x0000000180A86670-0x0000000180A866B0
	public void HandleApiResponse(string jsonResponse); // 0x0000000180A866B0-0x0000000180A86720
}

