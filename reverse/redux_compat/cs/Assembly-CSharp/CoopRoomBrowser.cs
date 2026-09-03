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

public class CoopRoomBrowser : MonoBehaviour // TypeDefIndex: 9
{
	// Fields
	private const string ROOM_TYPE = "ChinhPhuc"; // Metadata: 0x0064BF04
	private const int COOP_CAP_FALLBACK = 3; // Metadata: 0x0064BF0E
	private const string PANEL_PREFAB_PATH = "Prefabs/UI/CoopRoomListPanel"; // Metadata: 0x0064BF0F
	private ManagerChinhPhuc _host; // 0x20
	private GameObject _openButton; // 0x28
	private GameObject _panelRoot; // 0x30
	private Transform _content; // 0x38
	private UnityEngine.UI.Text _txtEmpty; // 0x40
	private GameObject _rowTemplate; // 0x48
	private bool _panelOpen; // 0x50
	private bool _listening; // 0x51
	private float _resubCheckAt; // 0x54
	private Font _font; // 0x58

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 10
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<RoomSummaryDTO, bool> __9__24_0; // 0x08
		public static Comparison<RoomSummaryDTO> __9__24_1; // 0x10

		// Constructors
		static __c(); // 0x00000001802FB130-0x00000001802FB1A0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _RebuildList_b__24_0(RoomSummaryDTO r); // 0x00000001802FAB60-0x00000001802FABC0
		internal int _RebuildList_b__24_1(RoomSummaryDTO a, RoomSummaryDTO b); // 0x00000001802FABC0-0x00000001802FAC70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 11
	{
		// Fields
		public CoopRoomBrowser __4__this; // 0x10
		public string capturedId; // 0x18
		public int capPetId; // 0x20
		public int capPetLv; // 0x24

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CreateRow_b__0(); // 0x00000001802FACD0-0x00000001802FAED0
	}

	// Constructors
	public CoopRoomBrowser(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static void EnsureAttached(ManagerChinhPhuc host); // 0x00000001802EC080-0x00000001802EC170
	private void OnDisable(); // 0x00000001802ECCF0-0x00000001802ECD00
	private void OnDestroy(); // 0x00000001802ECCE0-0x00000001802ECCF0
	private void Update(); // 0x00000001802ED980-0x00000001802EDAF0
	private void Subscribe(WsRoomService ws); // 0x00000001802ED6B0-0x00000001802ED7B0
	private void AttachListEvents(); // 0x00000001802E9830-0x00000001802E98D0
	private void DetachListEvents(); // 0x00000001802EBFE0-0x00000001802EC080
	public void TogglePanel(); // 0x00000001802ED7B0-0x00000001802ED940
	public void OpenPanel(); // 0x00000001802ECEF0-0x00000001802ED070
	public void ClosePanel(); // 0x00000001802EAC60-0x00000001802EAD10
	private void OnJoinClicked(string roomId, int enemyPetId, int enemyPetLevel); // 0x00000001802ECD00-0x00000001802ECEF0
	private void RebuildList(); // 0x00000001802ED070-0x00000001802ED640
	private static bool IsJoinable(RoomSummaryDTO room); // 0x00000001802ECCB0-0x00000001802ECCE0
	private void CreateRow(RoomSummaryDTO room); // 0x00000001802EAF10-0x00000001802EBD10
	private void EnsureOpenButton(); // 0x00000001802EC170-0x00000001802EC9C0
	private void BuildPanel(); // 0x00000001802E9D30-0x00000001802EAC60
	private void BuildPanelFromPrefab(GameObject prefab, Canvas canvas); // 0x00000001802E98D0-0x00000001802E9D30
	private static Transform FindDeep(Transform root, string name); // 0x00000001802EC9C0-0x00000001802ECAB0
	private static GameObject CreateRect(string name, Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 size); // 0x00000001802EAD10-0x00000001802EAF10
	private static void SetRect(RectTransform rt, Vector2 anchorMin, Vector2 anchorMax, Vector2 offsetMin, Vector2 offsetMax); // 0x00000001802ED640-0x00000001802ED6B0
	private UnityEngine.UI.Text CreateText(Transform parent, string content, int fontSize, TextAnchor anchor); // 0x00000001802EBD10-0x00000001802EBFE0
	private Font GetFont(); // 0x00000001802ECAB0-0x00000001802ECB30
	private static int GetPropInt(Dictionary<string, object> props, string key); // 0x00000001802ECB30-0x00000001802ECBF0
	private static string GetPropString(Dictionary<string, object> props, string key); // 0x00000001802ECBF0-0x00000001802ECCB0
	[CompilerGenerated]
	private void _BuildPanel_b__28_0(); // 0x00000001802ED940-0x00000001802ED980
	[CompilerGenerated]
	private void _BuildPanelFromPrefab_b__29_0(); // 0x00000001802ED940-0x00000001802ED980
}

