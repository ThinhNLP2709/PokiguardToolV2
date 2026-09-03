/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[DisallowMultipleComponent]
	[TMPHelpURL("index")]
	public class TMP_SpriteAnimator : MonoBehaviour // TypeDefIndex: 11875
	{
		// Fields
		private Dictionary<int, bool> m_animations; // 0x20
		private TMP_Text m_TextComponent; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private sealed class _DoSpriteAnimationInternal_d__7 : IEnumerator<object> // TypeDefIndex: 11876
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TMP_SpriteAnimator __4__this; // 0x20
			public int start; // 0x28
			public int end; // 0x2C
			public TMP_SpriteAsset spriteAsset; // 0x30
			public int currentCharacter; // 0x38
			public int framerate; // 0x3C
			private int _currentFrame_5__2; // 0x40
			private TMP_CharacterInfo _charInfo_5__3; // 0x48
			private int _materialIndex_5__4; // 0x1C0
			private int _vertexIndex_5__5; // 0x1C4
			private TMP_MeshInfo _meshInfo_5__6; // 0x1C8
			private float _baseSpriteScale_5__7; // 0x218
			private float _elapsedTime_5__8; // 0x21C
			private float _targetTime_5__9; // 0x220
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DoSpriteAnimationInternal_d__7(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001820D1D40-0x00000001820D1D90
			private bool MoveNext(); // 0x00000001820D1240-0x00000001820D1D00
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001820D1D00-0x00000001820D1D40
		}
	
		// Constructors
		public TMP_SpriteAnimator(); // 0x00000001820CA320-0x00000001820CA3A0
	
		// Methods
		private void Awake(); // 0x00000001820CA0B0-0x00000001820CA100
		private void OnEnable(); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnDisable(); // 0x00000001802E76C0-0x00000001802E76D0
		public void StopAllAnimations(); // 0x00000001820CA2F0-0x00000001820CA320
		public void DoSpriteAnimation(int currentCharacter, TMP_SpriteAsset spriteAsset, int start, int end, int framerate); // 0x00000001820CA1C0-0x00000001820CA2F0
		[IteratorStateMachine(typeof(_DoSpriteAnimationInternal_d__7))]
		private IEnumerator DoSpriteAnimationInternal(int currentCharacter, TMP_SpriteAsset spriteAsset, int start, int end, int framerate); // 0x00000001820CA100-0x00000001820CA1C0
	}
}
