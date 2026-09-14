/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ShowNotice : MonoBehaviour // TypeDefIndex: 2151
{
	// Fields
	public GameObject notice; // 0x20
	public Button showButton; // 0x28
	public Button cancleNotice; // 0x30
	[Tooltip("G\u1ECDi m\u1ED7i khi panel chuy\u1EC3n t\u1EEB inactive \u2192 active (d\u00F9ng \u0111\u1EC3 lazy-load d\u1EEF li\u1EC7u)")]
	public UnityEvent onOpened; // 0x38

	// Constructors
	public ShowNotice(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Start(); // 0x0000000180A215E0-0x0000000180A21820
	private void ToggleNotice(); // 0x0000000180A21820-0x0000000180A21A10
}

