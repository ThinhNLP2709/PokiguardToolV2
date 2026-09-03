/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.UI
{
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/UISupport.html#multiplayer-uis")]
	public class MultiplayerEventSystem : EventSystem // TypeDefIndex: 6307
	{
		// Fields
		[SerializeField]
		[Tooltip("If set, only process mouse and navigation events for any game objects which are children of this game object.")]
		private GameObject m_PlayerRoot; // 0x60
	
		// Properties
		public GameObject playerRoot { get; set; } // 0x0000000180333260-0x0000000180333490 0x0000000181DB5DF0-0x0000000181DB5E20
	
		// Constructors
		public MultiplayerEventSystem(); // 0x0000000181DB5DA0-0x0000000181DB5DF0
	
		// Methods
		protected override void OnEnable(); // 0x0000000181DB5C90-0x0000000181DB5CB0
		protected override void OnDisable(); // 0x0000000181DB5C80-0x0000000181DB5C90
		private void InitializePlayerRoot(); // 0x0000000181DB5BE0-0x0000000181DB5C80
		protected override void Update(); // 0x0000000181DB5CB0-0x0000000181DB5DA0
	}
}
