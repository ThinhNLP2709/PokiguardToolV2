/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	public class PokyHubShellBootstrap : MonoBehaviour // TypeDefIndex: 2639
	{
		// Fields
		public const string FLAG_SHELL = "pokyhub.shell"; // Metadata: 0x005F26B5
		[Tooltip("Prefab Assets/PokyHome/Prefabs/PokyHubShell.prefab (menu PokyHub/2 g\u00E1n).")]
		public GameObject shellPrefab; // 0x20
		[CompilerGenerated]
		private static bool _Active_k__BackingField; // 0x00
		private PokyHubShell _shell; // 0x28
	
		// Properties
		public static bool Active { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C27D90-0x0000000180C27DD0 0x0000000180C27DD0-0x0000000180C27E20
		public static bool ShellFlagOn { get; } // 0x0000000180C27E20-0x0000000180C27E90 
	
		// Constructors
		public PokyHubShellBootstrap(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180C27E90-0x0000000180C28270
		private void Start(); // 0x0000000180C28270-0x0000000180C28370
		private void OnDestroy(); // 0x0000000180C28370-0x0000000180C28480
	}
}
