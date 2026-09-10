/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class Api : MonoBehaviour // TypeDefIndex: 1815
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
	private sealed class _GetRequest_d__6 : IEnumerator<object> // TypeDefIndex: 1816
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int idUser; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _GetRequest_d__6(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E0B30-0x00000001806E0BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E0BC0-0x00000001806E0C00
	}

	[CompilerGenerated]
	private sealed class _PostRequest_d__7 : IEnumerator<object> // TypeDefIndex: 1817
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PostRequest_d__7(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E26B0-0x00000001806E2720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E2720-0x00000001806E2760
	}

	[CompilerGenerated]
	private sealed class _StartMatch_d__9 : IEnumerator<object> // TypeDefIndex: 1818
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _StartMatch_d__9(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E59D0-0x00000001806E5A40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E5A40-0x00000001806E5A80
	}

	[CompilerGenerated]
	private sealed class _UpdateEnergyAPI_d__8 : IEnumerator<object> // TypeDefIndex: 1819
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpdateEnergyAPI_d__8(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E6920-0x00000001806E6990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E6990-0x00000001806E69D0
	}

	// Constructors
	public Api(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	[IteratorStateMachine(typeof(_GetRequest_d__6))]
	public IEnumerator GetRequest(int idUser); // 0x00000001806D5220-0x00000001806D5280
	[IteratorStateMachine(typeof(_PostRequest_d__7))]
	public IEnumerator PostRequest(string codeV, int idGroupPetV, int idPetV, int idUserV); // 0x00000001806D52E0-0x00000001806D5330
	[IteratorStateMachine(typeof(_UpdateEnergyAPI_d__8))]
	public IEnumerator UpdateEnergyAPI(int idUser, int type); // 0x00000001806D5380-0x00000001806D53D0
	[IteratorStateMachine(typeof(_StartMatch_d__9))]
	public IEnumerator StartMatch(int idUser, int idPetUser, int idEnemyPet, string listCardUserId); // 0x00000001806D5330-0x00000001806D5380
	public void HandleApiResponse(string jsonResponse); // 0x00000001806D5280-0x00000001806D52E0
}

