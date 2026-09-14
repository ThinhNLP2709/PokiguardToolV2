/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyShopAvatarCell : MonoBehaviour // TypeDefIndex: 2693
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
		public PokyShopAvatarCell(); // 0x0000000180C49800-0x0000000180C49860
		static PokyShopAvatarCell(); // 0x0000000180C49860-0x0000000180C498B0
	
		// Methods
		public void Bind(string displayName, string spritePath, int atk, int hp, int mana); // 0x0000000180C48980-0x0000000180C48FF0
		public void SetOwned(bool owned); // 0x0000000180C48FF0-0x0000000180C49210
		private void SetAvatar(string path); // 0x0000000180C49210-0x0000000180C49480
		private void ShowLoading(bool on); // 0x0000000180C49480-0x0000000180C49640
		private void Update(); // 0x0000000180C49640-0x0000000180C497F0
		private void OnDisable(); // 0x0000000180C497F0-0x0000000180C49800
	}
}
