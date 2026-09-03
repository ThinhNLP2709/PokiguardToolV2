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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class FusionRoomCardUI : MonoBehaviour // TypeDefIndex: 1674
{
	// Fields
	public const string NODE_NAME = "cardFusionRoom"; // Metadata: 0x0064D8F3
	public const string PREFAB_PATH = "Prefabs/UI/CardFusionRoom"; // Metadata: 0x0064D902
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
	private sealed class __c // TypeDefIndex: 1675
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__25_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805E91C0-0x00000001805E9230
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _InstallRoomAutoPush_b__25_0(string _); // 0x00000001805E8710-0x00000001805E8750
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1676
	{
		// Fields
		public FusionRoomCardUI __4__this; // 0x10
		public float aMin; // 0x18
		public float aMax; // 0x1C

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RefreshState_b__0(float k); // 0x00000001805E8DF0-0x00000001805E8FD0
	}

	[CompilerGenerated]
	private sealed class _PushWhenReady_d__15 : IEnumerator<object> // TypeDefIndex: 1677
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _deadline_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PushWhenReady_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E7CF0-0x00000001805E7F10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E7F10-0x00000001805E7F50
	}

	// Constructors
	public FusionRoomCardUI(); // 0x00000001805DCA60-0x00000001805DCA90

	// Methods
	public static FusionRoomCardUI Ensure(Transform listParent, GameObject sizeTemplate); // 0x00000001805DB040-0x00000001805DB5A0
	private void Awake(); // 0x00000001805DA260-0x00000001805DA3B0
	private void EnsureClickable(); // 0x00000001805DAD80-0x00000001805DB040
	private void OnEnable(); // 0x00000001805DBEE0-0x00000001805DC090
	private void OnDisable(); // 0x00000001805DBD50-0x00000001805DBEE0
	[IteratorStateMachine(typeof(_PushWhenReady_d__15))]
	private IEnumerator PushWhenReady(); // 0x00000001805DC280-0x00000001805DC2D0
	private void OnRoomStatesChanged(); // 0x00000001805DC090-0x00000001805DC280
	private void RefreshState(); // 0x00000001805DC2D0-0x00000001805DC8F0
	private void AutoFindRefs(); // 0x00000001805DA030-0x00000001805DA260
	private Transform FindDeep(string nodeName); // 0x00000001805DB5A0-0x00000001805DB710
	private void CaptureBaseState(); // 0x00000001805DAB30-0x00000001805DAC80
	private static void InstallRoomAutoPush(); // 0x00000001805DBC00-0x00000001805DBD50
	public void BuildHierarchy(); // 0x00000001805DA3B0-0x00000001805DAB30
	private GameObject FindOrCreate(string name); // 0x00000001805DB970-0x00000001805DBB50
	private static Image GetOrAddImage(GameObject go); // 0x00000001805DBB50-0x00000001805DBC00
	private UnityEngine.UI.Text FindOrCreateText(string name, string content, Font font, int fontSize, Color color); // 0x00000001805DB710-0x00000001805DB970
	private static void StretchCenter(GameObject go, float scale); // 0x00000001805DC8F0-0x00000001805DCA60
	private static void AnchorBottom(GameObject go, float y, float height); // 0x00000001805D9F10-0x00000001805DA030
	private static void Center(GameObject go, Vector2 offset, Vector2 size); // 0x00000001805DAC80-0x00000001805DAD80
}

