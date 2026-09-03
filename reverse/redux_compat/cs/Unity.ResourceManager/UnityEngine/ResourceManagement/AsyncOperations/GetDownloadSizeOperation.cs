/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.AsyncOperations
{
	internal class GetDownloadSizeOperation : AsyncOperationBase<long> // TypeDefIndex: 13798
	{
		// Fields
		private IEnumerable<IResourceLocation> m_Locations; // 0x98
		private bool m_Started; // 0xA0
	
		// Constructors
		public GetDownloadSizeOperation(); // 0x000000018205DF40-0x000000018205DF80
	
		// Methods
		public void Init(IEnumerable<IResourceLocation> locations, ResourceManager resourceManager); // 0x000000018205DED0-0x000000018205DF20
		private void Calculate(); // 0x000000018205DB10-0x000000018205DEC0
		protected override void Execute(); // 0x000000018205DEC0-0x000000018205DED0
		protected override bool InvokeWaitForCompletion(); // 0x000000018205DF20-0x000000018205DF40
	}
}
