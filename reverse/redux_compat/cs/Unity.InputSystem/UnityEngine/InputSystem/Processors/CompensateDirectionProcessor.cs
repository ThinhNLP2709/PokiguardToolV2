/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Processors
{
	[DesignTimeVisible(false)]
	internal class CompensateDirectionProcessor : InputProcessor<Vector3> // TypeDefIndex: 6514
	{
		// Properties
		public override CachingPolicy cachingPolicy { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public CompensateDirectionProcessor(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override Vector3 Process(Vector3 value, InputControl control); // 0x0000000181DD7230-0x0000000181DD7390
		public override string ToString(); // 0x0000000181DD7390-0x0000000181DD73C0
	}
}
