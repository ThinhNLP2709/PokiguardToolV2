/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class GiftBoxPopup // TypeDefIndex: 840
{
	// Fields
	public const string NODE_RESULT = "PanelResult"; // Metadata: 0x0064CB34
	public const string NODE_TITLE = "txtTitle"; // Metadata: 0x0064CB40
	public const string NODE_BUTTON = "btnGet"; // Metadata: 0x0064CB49
	public const string DEFAULT_TITLE = "Ch\u00FAc m\u1EEBng b\u1EA1n \u0111\u00E3 nh\u1EADn \u0111\u01B0\u1EE3c!"; // Metadata: 0x0064CB50

	// Nested types
	private class DesignScale : MonoBehaviour // TypeDefIndex: 841
	{
		// Fields
		public Vector3 value; // 0x20

		// Constructors
		public DesignScale(); // 0x0000000180425B80-0x0000000180425BB0
	}

	// Methods
	public static void Open(GameObject panel, GameObject panelResult, UnityEngine.UI.Text title, string titleText, Button button, UnityAction onButton); // 0x00000001804268E0-0x0000000180426DE0
	private static T Node<T>(GameObject root, string name)
		where T : Component;
}

