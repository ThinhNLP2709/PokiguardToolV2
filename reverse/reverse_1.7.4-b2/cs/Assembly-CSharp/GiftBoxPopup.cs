/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class GiftBoxPopup // TypeDefIndex: 1038
{
	// Fields
	public const string NODE_RESULT = "PanelResult"; // Metadata: 0x0068C2C5
	public const string NODE_TITLE = "txtTitle"; // Metadata: 0x0068C2D1
	public const string NODE_BUTTON = "btnGet"; // Metadata: 0x0068C2DA
	public const string DEFAULT_TITLE = "Ch\u00FAc m\u1EEBng b\u1EA1n \u0111\u00E3 nh\u1EADn \u0111\u01B0\u1EE3c!"; // Metadata: 0x0068C2E1

	// Nested types
	private class DesignScale : MonoBehaviour // TypeDefIndex: 1039
	{
		// Fields
		public Vector3 value; // 0x20

		// Constructors
		public DesignScale(); // 0x00000001804FB300-0x00000001804FB330
	}

	// Methods
	public static void Open(GameObject panel, GameObject panelResult, UnityEngine.UI.Text title, string titleText, Button button, UnityAction onButton); // 0x00000001804FC050-0x00000001804FC550
	private static T Node<T>(GameObject root, string name)
		where T : Component;
}

