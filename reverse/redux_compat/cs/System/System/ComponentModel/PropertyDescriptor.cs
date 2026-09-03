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
	public abstract class PropertyDescriptor : MemberDescriptor // TypeDefIndex: 8871
	{
		// Fields
		private TypeConverter _converter; // 0x60
		private Hashtable _valueChangedHandlers; // 0x68
		private object[] _editors; // 0x70
		private Type[] _editorTypes; // 0x78
		private int _editorCount; // 0x80
	
		// Properties
		public abstract Type ComponentType { get; }
		public virtual TypeConverter Converter { get; } // 0x0000000181BB11A0-0x0000000181BB1410 
		public abstract bool IsReadOnly { get; }
		public abstract Type PropertyType { get; }
	
		// Constructors
		protected PropertyDescriptor(string name, Attribute[] attrs); // 0x0000000181BAA640-0x0000000181BAA650
		protected PropertyDescriptor(MemberDescriptor descr, Attribute[] attrs); // 0x0000000181BB1190-0x0000000181BB11A0
	
		// Methods
		public abstract bool CanResetValue(object component);
		public override bool Equals(object obj); // 0x0000000181BB0AF0-0x0000000181BB0C70
		protected object CreateInstance(Type type); // 0x0000000181BB08D0-0x0000000181BB0AF0
		protected override void FillAttributes(IList attributeList); // 0x0000000181BB0C70-0x0000000181BB0CE0
		public override int GetHashCode(); // 0x0000000181BB0CE0-0x0000000181BB0D50
		protected override object GetInvocationTarget(Type type, object instance); // 0x0000000181BB0D50-0x0000000181BB0ED0
		protected Type GetTypeFromName(string typeName); // 0x0000000181BB0ED0-0x0000000181BB10F0
		public abstract object GetValue(object component);
		protected virtual void OnValueChanged(object component, EventArgs e); // 0x0000000181BB10F0-0x0000000181BB1190
		public abstract void ResetValue(object component);
		public abstract void SetValue(object component, object value);
		public abstract bool ShouldSerializeValue(object component);
	}
}
