/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.ShopAvatar
{
	public class ShopAvatarConfirmView // TypeDefIndex: 2315
	{
		// Fields
		public const string N_ROOT = "sec_Confirm"; // Metadata: 0x0068E755
		public const string N_BLOCKER = "img_Blocker"; // Metadata: 0x0068E761
		public const string N_SHELL = "img_Shell"; // Metadata: 0x0068E76D
		public const string N_TITLE = "txt_ConfirmTitle"; // Metadata: 0x0068E777
		public const string N_ICON = "img_ConfirmIcon"; // Metadata: 0x0068E788
		public const string N_BODY = "txt_ConfirmBody"; // Metadata: 0x0068E798
		public const string N_EQUIP_NOW = "tog_EquipNow"; // Metadata: 0x0068E7A8
		public const string N_OK = "btn_Ok"; // Metadata: 0x0068E7B5
		public const string N_CANCEL = "btn_Cancel"; // Metadata: 0x0068E7BC
		public const string N_TOGGLE_BOX = "img_Box"; // Metadata: 0x0068E7C7
		public const string N_TOGGLE_CHECK = "img_Check"; // Metadata: 0x0068E7CF
		public const string N_LABEL = "txt_Label"; // Metadata: 0x0068E7D9
		private MonoBehaviour _host; // 0x10
		public GameObject root; // 0x18
		public Image imgBlocker; // 0x20
		public Image imgShell; // 0x28
		public UnityEngine.UI.Text txtTitle; // 0x30
		public Image imgIcon; // 0x38
		public UnityEngine.UI.Text txtBody; // 0x40
		public Toggle togEquipNow; // 0x48
		public UnityEngine.UI.Text txtEquipNowLabel; // 0x50
		public Button btnOk; // 0x58
		public Button btnCancel; // 0x60
		public UnityEngine.UI.Text txtOkLabel; // 0x68
		public UnityEngine.UI.Text txtCancelLabel; // 0x70
		[CompilerGenerated]
		private Action Confirmed; // 0x78
		[CompilerGenerated]
		private Action Cancelled; // 0x80
	
		// Properties
		public bool IsOpen { get; } // 0x00000001807BE5F0-0x00000001807BE670 
		public bool EquipNow { get; } // 0x00000001807BE540-0x00000001807BE5F0 
	
		// Events
		public event Action Confirmed {
			add; // 0x00000001807BE4A0-0x00000001807BE540
			remove; // 0x00000001807BE720-0x00000001807BE7C0
		}
		public event Action Cancelled {
			add; // 0x00000001807BE3F0-0x00000001807BE4A0
			remove; // 0x00000001807BE670-0x00000001807BE720
		}
	
		// Constructors
		public ShopAvatarConfirmView(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
		// Methods
		public void AutoWire(Transform panelRoot, MonoBehaviour host, Action<string> reportMissing); // 0x00000001807BB480-0x00000001807BBC90
		private void OnOk(); // 0x00000001807BDEE0-0x00000001807BDF60
		private void OnCancel(); // 0x00000001807BDE60-0x00000001807BDEE0
		public void Show(string title, string body, string iconPath, bool showEquipNow, bool equipNowDefault); // 0x00000001807BDFF0-0x00000001807BE3F0
		public void Hide(); // 0x00000001807BD5A0-0x00000001807BD630
		public void SetBusy(bool busy); // 0x00000001807BDF60-0x00000001807BDFF0
		private Transform Build(Transform panelRoot); // 0x00000001807BC780-0x00000001807BD400
		private void BuildToggle(RectTransform shell); // 0x00000001807BC200-0x00000001807BC780
		private void BuildButton(RectTransform shell, string name, Vector2 pos, Vector2 size, string label, Color tint); // 0x00000001807BBC90-0x00000001807BC200
		private static Image MakeImage(RectTransform parent, string name, Vector2 anchorMin, Vector2 anchorMax, Vector2 pos, Vector2 size); // 0x00000001807BD630-0x00000001807BD9E0
		private static UnityEngine.UI.Text MakeText(RectTransform parent, string name, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 pos, Vector2 size, int fontSize, Color color, TextAnchor align); // 0x00000001807BD9E0-0x00000001807BDDF0
		private static Image FindImage(Transform scope, string name); // 0x00000001807BD400-0x00000001807BD4D0
		private static UnityEngine.UI.Text FindText(Transform scope, string name); // 0x00000001807BD4D0-0x00000001807BD5A0
		private static void NoRichText(UnityEngine.UI.Text t); // 0x00000001807BDDF0-0x00000001807BDE60
	}
}
