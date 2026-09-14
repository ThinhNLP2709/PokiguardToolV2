/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class FusionPetPanelController : MonoBehaviour // TypeDefIndex: 2309
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/FusionPetPanel"; // Metadata: 0x005F0AE0
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
	public static long SavedUserPetId { get; set; } // 0x0000000180AF33E0-0x0000000180AF3430 0x0000000180AF3430-0x0000000180AF3490
	public static long SavedPetId { get; set; } // 0x0000000180AF3490-0x0000000180AF3500 0x0000000180AF3500-0x0000000180AF3570
	public static long ServerRoomSelectedUserPetId { get; } // 0x0000000180AF3A40-0x0000000180AF3AB0 
	public static string ServerRoomRejectReason { get; } // 0x0000000180AF3AB0-0x0000000180AF3B10 
	public static int PeakLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180AF4D00-0x0000000180AF4D60 0x0000000180AF4D60-0x0000000180AF4DC0

	// Events
	public static event Action OnSelectionChanged {
		add; // 0x0000000180AF37E0-0x0000000180AF3910
		remove; // 0x0000000180AF3910-0x0000000180AF3A40
	}

	// Constructors
	public FusionPetPanelController(); // 0x0000000180AFA050-0x0000000180AFA150
	static FusionPetPanelController(); // 0x0000000180AFA150-0x0000000180AFA310

	// Methods
	private static long ReadSaved(string suffix); // 0x0000000180AF3570-0x0000000180AF36B0
	private static void WriteSaved(string suffix, long value); // 0x0000000180AF36B0-0x0000000180AF37E0
	public static bool IsSelectionConfirmedByServer(); // 0x0000000180AF3B10-0x0000000180AF3BB0
	private static WsPlayerStateDTO GetMyRoomState(); // 0x0000000180AF3BB0-0x0000000180AF3C80
	public static bool PushSavedSelection(string caller); // 0x0000000180AF3C80-0x0000000180AF3EE0
	public static void HandleBattlePetChanged(int oldPetId, int newPetId); // 0x0000000180AF3EE0-0x0000000180AF41E0
	public static void HandleServerReject(string reason); // 0x0000000180AF41E0-0x0000000180AF44B0
	public static string DescribeReason(string reason); // 0x0000000180AF44B0-0x0000000180AF47A0
	private static string SavedKey(); // 0x0000000180AF47A0-0x0000000180AF48B0
	private static string LoginIdentity(); // 0x0000000180AF48B0-0x0000000180AF4940
	private static void MigrateLegacyKeyOnce(string user); // 0x0000000180AF4940-0x0000000180AF4D00
	public static void Open(); // 0x0000000180AF4DC0-0x0000000180AF54D0
	private static Canvas FindHostCanvas(); // 0x0000000180AF54D0-0x0000000180AF5750
	private void Awake(); // 0x0000000180AF5750-0x0000000180AF5800
	private void OnEnable(); // 0x0000000180AF5800-0x0000000180AF5CF0
	private bool RecomputeFitScale(); // 0x0000000180AF5CF0-0x0000000180AF6210
	public void ApplyWindowFit(); // 0x0000000180AF6210-0x0000000180AF66F0
	private void OnRectTransformDimensionsChange(); // 0x0000000180AF66F0-0x0000000180AF6830
	private void OnDisable(); // 0x0000000180AF6830-0x0000000180AF6A90
	private void OnDestroy(); // 0x0000000180AF6A90-0x0000000180AF6D20
	public void Close(); // 0x0000000180AF6D20-0x0000000180AF6DC0
	private void RequestList(); // 0x0000000180AF6DC0-0x0000000180AF6E60
	private void HandleFusionList(ChatMessageDTO m); // 0x0000000180AF6E60-0x0000000180AF85C0
	private void OnRowSelected(FusionPetRowUI row); // 0x0000000180AF85C0-0x0000000180AF8B30
	private void ClearRows(); // 0x0000000180AF8B30-0x0000000180AF8DB0
	private void SetStatus(string text); // 0x0000000180AF8DB0-0x0000000180AF8F60
	public static string ElementVn(string element); // 0x0000000180AF8F60-0x0000000180AF9010
	private static string ReadStr(Dictionary<string, object> p, string key); // 0x0000000180AF9010-0x0000000180AF90B0
	private static int ReadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x005F0AD7 */); // 0x0000000180AF90B0-0x0000000180AF91F0
	private static long ReadLong(Dictionary<string, object> p, string key, long fb = 0 /* Metadata: 0x005F0AD8 */); // 0x0000000180AF91F0-0x0000000180AF9330
	private static bool ReadBool(Dictionary<string, object> p, string key); // 0x0000000180AF9330-0x0000000180AF94B0
	private void AutoFindRefs(); // 0x0000000180AF94B0-0x0000000180AFA050
}

