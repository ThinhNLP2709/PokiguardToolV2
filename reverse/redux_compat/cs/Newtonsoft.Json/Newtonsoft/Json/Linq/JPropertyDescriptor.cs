/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(0)]
	[NullableContext(1)]
	public class JPropertyDescriptor : PropertyDescriptor // TypeDefIndex: 10320
	{
		// Properties
		public override Type ComponentType { get; } // 0x0000000181742420-0x0000000181742460 
		public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override Type PropertyType { get; } // 0x0000000181742460-0x00000001817424A0 
		protected override int NameHashCode { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Constructors
		public JPropertyDescriptor(string name); // 0x0000000181742410-0x0000000181742420
	
		// Methods
		private static JObject CastInstance(object instance); // 0x00000001817421D0-0x0000000181742250
		public override bool CanResetValue(object component); // 0x00000001802E7840-0x00000001802E7850
		[NullableContext(2)]
		public override object GetValue(object component); // 0x0000000181742250-0x00000001817422F0
		public override void ResetValue(object component); // 0x00000001802E76C0-0x00000001802E76D0
		[NullableContext(2)]
		public override void SetValue(object component, object value); // 0x00000001817422F0-0x0000000181742410
		public override bool ShouldSerializeValue(object component); // 0x00000001802E7840-0x00000001802E7850
	}
}
