/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	public class PokyHubShellBootstrap : MonoBehaviour // TypeDefIndex: 2632
	{
		// Fields
		public const string FLAG_SHELL = "pokyhub.shell"; // Metadata: 0x005F129E
		[Tooltip("Prefab Assets/PokyHome/Prefabs/PokyHubShell.prefab (menu PokyHub/2 g\u00E1n).")]
		public GameObject shellPrefab; // 0x20
		[CompilerGenerated]
		private static bool _Active_k__BackingField; // 0x00
		private PokyHubShell _shell; // 0x28
	
		// Properties
		public static bool Active { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C1A950-0x0000000180C1A990 0x0000000180C1A990-0x0000000180C1A9E0
		public static bool ShellFlagOn { get; } // 0x0000000180C1A9E0-0x0000000180C1AA50 
	
		// Constructors
		public PokyHubShellBootstrap(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180C1AA50-0x0000000180C1AE30
		private void Start(); // 0x0000000180C1AE30-0x0000000180C1AF30
		private void OnDestroy(); // 0x0000000180C1AF30-0x0000000180C1B040
	}
}
