/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class FusionPetPanelController : MonoBehaviour // TypeDefIndex: 2316
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/FusionPetPanel"; // Metadata: 0x005F1EF7
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
	[CompilerGenerated]
	private static int _PeakLevel_k__BackingField; // 0x18
	private float _fitScale; // 0x6C

	// Properties
	public static long SavedUserPetId { get; set; } // 0x0000000180B1D500-0x0000000180B1D550 0x0000000180B1D550-0x0000000180B1D5B0
	public static long SavedPetId { get; set; } // 0x0000000180B1D5B0-0x0000000180B1D620 0x0000000180B1D620-0x0000000180B1D690
	public static long ServerRoomSelectedUserPetId { get; } // 0x0000000180B1DB60-0x0000000180B1DBD0 
	public static string ServerRoomRejectReason { get; } // 0x0000000180B1DBD0-0x0000000180B1DC30 
	public static int PeakLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B1EE20-0x0000000180B1EE80 0x0000000180B1EE80-0x0000000180B1EEE0

	// Events
	public static event Action OnSelectionChanged {
		add; // 0x0000000180B1D900-0x0000000180B1DA30
		remove; // 0x0000000180B1DA30-0x0000000180B1DB60
	}

	// Constructors
	public FusionPetPanelController(); // 0x0000000180B24170-0x0000000180B24270
	static FusionPetPanelController(); // 0x0000000180B24270-0x0000000180B242C0

	// Methods
	private static long ReadSaved(string suffix); // 0x0000000180B1D690-0x0000000180B1D7D0
	private static void WriteSaved(string suffix, long value); // 0x0000000180B1D7D0-0x0000000180B1D900
	public static bool IsSelectionConfirmedByServer(); // 0x0000000180B1DC30-0x0000000180B1DCD0
	private static WsPlayerStateDTO GetMyRoomState(); // 0x0000000180B1DCD0-0x0000000180B1DDA0
	public static bool PushSavedSelection(string caller); // 0x0000000180B1DDA0-0x0000000180B1E000
	public static void HandleBattlePetChanged(int oldPetId, int newPetId); // 0x0000000180B1E000-0x0000000180B1E300
	public static void HandleServerReject(string reason); // 0x0000000180B1E300-0x0000000180B1E5D0
	public static string DescribeReason(string reason); // 0x0000000180B1E5D0-0x0000000180B1E8C0
	private static string SavedKey(); // 0x0000000180B1E8C0-0x0000000180B1E9D0
	private static string LoginIdentity(); // 0x0000000180B1E9D0-0x0000000180B1EA60
	private static void MigrateLegacyKeyOnce(string user); // 0x0000000180B1EA60-0x0000000180B1EE20
	public static void Open(); // 0x0000000180B1EEE0-0x0000000180B1F5F0
	private static Canvas FindHostCanvas(); // 0x0000000180B1F5F0-0x0000000180B1F870
	private void Awake(); // 0x0000000180B1F870-0x0000000180B1F920
	private void OnEnable(); // 0x0000000180B1F920-0x0000000180B1FE10
	private bool RecomputeFitScale(); // 0x0000000180B1FE10-0x0000000180B20330
	public void ApplyWindowFit(); // 0x0000000180B20330-0x0000000180B20810
	private void OnRectTransformDimensionsChange(); // 0x0000000180B20810-0x0000000180B20950
	private void OnDisable(); // 0x0000000180B20950-0x0000000180B20BB0
	private void OnDestroy(); // 0x0000000180B20BB0-0x0000000180B20E40
	public void Close(); // 0x0000000180B20E40-0x0000000180B20EE0
	private void RequestList(); // 0x0000000180B20EE0-0x0000000180B20F80
	private void HandleFusionList(ChatMessageDTO m); // 0x0000000180B20F80-0x0000000180B226E0
	private void OnRowSelected(FusionPetRowUI row); // 0x0000000180B226E0-0x0000000180B22C50
	private void ClearRows(); // 0x0000000180B22C50-0x0000000180B22ED0
	private void SetStatus(string text); // 0x0000000180B22ED0-0x0000000180B23080
	public static string ElementVn(string element); // 0x0000000180B23080-0x0000000180B23130
	private static string ReadStr(Dictionary<string, object> p, string key); // 0x0000000180B23130-0x0000000180B231D0
	private static int ReadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x005F1EEE */); // 0x0000000180B231D0-0x0000000180B23310
	private static long ReadLong(Dictionary<string, object> p, string key, long fb = 0 /* Metadata: 0x005F1EEF */); // 0x0000000180B23310-0x0000000180B23450
	private static bool ReadBool(Dictionary<string, object> p, string key); // 0x0000000180B23450-0x0000000180B235D0
	private void AutoFindRefs(); // 0x0000000180B235D0-0x0000000180B24170
}

