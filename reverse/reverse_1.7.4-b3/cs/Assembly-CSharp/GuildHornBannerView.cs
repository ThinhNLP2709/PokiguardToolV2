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
public class GuildHornBannerView : MonoBehaviour // TypeDefIndex: 1394
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/GuildHornBanner"; // Metadata: 0x005EFA63
	public const int SORTING_ORDER = 9400; // Metadata: 0x005EFA7E
	public static readonly Vector2 REF_RESOLUTION; // 0x00
	public const string ICON_PATH = "Image/GuildHorn/horn_icon"; // Metadata: 0x005EFA82
	public const string PLATE_PATH = "Image/GuildHorn/horn_plate"; // Metadata: 0x005EFA9C
	public const float BAR_H = 76f; // Metadata: 0x005EFAB7
	public const float ICON_D = 100f; // Metadata: 0x005EFABB
	public const float ICON_X = -22f; // Metadata: 0x005EFABF
	public const float TEXT_L = 92f; // Metadata: 0x005EFAC3
	public const float TEXT_R = 30f; // Metadata: 0x005EFAC7
	public const float EDGE_Y = 10f; // Metadata: 0x005EFACB
	public const float SLIDE = 26f; // Metadata: 0x005EFACF
	public const int FS_SENDER = 26; // Metadata: 0x005EFAD3
	public const int FS_MESSAGE = 27; // Metadata: 0x005EFAD4
	public const float GAP = 10f; // Metadata: 0x005EFAD5
	public const float W_FRAC_HUB = 0.62f; // Metadata: 0x005EFAD9
	public const float W_MIN_HUB = 640f; // Metadata: 0x005EFADD
	public const float W_MAX_HUB = 1180f; // Metadata: 0x005EFAE1
	public const float W_FRAC_MATCH = 0.5f; // Metadata: 0x005EFAE5
	public const float W_MIN_MATCH = 560f; // Metadata: 0x005EFAE9
	public const float W_MAX_MATCH = 900f; // Metadata: 0x005EFAED
	public static readonly Color SENDER_COLOR; // 0x08
	public static readonly Color MESSAGE_COLOR; // 0x18
	private const float FADE_IN = 0.26f; // Metadata: 0x005EFAF1
	private const float FADE_OUT = 0.22f; // Metadata: 0x005EFAF5
	private const float HOLD_EDGE = 1.2f; // Metadata: 0x005EFAF9
	private const float MAX_ONE = 22f; // Metadata: 0x005EFAFD
	private const int QUEUE_CAP = 5; // Metadata: 0x005EFB01
	private const float MAX_STEP = 0.1f; // Metadata: 0x005EFB02
	private const float RUNNER_STALL_SEC = 30f; // Metadata: 0x005EFB06
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
	public static int PendingCount { get; } // 0x0000000180787510-0x0000000180787660 
	public static GuildHornBannerView Current { get; } // 0x0000000180787660-0x00000001807876C0 
	public int QueuedCount { get; } // 0x0000000180788460-0x0000000180788480 

	// Nested types
	private struct Item // TypeDefIndex: 1395
	{
		// Fields
		public string sender; // 0x00
		public string message; // 0x08
	}

	[CompilerGenerated]
	private sealed class _CoRun_d__59 : IEnumerator<object> // TypeDefIndex: 1396
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018078C900-0x000000018078CCA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018078CCA0-0x000000018078CCE0
	}

	[CompilerGenerated]
	private sealed class _CoShow_d__60 : IEnumerator<object> // TypeDefIndex: 1397
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018078CCE0-0x000000018078DA40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018078DA40-0x000000018078DA80
	}

	// Constructors
	public GuildHornBannerView(); // 0x000000018078C6C0-0x000000018078C880
	static GuildHornBannerView(); // 0x000000018078C880-0x000000018078C900

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x00000001807872F0-0x00000001807873B0
	public static bool Enqueue(string sender, string message); // 0x00000001807873B0-0x0000000180787510
	private static GuildHornBannerView Ensure(); // 0x00000001807876C0-0x0000000180787CE0
	private void OnDestroy(); // 0x0000000180787CE0-0x0000000180787EC0
	private void OnDisable(); // 0x0000000180787EC0-0x0000000180787F20
	private void Push(string sender, string message); // 0x0000000180787F20-0x00000001807883C0
	private float Step(); // 0x00000001807883C0-0x0000000180788460
	public void ClearQueue(); // 0x0000000180788480-0x0000000180788500
	[IteratorStateMachine(typeof(_CoRun_d__59))]
	private IEnumerator CoRun(); // 0x0000000180788500-0x00000001807885A0
	[IteratorStateMachine(typeof(_CoShow_d__60))]
	private IEnumerator CoShow(Item it); // 0x00000001807885A0-0x00000001807886B0
	private void PulseIcon(float t); // 0x00000001807886B0-0x0000000180788880
	public void Fill(string sender, string message); // 0x0000000180788880-0x0000000180788C60
	private void LayoutLine(); // 0x0000000180788C60-0x0000000180789180
	public float LineWidth(); // 0x0000000180789180-0x0000000180789380
	private void SetLine(float x); // 0x0000000180789380-0x0000000180789490
	public void ApplyPlacement(bool inMatch); // 0x0000000180789490-0x00000001807899A0
	private static float SafeTopInset(RectTransform root); // 0x00000001807899A0-0x0000000180789C40
	private void SetVisible(bool on); // 0x0000000180789C40-0x0000000180789EA0
	private static bool InMatch(); // 0x0000000180789EA0-0x0000000180789ED0
	private static float KnobHold(); // 0x0000000180789ED0-0x0000000180789F60
	private static float KnobSpeed(); // 0x0000000180789F60-0x0000000180789FF0
	private static bool KnobInMatch(); // 0x0000000180789FF0-0x000000018078A080
	private static float KnobFloat(string prop, float def, float lo, float hi); // 0x000000018078A080-0x000000018078A230
	public void BuildHierarchy(); // 0x000000018078A230-0x000000018078BB40
	private static UnityEngine.UI.Text EnsureText(Transform parent, string name, Font font, int size, Color color, FontStyle style, string sample); // 0x000000018078BB40-0x000000018078C140
	public static Sprite IconSprite(); // 0x000000018078C140-0x000000018078C1B0
	private static Sprite LoadSprite(string path); // 0x000000018078C1B0-0x000000018078C310
	private static GameObject FindOrCreate(Transform parent, string name); // 0x000000018078C310-0x000000018078C6C0
}

