/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	public abstract class PagedStore<T> // TypeDefIndex: 2859
		where T : class
	{
		// Fields
		[CompilerGenerated]
		private bool _Loading_k__BackingField;
		[CompilerGenerated]
		private bool _Loaded_k__BackingField;
		[CompilerGenerated]
		private int _Page_k__BackingField;
		public readonly List<T> Sorted;
		[CompilerGenerated]
		private Action Changed;
		[CompilerGenerated]
		private Action<string> Toast;
		protected int _userId;
		protected int _requestId;
	
		// Properties
		public bool Loading { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public bool Loaded { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int Page { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int Count { get; }
		public int TotalPages { get; }
	
		// Events
		public event Action Changed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		public event Action<string> Toast {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Constructors
		protected PagedStore();
	
		// Methods
		public T At(int index);
		public virtual void Reset();
		public void SetPage(int page);
		protected void RaiseChanged();
		protected void RaiseToast(string msg);
		public void Load();
		protected abstract IEnumerator Fetch(int rid);
		protected void Finish(int rid, Action apply);
		protected void Fail(int rid, string logTag, string err, string friendly);
		protected abstract void Sort();
	}
}
