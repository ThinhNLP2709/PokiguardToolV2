/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Exceptions
{
	public class UnknownResourceProviderException : ResourceManagerException // TypeDefIndex: 13681
	{
		// Fields
		[CompilerGenerated]
		private IResourceLocation _Location_k__BackingField; // 0x90
	
		// Properties
		public IResourceLocation Location { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
		public override string Message { get; } // 0x000000018205B4E0-0x000000018205B640 
	
		// Constructors
		public UnknownResourceProviderException(IResourceLocation location); // 0x000000018205B490-0x000000018205B4E0
		public UnknownResourceProviderException(); // 0x00000001815FE7B0-0x00000001815FE7E0
		public UnknownResourceProviderException(string message); // 0x00000001813FDE30-0x00000001813FDE70
		public UnknownResourceProviderException(string message, Exception innerException); // 0x00000001813FDED0-0x00000001813FDF70
		protected UnknownResourceProviderException(SerializationInfo message, StreamingContext context); // 0x00000001814ADEF0-0x00000001814ADF50
	
		// Methods
		public override string ToString(); // 0x00000001819D61B0-0x00000001819D61D0
	}
}
