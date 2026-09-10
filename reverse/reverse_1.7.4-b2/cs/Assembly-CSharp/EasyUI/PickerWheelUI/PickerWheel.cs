/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace EasyUI.PickerWheelUI
{
	public class PickerWheel : MonoBehaviour // TypeDefIndex: 2132
	{
		// Fields
		[Header("References :")]
		[SerializeField]
		private GameObject linePrefab; // 0x20
		[SerializeField]
		private Transform linesParent; // 0x28
		[SerializeField]
		[Space]
		private Transform PickerWheelTransform; // 0x30
		[SerializeField]
		private Transform wheelCircle; // 0x38
		[SerializeField]
		private GameObject wheelPiecePrefab; // 0x40
		[SerializeField]
		private Transform wheelPiecesParent; // 0x48
		private GameObject wheelPiecePrefabInstance; // 0x50
		[Header("Sounds :")]
		[SerializeField]
		[Space]
		private AudioSource audioSource; // 0x58
		[SerializeField]
		private AudioClip tickAudioClip; // 0x60
		[Range(0f, 1f)]
		[SerializeField]
		private float volume; // 0x68
		[Range(-3f, 3f)]
		[SerializeField]
		private float pitch; // 0x6C
		[Header("Picker wheel settings :")]
		[Range(1f, 20f)]
		[Space]
		public int spinDuration; // 0x70
		[Range(0.2f, 2f)]
		[SerializeField]
		private float wheelSize; // 0x74
		[Header("Picker wheel pieces :")]
		[Space]
		public WheelPiece[] wheelPieces; // 0x78
		private UnityAction onSpinStartEvent; // 0x80
		private UnityAction<WheelPiece> onSpinEndEvent; // 0x88
		private UnityAction onTickEvent; // 0x90
		private bool _isSpinning; // 0x98
		private Vector2 pieceMinSize; // 0x9C
		private Vector2 pieceMaxSize; // 0xA4
		private int piecesMin; // 0xAC
		private int piecesMax; // 0xB0
		private float pieceAngle; // 0xB4
		private float halfPieceAngle; // 0xB8
		private float halfPieceAngleWithPaddings; // 0xBC
		private double accumulatedWeight; // 0xC0
		private System.Random rand; // 0xC8
		private List<int> nonZeroChancesIndices; // 0xD0
		private bool isGenerated; // 0xD8
		private readonly List<Transform> _pieceRoots; // 0xE0
		public const string GLOW_NODE = "glow"; // Metadata: 0x0068E0C9
		private const int LABEL_MIN_SIZE = 12; // Metadata: 0x0068E0CE
		private const int LABEL_MAX_SIZE = 20; // Metadata: 0x0068E0CF
		private bool needsRegenerate; // 0xE8
		private const float GlowInflate = 1.18f; // Metadata: 0x0068E0D0
	
		// Properties
		public bool IsSpinning { get; } // 0x000000018075DA30-0x000000018075DA40 
		public bool IsGenerated { get; } // 0x000000018075DA20-0x000000018075DA30 
		public float PieceAngle { get; } // 0x000000018075DA40-0x000000018075DA50 
		public Transform WheelCircle { get; } // 0x0000000180308AB0-0x0000000180308AC0 
		public int PieceCount { get; } // 0x000000018075DA50-0x000000018075DA70 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 2133
		{
			// Fields
			public float currentAngle; // 0x10
			public PickerWheel __4__this; // 0x18
			public float prevAngle; // 0x20
			public bool isIndicatorOnTheLine; // 0x24
			public WheelPiece piece; // 0x28
	
			// Constructors
			public __c__DisplayClass66_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Spin_b__0(); // 0x0000000180766E20-0x0000000180766FA0
			internal void _Spin_b__1(); // 0x0000000180766FA0-0x0000000180767040
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass67_0 // TypeDefIndex: 2134
		{
			// Fields
			public PickerWheel __4__this; // 0x10
			public float prevAngle; // 0x18
			public bool isIndicatorOnTheLine; // 0x1C
			public WheelPiece piece; // 0x20
	
			// Constructors
			public __c__DisplayClass67_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _SpinToIndex_b__0(); // 0x0000000180767040-0x0000000180767200
			internal void _SpinToIndex_b__1(); // 0x0000000180767200-0x00000001807672C0
		}
	
		[CompilerGenerated]
		private sealed class _SetupWheelCoroutine_d__55 : IEnumerator<object> // TypeDefIndex: 2135
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PickerWheel __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _SetupWheelCoroutine_d__55(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x0000000180766B30-0x0000000180766BB0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180766BB0-0x0000000180766BF0
		}
	
		// Constructors
		public PickerWheel(); // 0x000000018075D8C0-0x000000018075DA20
	
		// Methods
		private void OnDisable(); // 0x000000018075C990-0x000000018075C9A0
		public Transform GetPieceTransform(int index); // 0x000000018075C7B0-0x000000018075C7F0
		public void ClearPieceGlows(); // 0x000000018075B750-0x000000018075B920
		public void RefreshPieces(); // 0x000000018075CC00-0x000000018075CD60
		private void ApplyPieceContent(Transform pieceObj, WheelPiece piece, int index); // 0x000000018075AF50-0x000000018075B210
		private static void ApplyLabel(UnityEngine.UI.Text labelText, string label); // 0x000000018075AE70-0x000000018075AF50
		private static void ApplyIcon(Image iconImage, WheelPiece piece); // 0x000000018075ADD0-0x000000018075AE70
		private static void ApplyShardOverlay(Image icon, bool shard); // 0x000000018075B210-0x000000018075B640
		private void Start(); // 0x00000001802EB6C0-0x00000001802EB6D0
		public void SetupWheel(); // 0x000000018075D0A0-0x000000018075D150
		private void LateUpdate(); // 0x000000018075C970-0x000000018075C990
		[IteratorStateMachine(typeof(_SetupWheelCoroutine_d__55))]
		private IEnumerator SetupWheelCoroutine(); // 0x000000018075CEA0-0x000000018075CF10
		private void SetupWheelImmediate(); // 0x000000018075CF10-0x000000018075D0A0
		public void RecalculateWeights(); // 0x000000018075CAF0-0x000000018075CC00
		private void SetupAudio(); // 0x000000018075CDE0-0x000000018075CEA0
		private void Generate(); // 0x000000018075C350-0x000000018075C7B0
		private static void FitGlow(Transform pieceRoot, float pieceWidth, float pieceHeight); // 0x000000018075C0C0-0x000000018075C2D0
		private void ClearWheel(); // 0x000000018075B920-0x000000018075BAD0
		private void DrawPiece(int index); // 0x000000018075BAD0-0x000000018075C0C0
		public static string FormatVND(long amount); // 0x000000018075C2D0-0x000000018075C350
		private GameObject InstantiatePiece(); // 0x000000018075C880-0x000000018075C970
		public void Spin(); // 0x000000018075D4B0-0x000000018075D8C0
		public void SpinToIndex(int targetIndex); // 0x000000018075D150-0x000000018075D4B0
		public void OnSpinStart(UnityAction action); // 0x0000000180319C30-0x0000000180319C40
		public void OnSpinEnd(UnityAction<WheelPiece> action); // 0x0000000180319C10-0x0000000180319C30
		public void OnTick(UnityAction action); // 0x0000000180319BF0-0x0000000180319C10
		private int GetRandomPieceIndex(); // 0x000000018075C7F0-0x000000018075C880
		private void CalculateWeightsAndIndices(); // 0x000000018075B640-0x000000018075B750
		private void OnValidate(); // 0x000000018075C9A0-0x000000018075CAF0
		public void ResetWheelRotation(float duration = 0.5f /* Metadata: 0x0068E0C5 */, Action onComplete = null); // 0x000000018075CD60-0x000000018075CDE0
	}
}
