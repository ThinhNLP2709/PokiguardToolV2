/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ChatImageTap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler // TypeDefIndex: 441
{
	// Fields
	public string imageId; // 0x20
	public int imageW; // 0x28
	public int imageH; // 0x2C
	public long expiresAtMs; // 0x30
	public GameObject row; // 0x38
	private ChatRowLongPress _press; // 0x40
	private float _downAt; // 0x48

	// Constructors
	public ChatImageTap(); // 0x000000018036FF30-0x000000018036FF40

	// Methods
	public void Setup(GameObject rowGO, string id, int w, int h, long expires); // 0x000000018036FE10-0x000000018036FF30
	public void OnPointerDown(PointerEventData eventData); // 0x000000018036FC90-0x000000018036FD80
	public void OnPointerUp(PointerEventData eventData); // 0x000000018036FD80-0x000000018036FE10
	public void OnPointerClick(PointerEventData eventData); // 0x000000018036FC30-0x000000018036FC90
	private void OnDisable(); // 0x000000018036FC20-0x000000018036FC30
}

