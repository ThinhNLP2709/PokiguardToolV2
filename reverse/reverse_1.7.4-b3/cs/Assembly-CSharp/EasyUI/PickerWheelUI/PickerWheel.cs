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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace EasyUI.PickerWheelUI
{
	public class PickerWheel : MonoBehaviour // TypeDefIndex: 2548
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
		public const string GLOW_NODE = "glow"; // Metadata: 0x005F0FD3
		private const int LABEL_MIN_SIZE = 12; // Metadata: 0x005F0FD8
		private const int LABEL_MAX_SIZE = 20; // Metadata: 0x005F0FD9
		private bool needsRegenerate; // 0xE8
		private const float GlowInflate = 1.18f; // Metadata: 0x005F0FDA
	
		// Properties
		public bool IsSpinning { get; } // 0x00000001803C6210-0x00000001803C6220 
		public bool IsGenerated { get; } // 0x0000000180BCB1F0-0x0000000180BCB200 
		public float PieceAngle { get; } // 0x0000000180BCB200-0x0000000180BCB210 
		public Transform WheelCircle { get; } // 0x00000001802BA5A0-0x00000001802BA5B0 
		public int PieceCount { get; } // 0x0000000180BCB210-0x0000000180BCB230 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 2549
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
			internal void _Spin_b__0(); // 0x0000000180BD0400-0x0000000180BD0710
			internal void _Spin_b__1(); // 0x0000000180BD0710-0x0000000180BD0840
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass67_0 // TypeDefIndex: 2550
		{
			// Fields
			public PickerWheel __4__this; // 0x10
			public float prevAngle; // 0x18
			public bool isIndicatorOnTheLine; // 0x1C
			public WheelPiece piece; // 0x20
	
			// Constructors
			public __c__DisplayClass67_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _SpinToIndex_b__0(); // 0x0000000180BD0840-0x0000000180BD0B90
			internal void _SpinToIndex_b__1(); // 0x0000000180BD0B90-0x0000000180BD0D20
		}
	
		[CompilerGenerated]
		private sealed class _SetupWheelCoroutine_d__55 : IEnumerator<object> // TypeDefIndex: 2551
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
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180BD0D20-0x0000000180BD0DE0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BD0DE0-0x0000000180BD0E20
		}
	
		// Constructors
		public PickerWheel(); // 0x0000000180BD0140-0x0000000180BD0400
	
		// Methods
		private void OnDisable(); // 0x0000000180BCB1E0-0x0000000180BCB1F0
		public Transform GetPieceTransform(int index); // 0x0000000180BCB230-0x0000000180BCB290
		public void ClearPieceGlows(); // 0x0000000180BCB290-0x0000000180BCB620
		public void RefreshPieces(); // 0x0000000180BCB620-0x0000000180BCB820
		private void ApplyPieceContent(Transform pieceObj, WheelPiece piece, int index); // 0x0000000180BCB820-0x0000000180BCBC20
		private static void ApplyLabel(UnityEngine.UI.Text labelText, string label); // 0x0000000180BCBC20-0x0000000180BCBEA0
		private static void ApplyIcon(Image iconImage, WheelPiece piece); // 0x0000000180BCBEA0-0x0000000180BCC050
		private static void ApplyShardOverlay(Image icon, bool shard); // 0x0000000180BCC050-0x0000000180BCC970
		private void Start(); // 0x000000018028A320-0x000000018028A330
		public void SetupWheel(); // 0x0000000180BCC970-0x0000000180BCCA20
		private void LateUpdate(); // 0x0000000180BCCA20-0x0000000180BCCA40
		[IteratorStateMachine(typeof(_SetupWheelCoroutine_d__55))]
		private IEnumerator SetupWheelCoroutine(); // 0x0000000180BCCA40-0x0000000180BCCAE0
		private void SetupWheelImmediate(); // 0x0000000180BCCAE0-0x0000000180BCCBE0
		public void RecalculateWeights(); // 0x0000000180BCCBE0-0x0000000180BCCCF0
		private void SetupAudio(); // 0x0000000180BCCCF0-0x0000000180BCCF80
		private void Generate(); // 0x0000000180BCCF80-0x0000000180BCD870
		private static void FitGlow(Transform pieceRoot, float pieceWidth, float pieceHeight); // 0x0000000180BCD870-0x0000000180BCDD00
		private void ClearWheel(); // 0x0000000180BCDD00-0x0000000180BCE2A0
		private void DrawPiece(int index); // 0x0000000180BCE2A0-0x0000000180BCEE50
		public static string FormatVND(long amount); // 0x0000000180BCEE50-0x0000000180BCEF60
		private GameObject InstantiatePiece(); // 0x0000000180BCEF60-0x0000000180BCF0B0
		public void Spin(); // 0x0000000180BCF0B0-0x0000000180BCF750
		public void SpinToIndex(int targetIndex); // 0x0000000180BCF750-0x0000000180BCFC90
		public void OnSpinStart(UnityAction action); // 0x00000001802D8C70-0x00000001802D8CD0
		public void OnSpinEnd(UnityAction<WheelPiece> action); // 0x00000001802D8CE0-0x00000001802D8D40
		public void OnTick(UnityAction action); // 0x00000001802D8D50-0x00000001802D8DB0
		private int GetRandomPieceIndex(); // 0x0000000180BCFC90-0x0000000180BCFD20
		private void CalculateWeightsAndIndices(); // 0x0000000180BCFD20-0x0000000180BCFE30
		private void OnValidate(); // 0x0000000180BCFE30-0x0000000180BD0060
		public void ResetWheelRotation(float duration = 0.5f /* Metadata: 0x005F0FCF */, Action onComplete = null); // 0x0000000180BD0060-0x0000000180BD0140
	}
}
