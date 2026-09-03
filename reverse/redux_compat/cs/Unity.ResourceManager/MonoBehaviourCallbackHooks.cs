/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

internal class MonoBehaviourCallbackHooks : ComponentSingleton<MonoBehaviourCallbackHooks> // TypeDefIndex: 13668
{
	// Fields
	internal Action<float> m_OnUpdateDelegate; // 0x20
	internal Action<float> m_OnLateUpdateDelegate; // 0x28

	// Events
	public event Action<float> OnUpdateDelegate {
		add; // 0x00000001820503A0-0x0000000182050450
		remove; // 0x0000000182050500-0x00000001820505B0
	}
	internal event Action<float> OnLateUpdateDelegate {
		add; // 0x00000001820502F0-0x00000001820503A0
		remove; // 0x0000000182050450-0x0000000182050500
	}

	// Constructors
	public MonoBehaviourCallbackHooks(); // 0x00000001820502E0-0x00000001820502F0

	// Methods
	protected override string GetGameObjectName(); // 0x0000000182050230-0x0000000182050260
	internal void Update(); // 0x00000001820502A0-0x00000001820502E0
	internal void LateUpdate(); // 0x0000000182050260-0x00000001820502A0
}

