/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.Avatar
{
	public static class AvatarLayerLoader // TypeDefIndex: 2911
	{
		// Fields
		private static readonly HashSet<string> _warned; // 0x00
	
		// Nested types
		[CompilerGenerated]
		private sealed class _LoadOne_d__2 : IEnumerator<object> // TypeDefIndex: 2912
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public AvatarLayerResult result; // 0x20
			public string resourcePath; // 0x28
			private string[] _addresses_5__2; // 0x30
			private int _i_5__3; // 0x38
			private AsyncOperationHandle<IList<IResourceLocation>> _locHandle_5__4; // 0x40
			private AsyncOperationHandle<Sprite> _h_5__5; // 0x58
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadOne_d__2(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180D42CF0-0x0000000180D42D70
			private bool MoveNext(); // 0x0000000180D42D70-0x0000000180D43B90
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D43B90-0x0000000180D43BD0
		}
	
		// Constructors
		static AvatarLayerLoader(); // 0x0000000180D42B60-0x0000000180D42CF0
	
		// Methods
		public static string[] AddressCandidates(string resourcePath); // 0x0000000180D42960-0x0000000180D42A50
		[IteratorStateMachine(typeof(_LoadOne_d__2))]
		public static IEnumerator LoadOne(string resourcePath, AvatarLayerResult result); // 0x0000000180D42A50-0x0000000180D42B60
	}
}
