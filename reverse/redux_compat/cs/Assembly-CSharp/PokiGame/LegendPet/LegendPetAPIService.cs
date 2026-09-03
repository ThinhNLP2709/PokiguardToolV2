/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokiGame.LegendPet
{
	public class LegendPetAPIService : MonoBehaviour // TypeDefIndex: 1983
	{
		// Fields
		private static LegendPetAPIService instance; // 0x00
	
		// Properties
		public static LegendPetAPIService Instance { get; } // 0x0000000180658920-0x0000000180658A30 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 1984
		{
			// Fields
			public Action<LegendPetData> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _GetLegendPetInfo_b__0(LegendPetData response); // 0x00000001806709B0-0x00000001806709D0
			internal void _GetLegendPetInfo_b__1(string error); // 0x00000001806709D0-0x0000000180670A70
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 1985
		{
			// Fields
			public Action<InlayStarResponse> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _InlayStar_b__0(InlayStarResponse response); // 0x00000001806709B0-0x00000001806709D0
			internal void _InlayStar_b__1(string error); // 0x0000000180670A70-0x0000000180670B10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 1986
		{
			// Fields
			public Action<UnlockPetResponse> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _UnlockLegendPet_b__0(UnlockPetResponse response); // 0x00000001806709B0-0x00000001806709D0
			internal void _UnlockLegendPet_b__1(string error); // 0x0000000180670B10-0x0000000180670BB0
		}
	
		[CompilerGenerated]
		private sealed class _GetAllLegendPetsWithRawResponse_d__6 : IEnumerator<object> // TypeDefIndex: 1987
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string url; // 0x20
			public Action<string> onError; // 0x28
			public Action<LegendPetListResponse> onSuccess; // 0x30
			private UnityWebRequest _request_5__2; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetAllLegendPetsWithRawResponse_d__6(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018066C9B0-0x000000018066CA90
			private bool MoveNext(); // 0x000000018066C4A0-0x000000018066C970
			private void __m__Finally1(); // 0x000000018066CA90-0x000000018066CAE0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066C970-0x000000018066C9B0
		}
	
		[CompilerGenerated]
		private sealed class _GetUserPetInfoWithRawResponse_d__11 : IEnumerator<object> // TypeDefIndex: 1988
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string url; // 0x20
			public Action<string> onError; // 0x28
			public Action<PetUserDTO> onSuccess; // 0x30
			private UnityWebRequest _request_5__2; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetUserPetInfoWithRawResponse_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018066D000-0x000000018066D0E0
			private bool MoveNext(); // 0x000000018066CAE0-0x000000018066CFC0
			private void __m__Finally1(); // 0x000000018066D0E0-0x000000018066D130
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066CFC0-0x000000018066D000
		}
	
		// Constructors
		public LegendPetAPIService(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private static string GetAuthToken(); // 0x0000000180657F30-0x0000000180657F80
		private static void AttachAuth(UnityWebRequest request); // 0x0000000180657AF0-0x0000000180657BC0
		public void GetAllLegendPets(Action<LegendPetListResponse> onSuccess, Action<string> onError); // 0x0000000180657C70-0x0000000180657F30
		[IteratorStateMachine(typeof(_GetAllLegendPetsWithRawResponse_d__6))]
		private IEnumerator GetAllLegendPetsWithRawResponse(string url, Action<LegendPetListResponse> onSuccess, Action<string> onError); // 0x0000000180657BC0-0x0000000180657C70
		public void GetLegendPetInfo(long userId, long petId, Action<LegendPetData> onSuccess, Action<string> onError); // 0x0000000180657F80-0x00000001806581E0
		public void InlayStar(InlayStarRequest requestData, Action<InlayStarResponse> onSuccess, Action<string> onError); // 0x0000000180658440-0x0000000180658690
		public void UnlockLegendPet(long userId, long petId, Action<UnlockPetResponse> onSuccess, Action<string> onError); // 0x0000000180658690-0x0000000180658920
		public void GetUserPetInfo(int userId, int petId, Action<PetUserDTO> onSuccess, Action<string> onError); // 0x0000000180658290-0x0000000180658440
		[IteratorStateMachine(typeof(_GetUserPetInfoWithRawResponse_d__11))]
		private IEnumerator GetUserPetInfoWithRawResponse(string url, Action<PetUserDTO> onSuccess, Action<string> onError); // 0x00000001806581E0-0x0000000180658290
	}
}
