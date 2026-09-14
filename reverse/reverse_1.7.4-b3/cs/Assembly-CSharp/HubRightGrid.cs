/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class HubRightGrid : MonoBehaviour // TypeDefIndex: 1398
{
	// Fields
	public const string NODE_NAME = "PanelRightGrid"; // Metadata: 0x005EFB0B
	public const float CELL = 72f; // Metadata: 0x005EFB1A
	public const float SPACING = 10f; // Metadata: 0x005EFB1E
	public const float MARGIN_RIGHT = 12f; // Metadata: 0x005EFB22
	private static HubRightGrid _cached; // 0x00

	// Constructors
	public HubRightGrid(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static HubRightGrid Find(); // 0x000000018078DA80-0x000000018078DC50
	private void OnDestroy(); // 0x000000018078DC50-0x000000018078DE10
	public void Adopt(RectTransform rt, bool asLast = true /* Metadata: 0x005EFB0A */); // 0x000000018078DE10-0x000000018078E260
}

