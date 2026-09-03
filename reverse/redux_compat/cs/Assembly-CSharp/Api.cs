/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class Api : MonoBehaviour // TypeDefIndex: 1551
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
	private sealed class _GetRequest_d__6 : IEnumerator<object> // TypeDefIndex: 1552
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int idUser; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _GetRequest_d__6(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A5470-0x00000001805A5500
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A5500-0x00000001805A5540
	}

	[CompilerGenerated]
	private sealed class _PostRequest_d__7 : IEnumerator<object> // TypeDefIndex: 1553
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PostRequest_d__7(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A83B0-0x00000001805A8420
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A8420-0x00000001805A8460
	}

	[CompilerGenerated]
	private sealed class _StartMatch_d__9 : IEnumerator<object> // TypeDefIndex: 1554
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _StartMatch_d__9(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805ABBF0-0x00000001805ABC60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805ABC60-0x00000001805ABCA0
	}

	[CompilerGenerated]
	private sealed class _UpdateEnergyAPI_d__8 : IEnumerator<object> // TypeDefIndex: 1555
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpdateEnergyAPI_d__8(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805AC250-0x00000001805AC2C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805AC2C0-0x00000001805AC300
	}

	// Constructors
	public Api(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	[IteratorStateMachine(typeof(_GetRequest_d__6))]
	public IEnumerator GetRequest(int idUser); // 0x000000018059B8D0-0x000000018059B930
	[IteratorStateMachine(typeof(_PostRequest_d__7))]
	public IEnumerator PostRequest(string codeV, int idGroupPetV, int idPetV, int idUserV); // 0x000000018059B990-0x000000018059B9E0
	[IteratorStateMachine(typeof(_UpdateEnergyAPI_d__8))]
	public IEnumerator UpdateEnergyAPI(int idUser, int type); // 0x000000018059BA30-0x000000018059BA80
	[IteratorStateMachine(typeof(_StartMatch_d__9))]
	public IEnumerator StartMatch(int idUser, int idPetUser, int idEnemyPet, string listCardUserId); // 0x000000018059B9E0-0x000000018059BA30
	public void HandleApiResponse(string jsonResponse); // 0x000000018059B930-0x000000018059B990
}

