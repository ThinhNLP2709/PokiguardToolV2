/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class FusionPetPanelController : MonoBehaviour // TypeDefIndex: 1670
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/FusionPetPanel"; // Metadata: 0x0064D8D9
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

	// Properties
	public static long SavedUserPetId { get; set; } // 0x00000001805D8E80-0x00000001805D8E90 0x00000001805D9030-0x00000001805D9090
	public static long SavedPetId { get; set; } // 0x00000001805D8E40-0x00000001805D8E80 0x00000001805D8FA0-0x00000001805D9030
	public static long ServerRoomSelectedUserPetId { get; } // 0x00000001805D8EB0-0x00000001805D8EE0 
	public static string ServerRoomRejectReason { get; } // 0x00000001805D8E90-0x00000001805D8EB0 

	// Events
	public static event Action OnSelectionChanged {
		add; // 0x00000001805D8D80-0x00000001805D8E40
		remove; // 0x00000001805D8EE0-0x00000001805D8FA0
	}

	// Constructors
	public FusionPetPanelController(); // 0x00000001805D8D00-0x00000001805D8D80

	// Methods
	private static long ReadSaved(string suffix); // 0x00000001805D8920-0x00000001805D89C0
	private static void WriteSaved(string suffix, long value); // 0x00000001805D8C90-0x00000001805D8D00
	public static bool IsSelectionConfirmedByServer(); // 0x00000001805D7400-0x00000001805D7460
	private static WsPlayerStateDTO GetMyRoomState(); // 0x00000001805D6020-0x00000001805D60F0
	public static bool PushSavedSelection(string caller); // 0x00000001805D84E0-0x00000001805D86A0
	public static void HandleBattlePetChanged(int oldPetId, int newPetId); // 0x00000001805D60F0-0x00000001805D6390
	public static void HandleServerReject(string reason); // 0x00000001805D7200-0x00000001805D7400
	public static string DescribeReason(string reason); // 0x00000001805D5C10-0x00000001805D5D30
	private static string SavedKey(); // 0x00000001805D8AE0-0x00000001805D8BB0
	private static string LoginIdentity(); // 0x00000001805D7460-0x00000001805D74E0
	private static void MigrateLegacyKeyOnce(string user); // 0x00000001805D74E0-0x00000001805D7800
	public static void Open(); // 0x00000001805D8020-0x00000001805D84E0
	private static Canvas FindHostCanvas(); // 0x00000001805D5EF0-0x00000001805D6020
	private void Awake(); // 0x00000001805D59B0-0x00000001805D5A10
	private void OnEnable(); // 0x00000001805D79E0-0x00000001805D7C80
	private void OnDisable(); // 0x00000001805D78F0-0x00000001805D79E0
	private void OnDestroy(); // 0x00000001805D7800-0x00000001805D78F0
	public void Close(); // 0x00000001805D5BB0-0x00000001805D5C10
	private void RequestList(); // 0x00000001805D8A50-0x00000001805D8AE0
	private void HandleFusionList(ChatMessageDTO m); // 0x00000001805D6390-0x00000001805D7200
	private void OnRowSelected(FusionPetRowUI row); // 0x00000001805D7C80-0x00000001805D8020
	private void ClearRows(); // 0x00000001805D5A10-0x00000001805D5BB0
	private void SetStatus(string text); // 0x00000001805D8BB0-0x00000001805D8C90
	public static string ElementVn(string element); // 0x00000001805D5D30-0x00000001805D5EF0
	private static string ReadStr(Dictionary<string, object> p, string key); // 0x00000001805D89C0-0x00000001805D8A50
	private static int ReadInt(Dictionary<string, object> p, string key, int fb = 0 /* Metadata: 0x0064D8D0 */); // 0x00000001805D87C0-0x00000001805D8870
	private static long ReadLong(Dictionary<string, object> p, string key, long fb = 0 /* Metadata: 0x0064D8D1 */); // 0x00000001805D8870-0x00000001805D8920
	private static bool ReadBool(Dictionary<string, object> p, string key); // 0x00000001805D86A0-0x00000001805D87C0
	private void AutoFindRefs(); // 0x00000001805D5660-0x00000001805D59B0
}

