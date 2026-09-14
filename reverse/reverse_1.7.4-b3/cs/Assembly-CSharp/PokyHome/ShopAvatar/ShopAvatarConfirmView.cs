/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.ShopAvatar
{
	public class ShopAvatarConfirmView // TypeDefIndex: 2751
	{
		// Fields
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
		public bool IsOpen { get; } // 0x0000000180CA4F50-0x0000000180CA50A0 
		public bool EquipNow { get; } // 0x0000000180CA50A0-0x0000000180CA5220 
	
		// Events
		public event Action Confirmed {
			add; // 0x0000000180CA5220-0x0000000180CA5310
			remove; // 0x0000000180CA5310-0x0000000180CA5400
		}
	
		// Constructors
		public ShopAvatarConfirmView(); // 0x000000018028A320-0x000000018028A330
	
		// Methods
		public void AutoWire(Transform panelRoot, MonoBehaviour host, Action<string> reportMissing); // 0x0000000180CA5400-0x0000000180CA6280
		private void OnOk(); // 0x0000000180CA6280-0x0000000180CA6300
		private void OnCancel(); // 0x0000000180CA6300-0x0000000180CA6390
		public void Show(string title, string body, string iconPath, bool showEquipNow, bool equipNowDefault); // 0x0000000180CA6390-0x0000000180CA6D10
		public void Hide(); // 0x0000000180CA6D10-0x0000000180CA6EC0
		public void SetBusy(bool busy); // 0x0000000180CA6EC0-0x0000000180CA6FD0
		private Transform Build(Transform panelRoot); // 0x0000000180CA6FD0-0x0000000180CA8250
		private void BuildToggle(RectTransform shell); // 0x0000000180CA8250-0x0000000180CA8A10
		private void BuildButton(RectTransform shell, string name, Vector2 pos, Vector2 size, string label, Color tint); // 0x0000000180CA8A10-0x0000000180CA91B0
		private static Image MakeImage(RectTransform parent, string name, Vector2 anchorMin, Vector2 anchorMax, Vector2 pos, Vector2 size); // 0x0000000180CA91B0-0x0000000180CA96E0
		private static UnityEngine.UI.Text MakeText(RectTransform parent, string name, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 pos, Vector2 size, int fontSize, Color color, TextAnchor align); // 0x0000000180CA96E0-0x0000000180CA9D90
		private static Image FindImage(Transform scope, string name); // 0x0000000180CA9D90-0x0000000180CA9EE0
		private static UnityEngine.UI.Text FindText(Transform scope, string name); // 0x0000000180CA9EE0-0x0000000180CAA030
		private static void NoRichText(UnityEngine.UI.Text t); // 0x0000000180CAA030-0x0000000180CAA150
	}
}
