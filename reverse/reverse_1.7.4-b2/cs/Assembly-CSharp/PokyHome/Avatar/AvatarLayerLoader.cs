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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.Avatar
{
	public static class AvatarLayerLoader // TypeDefIndex: 2464
	{
		// Fields
		private static readonly HashSet<string> _warned; // 0x00
	
		// Nested types
		[CompilerGenerated]
		private sealed class _LoadOne_d__2 : IEnumerator<object> // TypeDefIndex: 2465
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadOne_d__2(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018080C470-0x000000018080C4B0
			private bool MoveNext(); // 0x000000018080B9C0-0x000000018080C430
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018080C430-0x000000018080C470
		}
	
		// Constructors
		static AvatarLayerLoader(); // 0x00000001807FE7A0-0x00000001807FE8B0
	
		// Methods
		public static string[] AddressCandidates(string resourcePath); // 0x00000001807FE630-0x00000001807FE710
		[IteratorStateMachine(typeof(_LoadOne_d__2))]
		public static IEnumerator LoadOne(string resourcePath, AvatarLayerResult result); // 0x00000001807FE710-0x00000001807FE7A0
	}
}
