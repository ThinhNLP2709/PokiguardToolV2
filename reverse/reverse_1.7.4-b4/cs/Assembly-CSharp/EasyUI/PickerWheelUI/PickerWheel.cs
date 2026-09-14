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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace EasyUI.PickerWheelUI
{
	public class PickerWheel : MonoBehaviour // TypeDefIndex: 2555
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
		public const string GLOW_NODE = "glow"; // Metadata: 0x005F23EA
		private const int LABEL_MIN_SIZE = 12; // Metadata: 0x005F23EF
		private const int LABEL_MAX_SIZE = 20; // Metadata: 0x005F23F0
		private bool needsRegenerate; // 0xE8
		private const float GlowInflate = 1.18f; // Metadata: 0x005F23F1
	
		// Properties
		public bool IsSpinning { get; } // 0x00000001803C6EE0-0x00000001803C6EF0 
		public bool IsGenerated { get; } // 0x0000000180BD8460-0x0000000180BD8470 
		public float PieceAngle { get; } // 0x0000000180BD8470-0x0000000180BD8480 
		public Transform WheelCircle { get; } // 0x00000001802BA5D0-0x00000001802BA5E0 
		public int PieceCount { get; } // 0x0000000180BD8480-0x0000000180BD84A0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 2556
		{
			// Fields
			public float currentAngle; // 0x10
			public PickerWheel __4__this; // 0x18
			public float prevAngle; // 0x20
			public bool isIndicatorOnTheLine; // 0x24
			public WheelPiece piece; // 0x28
	
			// Constructors
			public __c__DisplayClass66_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Spin_b__0(); // 0x0000000180BDD670-0x0000000180BDD980
			internal void _Spin_b__1(); // 0x0000000180BDD980-0x0000000180BDDAB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass67_0 // TypeDefIndex: 2557
		{
			// Fields
			public PickerWheel __4__this; // 0x10
			public float prevAngle; // 0x18
			public bool isIndicatorOnTheLine; // 0x1C
			public WheelPiece piece; // 0x20
	
			// Constructors
			public __c__DisplayClass67_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _SpinToIndex_b__0(); // 0x0000000180BDDAB0-0x0000000180BDDE00
			internal void _SpinToIndex_b__1(); // 0x0000000180BDDE00-0x0000000180BDDF90
		}
	
		[CompilerGenerated]
		private sealed class _SetupWheelCoroutine_d__55 : IEnumerator<object> // TypeDefIndex: 2558
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PickerWheel __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _SetupWheelCoroutine_d__55(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180BDDF90-0x0000000180BDE050
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BDE050-0x0000000180BDE090
		}
	
		// Constructors
		public PickerWheel(); // 0x0000000180BDD3B0-0x0000000180BDD670
	
		// Methods
		private void OnDisable(); // 0x0000000180BD8450-0x0000000180BD8460
		public Transform GetPieceTransform(int index); // 0x0000000180BD84A0-0x0000000180BD8500
		public void ClearPieceGlows(); // 0x0000000180BD8500-0x0000000180BD8890
		public void RefreshPieces(); // 0x0000000180BD8890-0x0000000180BD8A90
		private void ApplyPieceContent(Transform pieceObj, WheelPiece piece, int index); // 0x0000000180BD8A90-0x0000000180BD8E90
		private static void ApplyLabel(UnityEngine.UI.Text labelText, string label); // 0x0000000180BD8E90-0x0000000180BD9110
		private static void ApplyIcon(Image iconImage, WheelPiece piece); // 0x0000000180BD9110-0x0000000180BD92C0
		private static void ApplyShardOverlay(Image icon, bool shard); // 0x0000000180BD92C0-0x0000000180BD9BE0
		private void Start(); // 0x000000018028A320-0x000000018028A330
		public void SetupWheel(); // 0x0000000180BD9BE0-0x0000000180BD9C90
		private void LateUpdate(); // 0x0000000180BD9C90-0x0000000180BD9CB0
		[IteratorStateMachine(typeof(_SetupWheelCoroutine_d__55))]
		private IEnumerator SetupWheelCoroutine(); // 0x0000000180BD9CB0-0x0000000180BD9D50
		private void SetupWheelImmediate(); // 0x0000000180BD9D50-0x0000000180BD9E50
		public void RecalculateWeights(); // 0x0000000180BD9E50-0x0000000180BD9F60
		private void SetupAudio(); // 0x0000000180BD9F60-0x0000000180BDA1F0
		private void Generate(); // 0x0000000180BDA1F0-0x0000000180BDAAE0
		private static void FitGlow(Transform pieceRoot, float pieceWidth, float pieceHeight); // 0x0000000180BDAAE0-0x0000000180BDAF70
		private void ClearWheel(); // 0x0000000180BDAF70-0x0000000180BDB510
		private void DrawPiece(int index); // 0x0000000180BDB510-0x0000000180BDC0C0
		public static string FormatVND(long amount); // 0x0000000180BDC0C0-0x0000000180BDC1D0
		private GameObject InstantiatePiece(); // 0x0000000180BDC1D0-0x0000000180BDC320
		public void Spin(); // 0x0000000180BDC320-0x0000000180BDC9C0
		public void SpinToIndex(int targetIndex); // 0x0000000180BDC9C0-0x0000000180BDCF00
		public void OnSpinStart(UnityAction action); // 0x00000001802D8CA0-0x00000001802D8D00
		public void OnSpinEnd(UnityAction<WheelPiece> action); // 0x00000001802D8D10-0x00000001802D8D70
		public void OnTick(UnityAction action); // 0x00000001802D8D80-0x00000001802D8DE0
		private int GetRandomPieceIndex(); // 0x0000000180BDCF00-0x0000000180BDCF90
		private void CalculateWeightsAndIndices(); // 0x0000000180BDCF90-0x0000000180BDD0A0
		private void OnValidate(); // 0x0000000180BDD0A0-0x0000000180BDD2D0
		public void ResetWheelRotation(float duration = 0.5f /* Metadata: 0x005F23E6 */, Action onComplete = null); // 0x0000000180BDD2D0-0x0000000180BDD3B0
	}
}
