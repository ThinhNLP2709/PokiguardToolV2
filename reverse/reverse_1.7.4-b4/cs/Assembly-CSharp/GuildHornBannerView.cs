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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class GuildHornBannerView : MonoBehaviour // TypeDefIndex: 1396
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/GuildHornBanner"; // Metadata: 0x005F0E30
	public const int SORTING_ORDER = 9400; // Metadata: 0x005F0E4B
	public static readonly Vector2 REF_RESOLUTION; // 0x00
	public const string ICON_PATH = "Image/GuildHorn/horn_icon"; // Metadata: 0x005F0E4F
	public const string PLATE_PATH = "Image/GuildHorn/horn_plate"; // Metadata: 0x005F0E69
	public const float BAR_H = 76f; // Metadata: 0x005F0E84
	public const float ICON_D = 100f; // Metadata: 0x005F0E88
	public const float ICON_X = -22f; // Metadata: 0x005F0E8C
	public const float TEXT_L = 92f; // Metadata: 0x005F0E90
	public const float TEXT_R = 30f; // Metadata: 0x005F0E94
	public const float EDGE_Y = 10f; // Metadata: 0x005F0E98
	public const float SLIDE = 26f; // Metadata: 0x005F0E9C
	public const int FS_SENDER = 26; // Metadata: 0x005F0EA0
	public const int FS_MESSAGE = 27; // Metadata: 0x005F0EA1
	public const float GAP = 10f; // Metadata: 0x005F0EA2
	public const float W_FRAC_HUB = 0.62f; // Metadata: 0x005F0EA6
	public const float W_MIN_HUB = 640f; // Metadata: 0x005F0EAA
	public const float W_MAX_HUB = 1180f; // Metadata: 0x005F0EAE
	public const float W_FRAC_MATCH = 0.5f; // Metadata: 0x005F0EB2
	public const float W_MIN_MATCH = 560f; // Metadata: 0x005F0EB6
	public const float W_MAX_MATCH = 900f; // Metadata: 0x005F0EBA
	public static readonly Color SENDER_COLOR; // 0x08
	public static readonly Color MESSAGE_COLOR; // 0x18
	private const float FADE_IN = 0.26f; // Metadata: 0x005F0EBE
	private const float FADE_OUT = 0.22f; // Metadata: 0x005F0EC2
	private const float HOLD_EDGE = 1.2f; // Metadata: 0x005F0EC6
	private const float MAX_ONE = 22f; // Metadata: 0x005F0ECA
	private const int QUEUE_CAP = 5; // Metadata: 0x005F0ECE
	private const float MAX_STEP = 0.1f; // Metadata: 0x005F0ECF
	private const float RUNNER_STALL_SEC = 30f; // Metadata: 0x005F0ED3
	[SerializeField]
	private Canvas canvas; // 0x20
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x28
	[SerializeField]
	private RectTransform bar; // 0x30
	[SerializeField]
	private Image plate; // 0x38
	[SerializeField]
	private RectTransform icon; // 0x40
	[SerializeField]
	private RectTransform viewport; // 0x48
	[SerializeField]
	private RectTransform line; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtSender; // 0x58
	[SerializeField]
	private UnityEngine.UI.Text txtMessage; // 0x60
	private readonly Queue<Item> _queue; // 0x68
	private Coroutine _runner; // 0x70
	private float _runnerBeat; // 0x78
	private Vector3 _iconBaseScale; // 0x7C
	private static GuildHornBannerView _instance; // 0x28

	// Properties
	public static int PendingCount { get; } // 0x0000000180789460-0x00000001807895B0 
	public static GuildHornBannerView Current { get; } // 0x00000001807895B0-0x0000000180789610 
	public int QueuedCount { get; } // 0x000000018078A3B0-0x000000018078A3D0 

	// Nested types
	private struct Item // TypeDefIndex: 1397
	{
		// Fields
		public string sender; // 0x00
		public string message; // 0x08
	}

	[CompilerGenerated]
	private sealed class _CoRun_d__59 : IEnumerator<object> // TypeDefIndex: 1398
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildHornBannerView __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoRun_d__59(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018078E850-0x000000018078EBF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018078EBF0-0x000000018078EC30
	}

	[CompilerGenerated]
	private sealed class _CoShow_d__60 : IEnumerator<object> // TypeDefIndex: 1399
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildHornBannerView __4__this; // 0x20
		public Item it; // 0x28
		private float _overflow_5__2; // 0x38
		private float _hold_5__3; // 0x3C
		private float _speed_5__4; // 0x40
		private Vector2 _home_5__5; // 0x44
		private float _dir_5__6; // 0x4C
		private float _t_5__7; // 0x50
		private float _stay_5__8; // 0x54
		private float _s_5__9; // 0x58
		private float _scroll_5__10; // 0x5C
		private float _s_5__11; // 0x60
		private float _total_5__12; // 0x64

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoShow_d__60(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018078EC30-0x000000018078F990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018078F990-0x000000018078F9D0
	}

	// Constructors
	public GuildHornBannerView(); // 0x000000018078E610-0x000000018078E7D0
	static GuildHornBannerView(); // 0x000000018078E7D0-0x000000018078E850

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180789240-0x0000000180789300
	public static bool Enqueue(string sender, string message); // 0x0000000180789300-0x0000000180789460
	private static GuildHornBannerView Ensure(); // 0x0000000180789610-0x0000000180789C30
	private void OnDestroy(); // 0x0000000180789C30-0x0000000180789E10
	private void OnDisable(); // 0x0000000180789E10-0x0000000180789E70
	private void Push(string sender, string message); // 0x0000000180789E70-0x000000018078A310
	private float Step(); // 0x000000018078A310-0x000000018078A3B0
	public void ClearQueue(); // 0x000000018078A3D0-0x000000018078A450
	[IteratorStateMachine(typeof(_CoRun_d__59))]
	private IEnumerator CoRun(); // 0x000000018078A450-0x000000018078A4F0
	[IteratorStateMachine(typeof(_CoShow_d__60))]
	private IEnumerator CoShow(Item it); // 0x000000018078A4F0-0x000000018078A600
	private void PulseIcon(float t); // 0x000000018078A600-0x000000018078A7D0
	public void Fill(string sender, string message); // 0x000000018078A7D0-0x000000018078ABB0
	private void LayoutLine(); // 0x000000018078ABB0-0x000000018078B0D0
	public float LineWidth(); // 0x000000018078B0D0-0x000000018078B2D0
	private void SetLine(float x); // 0x000000018078B2D0-0x000000018078B3E0
	public void ApplyPlacement(bool inMatch); // 0x000000018078B3E0-0x000000018078B8F0
	private static float SafeTopInset(RectTransform root); // 0x000000018078B8F0-0x000000018078BB90
	private void SetVisible(bool on); // 0x000000018078BB90-0x000000018078BDF0
	private static bool InMatch(); // 0x000000018078BDF0-0x000000018078BE20
	private static float KnobHold(); // 0x000000018078BE20-0x000000018078BEB0
	private static float KnobSpeed(); // 0x000000018078BEB0-0x000000018078BF40
	private static bool KnobInMatch(); // 0x000000018078BF40-0x000000018078BFD0
	private static float KnobFloat(string prop, float def, float lo, float hi); // 0x000000018078BFD0-0x000000018078C180
	public void BuildHierarchy(); // 0x000000018078C180-0x000000018078DA90
	private static UnityEngine.UI.Text EnsureText(Transform parent, string name, Font font, int size, Color color, FontStyle style, string sample); // 0x000000018078DA90-0x000000018078E090
	public static Sprite IconSprite(); // 0x000000018078E090-0x000000018078E100
	private static Sprite LoadSprite(string path); // 0x000000018078E100-0x000000018078E260
	private static GameObject FindOrCreate(Transform parent, string name); // 0x000000018078E260-0x000000018078E610
}

