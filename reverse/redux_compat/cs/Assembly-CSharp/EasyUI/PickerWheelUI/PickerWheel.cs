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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace EasyUI.PickerWheelUI
{
	public class PickerWheel : MonoBehaviour // TypeDefIndex: 1965
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
		public const string GLOW_NODE = "glow"; // Metadata: 0x0064E124
		private const int LABEL_MIN_SIZE = 12; // Metadata: 0x0064E129
		private const int LABEL_MAX_SIZE = 20; // Metadata: 0x0064E12A
		private bool needsRegenerate; // 0xE8
		private const float GlowInflate = 1.18f; // Metadata: 0x0064E12B
	
		// Properties
		public bool IsSpinning { get; } // 0x0000000180665210-0x0000000180665220 
		public bool IsGenerated { get; } // 0x0000000180665200-0x0000000180665210 
		public float PieceAngle { get; } // 0x0000000180665220-0x0000000180665230 
		public Transform WheelCircle { get; } // 0x00000001803272A0-0x00000001803272B0 
		public int PieceCount { get; } // 0x0000000180665230-0x0000000180665250 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 1966
		{
			// Fields
			public float currentAngle; // 0x10
			public PickerWheel __4__this; // 0x18
			public float prevAngle; // 0x20
			public bool isIndicatorOnTheLine; // 0x24
			public WheelPiece piece; // 0x28
	
			// Constructors
			public __c__DisplayClass66_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Spin_b__0(); // 0x0000000180670310-0x0000000180670490
			internal void _Spin_b__1(); // 0x0000000180670490-0x0000000180670530
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass67_0 // TypeDefIndex: 1967
		{
			// Fields
			public PickerWheel __4__this; // 0x10
			public float prevAngle; // 0x18
			public bool isIndicatorOnTheLine; // 0x1C
			public WheelPiece piece; // 0x20
	
			// Constructors
			public __c__DisplayClass67_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SpinToIndex_b__0(); // 0x0000000180670530-0x00000001806706F0
			internal void _SpinToIndex_b__1(); // 0x00000001806706F0-0x00000001806707B0
		}
	
		[CompilerGenerated]
		private sealed class _SetupWheelCoroutine_d__55 : IEnumerator<object> // TypeDefIndex: 1968
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PickerWheel __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _SetupWheelCoroutine_d__55(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x000000018066FAB0-0x000000018066FB30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066FB30-0x000000018066FB70
		}
	
		// Constructors
		public PickerWheel(); // 0x00000001806650A0-0x0000000180665200
	
		// Methods
		private void OnDisable(); // 0x0000000180664130-0x0000000180664140
		public Transform GetPieceTransform(int index); // 0x0000000180663F50-0x0000000180663F90
		public void ClearPieceGlows(); // 0x0000000180662EF0-0x00000001806630C0
		public void RefreshPieces(); // 0x00000001806643E0-0x0000000180664540
		private void ApplyPieceContent(Transform pieceObj, WheelPiece piece, int index); // 0x00000001806626F0-0x00000001806629B0
		private static void ApplyLabel(UnityEngine.UI.Text labelText, string label); // 0x0000000180662610-0x00000001806626F0
		private static void ApplyIcon(Image iconImage, WheelPiece piece); // 0x0000000180662570-0x0000000180662610
		private static void ApplyShardOverlay(Image icon, bool shard); // 0x00000001806629B0-0x0000000180662DE0
		private void Start(); // 0x00000001802E76C0-0x00000001802E76D0
		public void SetupWheel(); // 0x0000000180664880-0x0000000180664930
		private void LateUpdate(); // 0x0000000180664110-0x0000000180664130
		[IteratorStateMachine(typeof(_SetupWheelCoroutine_d__55))]
		private IEnumerator SetupWheelCoroutine(); // 0x0000000180664680-0x00000001806646F0
		private void SetupWheelImmediate(); // 0x00000001806646F0-0x0000000180664880
		public void RecalculateWeights(); // 0x00000001806642D0-0x00000001806643E0
		private void SetupAudio(); // 0x00000001806645C0-0x0000000180664680
		private void Generate(); // 0x0000000180663AF0-0x0000000180663F50
		private static void FitGlow(Transform pieceRoot, float pieceWidth, float pieceHeight); // 0x0000000180663860-0x0000000180663A70
		private void ClearWheel(); // 0x00000001806630C0-0x0000000180663270
		private void DrawPiece(int index); // 0x0000000180663270-0x0000000180663860
		public static string FormatVND(long amount); // 0x0000000180663A70-0x0000000180663AF0
		private GameObject InstantiatePiece(); // 0x0000000180664020-0x0000000180664110
		public void Spin(); // 0x0000000180664C90-0x00000001806650A0
		public void SpinToIndex(int targetIndex); // 0x0000000180664930-0x0000000180664C90
		public void OnSpinStart(UnityAction action); // 0x000000018033EA30-0x000000018033EA40
		public void OnSpinEnd(UnityAction<WheelPiece> action); // 0x0000000180664140-0x0000000180664160
		public void OnTick(UnityAction action); // 0x0000000180664160-0x0000000180664180
		private int GetRandomPieceIndex(); // 0x0000000180663F90-0x0000000180664020
		private void CalculateWeightsAndIndices(); // 0x0000000180662DE0-0x0000000180662EF0
		private void OnValidate(); // 0x0000000180664180-0x00000001806642D0
		public void ResetWheelRotation(float duration = 0.5f /* Metadata: 0x0064E120 */, Action onComplete = null); // 0x0000000180664540-0x00000001806645C0
	}
}
