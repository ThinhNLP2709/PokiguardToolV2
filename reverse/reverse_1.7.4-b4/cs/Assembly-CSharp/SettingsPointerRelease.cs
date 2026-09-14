/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class SettingsPointerRelease : MonoBehaviour, IPointerUpHandler, IPointerDownHandler // TypeDefIndex: 1235
{
	// Fields
	[NonSerialized]
	public Action Pressed; // 0x20
	[NonSerialized]
	public Action Released; // 0x28

	// Constructors
	public SettingsPointerRelease(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void OnPointerDown(PointerEventData eventData); // 0x0000000180337920-0x0000000180337940
	public void OnPointerUp(PointerEventData eventData); // 0x000000018029FCA0-0x000000018029FCC0
}

