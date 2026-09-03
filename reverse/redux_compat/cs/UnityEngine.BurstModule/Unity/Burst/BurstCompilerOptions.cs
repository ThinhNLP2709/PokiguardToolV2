/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst
{
	public sealed class BurstCompilerOptions // TypeDefIndex: 15009
	{
		// Fields
		private static readonly bool _forceDisableBurstCompilation; // 0x00
		private static readonly bool ForceBurstCompilationSynchronously; // 0x01
		internal static bool IsSecondaryUnityProcess; // 0x02
		private bool _enableBurstCompilation; // 0x10
		private bool _enableBurstSafetyChecks; // 0x11
		[CompilerGenerated]
		private readonly bool _IsGlobal_k__BackingField; // 0x12
		[CompilerGenerated]
		private Action _OptionsChanged_k__BackingField; // 0x18
	
		// Properties
		internal static bool ForceDisableBurstCompilation { get; } // 0x000000018216E8F0-0x000000018216E950 
		private bool IsGlobal { [CompilerGenerated] get; } // 0x0000000180E38E20-0x0000000180E38E30 
		public bool EnableBurstCompilation { get; set; } // 0x00000001805625D0-0x00000001805625E0 0x000000018216E950-0x000000018216EA70
		public bool EnableBurstSafetyChecks { set; } // 0x000000018216EA70-0x000000018216EAA0
		internal Action OptionsChanged { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal BurstCompilerOptions(bool isGlobal); // 0x000000018216E7A0-0x000000018216E8F0
		static BurstCompilerOptions(); // 0x000000018216E610-0x000000018216E7A0
	
		// Methods
		private static bool TryGetAttribute(MemberInfo member, out BurstCompileAttribute attribute); // 0x000000018216E570-0x000000018216E610
		private static BurstCompileAttribute GetBurstCompileAttribute(MemberInfo memberInfo); // 0x000000018216E010-0x000000018216E440
		internal static bool HasBurstCompileAttribute(MemberInfo member); // 0x000000018216E440-0x000000018216E570
		private void OnOptionsChanged(); // 0x00000001803A7770-0x00000001803A7790
		private void MaybeTriggerRecompilation(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
