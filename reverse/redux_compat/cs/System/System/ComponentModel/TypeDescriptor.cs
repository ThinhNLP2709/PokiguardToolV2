/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public sealed class TypeDescriptor // TypeDefIndex: 8914
	{
		// Fields
		private static WeakHashtable _providerTable; // 0x00
		private static Hashtable _providerTypeTable; // 0x08
		private static Hashtable _defaultProviders; // 0x10
		private static WeakHashtable _associationTable; // 0x18
		private static int _metadataVersion; // 0x20
		private static int _collisionIndex; // 0x24
		private static BooleanSwitch TraceDescriptor; // 0x28
		private static readonly Guid[] _pipelineInitializeKeys; // 0x30
		private static readonly Guid[] _pipelineMergeKeys; // 0x38
		private static readonly Guid[] _pipelineFilterKeys; // 0x40
		private static readonly Guid[] _pipelineAttributeFilterKeys; // 0x48
		private static object _internalSyncObject; // 0x50
		[CompilerGenerated]
		private static RefreshEventHandler Refreshed; // 0x58
	
		// Properties
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static Type ComObjectType { get; } // 0x0000000181BDCA70-0x0000000181BDCAB0 
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static Type InterfaceType { get; } // 0x0000000181BDCAB0-0x0000000181BDCAF0 
		internal static int MetadataVersion { get; } // 0x0000000181BDCAF0-0x0000000181BDCB40 
	
		// Nested types
		private sealed class AttributeFilterCacheItem // TypeDefIndex: 8915
		{
			// Fields
			private Attribute[] _filter; // 0x10
			internal ICollection FilteredMembers; // 0x18
	
			// Constructors
			internal AttributeFilterCacheItem(Attribute[] filter, ICollection filteredMembers); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			internal bool IsValid(Attribute[] filter); // 0x0000000181BC0AF0-0x0000000181BC0B60
		}
	
		private sealed class FilterCacheItem // TypeDefIndex: 8916
		{
			// Fields
			private ITypeDescriptorFilterService _filterService; // 0x10
			internal ICollection FilteredMembers; // 0x18
	
			// Constructors
			internal FilterCacheItem(ITypeDescriptorFilterService filterService, ICollection filteredMembers); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			internal bool IsValid(ITypeDescriptorFilterService filterService); // 0x0000000181743720-0x0000000181743730
		}
	
		private interface IUnimplemented // TypeDefIndex: 8917
		{
		}
	
		private sealed class MemberDescriptorComparer : IComparer // TypeDefIndex: 8918
		{
			// Fields
			public static readonly MemberDescriptorComparer Instance; // 0x00
	
			// Constructors
			public MemberDescriptorComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static MemberDescriptorComparer(); // 0x0000000181BCB990-0x0000000181BCBA00
	
			// Methods
			public int Compare(object left, object right); // 0x0000000181BCB860-0x0000000181BCB990
		}
	
		private sealed class MergedTypeDescriptor : ICustomTypeDescriptor // TypeDefIndex: 8919
		{
			// Fields
			private ICustomTypeDescriptor _primary; // 0x10
			private ICustomTypeDescriptor _secondary; // 0x18
	
			// Constructors
			internal MergedTypeDescriptor(ICustomTypeDescriptor primary, ICustomTypeDescriptor secondary); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			AttributeCollection ICustomTypeDescriptor.GetAttributes(); // 0x0000000181BCBA00-0x0000000181BCBA70
			string ICustomTypeDescriptor.GetClassName(); // 0x0000000181BCBA70-0x0000000181BCBAE0
			string ICustomTypeDescriptor.GetComponentName(); // 0x0000000181BCBAE0-0x0000000181BCBB50
			TypeConverter ICustomTypeDescriptor.GetConverter(); // 0x0000000181BCBB50-0x0000000181BCBBC0
			EventDescriptor ICustomTypeDescriptor.GetDefaultEvent(); // 0x0000000181BCBBC0-0x0000000181BCBC30
			PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty(); // 0x0000000181BCBC30-0x0000000181BCBCA0
			object ICustomTypeDescriptor.GetEditor(Type editorBaseType); // 0x0000000181BCBCA0-0x0000000181BCBD90
			EventDescriptorCollection ICustomTypeDescriptor.GetEvents(); // 0x0000000181BCBD90-0x0000000181BCBE00
			EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes); // 0x0000000181BCBE00-0x0000000181BCBE80
			PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(); // 0x0000000181BCBF00-0x0000000181BCBF70
			PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes); // 0x0000000181BCBE80-0x0000000181BCBF00
			object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd); // 0x0000000181BCBF70-0x0000000181BCBFF0
		}
	
		private sealed class TypeDescriptionNode : TypeDescriptionProvider // TypeDefIndex: 8920
		{
			// Fields
			internal TypeDescriptionNode Next; // 0x20
			internal TypeDescriptionProvider Provider; // 0x28
	
			// Nested types
			private struct DefaultExtendedTypeDescriptor : ICustomTypeDescriptor // TypeDefIndex: 8921
			{
				// Fields
				private TypeDescriptionNode _node; // 0x00
				private object _instance; // 0x08
	
				// Constructors
				internal DefaultExtendedTypeDescriptor(TypeDescriptionNode node, object instance); // 0x0000000180CC3FE0-0x0000000180CC4020
	
				// Methods
				AttributeCollection ICustomTypeDescriptor.GetAttributes(); // 0x0000000181BC2020-0x0000000181BC2330
				string ICustomTypeDescriptor.GetClassName(); // 0x0000000181BC2330-0x0000000181BC2520
				string ICustomTypeDescriptor.GetComponentName(); // 0x0000000181BC2520-0x0000000181BC26E0
				TypeConverter ICustomTypeDescriptor.GetConverter(); // 0x0000000181BC26E0-0x0000000181BC29C0
				EventDescriptor ICustomTypeDescriptor.GetDefaultEvent(); // 0x0000000181BC29C0-0x0000000181BC2B80
				PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty(); // 0x0000000181BC2B80-0x0000000181BC2D40
				object ICustomTypeDescriptor.GetEditor(Type editorBaseType); // 0x0000000181BC2D40-0x0000000181BC2F90
				EventDescriptorCollection ICustomTypeDescriptor.GetEvents(); // 0x0000000181BC2F90-0x0000000181BC32B0
				EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes); // 0x0000000181BC32B0-0x0000000181BC35C0
				PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(); // 0x0000000181BC3890-0x0000000181BC3B70
				PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes); // 0x0000000181BC35C0-0x0000000181BC3890
				object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd); // 0x0000000181BC3B70-0x0000000181BC3D40
			}
	
			private struct DefaultTypeDescriptor : ICustomTypeDescriptor // TypeDefIndex: 8922
			{
				// Fields
				private TypeDescriptionNode _node; // 0x00
				private Type _objectType; // 0x08
				private object _instance; // 0x10
	
				// Constructors
				internal DefaultTypeDescriptor(TypeDescriptionNode node, Type objectType, object instance); // 0x0000000180F466A0-0x0000000180F466F0
	
				// Methods
				AttributeCollection ICustomTypeDescriptor.GetAttributes(); // 0x0000000181BC3D40-0x0000000181BC4010
				string ICustomTypeDescriptor.GetClassName(); // 0x0000000181BC4010-0x0000000181BC4200
				string ICustomTypeDescriptor.GetComponentName(); // 0x0000000181BC4200-0x0000000181BC43C0
				TypeConverter ICustomTypeDescriptor.GetConverter(); // 0x0000000181BC43C0-0x0000000181BC4690
				EventDescriptor ICustomTypeDescriptor.GetDefaultEvent(); // 0x0000000181BC4690-0x0000000181BC4850
				PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty(); // 0x0000000181BC4850-0x0000000181BC4A10
				object ICustomTypeDescriptor.GetEditor(Type editorBaseType); // 0x0000000181BC4A10-0x0000000181BC4C60
				EventDescriptorCollection ICustomTypeDescriptor.GetEvents(); // 0x0000000181BC4F40-0x0000000181BC5210
				EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes); // 0x0000000181BC4C60-0x0000000181BC4F40
				PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(); // 0x0000000181BC54F0-0x0000000181BC57C0
				PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes); // 0x0000000181BC5210-0x0000000181BC54F0
				object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd); // 0x0000000181BC57C0-0x0000000181BC59B0
			}
	
			// Constructors
			internal TypeDescriptionNode(TypeDescriptionProvider provider); // 0x0000000181BD64A0-0x0000000181BD64E0
	
			// Methods
			public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args); // 0x0000000181BD5EB0-0x0000000181BD6050
			public override IDictionary GetCache(object instance); // 0x0000000181BD6050-0x0000000181BD60E0
			public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance); // 0x0000000181BD60E0-0x0000000181BD61B0
			protected internal override IExtenderProvider[] GetExtenderProviders(object instance); // 0x0000000181BD61B0-0x0000000181BD6240
			public override Type GetReflectionType(Type objectType, object instance); // 0x0000000181BD6240-0x0000000181BD6300
			public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance); // 0x0000000181BD6300-0x0000000181BD64A0
		}
	
		[TypeDescriptionProvider("System.Windows.Forms.ComponentModel.Com2Interop.ComNativeDescriptor, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
		private sealed class TypeDescriptorComObject // TypeDefIndex: 8923
		{
		}
	
		private sealed class TypeDescriptorInterface // TypeDefIndex: 8924
		{
		}
	
		// Constructors
		static TypeDescriptor(); // 0x0000000181BDC5C0-0x0000000181BDCA70
	
		// Methods
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static void AddProvider(TypeDescriptionProvider provider, Type type); // 0x0000000181BD64E0-0x0000000181BD67A0
		private static void CheckDefaultProvider(Type type); // 0x0000000181BD67A0-0x0000000181BD6D00
		public static object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args); // 0x0000000181BD6D00-0x0000000181BD6FA0
		private static ArrayList FilterMembers(IList members, Attribute[] attributes); // 0x0000000181BD6FA0-0x0000000181BD7200
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static object GetAssociation(Type type, object primary); // 0x0000000181BD7200-0x0000000181BD76C0
		public static AttributeCollection GetAttributes(Type componentType); // 0x0000000181BD7A30-0x0000000181BD7B10
		public static AttributeCollection GetAttributes(object component); // 0x0000000181BD79E0-0x0000000181BD7A30
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static AttributeCollection GetAttributes(object component, bool noCustomTypeDesc); // 0x0000000181BD76C0-0x0000000181BD79E0
		internal static IDictionary GetCache(object instance); // 0x0000000181BD7B10-0x0000000181BD7B80
		public static TypeConverter GetConverter(Type type); // 0x0000000181BD7B80-0x0000000181BD7C10
		internal static ICustomTypeDescriptor GetDescriptor(Type type, string typeName); // 0x0000000181BD7E50-0x0000000181BD7F60
		internal static ICustomTypeDescriptor GetDescriptor(object component, bool noCustomTypeDesc); // 0x0000000181BD7C10-0x0000000181BD7E50
		internal static ICustomTypeDescriptor GetExtendedDescriptor(object component); // 0x0000000181BD8440-0x0000000181BD8500
		public static EventDescriptorCollection GetEvents(Type componentType); // 0x0000000181BD8300-0x0000000181BD83F0
		public static EventDescriptorCollection GetEvents(object component); // 0x0000000181BD83F0-0x0000000181BD8440
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static EventDescriptorCollection GetEvents(object component, Attribute[] attributes, bool noCustomTypeDesc); // 0x0000000181BD7F60-0x0000000181BD8300
		private static string GetExtenderCollisionSuffix(MemberDescriptor member); // 0x0000000181BD8500-0x0000000181BD8720
		private static Type GetNodeForBaseType(Type searchType); // 0x0000000181BD8720-0x0000000181BD8840
		public static PropertyDescriptorCollection GetProperties(Type componentType); // 0x0000000181BD8C20-0x0000000181BD8D10
		public static PropertyDescriptorCollection GetProperties(object component); // 0x0000000181BD8EA0-0x0000000181BD8F40
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static PropertyDescriptorCollection GetProperties(object component, bool noCustomTypeDesc); // 0x0000000181BD8D10-0x0000000181BD8D80
		public static PropertyDescriptorCollection GetProperties(object component, Attribute[] attributes); // 0x0000000181BD8D80-0x0000000181BD8E20
		public static PropertyDescriptorCollection GetProperties(object component, Attribute[] attributes, bool noCustomTypeDesc); // 0x0000000181BD8E20-0x0000000181BD8EA0
		private static PropertyDescriptorCollection GetPropertiesImpl(object component, Attribute[] attributes, bool noCustomTypeDesc, bool noAttributes); // 0x0000000181BD8840-0x0000000181BD8C20
		internal static TypeDescriptionProvider GetProviderRecursive(Type type); // 0x0000000181BD8F40-0x0000000181BD8F90
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static Type GetReflectionType(Type type); // 0x0000000181BD8F90-0x0000000181BD90A0
		private static TypeDescriptionNode NodeFor(Type type); // 0x0000000181BD9400-0x0000000181BD9450
		private static TypeDescriptionNode NodeFor(Type type, bool createDelegator); // 0x0000000181BD9450-0x0000000181BD9A90
		private static TypeDescriptionNode NodeFor(object instance); // 0x0000000181BD9270-0x0000000181BD9400
		private static TypeDescriptionNode NodeFor(object instance, bool createDelegator); // 0x0000000181BD90A0-0x0000000181BD9270
		private static ICollection PipelineAttributeFilter(int pipelineType, ICollection members, Attribute[] filter, object instance, IDictionary cache); // 0x0000000181BD9A90-0x0000000181BD9F30
		private static ICollection PipelineFilter(int pipelineType, ICollection members, object instance, IDictionary cache); // 0x0000000181BD9F30-0x0000000181BDB060
		private static ICollection PipelineInitialize(int pipelineType, ICollection members, IDictionary cache); // 0x0000000181BDB060-0x0000000181BDB400
		private static ICollection PipelineMerge(int pipelineType, ICollection primary, ICollection secondary, object instance, IDictionary cache); // 0x0000000181BDB400-0x0000000181BDBE30
		private static void RaiseRefresh(Type type); // 0x0000000181BDBE30-0x0000000181BDBEE0
		public static void Refresh(Type type); // 0x0000000181BDBEE0-0x0000000181BDC430
		private static bool ShouldHideMember(MemberDescriptor member, Attribute attribute); // 0x0000000181BDC430-0x0000000181BDC4F0
		public static void SortDescriptorArray(IList infos); // 0x0000000181BDC4F0-0x0000000181BDC5C0
	}
}
