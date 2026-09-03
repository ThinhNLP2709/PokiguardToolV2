/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
	public class BurstCompileAttribute : Attribute // TypeDefIndex: 15004
	{
		// Fields
		[CompilerGenerated]
		private FloatMode _FloatMode_k__BackingField; // 0x10
		[CompilerGenerated]
		private FloatPrecision _FloatPrecision_k__BackingField; // 0x14
		internal bool? _compileSynchronously; // 0x18
		internal bool? _disableSafetyChecks; // 0x1A
		[CompilerGenerated]
		private OptimizeFor _OptimizeFor_k__BackingField; // 0x1C
		[CompilerGenerated]
		private string[] _Options_k__BackingField; // 0x20
	
		// Properties
		public FloatMode FloatMode { [CompilerGenerated] set; } // 0x00000001805D5560-0x00000001805D5570
		public FloatPrecision FloatPrecision { [CompilerGenerated] set; } // 0x0000000180E02550-0x0000000180E02560
		public bool CompileSynchronously { set; } // 0x000000018216DDB0-0x000000018216DDE0
		public bool DisableSafetyChecks { set; } // 0x000000018216DDE0-0x000000018216DE10
		public OptimizeFor OptimizeFor { [CompilerGenerated] set; } // 0x0000000180E025C0-0x0000000180E025D0
		internal string[] Options { [CompilerGenerated] set; } // 0x000000018033E830-0x000000018033E840
	
		// Constructors
		public BurstCompileAttribute(); // 0x00000001802F4070-0x00000001802F4080
		public BurstCompileAttribute(FloatPrecision floatPrecision, FloatMode floatMode); // 0x000000018216DD70-0x000000018216DDB0
	}
}
