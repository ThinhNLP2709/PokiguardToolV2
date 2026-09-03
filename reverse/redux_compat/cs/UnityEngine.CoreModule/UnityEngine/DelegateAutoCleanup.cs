/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using Unity.Scripting.LifecycleManagement.CodeGen;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	public sealed class DelegateAutoCleanup : ClassAutoCleanup // TypeDefIndex: 7839
	{
		// Fields
		private readonly Action _cleanup; // 0x10
		private readonly string _ownerDescription; // 0x18
	
		// Constructors
		public DelegateAutoCleanup(Action cleanup, Type scopeType, string ownerDescription = "" /* Metadata: 0x0069D78C */); // 0x00000001822038E0-0x0000000182203990
		[VisibleToOtherModules]
		internal DelegateAutoCleanup(Action cleanup, Type scopeType, ScopeTransitionType cleanOn, string ownerDescription = "" /* Metadata: 0x0069D78D */); // 0x0000000182203990-0x0000000182203A40
	
		// Methods
		public override void Cleanup(); // 0x00000001804EAA20-0x00000001804EAA50
		public override string ToString(); // 0x00000001802F8EC0-0x00000001802F8ED0
		public static DelegateAutoCleanup CreateForPlayMode(Action cleanup, string ownerDescription = "" /* Metadata: 0x0069D78E */); // 0x00000001822037C0-0x00000001822038E0
	}
}
