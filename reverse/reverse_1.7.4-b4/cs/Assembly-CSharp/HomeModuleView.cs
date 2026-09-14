/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class HomeModuleView : MonoBehaviour // TypeDefIndex: 978
{
	// Fields
	[Header("D\u1EEF li\u1EC7u (builder ghi t\u1EEB HomeModuleConfig)")]
	public string moduleId; // 0x20
	public string label; // 0x28
	public string routeKey; // 0x30
	public string flagKey; // 0x38
	public int requireLevel; // 0x40
	public HomeNotifySource notifySource; // 0x44
	[Header("Tham chi\u1EBFu")]
	public HomePressScale press; // 0x48
	public Image icon; // 0x50
	public Sprite normalSprite; // 0x58
	public Sprite lockedSprite; // 0x60
	public GameObject lockIcon; // 0x68
	public UnityEngine.UI.Text labelText; // 0x70
	public HomeNotifyBadge badge; // 0x78
	[Tooltip("Node ch\u1EE9a hi\u1EC7u \u1EE9ng idle \u2014 t\u1EAFt khi \u00F4 b\u1ECB kho\u00E1 cho \u0111\u1EE1 m\u1EDDi g\u1ECDi sai ch\u1ED7.")]
	public GameObject fxRoot; // 0x80
	private bool _locked; // 0x88
	private bool _hooked; // 0x89
	private bool _applied; // 0x8A

	// Properties
	public bool IsLocked { get; } // 0x00000001803C6DC0-0x00000001803C6DD0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 979
	{
		// Fields
		public Transform t; // 0x10
		public float x; // 0x18

		// Constructors
		public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakeLocked_b__0(); // 0x00000001805EC3D0-0x00000001805EC5D0
	}

	// Constructors
	public HomeModuleView(); // 0x00000001805EC380-0x00000001805EC3D0

	// Methods
	private void Awake(); // 0x00000001805EAE80-0x00000001805EB0D0
	private void OnDestroy(); // 0x00000001805EB0D0-0x00000001805EB230
	public void Bind(HomeModuleDef def); // 0x00000001805EB230-0x00000001805EB4C0
	public void ApplyUserLevel(int userLevel); // 0x00000001805EB4C0-0x00000001805EBC00
	public void SetNotify(int count); // 0x00000001805EBC00-0x00000001805EBD10
	public void ShakeLocked(); // 0x00000001805EBD10-0x00000001805EC0F0
	private void HandleClick(); // 0x00000001805EC0F0-0x00000001805EC380
}

