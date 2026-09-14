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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokiGame.LegendPet
{
	public class LegendPetAPIService : MonoBehaviour // TypeDefIndex: 2574
	{
		// Fields
		private static LegendPetAPIService instance; // 0x00
	
		// Properties
		public static LegendPetAPIService Instance { get; } // 0x0000000180BE0600-0x0000000180BE07F0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 2575
		{
			// Fields
			public Action<LegendPetData> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _GetLegendPetInfo_b__0(LegendPetData response); // 0x0000000180BE1F30-0x0000000180BE1F50
			internal void _GetLegendPetInfo_b__1(string error); // 0x0000000180BE1F50-0x0000000180BE2000
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 2576
		{
			// Fields
			public Action<InlayStarResponse> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _InlayStar_b__0(InlayStarResponse response); // 0x0000000180BE1F30-0x0000000180BE1F50
			internal void _InlayStar_b__1(string error); // 0x0000000180BE2000-0x0000000180BE20B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 2577
		{
			// Fields
			public Action<UnlockPetResponse> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass9_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _UnlockLegendPet_b__0(UnlockPetResponse response); // 0x0000000180BE1F30-0x0000000180BE1F50
			internal void _UnlockLegendPet_b__1(string error); // 0x0000000180BE20B0-0x0000000180BE2160
		}
	
		[CompilerGenerated]
		private sealed class _GetAllLegendPetsWithRawResponse_d__6 : IEnumerator<object> // TypeDefIndex: 2578
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string url; // 0x20
			public Action<string> onError; // 0x28
			public Action<LegendPetListResponse> onSuccess; // 0x30
			private UnityWebRequest _request_5__2; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _GetAllLegendPetsWithRawResponse_d__6(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180BE2160-0x0000000180BE2290
			private bool MoveNext(); // 0x0000000180BE2290-0x0000000180BE28E0
			private void __m__Finally1(); // 0x0000000180BE28E0-0x0000000180BE2940
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BE2940-0x0000000180BE2980
		}
	
		[CompilerGenerated]
		private sealed class _GetUserPetInfoWithRawResponse_d__11 : IEnumerator<object> // TypeDefIndex: 2579
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string url; // 0x20
			public Action<string> onError; // 0x28
			public Action<PetUserDTO> onSuccess; // 0x30
			private UnityWebRequest _request_5__2; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _GetUserPetInfoWithRawResponse_d__11(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180BE2980-0x0000000180BE2AB0
			private bool MoveNext(); // 0x0000000180BE2AB0-0x0000000180BE3120
			private void __m__Finally1(); // 0x0000000180BE3120-0x0000000180BE3180
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BE3180-0x0000000180BE31C0
		}
	
		// Constructors
		public LegendPetAPIService(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private static string GetAuthToken(); // 0x0000000180BE07F0-0x0000000180BE0850
		private static void AttachAuth(UnityWebRequest request); // 0x0000000180BE0850-0x0000000180BE0930
		public void GetAllLegendPets(Action<LegendPetListResponse> onSuccess, Action<string> onError); // 0x0000000180BE0930-0x0000000180BE0D90
		[IteratorStateMachine(typeof(_GetAllLegendPetsWithRawResponse_d__6))]
		private IEnumerator GetAllLegendPetsWithRawResponse(string url, Action<LegendPetListResponse> onSuccess, Action<string> onError); // 0x0000000180BE0D90-0x0000000180BE0EF0
		public void GetLegendPetInfo(long userId, long petId, Action<LegendPetData> onSuccess, Action<string> onError); // 0x0000000180BE0EF0-0x0000000180BE1330
		public void InlayStar(InlayStarRequest requestData, Action<InlayStarResponse> onSuccess, Action<string> onError); // 0x0000000180BE1330-0x0000000180BE16D0
		public void UnlockLegendPet(long userId, long petId, Action<UnlockPetResponse> onSuccess, Action<string> onError); // 0x0000000180BE16D0-0x0000000180BE1A50
		public void GetUserPetInfo(int userId, int petId, Action<PetUserDTO> onSuccess, Action<string> onError); // 0x0000000180BE1A50-0x0000000180BE1DD0
		[IteratorStateMachine(typeof(_GetUserPetInfoWithRawResponse_d__11))]
		private IEnumerator GetUserPetInfoWithRawResponse(string url, Action<PetUserDTO> onSuccess, Action<string> onError); // 0x0000000180BE1DD0-0x0000000180BE1F30
	}
}
