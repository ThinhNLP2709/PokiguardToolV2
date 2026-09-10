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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokiGame.LegendPet
{
	public class LegendPetAPIService : MonoBehaviour // TypeDefIndex: 2150
	{
		// Fields
		private static LegendPetAPIService instance; // 0x00
	
		// Properties
		public static LegendPetAPIService Instance { get; } // 0x0000000180751180-0x0000000180751290 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 2151
		{
			// Fields
			public Action<LegendPetData> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _GetLegendPetInfo_b__0(LegendPetData response); // 0x00000001807672C0-0x00000001807672E0
			internal void _GetLegendPetInfo_b__1(string error); // 0x00000001807672E0-0x0000000180767380
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 2152
		{
			// Fields
			public Action<InlayStarResponse> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _InlayStar_b__0(InlayStarResponse response); // 0x00000001807672C0-0x00000001807672E0
			internal void _InlayStar_b__1(string error); // 0x0000000180767380-0x0000000180767420
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 2153
		{
			// Fields
			public Action<UnlockPetResponse> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass9_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _UnlockLegendPet_b__0(UnlockPetResponse response); // 0x00000001807672C0-0x00000001807672E0
			internal void _UnlockLegendPet_b__1(string error); // 0x0000000180767420-0x00000001807674C0
		}
	
		[CompilerGenerated]
		private sealed class _GetAllLegendPetsWithRawResponse_d__6 : IEnumerator<object> // TypeDefIndex: 2154
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string url; // 0x20
			public Action<string> onError; // 0x28
			public Action<LegendPetListResponse> onSuccess; // 0x30
			private UnityWebRequest _request_5__2; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _GetAllLegendPetsWithRawResponse_d__6(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001807651C0-0x00000001807652A0
			private bool MoveNext(); // 0x0000000180764CB0-0x0000000180765180
			private void __m__Finally1(); // 0x00000001807652A0-0x00000001807652F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180765180-0x00000001807651C0
		}
	
		[CompilerGenerated]
		private sealed class _GetUserPetInfoWithRawResponse_d__11 : IEnumerator<object> // TypeDefIndex: 2155
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string url; // 0x20
			public Action<string> onError; // 0x28
			public Action<PetUserDTO> onSuccess; // 0x30
			private UnityWebRequest _request_5__2; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _GetUserPetInfoWithRawResponse_d__11(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180765810-0x00000001807658F0
			private bool MoveNext(); // 0x00000001807652F0-0x00000001807657D0
			private void __m__Finally1(); // 0x00000001807658F0-0x0000000180765940
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807657D0-0x0000000180765810
		}
	
		// Constructors
		public LegendPetAPIService(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private static string GetAuthToken(); // 0x0000000180750790-0x00000001807507E0
		private static void AttachAuth(UnityWebRequest request); // 0x0000000180750350-0x0000000180750420
		public void GetAllLegendPets(Action<LegendPetListResponse> onSuccess, Action<string> onError); // 0x00000001807504D0-0x0000000180750790
		[IteratorStateMachine(typeof(_GetAllLegendPetsWithRawResponse_d__6))]
		private IEnumerator GetAllLegendPetsWithRawResponse(string url, Action<LegendPetListResponse> onSuccess, Action<string> onError); // 0x0000000180750420-0x00000001807504D0
		public void GetLegendPetInfo(long userId, long petId, Action<LegendPetData> onSuccess, Action<string> onError); // 0x00000001807507E0-0x0000000180750A40
		public void InlayStar(InlayStarRequest requestData, Action<InlayStarResponse> onSuccess, Action<string> onError); // 0x0000000180750CA0-0x0000000180750EF0
		public void UnlockLegendPet(long userId, long petId, Action<UnlockPetResponse> onSuccess, Action<string> onError); // 0x0000000180750EF0-0x0000000180751180
		public void GetUserPetInfo(int userId, int petId, Action<PetUserDTO> onSuccess, Action<string> onError); // 0x0000000180750AF0-0x0000000180750CA0
		[IteratorStateMachine(typeof(_GetUserPetInfoWithRawResponse_d__11))]
		private IEnumerator GetUserPetInfoWithRawResponse(string url, Action<PetUserDTO> onSuccess, Action<string> onError); // 0x0000000180750A40-0x0000000180750AF0
	}
}
