/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class SharedDecalEntityManager : IDisposable // TypeDefIndex: 9708
	{
		// Fields
		private DecalEntityManager m_DecalEntityManager; // 0x10
		private int m_ReferenceCounter; // 0x18
	
		// Constructors
		public SharedDecalEntityManager(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public DecalEntityManager Get(); // 0x0000000181FD4900-0x0000000181FD4BA0
		public void Release(DecalEntityManager decalEntityManager); // 0x0000000181FD4D20-0x0000000181FD4EC0
		public void Dispose(); // 0x0000000181FD4770-0x0000000181FD4900
		private void OnDecalAdd(DecalProjector decalProjector); // 0x0000000181FD4BC0-0x0000000181FD4C20
		private void OnDecalRemove(DecalProjector decalProjector); // 0x0000000181FD4CF0-0x0000000181FD4D20
		private void OnDecalPropertyChange(DecalProjector decalProjector); // 0x0000000181FD4C90-0x0000000181FD4CF0
		private void OnAllDecalPropertyChange(); // 0x0000000181FD4BA0-0x0000000181FD4BC0
		private void OnDecalMaterialChange(DecalProjector decalProjector); // 0x0000000181FD4C20-0x0000000181FD4C90
	}
}
