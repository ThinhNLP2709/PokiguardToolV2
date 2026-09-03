/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Playables
{
	[Serializable]
	[AssetFileNameExtension("playable", new string[0])]
	[RequiredByNativeCode]
	public abstract class PlayableAsset : ScriptableObject // TypeDefIndex: 8199
	{
		// Properties
		public virtual double duration { get; } // 0x000000018224B0C0-0x000000018224B110 
		public virtual IEnumerable<PlayableBinding> outputs { get; } // 0x000000018224B110-0x000000018224B160 
	
		// Constructors
		protected PlayableAsset(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public abstract Playable CreatePlayable(PlayableGraph graph, GameObject owner);
		[RequiredByNativeCode]
		internal static void Internal_CreatePlayable(PlayableAsset asset, PlayableGraph graph, GameObject go, IntPtr ptr); // 0x000000018224AF50-0x000000018224B080
		[RequiredByNativeCode]
		internal static void Internal_GetPlayableAssetDuration(PlayableAsset asset, IntPtr ptrToDouble); // 0x000000018224B080-0x000000018224B0C0
	}
}
