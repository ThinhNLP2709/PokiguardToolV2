/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerChinhPhuc : MonoBehaviour // TypeDefIndex: 1325
{
	// Fields
	public GameObject LoadingPanel; // 0x20
	public GameObject[] panels; // 0x28
	public Button[] buttons; // 0x30
	public GameObject panelMain; // 0x38
	public GameObject backBtn; // 0x40
	public UnityEngine.UI.Text txtVang; // 0x48
	public UnityEngine.UI.Text txtCt; // 0x50
	public UnityEngine.UI.Text txtNl; // 0x58
	public GameObject notice; // 0x60
	public Button cancleNotice; // 0x68
	[Header("UI")]
	[SerializeField]
	private Material grayscaleUIMaterial; // 0x70
	[Header("Animation Settings")]
	[SerializeField]
	private float buttonPopDelay; // 0x78
	[SerializeField]
	private float panelSlideSpeed; // 0x7C
	[SerializeField]
	private bool enableParticleEffects; // 0x80
	private Material _runtimeGrayMat; // 0x88
	private bool isDataLoaded; // 0x90
	private List<GroupDTO> cachedPetData; // 0x98
	[Header("Close Button")]
	public Button btnClose; // 0xA0
	private bool _subscribedToService; // 0xA8
	private readonly Dictionary<int, bool> _lastLockedByPetId; // 0xB0
	[Header("Transition")]
	public GameObject fadeOverlay; // 0xB8
	private static bool _grayShaderWarned; // 0x00
	private Sprite _huntBadgeBg; // 0xC0
	private Sprite[] _huntDigitSprites; // 0xC8

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1326
	{
		// Fields
		public int index; // 0x10
		public ManagerChinhPhuc __4__this; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Start_b__0(); // 0x0000000180512500-0x0000000180512640
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1327
	{
		// Fields
		public GameObject mainPanel; // 0x10

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ClosePanel_b__0(); // 0x0000000180512830-0x00000001805128A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 1328
	{
		// Fields
		public List<GroupDTO> loadedData; // 0x10
		public bool apiCompleted; // 0x18
		public string errorMessage; // 0x20

		// Constructors
		public __c__DisplayClass32_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadDataCoroutine_b__0(List<GroupDTO> data); // 0x0000000180439DF0-0x0000000180439E10
		internal void _LoadDataCoroutine_b__1(string error); // 0x00000001805128D0-0x0000000180512960
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass36_0 // TypeDefIndex: 1329
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10
		public Color originalColor; // 0x18

		// Constructors
		public __c__DisplayClass36_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateTextFadeIn_b__0(float val); // 0x0000000180512960-0x00000001805129D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass37_0 // TypeDefIndex: 1330
	{
		// Fields
		public GameObject buttonObj; // 0x10

		// Constructors
		public __c__DisplayClass37_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AddButtonHoverEffect_b__0(BaseEventData data); // 0x00000001805129D0-0x0000000180512AA0
		internal void _AddButtonHoverEffect_b__1(BaseEventData data); // 0x0000000180512AA0-0x0000000180512B50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 1331
	{
		// Fields
		public bool lockedForClick; // 0x10
		public int lockedOrderForClick; // 0x14
		public int requiredAttack; // 0x18
		public int petId; // 0x1C
		public string reA; // 0x20
		public ManagerChinhPhuc __4__this; // 0x28

		// Constructors
		public __c__DisplayClass38_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnReceived_b__0(); // 0x0000000180512B50-0x0000000180512E50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 1332
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass41_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayUnlockPunch_b__0(); // 0x0000000180512E50-0x0000000180512F50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 1333
	{
		// Fields
		public int petId; // 0x10
		public Func<PetEnemyDTO, bool> __9__0; // 0x18

		// Constructors
		public __c__DisplayClass44_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _OpenRoomWithPetRoutine_b__0(PetEnemyDTO p); // 0x0000000180513030-0x0000000180513050
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass45_0 // TypeDefIndex: 1334
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass45_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateNumberCount_b__0(float val); // 0x0000000180513050-0x00000001805130B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass46_0 // TypeDefIndex: 1335
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10
		public Vector3 originalScale; // 0x18

		// Constructors
		public __c__DisplayClass46_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateTextPulse_b__0(); // 0x00000001805130B0-0x00000001805131A0
	}

	[CompilerGenerated]
	private sealed class _AnimatePanelContent_d__51 : IEnumerator<object> // TypeDefIndex: 1336
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject panel; // 0x20
		public ManagerChinhPhuc __4__this; // 0x28
		private Button[] _panelButtons_5__2; // 0x30
		private int _i_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AnimatePanelContent_d__51(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018050F570-0x000000018050F840
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050F840-0x000000018050F880
	}

	[CompilerGenerated]
	private sealed class _BackSceneWithFade_d__50 : IEnumerator<object> // TypeDefIndex: 1337
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerChinhPhuc __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BackSceneWithFade_d__50(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018050FA20-0x000000018050FED0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050FED0-0x000000018050FF10
	}

	[CompilerGenerated]
	private sealed class _LoadDataCoroutine_d__32 : IEnumerator<object> // TypeDefIndex: 1338
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerChinhPhuc __4__this; // 0x20
		public Action onComplete; // 0x28
		private __c__DisplayClass32_0 __8__1; // 0x30
		private bool _isRestoring_5__2; // 0x38
		private ChinhPhucDataService _svc_5__3; // 0x40
		private float _deadline_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataCoroutine_d__32(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180356CD0-0x0000000180356D10
		private bool MoveNext(); // 0x0000000180510EC0-0x0000000180511640
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180511640-0x0000000180511680
	}

	[CompilerGenerated]
	private sealed class _OpenRoomWithPetRoutine_d__44 : IEnumerator<object> // TypeDefIndex: 1339
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int petId; // 0x20
		private __c__DisplayClass44_0 __8__1; // 0x28
		public ManagerChinhPhuc __4__this; // 0x30
		public ManagerRoom flow; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OpenRoomWithPetRoutine_d__44(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805118B0-0x0000000180511C60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180511C60-0x0000000180511CA0
	}

	[CompilerGenerated]
	private sealed class _ShowPanelWithLoadingCoroutine_d__29 : IEnumerator<object> // TypeDefIndex: 1340
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerChinhPhuc __4__this; // 0x20
		public int index; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowPanelWithLoadingCoroutine_d__29(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180511E90-0x0000000180512180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180512180-0x00000001805121C0
	}

	// Constructors
	public ManagerChinhPhuc(); // 0x00000001804FB690-0x00000001804FB730

	// Methods
	private void Start(); // 0x00000001804FB030-0x00000001804FB3A0
	private void OnEnable(); // 0x00000001804F88E0-0x00000001804F8950
	private void RebindIfServiceDataChanged(); // 0x00000001804FA480-0x00000001804FA550
	private void OnDisable(); // 0x00000001804F87E0-0x00000001804F88E0
	private void SubscribeServiceEvents(); // 0x00000001804FB3A0-0x00000001804FB4A0
	private void UnsubscribeServiceEvents(); // 0x00000001804F87E0-0x00000001804F88E0
	private void HandleServiceDataChanged(); // 0x00000001804F8050-0x00000001804F8120
	public void ClosePanel(); // 0x00000001804F7040-0x00000001804F71D0
	public void RestoreState(int panelIndex); // 0x00000001804FA550-0x00000001804FA820
	public void ShowPanel(int index, bool withAnimation = true /* Metadata: 0x0064D622 */); // 0x00000001804FAEF0-0x00000001804FB030
	[IteratorStateMachine(typeof(_ShowPanelWithLoadingCoroutine_d__29))]
	private IEnumerator ShowPanelWithLoadingCoroutine(int index, bool withAnimation); // 0x00000001804FAE70-0x00000001804FAEF0
	public void InitializeAndLoadData(Action onComplete = null); // 0x00000001804F8490-0x00000001804F8520
	public void InvalidateCache(); // 0x00000001804F8520-0x00000001804F8590
	[IteratorStateMachine(typeof(_LoadDataCoroutine_d__32))]
	private IEnumerator LoadDataCoroutine(Action onComplete); // 0x00000001804F8590-0x00000001804F8620
	private void ShowLoadingPanel(); // 0x00000001804FAA70-0x00000001804FAC10
	private void HideLoadingPanel(); // 0x00000001804F82A0-0x00000001804F8410
	private void AnimateInitialUI(); // 0x00000001804F5DA0-0x00000001804F60D0
	private void AnimateTextFadeIn(UnityEngine.UI.Text text, float delay); // 0x00000001804F6330-0x00000001804F6550
	private void AddButtonHoverEffect(GameObject buttonObj); // 0x00000001804F5970-0x00000001804F5C80
	public void OnReceived(List<GroupDTO> petE); // 0x00000001804F8A40-0x00000001804FA070
	private static bool HasServerLockFlags(GroupDTO group); // 0x00000001804F8120-0x00000001804F8190
	private void PlayUnlockPunch(GameObject btnObj); // 0x00000001804FA270-0x00000001804FA480
	private void AddPetButtonAnimation(GameObject btnObj); // 0x00000001804F5C80-0x00000001804F5DA0
	private void OpenRoomWithPet(int petId, string reA); // 0x00000001804FA110-0x00000001804FA270
	[IteratorStateMachine(typeof(_OpenRoomWithPetRoutine_d__44))]
	private IEnumerator OpenRoomWithPetRoutine(int petId, string reA, ManagerRoom flow); // 0x00000001804FA070-0x00000001804FA110
	private void AnimateNumberCount(UnityEngine.UI.Text textComponent, int targetValue); // 0x00000001804F60D0-0x00000001804F62A0
	private void AnimateTextPulse(UnityEngine.UI.Text textComponent); // 0x00000001804F6550-0x00000001804F6750
	private void OnError(string error); // 0x00000001804F8950-0x00000001804F8A40
	public void BackScene(); // 0x00000001804F67C0-0x00000001804F6840
	[IteratorStateMachine(typeof(_BackSceneWithFade_d__50))]
	private IEnumerator BackSceneWithFade(); // 0x00000001804F6750-0x00000001804F67C0
	[IteratorStateMachine(typeof(_AnimatePanelContent_d__51))]
	private IEnumerator AnimatePanelContent(GameObject panel); // 0x00000001804F62A0-0x00000001804F6330
	public void HideAllPanels(); // 0x00000001804F8190-0x00000001804F82A0
	private void ToggleNotice(); // 0x00000001804FB4A0-0x00000001804FB5A0
	private void ShowNoticeWithAnimation(string message = "" /* Metadata: 0x0064D623 */); // 0x00000001804FAC10-0x00000001804FAE70
	private void HideNoticeWithAnimation(); // 0x00000001804F8410-0x00000001804F8490
	private void EnsureGrayMaterial(); // 0x00000001804F7920-0x00000001804F7A80
	private void EnsureElementReqBadge(Transform petButton, string[] elements, bool locked); // 0x00000001804F71D0-0x00000001804F7920
	private void EnsureHuntOrderBadge(Transform petButton, int orderNumber, bool locked, bool cleared); // 0x00000001804F7A80-0x00000001804F8050
	private void BuildHuntOrderDigits(Transform badgeT, int orderNumber, bool locked); // 0x00000001804F6840-0x00000001804F7040
	private void SetImageGrayscale(Image img, bool enable); // 0x00000001804FA820-0x00000001804FAA70
	private void OnDestroy(); // 0x00000001804F8620-0x00000001804F87E0
	[CompilerGenerated]
	private void _HideLoadingPanel_b__34_0(); // 0x00000001804FB5D0-0x00000001804FB640
	[CompilerGenerated]
	private void _BackSceneWithFade_b__50_0(); // 0x00000001804FB5A0-0x00000001804FB5D0
	[CompilerGenerated]
	private void _ShowNoticeWithAnimation_b__54_0(); // 0x00000001804FB640-0x00000001804FB690
}

