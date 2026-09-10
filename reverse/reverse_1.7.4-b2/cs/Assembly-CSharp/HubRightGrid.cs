/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class HubRightGrid : MonoBehaviour // TypeDefIndex: 1020
{
	// Fields
	public const string NODE_NAME = "PanelRightGrid"; // Metadata: 0x0068C0DE
	public const float CELL = 72f; // Metadata: 0x0068C0ED
	public const float SPACING = 10f; // Metadata: 0x0068C0F1
	public const float MARGIN_RIGHT = 12f; // Metadata: 0x0068C0F5
	private static HubRightGrid _cached; // 0x00

	// Constructors
	public HubRightGrid(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static HubRightGrid Find(); // 0x00000001804FC750-0x00000001804FC840
	private void OnDestroy(); // 0x00000001804FC840-0x00000001804FC8F0
	public void Adopt(RectTransform rt, bool asLast = true /* Metadata: 0x0068C0DD */); // 0x00000001804FC550-0x00000001804FC750
}

