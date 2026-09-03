/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(PenState), isGenericTypeOfDevice = true)]
	public class Pen : Pointer // TypeDefIndex: 6167
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _tip_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _eraser_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _firstBarrelButton_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private ButtonControl _secondBarrelButton_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private ButtonControl _thirdBarrelButton_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private ButtonControl _fourthBarrelButton_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private ButtonControl _inRange_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private Vector2Control _tilt_k__BackingField; // 0x1F8
		[CompilerGenerated]
		private AxisControl _twist_k__BackingField; // 0x200
		[CompilerGenerated]
		private static Pen _current_k__BackingField; // 0x00
	
		// Properties
		public ButtonControl tip { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		public ButtonControl eraser { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		public ButtonControl firstBarrelButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		public ButtonControl secondBarrelButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		public ButtonControl thirdBarrelButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		public ButtonControl fourthBarrelButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		public ButtonControl inRange { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		public Vector2Control tilt { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
		public AxisControl twist { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
		public static new Pen current { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181D86400-0x0000000181D86440 0x0000000181D86440-0x0000000181D864A0
		public ButtonControl this[PenButton button] { get => default; } // 0x0000000181D862D0-0x0000000181D86400 
	
		// Constructors
		public Pen(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D861A0-0x0000000181D86240
		protected override void OnRemoved(); // 0x0000000181D86240-0x0000000181D862D0
		protected override void FinishSetup(); // 0x0000000181D85F10-0x0000000181D861A0
	}
}
