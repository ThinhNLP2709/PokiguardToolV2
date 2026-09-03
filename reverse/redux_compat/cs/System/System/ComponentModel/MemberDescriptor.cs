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
	[ComVisible(true)]
	public abstract class MemberDescriptor // TypeDefIndex: 8907
	{
		// Fields
		private string name; // 0x10
		private string displayName; // 0x18
		private int nameHash; // 0x20
		private AttributeCollection attributeCollection; // 0x28
		private Attribute[] attributes; // 0x30
		private Attribute[] originalAttributes; // 0x38
		private bool attributesFiltered; // 0x40
		private bool attributesFilled; // 0x41
		private int metadataVersion; // 0x44
		private string category; // 0x48
		private string description; // 0x50
		private object lockCookie; // 0x58
	
		// Properties
		protected virtual Attribute[] AttributeArray { get; set; } // 0x0000000181BAD300-0x0000000181BAD330 0x0000000181BAD5A0-0x0000000181BAD680
		public virtual AttributeCollection Attributes { get; } // 0x0000000181BAD330-0x0000000181BAD430 
		public virtual string Name { get; } // 0x0000000181BAD550-0x0000000181BAD5A0 
		protected virtual int NameHashCode { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public virtual string DisplayName { get; } // 0x0000000181BAD430-0x0000000181BAD550 
	
		// Constructors
		protected MemberDescriptor(string name, Attribute[] attributes); // 0x0000000181BAD1A0-0x0000000181BAD300
		protected MemberDescriptor(MemberDescriptor oldMemberDescriptor, Attribute[] newAttributes); // 0x0000000181BACD80-0x0000000181BAD1A0
	
		// Methods
		private void CheckAttributesValid(); // 0x0000000181BAC020-0x0000000181BAC0F0
		protected virtual AttributeCollection CreateAttributeCollection(); // 0x0000000181BAC0F0-0x0000000181BAC160
		public override bool Equals(object obj); // 0x0000000181BAC160-0x0000000181BAC400
		protected virtual void FillAttributes(IList attributeList); // 0x0000000181BAC400-0x0000000181BAC530
		private void FilterAttributesIfNeeded(); // 0x0000000181BAC530-0x0000000181BACA60
		protected static MethodInfo FindMethod(Type componentClass, string name, Type[] args, Type returnType); // 0x0000000181BACB20-0x0000000181BACBB0
		protected static MethodInfo FindMethod(Type componentClass, string name, Type[] args, Type returnType, bool publicOnly); // 0x0000000181BACA60-0x0000000181BACB20
		public override int GetHashCode(); // 0x0000000180C4F680-0x0000000180C4F690
		protected virtual object GetInvocationTarget(Type type, object instance); // 0x0000000181BACBB0-0x0000000181BACCD0
		protected static ISite GetSite(object component); // 0x0000000181BACCD0-0x0000000181BACD80
	}
}
