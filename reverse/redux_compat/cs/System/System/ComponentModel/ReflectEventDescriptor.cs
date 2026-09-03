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

namespace System.ComponentModel
{
	internal sealed class ReflectEventDescriptor : EventDescriptor // TypeDefIndex: 8877
	{
		// Fields
		private Type _type; // 0x60
		private readonly Type _componentClass; // 0x68
		private MethodInfo _addMethod; // 0x70
		private MethodInfo _removeMethod; // 0x78
		private EventInfo _realEvent; // 0x80
		private bool _filledMethods; // 0x88
	
		// Constructors
		public ReflectEventDescriptor(Type componentClass, EventInfo eventInfo); // 0x0000000181BB2C80-0x0000000181BB2E00
	
		// Methods
		protected override void FillAttributes(IList attributes); // 0x0000000181BB20A0-0x0000000181BB2120
		private void FillEventInfoAttribute(EventInfo realEventInfo, IList attributes); // 0x0000000181BB2120-0x0000000181BB2430
		private void FillMethods(); // 0x0000000181BB2430-0x0000000181BB2930
		private void FillSingleMethodAttribute(MethodInfo realMethodInfo, IList attributes); // 0x0000000181BB2930-0x0000000181BB2C80
	}
}
