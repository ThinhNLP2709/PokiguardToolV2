/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 40: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15099-15191

namespace DG.Tweening
{
	public static class DOTweenCYInstruction // TypeDefIndex: 15183
	{
		// Nested types
		public class WaitForCompletion : CustomYieldInstruction // TypeDefIndex: 15184
		{
			// Fields
			private readonly Tween t; // 0x10
	
			// Properties
			public override bool keepWaiting { get; } // 0x00000001802E7460-0x00000001802E74A0 
	
			// Constructors
			public WaitForCompletion(Tween tween); // 0x00000001802E7420-0x00000001802E7460
		}
	
		public class WaitForRewind : CustomYieldInstruction // TypeDefIndex: 15185
		{
			// Fields
			private readonly Tween t; // 0x10
	
			// Properties
			public override bool keepWaiting { get; } // 0x00000001802E7610-0x00000001802E7680 
	
			// Constructors
			public WaitForRewind(Tween tween); // 0x00000001802E7420-0x00000001802E7460
		}
	
		public class WaitForKill : CustomYieldInstruction // TypeDefIndex: 15186
		{
			// Fields
			private readonly Tween t; // 0x10
	
			// Properties
			public override bool keepWaiting { get; } // 0x00000001802E7530-0x00000001802E7550 
	
			// Constructors
			public WaitForKill(Tween tween); // 0x00000001802E7420-0x00000001802E7460
		}
	
		public class WaitForElapsedLoops : CustomYieldInstruction // TypeDefIndex: 15187
		{
			// Fields
			private readonly Tween t; // 0x10
			private readonly int elapsedLoops; // 0x18
	
			// Properties
			public override bool keepWaiting { get; } // 0x00000001802E74F0-0x00000001802E7530 
	
			// Constructors
			public WaitForElapsedLoops(Tween tween, int elapsedLoops); // 0x00000001802E74A0-0x00000001802E74F0
		}
	
		public class WaitForPosition : CustomYieldInstruction // TypeDefIndex: 15188
		{
			// Fields
			private readonly Tween t; // 0x10
			private readonly float position; // 0x18
	
			// Properties
			public override bool keepWaiting { get; } // 0x00000001802E75A0-0x00000001802E7610 
	
			// Constructors
			public WaitForPosition(Tween tween, float position); // 0x00000001802E7550-0x00000001802E75A0
		}
	
		public class WaitForStart : CustomYieldInstruction // TypeDefIndex: 15189
		{
			// Fields
			private readonly Tween t; // 0x10
	
			// Properties
			public override bool keepWaiting { get; } // 0x00000001802E7680-0x00000001802E76C0 
	
			// Constructors
			public WaitForStart(Tween tween); // 0x00000001802E7420-0x00000001802E7460
		}
	}
}
