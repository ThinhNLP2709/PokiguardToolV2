/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	internal sealed class ReflectPropertyDescriptor : PropertyDescriptor // TypeDefIndex: 8908
	{
		// Fields
		private static readonly Type[] argsNone; // 0x00
		private static readonly object noValue; // 0x08
		private static TraceSwitch PropDescCreateSwitch; // 0x10
		private static TraceSwitch PropDescUsageSwitch; // 0x18
		private static readonly int BitDefaultValueQueried; // 0x20
		private static readonly int BitGetQueried; // 0x24
		private static readonly int BitSetQueried; // 0x28
		private static readonly int BitShouldSerializeQueried; // 0x2C
		private static readonly int BitResetQueried; // 0x30
		private static readonly int BitChangedQueried; // 0x34
		private static readonly int BitIPropChangedQueried; // 0x38
		private static readonly int BitReadOnlyChecked; // 0x3C
		private static readonly int BitAmbientValueQueried; // 0x40
		private static readonly int BitSetOnDemand; // 0x44
		private BitVector32 state; // 0x88
		private Type componentClass; // 0x90
		private Type type; // 0x98
		private object defaultValue; // 0xA0
		private object ambientValue; // 0xA8
		private PropertyInfo propInfo; // 0xB0
		private MethodInfo getMethod; // 0xB8
		private MethodInfo setMethod; // 0xC0
		private MethodInfo shouldSerializeMethod; // 0xC8
		private MethodInfo resetMethod; // 0xD0
		private EventDescriptor realChangedEvent; // 0xD8
		private Type receiverType; // 0xE0
	
		// Properties
		private object AmbientValue { get; } // 0x0000000181BB5EC0-0x0000000181BB6040 
		public override Type ComponentType { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		private object DefaultValue { get; } // 0x0000000181BB6040-0x0000000181BB62F0 
		private MethodInfo GetMethodValue { get; } // 0x0000000181BB62F0-0x0000000181BB6810 
		private bool IsExtender { get; } // 0x0000000181BB6810-0x0000000181BB6850 
		public override bool IsReadOnly { get; } // 0x0000000181BB6850-0x0000000181BB6940 
		public override Type PropertyType { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		private MethodInfo ResetMethodValue { get; } // 0x0000000181BB6940-0x0000000181BB6B40 
		private MethodInfo SetMethodValue { get; } // 0x0000000181BB6B40-0x0000000181BB7180 
		private MethodInfo ShouldSerializeMethodValue { get; } // 0x0000000181BB7180-0x0000000181BB7380 
	
		// Constructors
		public ReflectPropertyDescriptor(Type componentClass, string name, Type type, Attribute[] attributes); // 0x0000000181BB5A30-0x0000000181BB5C50
		public ReflectPropertyDescriptor(Type componentClass, string name, Type type, PropertyInfo propInfo, MethodInfo getMethod, MethodInfo setMethod, Attribute[] attrs); // 0x0000000181BB5D50-0x0000000181BB5EC0
		public ReflectPropertyDescriptor(Type componentClass, string name, Type type, Type receiverType, MethodInfo getMethod, MethodInfo setMethod, Attribute[] attrs); // 0x0000000181BB5C50-0x0000000181BB5D50
		static ReflectPropertyDescriptor(); // 0x0000000181BB5710-0x0000000181BB5A30
	
		// Methods
		internal bool ExtenderCanResetValue(IExtenderProvider provider, object component); // 0x0000000181BB3030-0x0000000181BB3260
		internal Type ExtenderGetReceiverType(); // 0x00000001806CCB80-0x00000001806CCB90
		internal Type ExtenderGetType(IExtenderProvider provider); // 0x0000000181BB3260-0x0000000181BB3280
		internal object ExtenderGetValue(IExtenderProvider provider, object component); // 0x0000000181BB3280-0x0000000181BB33E0
		internal void ExtenderResetValue(IExtenderProvider provider, object component, PropertyDescriptor notifyDesc); // 0x0000000181BB33E0-0x0000000181BB3790
		internal void ExtenderSetValue(IExtenderProvider provider, object component, object value, PropertyDescriptor notifyDesc); // 0x0000000181BB3790-0x0000000181BB3AE0
		internal bool ExtenderShouldSerializeValue(IExtenderProvider provider, object component); // 0x0000000181BB3AE0-0x0000000181BB3E70
		public override bool CanResetValue(object component); // 0x0000000181BB2E00-0x0000000181BB3030
		protected override void FillAttributes(IList attributes); // 0x0000000181BB3E70-0x0000000181BB48F0
		public override object GetValue(object component); // 0x0000000181BB48F0-0x0000000181BB4BF0
		protected override void OnValueChanged(object component, EventArgs e); // 0x0000000181BB4BF0-0x0000000181BB4D00
		public override void ResetValue(object component); // 0x0000000181BB4D00-0x0000000181BB4FE0
		public override void SetValue(object component, object value); // 0x0000000181BB4FE0-0x0000000181BB5490
		public override bool ShouldSerializeValue(object component); // 0x0000000181BB5490-0x0000000181BB5710
	}
}
