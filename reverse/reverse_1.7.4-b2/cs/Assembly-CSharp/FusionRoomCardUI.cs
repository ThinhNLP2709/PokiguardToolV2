/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class FusionRoomCardUI : MonoBehaviour // TypeDefIndex: 1947
{
	// Fields
	public const string NODE_NAME = "cardFusionRoom"; // Metadata: 0x0068DD22
	public const string PREFAB_PATH = "Prefabs/UI/CardFusionRoom"; // Metadata: 0x0068DD31
	[SerializeField]
	private Image imgGlow; // 0x20
	[SerializeField]
	private Image imgtCard; // 0x28
	[SerializeField]
	private Image imgFusionPet; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtLabel; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtHint; // 0x40
	private Color _labelBase; // 0x48
	private float _glowBaseAlpha; // 0x58
	private bool _baseCaptured; // 0x5C
	private string _noticedReason; // 0x60
	private string _hintBase; // 0x68
	private Color _hintBaseColor; // 0x70
	private static bool _autoPushInstalled; // 0x00

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1948
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__25_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180710720-0x0000000180710790
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _InstallRoomAutoPush_b__25_0(string _); // 0x000000018070FE10-0x000000018070FE50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1949
	{
		// Fields
		public FusionRoomCardUI __4__this; // 0x10
		public float aMin; // 0x18
		public float aMax; // 0x1C

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RefreshState_b__0(float k); // 0x0000000180710440-0x0000000180710620
	}

	[CompilerGenerated]
	private sealed class _PushWhenReady_d__15 : IEnumerator<object> // TypeDefIndex: 1950
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _deadline_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PushWhenReady_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018070F370-0x000000018070F590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070F590-0x000000018070F5D0
	}

	// Constructors
	public FusionRoomCardUI(); // 0x0000000180706D70-0x0000000180706DA0

	// Methods
	public static FusionRoomCardUI Ensure(Transform listParent, GameObject sizeTemplate); // 0x0000000180705450-0x00000001807059B0
	private void Awake(); // 0x0000000180704670-0x00000001807047C0
	private void EnsureClickable(); // 0x0000000180705190-0x0000000180705450
	private void OnEnable(); // 0x00000001807062F0-0x00000001807064A0
	private void OnDisable(); // 0x0000000180706160-0x00000001807062F0
	[IteratorStateMachine(typeof(_PushWhenReady_d__15))]
	private IEnumerator PushWhenReady(); // 0x0000000180706590-0x00000001807065E0
	private void OnRoomStatesChanged(); // 0x00000001807064A0-0x0000000180706590
	private void RefreshState(); // 0x00000001807065E0-0x0000000180706C00
	private void AutoFindRefs(); // 0x0000000180704440-0x0000000180704670
	private Transform FindDeep(string nodeName); // 0x00000001807059B0-0x0000000180705B20
	private void CaptureBaseState(); // 0x0000000180704F40-0x0000000180705090
	private static void InstallRoomAutoPush(); // 0x0000000180706010-0x0000000180706160
	public void BuildHierarchy(); // 0x00000001807047C0-0x0000000180704F40
	private GameObject FindOrCreate(string name); // 0x0000000180705D80-0x0000000180705F60
	private static Image GetOrAddImage(GameObject go); // 0x0000000180705F60-0x0000000180706010
	private UnityEngine.UI.Text FindOrCreateText(string name, string content, Font font, int fontSize, Color color); // 0x0000000180705B20-0x0000000180705D80
	private static void StretchCenter(GameObject go, float scale); // 0x0000000180706C00-0x0000000180706D70
	private static void AnchorBottom(GameObject go, float y, float height); // 0x0000000180704320-0x0000000180704440
	private static void Center(GameObject go, Vector2 offset, Vector2 size); // 0x0000000180705090-0x0000000180705190
}

