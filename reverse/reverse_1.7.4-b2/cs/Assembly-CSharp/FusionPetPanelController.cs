/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class FusionPetPanelController : MonoBehaviour // TypeDefIndex: 1943
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/FusionPetPanel"; // Metadata: 0x0068DD08
	private static FusionPetPanelController _active; // 0x00
	[CompilerGenerated]
	private static Action OnSelectionChanged; // 0x08
	private static string _migratedFor; // 0x10
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtHint; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtStatus; // 0x30
	[SerializeField]
	private Button btnClose; // 0x38
	[SerializeField]
	private Transform content; // 0x40
	[SerializeField]
	private GameObject rowTemplate; // 0x48
	[SerializeField]
	private GameObject window; // 0x50
	private readonly List<FusionPetRowUI> _rows; // 0x58
	private long _selectedUserPetId; // 0x60
	private bool _legendNoticeShown; // 0x68
	private float _fitScale; // 0x6C

	// Properties
	public static long SavedUserPetId { get; set; } // 0x0000000180703290-0x00000001807032A0 0x0000000180703440-0x00000001807034A0
	public static long SavedPetId { get; set; } // 0x0000000180703250-0x0000000180703290 0x00000001807033B0-0x0000000180703440
	public static long ServerRoomSelectedUserPetId { get; } // 0x00000001807032C0-0x00000001807032F0 
	public static string ServerRoomRejectReason { get; } // 0x00000001807032A0-0x00000001807032C0 

	// Events
	public static event Action OnSelectionChanged {
		add; // 0x0000000180703190-0x0000000180703250
		remove; // 0x00000001807032F0-0x00000001807033B0
	}

	// Constructors
	public FusionPetPanelController(); // 0x0000000180703110-0x0000000180703190

	// Methods
	private static long ReadSaved(string suffix); // 0x0000000180702A20-0x0000000180702AC0
	private static void WriteSaved(string suffix, long value); // 0x00000001807030A0-0x0000000180703110
	public static bool IsSelectionConfirmedByServer(); // 0x0000000180701430-0x0000000180701490
	private static WsPlayerStateDTO GetMyRoomState(); // 0x00000001806FFFC0-0x0000000180700090
	public static bool PushSavedSelection(string caller); // 0x00000001807025E0-0x00000001807027A0
	public static void HandleBattlePetChanged(int oldPetId, int newPetId); // 0x0000000180700090-0x0000000180700330
	public static void HandleServerReject(string reason); // 0x0000000180701230-0x0000000180701430
	public static string DescribeReason(string reason); // 0x00000001806FFCD0-0x00000001806FFDF0
	private static string SavedKey(); // 0x0000000180702EF0-0x0000000180702FC0
	private static string LoginIdentity(); // 0x0000000180701490-0x0000000180701510
	private static void MigrateLegacyKeyOnce(string user); // 0x0000000180701510-0x0000000180701830
	public static void Open(); // 0x0000000180702110-0x00000001807025E0
	private static Canvas FindHostCanvas(); // 0x00000001806FFE90-0x00000001806FFFC0
	private void Awake(); // 0x00000001806FFA70-0x00000001806FFAD0
	private void OnEnable(); // 0x0000000180701A10-0x0000000180701CF0
	private bool RecomputeFitScale(); // 0x0000000180702B50-0x0000000180702E60
	public void ApplyWindowFit(); // 0x00000001806FF460-0x00000001806FF720
	private void OnRectTransformDimensionsChange(); // 0x0000000180701CF0-0x0000000180701D70
	private void OnDisable(); // 0x0000000180701920-0x0000000180701A10
	private void OnDestroy(); // 0x0000000180701830-0x0000000180701920
	public void Close(); // 0x00000001806FFC70-0x00000001806FFCD0
	private void RequestList(); // 0x0000000180702E60-0x0000000180702EF0
	private void HandleFusionList(ChatMessageDTO m); // 0x0000000180700330-0x0000000180701230
	private void OnRowSelected(FusionPetRowUI row); // 0x0000000180701D70-0x0000000180702110
	private void ClearRows(); // 0x00000001806FFAD0-0x00000001806FFC70
	private void SetStatus(string text); // 0x0000000180702FC0-0x00000001807030A0
	public static string ElementVn(string element); // 0x00000001806FFDF0-0x00000001806FFE90
	private static string ReadStr(Dictionary<string, object> p, string key); // 0x0000000180702AC0-0x0000000180702B50
	private static int ReadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x0068DCFF */); // 0x00000001807028C0-0x0000000180702970
	private static long ReadLong(Dictionary<string, object> p, string key, long fb = 0 /* Metadata: 0x0068DD00 */); // 0x0000000180702970-0x0000000180702A20
	private static bool ReadBool(Dictionary<string, object> p, string key); // 0x00000001807027A0-0x00000001807028C0
	private void AutoFindRefs(); // 0x00000001806FF720-0x00000001806FFA70
}

