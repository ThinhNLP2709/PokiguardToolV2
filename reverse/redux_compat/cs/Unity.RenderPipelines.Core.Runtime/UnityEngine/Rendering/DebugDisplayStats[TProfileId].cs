/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Obsolete("Use the non-generic DebugDisplayStats base class with ProfilingSampler lists. #from(6000.6)")]
	public abstract class DebugDisplayStats<TProfileId> : DebugDisplayStats // TypeDefIndex: 5438
		where TProfileId : Enum
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass0_0 // TypeDefIndex: 5439
		{
			// Fields
			public Type type;
			public Func<MemberInfo, bool> __9__0;
	
			// Constructors
			public __c__DisplayClass0_0();
	
			// Methods
			internal bool _GetProfilerIdsToDisplay_b__0(MemberInfo m);
		}
	
		// Constructors
		protected DebugDisplayStats();
	
		// Methods
		[Obsolete("Use GetProfilingSamplersToDisplay(Type) with a static marker class. #from(6000.6)")]
		protected List<TProfileId> GetProfilerIdsToDisplay();
		[Obsolete("Use UpdateDetailedStats(List<ProfilingSampler>) instead. #from(6000.6)")]
		protected void UpdateDetailedStats(List<TProfileId> samplers);
		[Obsolete("Use BuildDetailedStatsList(string, List<ProfilingSampler>) instead. #from(6000.6)")]
		protected DebugUI.Widget BuildDetailedStatsList(string title, List<TProfileId> samplers);
		private static List<ProfilingSampler> ConvertToSamplers(List<TProfileId> ids);
	}
}
