/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	public class UnityWebRequestResult // TypeDefIndex: 13728
	{
		// Fields
		[CompilerGenerated]
		private string _Error_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly long _ResponseCode_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly UnityWebRequest.Result _Result_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly string _Method_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly string _Url_k__BackingField; // 0x30
	
		// Properties
		public string Error { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public long ResponseCode { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public UnityWebRequest.Result Result { [CompilerGenerated] get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public string Method { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		public string Url { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
	
		// Constructors
		public UnityWebRequestResult(UnityWebRequest request); // 0x000000018205AFF0-0x000000018205B0F0
	
		// Methods
		public override string ToString(); // 0x000000018205AEB0-0x000000018205AFF0
		public bool ShouldRetryDownloadError(); // 0x000000018205ABE0-0x000000018205AEB0
	}
}
