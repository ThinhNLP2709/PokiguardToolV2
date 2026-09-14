/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class HubRightGrid : MonoBehaviour // TypeDefIndex: 1400
{
	// Fields
	public const string NODE_NAME = "PanelRightGrid"; // Metadata: 0x005F0ED8
	public const float CELL = 72f; // Metadata: 0x005F0EE7
	public const float SPACING = 10f; // Metadata: 0x005F0EEB
	public const float MARGIN_RIGHT = 12f; // Metadata: 0x005F0EEF
	private static HubRightGrid _cached; // 0x00

	// Constructors
	public HubRightGrid(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static HubRightGrid Find(); // 0x000000018078F9D0-0x000000018078FBA0
	private void OnDestroy(); // 0x000000018078FBA0-0x000000018078FD60
	public void Adopt(RectTransform rt, bool asLast = true /* Metadata: 0x005F0ED7 */); // 0x000000018078FD60-0x00000001807901B0
}

