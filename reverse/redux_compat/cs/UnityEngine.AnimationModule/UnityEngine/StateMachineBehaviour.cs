/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Scripting;

// Image 32: UnityEngine.AnimationModule.dll - Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14715-14764

namespace UnityEngine
{
	[RequiredByNativeCode]
	public abstract class StateMachineBehaviour : ScriptableObject // TypeDefIndex: 14719
	{
		// Constructors
		protected StateMachineBehaviour(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
