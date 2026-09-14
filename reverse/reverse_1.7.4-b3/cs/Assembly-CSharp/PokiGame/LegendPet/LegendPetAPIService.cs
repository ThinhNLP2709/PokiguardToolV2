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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGame.LegendPet
{
	public class LegendPetAPIService : MonoBehaviour // TypeDefIndex: 2567
	{
		// Fields
		private static LegendPetAPIService instance; // 0x00
	
		// Properties
		public static LegendPetAPIService Instance { get; } // 0x0000000180BD31E0-0x0000000180BD33D0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 2568
		{
			// Fields
			public Action<LegendPetData> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _GetLegendPetInfo_b__0(LegendPetData response); // 0x0000000180BD4A80-0x0000000180BD4AA0
			internal void _GetLegendPetInfo_b__1(string error); // 0x0000000180BD4AA0-0x0000000180BD4B50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 2569
		{
			// Fields
			public Action<InlayStarResponse> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _InlayStar_b__0(InlayStarResponse response); // 0x0000000180BD4A80-0x0000000180BD4AA0
			internal void _InlayStar_b__1(string error); // 0x0000000180BD4B50-0x0000000180BD4C00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 2570
		{
			// Fields
			public Action<UnlockPetResponse> onSuccess; // 0x10
			public Action<string> onError; // 0x18
	
			// Constructors
			public __c__DisplayClass9_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _UnlockLegendPet_b__0(UnlockPetResponse response); // 0x0000000180BD4A80-0x0000000180BD4AA0
			internal void _UnlockLegendPet_b__1(string error); // 0x0000000180BD4C00-0x0000000180BD4CB0
		}
	
		[CompilerGenerated]
		private sealed class _GetAllLegendPetsWithRawResponse_d__6 : IEnumerator<object> // TypeDefIndex: 2571
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
			void IDisposable.Dispose(); // 0x0000000180BD4CB0-0x0000000180BD4DE0
			private bool MoveNext(); // 0x0000000180BD4DE0-0x0000000180BD5430
			private void __m__Finally1(); // 0x0000000180BD5430-0x0000000180BD5490
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BD5490-0x0000000180BD54D0
		}
	
		[CompilerGenerated]
		private sealed class _GetUserPetInfoWithRawResponse_d__11 : IEnumerator<object> // TypeDefIndex: 2572
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
			void IDisposable.Dispose(); // 0x0000000180BD54D0-0x0000000180BD5600
			private bool MoveNext(); // 0x0000000180BD5600-0x0000000180BD5C70
			private void __m__Finally1(); // 0x0000000180BD5C70-0x0000000180BD5CD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BD5CD0-0x0000000180BD5D10
		}
	
		// Constructors
		public LegendPetAPIService(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private static string GetAuthToken(); // 0x0000000180BD33D0-0x0000000180BD3430
		private static void AttachAuth(UnityWebRequest request); // 0x0000000180BD3430-0x0000000180BD3510
		public void GetAllLegendPets(Action<LegendPetListResponse> onSuccess, Action<string> onError); // 0x0000000180BD3510-0x0000000180BD3950
		[IteratorStateMachine(typeof(_GetAllLegendPetsWithRawResponse_d__6))]
		private IEnumerator GetAllLegendPetsWithRawResponse(string url, Action<LegendPetListResponse> onSuccess, Action<string> onError); // 0x0000000180BD3950-0x0000000180BD3AB0
		public void GetLegendPetInfo(long userId, long petId, Action<LegendPetData> onSuccess, Action<string> onError); // 0x0000000180BD3AB0-0x0000000180BD3EC0
		public void InlayStar(InlayStarRequest requestData, Action<InlayStarResponse> onSuccess, Action<string> onError); // 0x0000000180BD3EC0-0x0000000180BD4240
		public void UnlockLegendPet(long userId, long petId, Action<UnlockPetResponse> onSuccess, Action<string> onError); // 0x0000000180BD4240-0x0000000180BD45A0
		public void GetUserPetInfo(int userId, int petId, Action<PetUserDTO> onSuccess, Action<string> onError); // 0x0000000180BD45A0-0x0000000180BD4920
		[IteratorStateMachine(typeof(_GetUserPetInfoWithRawResponse_d__11))]
		private IEnumerator GetUserPetInfoWithRawResponse(string url, Action<PetUserDTO> onSuccess, Action<string> onError); // 0x0000000180BD4920-0x0000000180BD4A80
	}
}
