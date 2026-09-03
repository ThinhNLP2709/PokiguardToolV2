/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel.Design.Serialization
{
	public sealed class InstanceDescriptor // TypeDefIndex: 8943
	{
		// Fields
		[CompilerGenerated]
		private readonly ICollection _Arguments_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly bool _IsComplete_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly MemberInfo _MemberInfo_k__BackingField; // 0x20
	
		// Properties
		public ICollection Arguments { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public MemberInfo MemberInfo { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		public InstanceDescriptor(MemberInfo member, ICollection arguments); // 0x0000000181BCAD50-0x0000000181BCAD70
		public InstanceDescriptor(MemberInfo member, ICollection arguments, bool isComplete); // 0x0000000181BCAD70-0x0000000181BCB3C0
	
		// Methods
		public object Invoke(); // 0x0000000181BCA950-0x0000000181BCAD50
	}
}
