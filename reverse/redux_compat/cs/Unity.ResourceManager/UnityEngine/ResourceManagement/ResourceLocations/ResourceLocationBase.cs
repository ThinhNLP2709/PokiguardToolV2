/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceLocations
{
	public class ResourceLocationBase : IResourceLocation // TypeDefIndex: 13776
	{
		// Fields
		private string m_Name; // 0x10
		private string m_Id; // 0x18
		private string m_ProviderId; // 0x20
		private object m_Data; // 0x28
		private int m_DependencyHashCode; // 0x30
		private int m_HashCode; // 0x34
		private Type m_Type; // 0x38
		private List<IResourceLocation> m_Dependencies; // 0x40
		private string m_PrimaryKey; // 0x48
	
		// Properties
		public string InternalId { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string ProviderId { get; } // 0x00000001802F8630-0x00000001802F8640 
		public IList<IResourceLocation> Dependencies { get; } // 0x0000000180377940-0x0000000180377950 
		public bool HasDependencies { get; } // 0x0000000182052FE0-0x0000000182053000 
		public object Data { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public string PrimaryKey { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public int DependencyHashCode { get; } // 0x000000018033D100-0x000000018033D110 
		public Type ResourceType { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		public ResourceLocationBase(string name, string id, string providerId, Type t, params IResourceLocation[] dependencies); // 0x0000000182052D70-0x0000000182052FE0
	
		// Methods
		public int Hash(Type t); // 0x0000000182052D20-0x0000000182052D70
		public override string ToString(); // 0x00000001802F8EC0-0x00000001802F8ED0
		public void ComputeDependencyHash(); // 0x0000000182052B20-0x0000000182052D20
	}
}
