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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class FusionRoomCardUI : MonoBehaviour // TypeDefIndex: 2319
{
	// Fields
	public const string NODE_NAME = "cardFusionRoom"; // Metadata: 0x005F0AFD
	public const string PREFAB_PATH = "Prefabs/UI/CardFusionRoom"; // Metadata: 0x005F0B0C
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
	private sealed class __c // TypeDefIndex: 2320
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__25_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180B27520-0x0000000180B275C0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _InstallRoomAutoPush_b__25_0(string _); // 0x0000000180B275C0-0x0000000180B27630
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2321
	{
		// Fields
		public FusionRoomCardUI __4__this; // 0x10
		public float aMin; // 0x18
		public float aMax; // 0x1C

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshState_b__0(float k); // 0x0000000180B27630-0x0000000180B278F0
	}

	[CompilerGenerated]
	private sealed class _PushWhenReady_d__15 : IEnumerator<object> // TypeDefIndex: 2322
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _deadline_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PushWhenReady_d__15(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B278F0-0x0000000180B27D80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B27D80-0x0000000180B27DC0
	}

	// Constructors
	public FusionRoomCardUI(); // 0x0000000180B274B0-0x0000000180B27520

	// Methods
	public static FusionRoomCardUI Ensure(Transform listParent, GameObject sizeTemplate); // 0x0000000180B22A60-0x0000000180B234D0
	private void Awake(); // 0x0000000180B234D0-0x0000000180B23730
	private void EnsureClickable(); // 0x0000000180B23730-0x0000000180B23B80
	private void OnEnable(); // 0x0000000180B23B80-0x0000000180B23DF0
	private void OnDisable(); // 0x0000000180B23DF0-0x0000000180B240A0
	[IteratorStateMachine(typeof(_PushWhenReady_d__15))]
	private IEnumerator PushWhenReady(); // 0x0000000180B240A0-0x0000000180B240E0
	private void OnRoomStatesChanged(); // 0x0000000180B240E0-0x0000000180B24300
	private void RefreshState(); // 0x0000000180B24300-0x0000000180B24CF0
	private void AutoFindRefs(); // 0x0000000180B24CF0-0x0000000180B252E0
	private Transform FindDeep(string nodeName); // 0x0000000180B252E0-0x0000000180B255A0
	private void CaptureBaseState(); // 0x0000000180B255A0-0x0000000180B25890
	private static void InstallRoomAutoPush(); // 0x0000000180B25890-0x0000000180B25A20
	public void BuildHierarchy(); // 0x0000000180B25A20-0x0000000180B26660
	private GameObject FindOrCreate(string name); // 0x0000000180B26660-0x0000000180B26A30
	private static Image GetOrAddImage(GameObject go); // 0x0000000180B26A30-0x0000000180B26B70
	private UnityEngine.UI.Text FindOrCreateText(string name, string content, Font font, int fontSize, Color color); // 0x0000000180B26B70-0x0000000180B270B0
	private static void StretchCenter(GameObject go, float scale); // 0x0000000180B270B0-0x0000000180B27280
	private static void AnchorBottom(GameObject go, float y, float height); // 0x0000000180B27280-0x0000000180B273B0
	private static void Center(GameObject go, Vector2 offset, Vector2 size); // 0x0000000180B273B0-0x0000000180B274B0
}

