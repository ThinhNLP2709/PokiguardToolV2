/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Exceptions
{
	public class RemoteProviderException : ProviderException // TypeDefIndex: 13684
	{
		// Fields
		[CompilerGenerated]
		private readonly UnityWebRequestResult _WebRequestResult_k__BackingField; // 0x98
	
		// Properties
		public override string Message { get; } // 0x00000001815A1B20-0x00000001815A1B40 
		public UnityWebRequestResult WebRequestResult { [CompilerGenerated] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public RemoteProviderException(string message, IResourceLocation location = null, UnityWebRequestResult uwrResult = null, Exception innerException = null); // 0x0000000182052A90-0x0000000182052B20
	
		// Methods
		public override string ToString(); // 0x0000000182052820-0x0000000182052A90
	}
}
