/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyShopAvatarCell : MonoBehaviour // TypeDefIndex: 1931
	{
		// Fields
		[Header("G\u1ED1c \u00F4")]
		public Button button; // 0x20
		public Image frame; // 0x28
		[Header("N\u1ED9i dung")]
		public Image imgAvatar; // 0x30
		public GameObject txtLoading; // 0x38
		public UnityEngine.UI.Text txtName; // 0x40
		public UnityEngine.UI.Text txtAtk; // 0x48
		public UnityEngine.UI.Text txtHp; // 0x50
		public UnityEngine.UI.Text txtMana; // 0x58
		public UnityEngine.UI.Text txtPrice; // 0x60
		private static readonly Color OwnedTint; // 0x00
		private Color _frameTint; // 0x68
		private bool _tintCaptured; // 0x78
		private bool _waitingSprite; // 0x79
	
		// Constructors
		public PokyShopAvatarCell(); // 0x000000018064D6D0-0x000000018064D6F0
		static PokyShopAvatarCell(); // 0x000000018064D690-0x000000018064D6D0
	
		// Methods
		public void Bind(string displayName, string spritePath, int atk, int hp, int mana); // 0x000000018064CEF0-0x000000018064D2D0
		public void SetOwned(bool owned); // 0x000000018064D440-0x000000018064D550
		private void SetAvatar(string path); // 0x000000018064D2E0-0x000000018064D440
		private void ShowLoading(bool on); // 0x000000018064D550-0x000000018064D5F0
		private void Update(); // 0x000000018064D5F0-0x000000018064D690
		private void OnDisable(); // 0x000000018064D2D0-0x000000018064D2E0
	}
}
