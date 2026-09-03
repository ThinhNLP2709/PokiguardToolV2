/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter | AttributeTargets.All)]
	public sealed class ExtenderProvidedPropertyAttribute : Attribute // TypeDefIndex: 8852
	{
		// Fields
		[CompilerGenerated]
		private PropertyDescriptor _ExtenderProperty_k__BackingField; // 0x10
		[CompilerGenerated]
		private IExtenderProvider _Provider_k__BackingField; // 0x18
		[CompilerGenerated]
		private Type _ReceiverType_k__BackingField; // 0x20
	
		// Properties
		public PropertyDescriptor ExtenderProperty { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public IExtenderProvider Provider { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public Type ReceiverType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Constructors
		public ExtenderProvidedPropertyAttribute(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal static ExtenderProvidedPropertyAttribute Create(PropertyDescriptor extenderProperty, Type receiverType, IExtenderProvider provider); // 0x0000000181BAAE10-0x0000000181BAAEC0
		public override bool Equals(object obj); // 0x0000000181BAAEC0-0x0000000181BAAFC0
		public override int GetHashCode(); // 0x0000000181B8F900-0x0000000181B8F910
		public override bool IsDefaultAttribute(); // 0x0000000181BAAFC0-0x0000000181BAB000
	}
}
