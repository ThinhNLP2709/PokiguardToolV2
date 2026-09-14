/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class LoginFieldFocus : MonoBehaviour, ISelectHandler, IDeselectHandler // TypeDefIndex: 1052
{
	// Fields
	[NonSerialized]
	public Action Selected; // 0x20
	[NonSerialized]
	public Action Deselected; // 0x28

	// Constructors
	public LoginFieldFocus(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void OnSelect(BaseEventData eventData); // 0x0000000180337800-0x0000000180337820
	public void OnDeselect(BaseEventData eventData); // 0x000000018029FCA0-0x000000018029FCC0
}

