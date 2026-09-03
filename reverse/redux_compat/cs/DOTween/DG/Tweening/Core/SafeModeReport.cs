/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Core
{
	internal struct SafeModeReport // TypeDefIndex: 13515
	{
		// Fields
		[CompilerGenerated]
		private int _totMissingTargetOrFieldErrors_k__BackingField; // 0x00
		[CompilerGenerated]
		private int _totCallbackErrors_k__BackingField; // 0x04
		[CompilerGenerated]
		private int _totStartupErrors_k__BackingField; // 0x08
		[CompilerGenerated]
		private int _totUnsetErrors_k__BackingField; // 0x0C
	
		// Properties
		public int totMissingTargetOrFieldErrors { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int totCallbackErrors { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public int totStartupErrors { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public int totUnsetErrors { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
	
		// Nested types
		internal enum SafeModeReportType // TypeDefIndex: 13516
		{
			Unset = 0,
			TargetOrFieldMissing = 1,
			Callback = 2,
			StartupFailure = 3
		}
	
		// Methods
		public void Add(SafeModeReportType type); // 0x0000000180732CE0-0x0000000180732D00
		public int GetTotErrors(); // 0x0000000180732D00-0x0000000180732D10
	}
}
