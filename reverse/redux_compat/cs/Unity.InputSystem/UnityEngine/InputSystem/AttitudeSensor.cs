/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(AttitudeState), displayName = "Attitude")]
	public class AttitudeSensor : Sensor // TypeDefIndex: 6199
	{
		// Fields
		[CompilerGenerated]
		private QuaternionControl _attitude_k__BackingField; // 0x190
		[CompilerGenerated]
		private static AttitudeSensor _current_k__BackingField; // 0x00
	
		// Properties
		public QuaternionControl attitude { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static AttitudeSensor current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D69690-0x0000000181D696D0 0x0000000181D696D0-0x0000000181D69730
	
		// Constructors
		public AttitudeSensor(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D695A0-0x0000000181D69600
		protected override void OnRemoved(); // 0x0000000181D69600-0x0000000181D69690
		protected override void FinishSetup(); // 0x0000000181D69530-0x0000000181D695A0
	}
}
