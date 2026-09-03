/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class HubRightGrid : MonoBehaviour // TypeDefIndex: 825
{
	// Fields
	public const string NODE_NAME = "PanelRightGrid"; // Metadata: 0x0064CA08
	public const float CELL = 72f; // Metadata: 0x0064CA17
	public const float SPACING = 10f; // Metadata: 0x0064CA1B
	public const float MARGIN_RIGHT = 12f; // Metadata: 0x0064CA1F
	private static HubRightGrid _cached; // 0x00

	// Constructors
	public HubRightGrid(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static HubRightGrid Find(); // 0x0000000180426FE0-0x00000001804270D0
	private void OnDestroy(); // 0x00000001804270D0-0x0000000180427180
	public void Adopt(RectTransform rt, bool asLast = true /* Metadata: 0x0064CA07 */); // 0x0000000180426DE0-0x0000000180426FE0
}

