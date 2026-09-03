/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	public class PokyHubShellBootstrap : MonoBehaviour // TypeDefIndex: 1869
	{
		// Fields
		public const string FLAG_SHELL = "pokyhub.shell"; // Metadata: 0x0064DD00
		[Tooltip("Prefab Assets/PokyHome/Prefabs/PokyHubShell.prefab (menu PokyHub/2 g\u00E1n).")]
		public GameObject shellPrefab; // 0x20
		[CompilerGenerated]
		private static bool _Active_k__BackingField; // 0x00
		private PokyHubShell _shell; // 0x28
	
		// Properties
		public static bool Active { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180639650-0x0000000180639690 0x00000001806396F0-0x0000000180639730
		public static bool ShellFlagOn { get; } // 0x0000000180639690-0x00000001806396F0 
	
		// Constructors
		public PokyHubShellBootstrap(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Awake(); // 0x00000001806392D0-0x0000000180639540
		private void Start(); // 0x00000001806395D0-0x0000000180639650
		private void OnDestroy(); // 0x0000000180639540-0x00000001806395D0
	}
}
