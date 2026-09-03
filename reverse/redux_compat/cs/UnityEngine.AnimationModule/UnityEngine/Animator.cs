/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Playables;
using UnityEngine.Scripting;

// Image 32: UnityEngine.AnimationModule.dll - Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14715-14764

namespace UnityEngine
{
	[NativeClass("Animator", PersistentTypeId = 95)]
	[NativeHeader("Modules/Animation/ScriptBindings/Animator.bindings.h")]
	[NativeHeader("Modules/Animation/Animator.h")]
	[UsedByNativeCode]
	public class Animator : Behaviour // TypeDefIndex: 14737
	{
		// Properties
		public bool isOptimizable { [NativeMethod("IsOptimizable")] get; } // 0x0000000182161110-0x0000000182161170 
		public bool isHuman { [NativeMethod("IsHuman")] get; } // 0x0000000182160F30-0x0000000182160F90 
		public bool hasRootMotion { [NativeMethod("HasRootMotion")] get; } // 0x0000000182160D50-0x0000000182160DB0 
		internal bool isRootPositionOrRotationControlledByCurves { [NativeMethod("IsRootTranslationOrRotationControllerByCurves")] get; } // 0x00000001821611B0-0x0000000182161210 
		public float humanScale { get; } // 0x0000000182160E90-0x0000000182160EF0 
		public bool isInitialized { [NativeMethod("IsInitialized")] get; } // 0x0000000182160FD0-0x0000000182161030 
		public Vector3 deltaPosition { get; } // 0x0000000182160960-0x00000001821609D0 
		public Quaternion deltaRotation { get; } // 0x0000000182160A20-0x0000000182160A90 
		public Vector3 velocity { get; } // 0x0000000182162160-0x00000001821621D0 
		public Vector3 angularVelocity { get; } // 0x0000000182160270-0x00000001821602E0 
		public Vector3 rootPosition { [NativeMethod("GetAvatarPosition")] get; [NativeMethod("SetAvatarPosition")] set; } // 0x0000000182161B10-0x0000000182161B80 0x0000000182162D90-0x0000000182162DF0
		public Quaternion rootRotation { [NativeMethod("GetAvatarRotation")] get; [NativeMethod("SetAvatarRotation")] set; } // 0x0000000182161BD0-0x0000000182161C40 0x0000000182162E40-0x0000000182162EA0
		public bool applyRootMotion { get; set; } // 0x00000001821603C0-0x0000000182160420 0x0000000182162420-0x0000000182162480
		[Obsolete("Animator.linearVelocityBlending is no longer used and has been deprecated.")]
		public bool linearVelocityBlending { get; set; } // 0x00000001821614D0-0x0000000182161530 0x0000000182162B70-0x0000000182162BD0
		public bool animatePhysics { get; set; } // 0x0000000182160320-0x0000000182160380 0x0000000182162370-0x00000001821623D0
		public AnimatorUpdateMode updateMode { get; set; } // 0x00000001821620B0-0x0000000182162110 0x0000000182163120-0x0000000182163180
		public bool hasTransformHierarchy { get; } // 0x0000000182160DF0-0x0000000182160E50 
		internal bool allowConstantClipSamplingOptimization { get; set; } // 0x00000001821601C0-0x0000000182160220 0x00000001821622C0-0x0000000182162320
		public float gravityWeight { get; } // 0x0000000182160C10-0x0000000182160C70 
		public Vector3 bodyPosition { get; set; } // 0x0000000182160680-0x0000000182160720 0x0000000182162600-0x0000000182162680
		internal Vector3 bodyPositionInternal { [NativeMethod("GetBodyPosition")] get; [NativeMethod("SetBodyPosition")] set; } // 0x0000000182160610-0x0000000182160680 0x00000001821625A0-0x0000000182162600
		public Quaternion bodyRotation { get; set; } // 0x00000001821607E0-0x0000000182160870 0x0000000182162730-0x00000001821627B0
		internal Quaternion bodyRotationInternal { [NativeMethod("GetBodyRotation")] get; [NativeMethod("SetBodyRotation")] set; } // 0x0000000182160770-0x00000001821607E0 0x00000001821626D0-0x0000000182162730
		public bool stabilizeFeet { get; set; } // 0x0000000182161DF0-0x0000000182161E50 0x0000000182163080-0x00000001821630E0
		public int layerCount { get; } // 0x00000001821612F0-0x0000000182161350 
		public AnimatorControllerParameter[] parameters { [FreeFunction(Name = "AnimatorBindings::GetParameters", HasExplicitThis = true)] get; } // 0x00000001821616B0-0x0000000182161710 
		public int parameterCount { get; } // 0x0000000182161610-0x0000000182161670 
		public float feetPivotActive { get; set; } // 0x0000000182160AD0-0x0000000182160B30 0x00000001821628A0-0x0000000182162910
		public float pivotWeight { get; } // 0x0000000182161810-0x0000000182161870 
		public Vector3 pivotPosition { get; } // 0x0000000182161760-0x00000001821617D0 
		public bool isMatchingTarget { [NativeMethod("IsMatchingTarget")] get; } // 0x0000000182161070-0x00000001821610D0 
		public float speed { get; set; } // 0x0000000182161D50-0x0000000182161DB0 0x0000000182162FC0-0x0000000182163030
		public Vector3 targetPosition { get; } // 0x0000000182161F40-0x0000000182161FB0 
		public Quaternion targetRotation { get; } // 0x0000000182162000-0x0000000182162070 
		public Transform avatarRoot { get; } // 0x0000000182160460-0x00000001821604F0 
		public AnimatorCullingMode cullingMode { get; set; } // 0x00000001821608B0-0x0000000182160910 0x00000001821627F0-0x0000000182162850
		public float playbackTime { get; set; } // 0x0000000182161920-0x0000000182161980 0x0000000182162CD0-0x0000000182162D40
		public float recorderStartTime { get; set; } // 0x000000018215C1A0-0x000000018215C200 0x00000001802E76C0-0x00000001802E76D0
		public float recorderStopTime { get; set; } // 0x000000018215C240-0x000000018215C2A0 0x00000001802E76C0-0x00000001802E76D0
		public AnimatorRecorderMode recorderMode { get; } // 0x00000001821619C0-0x0000000182161A20 
		public RuntimeAnimatorController runtimeAnimatorController { get; set; } // 0x0000000182161C80-0x0000000182161D10 0x0000000182162EF0-0x0000000182162F70
		public bool hasBoundPlayables { [NativeMethod("HasBoundPlayables")] get; } // 0x0000000182160CB0-0x0000000182160D10 
		public Avatar avatar { get; set; } // 0x0000000182160530-0x00000001821605C0 0x00000001821624D0-0x0000000182162550
		public PlayableGraph playableGraph { get; } // 0x0000000182161870-0x00000001821618E0 
		public bool layersAffectMassCenter { get; set; } // 0x0000000182161390-0x00000001821613F0 0x0000000182162AC0-0x0000000182162B20
		public float leftFeetBottomHeight { get; } // 0x0000000182161430-0x0000000182161490 
		public float rightFeetBottomHeight { get; } // 0x0000000182161A60-0x0000000182161AC0 
		[NativeConditional("UNITY_EDITOR")]
		internal bool supportsOnAnimatorMove { [NativeMethod("SupportsOnAnimatorMove")] get; } // 0x0000000182161E90-0x0000000182161EF0 
		public bool logWarnings { get; set; } // 0x0000000182161570-0x00000001821615D0 0x0000000182162C20-0x0000000182162C80
		public bool fireEvents { get; set; } // 0x0000000182160B70-0x0000000182160BD0 0x0000000182162960-0x00000001821629C0
		[Obsolete("keepAnimatorControllerStateOnDisable is deprecated, use keepAnimatorStateOnDisable instead. (UnityUpgradable) -> keepAnimatorStateOnDisable", false)]
		public bool keepAnimatorControllerStateOnDisable { get; set; } // 0x0000000182161210-0x0000000182161270 0x00000001821629C0-0x0000000182162A20
		public bool keepAnimatorStateOnDisable { get; set; } // 0x0000000182161210-0x0000000182161270 0x00000001821629C0-0x0000000182162A20
		public bool writeDefaultValuesOnDisable { get; set; } // 0x0000000182162210-0x0000000182162270 0x00000001821631D0-0x0000000182163230
	
		// Constructors
		public Animator(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public float GetFloat(string name); // 0x000000018215AF90-0x000000018215AFA0
		public float GetFloat(int id); // 0x000000018215AD50-0x000000018215ADB0
		public void SetFloat(string name, float value); // 0x000000018215E7A0-0x000000018215E7B0
		public void SetFloat(string name, float value, float dampTime, float deltaTime); // 0x000000018215E790-0x000000018215E7A0
		public void SetFloat(int id, float value); // 0x000000018215E330-0x000000018215E3A0
		public void SetFloat(int id, float value, float dampTime, float deltaTime); // 0x000000018215E260-0x000000018215E2E0
		public bool GetBool(string name); // 0x000000018215AA30-0x000000018215AA40
		public bool GetBool(int id); // 0x000000018215A800-0x000000018215A860
		public void SetBool(string name, bool value); // 0x000000018215E1F0-0x000000018215E200
		public void SetBool(int id, bool value); // 0x000000018215DFA0-0x000000018215E010
		public int GetInteger(string name); // 0x000000018215B9B0-0x000000018215B9C0
		public int GetInteger(int id); // 0x000000018215B780-0x000000018215B7E0
		public void SetInteger(string name, int value); // 0x000000018215F1F0-0x000000018215F200
		public void SetInteger(int id, int value); // 0x000000018215EFA0-0x000000018215F010
		public void SetTrigger(string name); // 0x000000018215FB60-0x000000018215FB70
		public void SetTrigger(int id); // 0x000000018215F940-0x000000018215F9A0
		public void ResetTrigger(string name); // 0x000000018215DC70-0x000000018215DC80
		public void ResetTrigger(int id); // 0x000000018215DA50-0x000000018215DAB0
		public bool IsParameterControlledByCurve(string name); // 0x000000018215CC60-0x000000018215CC70
		public bool IsParameterControlledByCurve(int id); // 0x000000018215CA30-0x000000018215CA90
		public Vector3 GetIKPosition(AvatarIKGoal goal); // 0x000000018215B580-0x000000018215B630
		private Vector3 GetGoalPosition(AvatarIKGoal goal); // 0x000000018215AFF0-0x000000018215B070
		public void SetIKPosition(AvatarIKGoal goal, Vector3 goalPosition); // 0x000000018215EDC0-0x000000018215EE50
		private void SetGoalPosition(AvatarIKGoal goal, Vector3 goalPosition); // 0x000000018215E800-0x000000018215E870
		public Quaternion GetIKRotation(AvatarIKGoal goal); // 0x000000018215B6A0-0x000000018215B740
		private Quaternion GetGoalRotation(AvatarIKGoal goal); // 0x000000018215B0C0-0x000000018215B140
		public void SetIKRotation(AvatarIKGoal goal, Quaternion goalRotation); // 0x000000018215EED0-0x000000018215EF50
		private void SetGoalRotation(AvatarIKGoal goal, Quaternion goalRotation); // 0x000000018215E8C0-0x000000018215E930
		public float GetIKPositionWeight(AvatarIKGoal goal); // 0x000000018215B510-0x000000018215B580
		private float GetGoalWeightPosition(AvatarIKGoal goal); // 0x000000018215B180-0x000000018215B1E0
		public void SetIKPositionWeight(AvatarIKGoal goal, float value); // 0x000000018215ED40-0x000000018215EDC0
		private void SetGoalWeightPosition(AvatarIKGoal goal, float value); // 0x000000018215E980-0x000000018215E9F0
		public float GetIKRotationWeight(AvatarIKGoal goal); // 0x000000018215B630-0x000000018215B6A0
		private float GetGoalWeightRotation(AvatarIKGoal goal); // 0x000000018215B220-0x000000018215B280
		public void SetIKRotationWeight(AvatarIKGoal goal, float value); // 0x000000018215EE50-0x000000018215EED0
		private void SetGoalWeightRotation(AvatarIKGoal goal, float value); // 0x000000018215EA40-0x000000018215EAB0
		public Vector3 GetIKHintPosition(AvatarIKHint hint); // 0x000000018215B460-0x000000018215B510
		private Vector3 GetHintPosition(AvatarIKHint hint); // 0x000000018215B2D0-0x000000018215B350
		public void SetIKHintPosition(AvatarIKHint hint, Vector3 hintPosition); // 0x000000018215ECB0-0x000000018215ED40
		private void SetHintPosition(AvatarIKHint hint, Vector3 hintPosition); // 0x000000018215EB00-0x000000018215EB70
		public float GetIKHintPositionWeight(AvatarIKHint hint); // 0x000000018215B3F0-0x000000018215B460
		private float GetHintWeightPosition(AvatarIKHint hint); // 0x000000018215B390-0x000000018215B3F0
		public void SetIKHintPositionWeight(AvatarIKHint hint, float value); // 0x000000018215EC30-0x000000018215ECB0
		private void SetHintWeightPosition(AvatarIKHint hint, float value); // 0x000000018215EBC0-0x000000018215EC30
		public void SetLookAtPosition(Vector3 lookAtPosition); // 0x000000018215F370-0x000000018215F3F0
		[NativeMethod("SetLookAtPosition")]
		private void SetLookAtPositionInternal(Vector3 lookAtPosition); // 0x000000018215F310-0x000000018215F370
		public void SetLookAtWeight(float weight); // 0x000000018215F7A0-0x000000018215F840
		public void SetLookAtWeight(float weight, float bodyWeight); // 0x000000018215F4F0-0x000000018215F5A0
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight); // 0x000000018215F6F0-0x000000018215F7A0
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight); // 0x000000018215F5A0-0x000000018215F650
		public void SetLookAtWeight(float weight, [DefaultValue("0.0f")] float bodyWeight, [DefaultValue("1.0f")] float headWeight, [DefaultValue("0.0f")] float eyesWeight, [DefaultValue("0.5f")] float clampWeight); // 0x000000018215F650-0x000000018215F6F0
		[NativeMethod("SetLookAtWeight")]
		private void SetLookAtWeightInternal(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight); // 0x000000018215F460-0x000000018215F4F0
		public void SetBoneLocalRotation(HumanBodyBones humanBoneId, Quaternion rotation); // 0x000000018215DE90-0x000000018215DF40
		[NativeMethod("SetBoneLocalRotation")]
		private void SetBoneLocalRotationInternal(int humanBoneId, Quaternion rotation); // 0x000000018215DE20-0x000000018215DE90
		private ScriptableObject GetBehaviour([NotNull] Type type); // 0x000000018215A0E0-0x000000018215A1A0
		public T GetBehaviour<T>()
			where T : StateMachineBehaviour;
		private static T[] ConvertStateMachineBehaviour<T>(ScriptableObject[] rawObjects)
			where T : StateMachineBehaviour;
		public T[] GetBehaviours<T>()
			where T : StateMachineBehaviour;
		[FreeFunction(Name = "AnimatorBindings::InternalGetBehaviours", HasExplicitThis = true)]
		internal ScriptableObject[] InternalGetBehaviours([NotNull] Type type); // 0x000000018215C630-0x000000018215C6D0
		public StateMachineBehaviour[] GetBehaviours(int fullPathHash, int layerIndex); // 0x000000018215A1A0-0x000000018215A2B0
		[FreeFunction(Name = "AnimatorBindings::InternalGetBehavioursByKey", HasExplicitThis = true)]
		internal ScriptableObject[] InternalGetBehavioursByKey(int fullPathHash, int layerIndex, [NotNull] Type type); // 0x000000018215C520-0x000000018215C5E0
		public string GetLayerName(int layerIndex); // 0x000000018215BBE0-0x000000018215BCE0
		public int GetLayerIndex(string layerName); // 0x000000018215BA10-0x000000018215BB90
		public float GetLayerWeight(int layerIndex); // 0x000000018215BD20-0x000000018215BD80
		public void SetLayerWeight(int layerIndex, float weight); // 0x000000018215F250-0x000000018215F2C0
		private void GetAnimatorStateInfo(int layerIndex, StateInfoIndex stateInfoIndex, out AnimatorStateInfo info); // 0x0000000182159D50-0x0000000182159DD0
		public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex); // 0x000000018215ABC0-0x000000018215AC50
		public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex); // 0x000000018215BF00-0x000000018215BF90
		private void GetAnimatorTransitionInfo(int layerIndex, out AnimatorTransitionInfo info); // 0x0000000182159FA0-0x000000018215A010
		public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex); // 0x000000018215A010-0x000000018215A090
		internal int GetAnimatorClipInfoCount(int layerIndex, bool current); // 0x0000000182159A40-0x0000000182159AB0
		public int GetCurrentAnimatorClipInfoCount(int layerIndex); // 0x000000018215AA40-0x000000018215AAA0
		public int GetNextAnimatorClipInfoCount(int layerIndex); // 0x000000018215BD80-0x000000018215BDE0
		[FreeFunction(Name = "AnimatorBindings::GetCurrentAnimatorClipInfo", HasExplicitThis = true)]
		public AnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex); // 0x000000018215AB60-0x000000018215ABC0
		[FreeFunction(Name = "AnimatorBindings::GetNextAnimatorClipInfo", HasExplicitThis = true)]
		public AnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex); // 0x000000018215BEA0-0x000000018215BF00
		public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips); // 0x000000018215AAE0-0x000000018215AB60
		[FreeFunction(Name = "AnimatorBindings::GetAnimatorClipInfoInternal", HasExplicitThis = true)]
		private void GetAnimatorClipInfoInternal(int layerIndex, bool isCurrent, [NotNull] out List<AnimatorClipInfo> clips); // 0x0000000182159B20-0x0000000182159CF0
		public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips); // 0x000000018215BE20-0x000000018215BEA0
		public bool IsInTransition(int layerIndex); // 0x000000018215C990-0x000000018215C9F0
		[FreeFunction(Name = "AnimatorBindings::GetParameterInternal", HasExplicitThis = true)]
		private AnimatorControllerParameter GetParameterInternal(int index); // 0x000000018215BFE0-0x000000018215C040
		public AnimatorControllerParameter GetParameter(int index); // 0x000000018215C040-0x000000018215C140
		private void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, int targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime, bool completeMatch); // 0x000000018215CE90-0x000000018215CF40
		public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime); // 0x000000018215CDC0-0x000000018215CE90
		public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, [DefaultValue("1")] float targetNormalizedTime); // 0x000000018215CCF0-0x000000018215CDC0
		public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, [DefaultValue("1")] float targetNormalizedTime, [DefaultValue("true")] bool completeMatch); // 0x000000018215CF40-0x000000018215D010
		public void InterruptMatchTarget(); // 0x000000018215C780-0x000000018215C7E0
		public void InterruptMatchTarget([DefaultValue("true")] bool completeMatch); // 0x000000018215C720-0x000000018215C780
		[Obsolete("ForceStateNormalizedTime is deprecated. Please use Play or CrossFade instead.")]
		public void ForceStateNormalizedTime(float normalizedTime); // 0x0000000182159970-0x00000001821599E0
		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration); // 0x0000000182159280-0x0000000182159320
		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer); // 0x0000000182158F80-0x0000000182159030
		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset); // 0x00000001821590B0-0x0000000182159150
		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("0.0f")] float fixedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime); // 0x00000001821591E0-0x0000000182159280
		public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset); // 0x0000000182159150-0x00000001821591E0
		public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer); // 0x0000000182158E70-0x0000000182158F00
		public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration); // 0x0000000182158F00-0x0000000182158F80
		[FreeFunction(Name = "AnimatorBindings::CrossFadeInFixedTime", HasExplicitThis = true)]
		public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("0.0f")] float fixedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime); // 0x0000000182159030-0x00000001821590B0
		[FreeFunction(Name = "AnimatorBindings::WriteDefaultValues", HasExplicitThis = true)]
		public void WriteDefaultValues(); // 0x0000000182160120-0x0000000182160180
		public void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset); // 0x00000001821594C0-0x0000000182159560
		public void CrossFade(string stateName, float normalizedTransitionDuration, int layer); // 0x0000000182159410-0x00000001821594C0
		public void CrossFade(string stateName, float normalizedTransitionDuration); // 0x0000000182159670-0x0000000182159720
		public void CrossFade(string stateName, float normalizedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float normalizedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime); // 0x0000000182159720-0x00000001821597C0
		[FreeFunction(Name = "AnimatorBindings::CrossFade", HasExplicitThis = true)]
		public void CrossFade(int stateHashName, float normalizedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("0.0f")] float normalizedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime); // 0x0000000182159560-0x00000001821595E0
		public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset); // 0x00000001821597C0-0x0000000182159850
		public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer); // 0x0000000182159380-0x0000000182159410
		public void CrossFade(int stateHashName, float normalizedTransitionDuration); // 0x00000001821595E0-0x0000000182159670
		public void PlayInFixedTime(string stateName, int layer); // 0x000000018215D350-0x000000018215D3E0
		public void PlayInFixedTime(string stateName); // 0x000000018215D220-0x000000018215D2B0
		public void PlayInFixedTime(string stateName, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float fixedTime); // 0x000000018215D2B0-0x000000018215D350
		[FreeFunction(Name = "AnimatorBindings::PlayInFixedTime", HasExplicitThis = true)]
		public void PlayInFixedTime(int stateNameHash, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float fixedTime); // 0x000000018215D3E0-0x000000018215D460
		public void PlayInFixedTime(int stateNameHash, int layer); // 0x000000018215D1B0-0x000000018215D220
		public void PlayInFixedTime(int stateNameHash); // 0x000000018215D460-0x000000018215D4D0
		public void Play(string stateName, int layer); // 0x000000018215D6E0-0x000000018215D770
		public void Play(string stateName); // 0x000000018215D530-0x000000018215D5C0
		public void Play(string stateName, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float normalizedTime); // 0x000000018215D640-0x000000018215D6E0
		[FreeFunction(Name = "AnimatorBindings::Play", HasExplicitThis = true)]
		public void Play(int stateNameHash, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float normalizedTime); // 0x000000018215D5C0-0x000000018215D640
		public void Play(int stateNameHash, int layer); // 0x000000018215D770-0x000000018215D7E0
		public void Play(int stateNameHash); // 0x000000018215D7E0-0x000000018215D850
		public void ResetControllerState([DefaultValue("true")] bool resetParameters = true /* Metadata: 0x006A97D2 */); // 0x000000018215D9B0-0x000000018215DA10
		public void SetTarget(AvatarTarget targetIndex, float targetNormalizedTime); // 0x000000018215F890-0x000000018215F900
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use mask and layers to control subset of transfroms in a skeleton.", true)]
		public bool IsControlled(Transform transform); // 0x00000001802E7840-0x00000001802E7850
		internal bool IsBoneTransform(Transform transform); // 0x000000018215C830-0x000000018215C8B0
		public Transform GetBoneTransform(HumanBodyBones humanBoneId); // 0x000000018215A390-0x000000018215A7C0
		[NativeMethod("GetBoneTransform")]
		internal Transform GetBoneTransformInternal(int humanBoneId); // 0x000000018215A2F0-0x000000018215A390
		public void StartPlayback(); // 0x000000018215FBB0-0x000000018215FC10
		public void StopPlayback(); // 0x000000018215FCF0-0x000000018215FD50
		public void StartRecording(int frameCount); // 0x000000018215FC50-0x000000018215FCB0
		public void StopRecording(); // 0x000000018215FD90-0x000000018215FDF0
		private float GetRecorderStartTime(); // 0x000000018215C1A0-0x000000018215C200
		private float GetRecorderStopTime(); // 0x000000018215C240-0x000000018215C2A0
		internal void ClearInternalControllerPlayable(); // 0x0000000182158DB0-0x0000000182158E10
		public bool HasState(int layerIndex, int stateID); // 0x000000018215C450-0x000000018215C4C0
		[NativeMethod(Name = "ScriptingStringToCRC32", IsThreadSafe = true)]
		public static int StringToHash(string name); // 0x000000018215FE30-0x000000018215FF80
		internal string GetStats(); // 0x000000018215C2F0-0x000000018215C3E0
		[FreeFunction(Name = "AnimatorBindings::GetCurrentGraph", HasExplicitThis = true)]
		private void GetCurrentGraph(ref PlayableGraph graph); // 0x000000018215ACA0-0x000000018215AD00
		private void CheckIfInIKPass(); // 0x0000000182158C80-0x0000000182158D70
		private bool IsInIKPass(); // 0x000000018215C8F0-0x000000018215C950
		[FreeFunction(Name = "AnimatorBindings::SetFloatString", HasExplicitThis = true)]
		private void SetFloatString(string name, float value); // 0x000000018215E610-0x000000018215E790
		[FreeFunction(Name = "AnimatorBindings::SetFloatID", HasExplicitThis = true)]
		private void SetFloatID(int id, float value); // 0x000000018215E330-0x000000018215E3A0
		[FreeFunction(Name = "AnimatorBindings::GetFloatString", HasExplicitThis = true)]
		private float GetFloatString(string name); // 0x000000018215AE00-0x000000018215AF90
		[FreeFunction(Name = "AnimatorBindings::GetFloatID", HasExplicitThis = true)]
		private float GetFloatID(int id); // 0x000000018215AD50-0x000000018215ADB0
		[FreeFunction(Name = "AnimatorBindings::SetBoolString", HasExplicitThis = true)]
		private void SetBoolString(string name, bool value); // 0x000000018215E070-0x000000018215E1F0
		[FreeFunction(Name = "AnimatorBindings::SetBoolID", HasExplicitThis = true)]
		private void SetBoolID(int id, bool value); // 0x000000018215DFA0-0x000000018215E010
		[FreeFunction(Name = "AnimatorBindings::GetBoolString", HasExplicitThis = true)]
		private bool GetBoolString(string name); // 0x000000018215A8B0-0x000000018215AA30
		[FreeFunction(Name = "AnimatorBindings::GetBoolID", HasExplicitThis = true)]
		private bool GetBoolID(int id); // 0x000000018215A800-0x000000018215A860
		[FreeFunction(Name = "AnimatorBindings::SetIntegerString", HasExplicitThis = true)]
		private void SetIntegerString(string name, int value); // 0x000000018215F070-0x000000018215F1F0
		[FreeFunction(Name = "AnimatorBindings::SetIntegerID", HasExplicitThis = true)]
		private void SetIntegerID(int id, int value); // 0x000000018215EFA0-0x000000018215F010
		[FreeFunction(Name = "AnimatorBindings::GetIntegerString", HasExplicitThis = true)]
		private int GetIntegerString(string name); // 0x000000018215B830-0x000000018215B9B0
		[FreeFunction(Name = "AnimatorBindings::GetIntegerID", HasExplicitThis = true)]
		private int GetIntegerID(int id); // 0x000000018215B780-0x000000018215B7E0
		[FreeFunction(Name = "AnimatorBindings::SetTriggerString", HasExplicitThis = true)]
		private void SetTriggerString(string name); // 0x000000018215F9F0-0x000000018215FB60
		[FreeFunction(Name = "AnimatorBindings::SetTriggerID", HasExplicitThis = true)]
		private void SetTriggerID(int id); // 0x000000018215F940-0x000000018215F9A0
		[FreeFunction(Name = "AnimatorBindings::ResetTriggerString", HasExplicitThis = true)]
		private void ResetTriggerString(string name); // 0x000000018215DB00-0x000000018215DC70
		[FreeFunction(Name = "AnimatorBindings::ResetTriggerID", HasExplicitThis = true)]
		private void ResetTriggerID(int id); // 0x000000018215DA50-0x000000018215DAB0
		[FreeFunction(Name = "AnimatorBindings::IsParameterControlledByCurveString", HasExplicitThis = true)]
		private bool IsParameterControlledByCurveString(string name); // 0x000000018215CAE0-0x000000018215CC60
		[FreeFunction(Name = "AnimatorBindings::IsParameterControlledByCurveID", HasExplicitThis = true)]
		private bool IsParameterControlledByCurveID(int id); // 0x000000018215CA30-0x000000018215CA90
		[FreeFunction(Name = "AnimatorBindings::SetFloatStringDamp", HasExplicitThis = true)]
		private void SetFloatStringDamp(string name, float value, float dampTime, float deltaTime); // 0x000000018215E410-0x000000018215E5B0
		[FreeFunction(Name = "AnimatorBindings::SetFloatIDDamp", HasExplicitThis = true)]
		private void SetFloatIDDamp(int id, float value, float dampTime, float deltaTime); // 0x000000018215E260-0x000000018215E2E0
		[NativeConditional("UNITY_EDITOR")]
		internal void OnUpdateModeChanged(); // 0x000000018215D0F0-0x000000018215D150
		[NativeConditional("UNITY_EDITOR")]
		internal void OnCullingModeChanged(); // 0x000000018215D050-0x000000018215D0B0
		[NativeConditional("UNITY_EDITOR")]
		internal void WriteDefaultPose(); // 0x0000000182160080-0x00000001821600E0
		[NativeMethod("UpdateWithDelta")]
		public void Update(float deltaTime); // 0x000000018215FFD0-0x0000000182160040
		public void Rebind(); // 0x000000018215D8A0-0x000000018215D900
		private void Rebind(bool writeDefaultValues); // 0x000000018215D900-0x000000018215D960
		public void ApplyBuiltinRootMotion(); // 0x0000000182158C20-0x0000000182158C80
		[NativeConditional("UNITY_EDITOR")]
		internal void EvaluateController(); // 0x0000000182159910-0x0000000182159970
		private void EvaluateController(float deltaTime); // 0x00000001821598A0-0x0000000182159910
		[NativeConditional("UNITY_EDITOR")]
		internal string GetCurrentStateName(int layerIndex); // 0x000000018215AD00-0x000000018215AD10
		[NativeConditional("UNITY_EDITOR")]
		internal string GetNextStateName(int layerIndex); // 0x000000018215BF90-0x000000018215BFA0
		[NativeConditional("UNITY_EDITOR")]
		private string GetAnimatorStateName(int layerIndex, bool current); // 0x0000000182159E40-0x0000000182159F50
		internal string ResolveHash(int hash); // 0x000000018215DCD0-0x000000018215DDD0
		[Obsolete("GetVector is deprecated.")]
		public Vector3 GetVector(string name); // 0x000000018215C3E0-0x000000018215C400
		[Obsolete("GetVector is deprecated.")]
		public Vector3 GetVector(int id); // 0x000000018215C3E0-0x000000018215C400
		[Obsolete("SetVector is deprecated.")]
		public void SetVector(string name, Vector3 value); // 0x00000001802E76C0-0x00000001802E76D0
		[Obsolete("SetVector is deprecated.")]
		public void SetVector(int id, Vector3 value); // 0x00000001802E76C0-0x00000001802E76D0
		[Obsolete("GetQuaternion is deprecated.")]
		public Quaternion GetQuaternion(string name); // 0x000000018215C140-0x000000018215C160
		[Obsolete("GetQuaternion is deprecated.")]
		public Quaternion GetQuaternion(int id); // 0x000000018215C140-0x000000018215C160
		[Obsolete("SetQuaternion is deprecated.")]
		public void SetQuaternion(string name, Quaternion value); // 0x00000001802E76C0-0x00000001802E76D0
		[Obsolete("SetQuaternion is deprecated.")]
		public void SetQuaternion(int id, Quaternion value); // 0x00000001802E76C0-0x00000001802E76D0
		private static bool get_isOptimizable_Injected(IntPtr _unity_self); // 0x00000001821610D0-0x0000000182161110
		private static bool get_isHuman_Injected(IntPtr _unity_self); // 0x0000000182160EF0-0x0000000182160F30
		private static bool get_hasRootMotion_Injected(IntPtr _unity_self); // 0x0000000182160D10-0x0000000182160D50
		private static bool get_isRootPositionOrRotationControlledByCurves_Injected(IntPtr _unity_self); // 0x0000000182161170-0x00000001821611B0
		private static float get_humanScale_Injected(IntPtr _unity_self); // 0x0000000182160E50-0x0000000182160E90
		private static bool get_isInitialized_Injected(IntPtr _unity_self); // 0x0000000182160F90-0x0000000182160FD0
		private static void get_deltaPosition_Injected(IntPtr _unity_self, ); // 0x0000000182160910-0x0000000182160960
		private static void get_deltaRotation_Injected(IntPtr _unity_self, ); // 0x00000001821609D0-0x0000000182160A20
		private static void get_velocity_Injected(IntPtr _unity_self, ); // 0x0000000182162110-0x0000000182162160
		private static void get_angularVelocity_Injected(IntPtr _unity_self, ); // 0x0000000182160220-0x0000000182160270
		private static void get_rootPosition_Injected(IntPtr _unity_self, ); // 0x0000000182161AC0-0x0000000182161B10
		private static void set_rootPosition_Injected(IntPtr _unity_self, in Vector3 value); // 0x0000000182162D40-0x0000000182162D90
		private static void get_rootRotation_Injected(IntPtr _unity_self, ); // 0x0000000182161B80-0x0000000182161BD0
		private static void set_rootRotation_Injected(IntPtr _unity_self, in Quaternion value); // 0x0000000182162DF0-0x0000000182162E40
		private static bool get_applyRootMotion_Injected(IntPtr _unity_self); // 0x0000000182160380-0x00000001821603C0
		private static void set_applyRootMotion_Injected(IntPtr _unity_self, bool value); // 0x00000001821623D0-0x0000000182162420
		private static bool get_linearVelocityBlending_Injected(IntPtr _unity_self); // 0x0000000182161490-0x00000001821614D0
		private static void set_linearVelocityBlending_Injected(IntPtr _unity_self, bool value); // 0x0000000182162B20-0x0000000182162B70
		private static bool get_animatePhysics_Injected(IntPtr _unity_self); // 0x00000001821602E0-0x0000000182160320
		private static void set_animatePhysics_Injected(IntPtr _unity_self, bool value); // 0x0000000182162320-0x0000000182162370
		private static AnimatorUpdateMode get_updateMode_Injected(IntPtr _unity_self); // 0x0000000182162070-0x00000001821620B0
		private static void set_updateMode_Injected(IntPtr _unity_self, AnimatorUpdateMode value); // 0x00000001821630E0-0x0000000182163120
		private static bool get_hasTransformHierarchy_Injected(IntPtr _unity_self); // 0x0000000182160DB0-0x0000000182160DF0
		private static bool get_allowConstantClipSamplingOptimization_Injected(IntPtr _unity_self); // 0x0000000182160180-0x00000001821601C0
		private static void set_allowConstantClipSamplingOptimization_Injected(IntPtr _unity_self, bool value); // 0x0000000182162270-0x00000001821622C0
		private static float get_gravityWeight_Injected(IntPtr _unity_self); // 0x0000000182160BD0-0x0000000182160C10
		private static void get_bodyPositionInternal_Injected(IntPtr _unity_self, ); // 0x00000001821605C0-0x0000000182160610
		private static void set_bodyPositionInternal_Injected(IntPtr _unity_self, in Vector3 value); // 0x0000000182162550-0x00000001821625A0
		private static void get_bodyRotationInternal_Injected(IntPtr _unity_self, ); // 0x0000000182160720-0x0000000182160770
		private static void set_bodyRotationInternal_Injected(IntPtr _unity_self, in Quaternion value); // 0x0000000182162680-0x00000001821626D0
		private static void GetGoalPosition_Injected(IntPtr _unity_self, AvatarIKGoal goal, ); // 0x000000018215AFA0-0x000000018215AFF0
		private static void SetGoalPosition_Injected(IntPtr _unity_self, AvatarIKGoal goal, in Vector3 goalPosition); // 0x000000018215E7B0-0x000000018215E800
		private static void GetGoalRotation_Injected(IntPtr _unity_self, AvatarIKGoal goal, ); // 0x000000018215B070-0x000000018215B0C0
		private static void SetGoalRotation_Injected(IntPtr _unity_self, AvatarIKGoal goal, in Quaternion goalRotation); // 0x000000018215E870-0x000000018215E8C0
		private static float GetGoalWeightPosition_Injected(IntPtr _unity_self, AvatarIKGoal goal); // 0x000000018215B140-0x000000018215B180
		private static void SetGoalWeightPosition_Injected(IntPtr _unity_self, AvatarIKGoal goal, float value); // 0x000000018215E930-0x000000018215E980
		private static float GetGoalWeightRotation_Injected(IntPtr _unity_self, AvatarIKGoal goal); // 0x000000018215B1E0-0x000000018215B220
		private static void SetGoalWeightRotation_Injected(IntPtr _unity_self, AvatarIKGoal goal, float value); // 0x000000018215E9F0-0x000000018215EA40
		private static void GetHintPosition_Injected(IntPtr _unity_self, AvatarIKHint hint, ); // 0x000000018215B280-0x000000018215B2D0
		private static void SetHintPosition_Injected(IntPtr _unity_self, AvatarIKHint hint, in Vector3 hintPosition); // 0x000000018215EAB0-0x000000018215EB00
		private static float GetHintWeightPosition_Injected(IntPtr _unity_self, AvatarIKHint hint); // 0x000000018215B350-0x000000018215B390
		private static void SetHintWeightPosition_Injected(IntPtr _unity_self, AvatarIKHint hint, float value); // 0x000000018215EB70-0x000000018215EBC0
		private static void SetLookAtPositionInternal_Injected(IntPtr _unity_self, in Vector3 lookAtPosition); // 0x000000018215F2C0-0x000000018215F310
		private static void SetLookAtWeightInternal_Injected(IntPtr _unity_self, float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight); // 0x000000018215F3F0-0x000000018215F460
		private static void SetBoneLocalRotationInternal_Injected(IntPtr _unity_self, int humanBoneId, in Quaternion rotation); // 0x000000018215DDD0-0x000000018215DE20
		private static IntPtr GetBehaviour_Injected(IntPtr _unity_self, Type type); // 0x000000018215A090-0x000000018215A0E0
		private static ScriptableObject[] InternalGetBehaviours_Injected(IntPtr _unity_self, Type type); // 0x000000018215C5E0-0x000000018215C630
		private static ScriptableObject[] InternalGetBehavioursByKey_Injected(IntPtr _unity_self, int fullPathHash, int layerIndex, Type type); // 0x000000018215C4C0-0x000000018215C520
		private static bool get_stabilizeFeet_Injected(IntPtr _unity_self); // 0x0000000182161DB0-0x0000000182161DF0
		private static void set_stabilizeFeet_Injected(IntPtr _unity_self, bool value); // 0x0000000182163030-0x0000000182163080
		private static int get_layerCount_Injected(IntPtr _unity_self); // 0x00000001821612B0-0x00000001821612F0
		private static void GetLayerName_Injected(IntPtr _unity_self, int layerIndex, ); // 0x000000018215BB90-0x000000018215BBE0
		private static int GetLayerIndex_Injected(IntPtr _unity_self, ref ManagedSpanWrapper layerName); // 0x000000018215B9C0-0x000000018215BA10
		private static float GetLayerWeight_Injected(IntPtr _unity_self, int layerIndex); // 0x000000018215BCE0-0x000000018215BD20
		private static void SetLayerWeight_Injected(IntPtr _unity_self, int layerIndex, float weight); // 0x000000018215F200-0x000000018215F250
		private static void GetAnimatorStateInfo_Injected(IntPtr _unity_self, int layerIndex, StateInfoIndex stateInfoIndex, out AnimatorStateInfo info); // 0x0000000182159CF0-0x0000000182159D50
		private static void GetAnimatorTransitionInfo_Injected(IntPtr _unity_self, int layerIndex, out AnimatorTransitionInfo info); // 0x0000000182159F50-0x0000000182159FA0
		private static int GetAnimatorClipInfoCount_Injected(IntPtr _unity_self, int layerIndex, bool current); // 0x00000001821599E0-0x0000000182159A40
		private static AnimatorClipInfo[] GetCurrentAnimatorClipInfo_Injected(IntPtr _unity_self, int layerIndex); // 0x000000018215AAA0-0x000000018215AAE0
		private static AnimatorClipInfo[] GetNextAnimatorClipInfo_Injected(IntPtr _unity_self, int layerIndex); // 0x000000018215BDE0-0x000000018215BE20
		private static void GetAnimatorClipInfoInternal_Injected(IntPtr _unity_self, int layerIndex, bool isCurrent, out BlittableListWrapper clips); // 0x0000000182159AB0-0x0000000182159B20
		private static bool IsInTransition_Injected(IntPtr _unity_self, int layerIndex); // 0x000000018215C950-0x000000018215C990
		private static AnimatorControllerParameter[] get_parameters_Injected(IntPtr _unity_self); // 0x0000000182161670-0x00000001821616B0
		private static int get_parameterCount_Injected(IntPtr _unity_self); // 0x00000001821615D0-0x0000000182161610
		private static AnimatorControllerParameter GetParameterInternal_Injected(IntPtr _unity_self, int index); // 0x000000018215BFA0-0x000000018215BFE0
		private static float get_feetPivotActive_Injected(IntPtr _unity_self); // 0x0000000182160A90-0x0000000182160AD0
		private static void set_feetPivotActive_Injected(IntPtr _unity_self, float value); // 0x0000000182162850-0x00000001821628A0
		private static float get_pivotWeight_Injected(IntPtr _unity_self); // 0x00000001821617D0-0x0000000182161810
		private static void get_pivotPosition_Injected(IntPtr _unity_self, ); // 0x0000000182161710-0x0000000182161760
		private static void MatchTarget_Injected(IntPtr _unity_self, in Vector3 matchPosition, in Quaternion matchRotation, int targetBodyPart, in MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime, bool completeMatch); // 0x000000018215CC70-0x000000018215CCF0
		private static void InterruptMatchTarget_Injected(IntPtr _unity_self, [DefaultValue("true")] bool completeMatch); // 0x000000018215C6D0-0x000000018215C720
		private static bool get_isMatchingTarget_Injected(IntPtr _unity_self); // 0x0000000182161030-0x0000000182161070
		private static float get_speed_Injected(IntPtr _unity_self); // 0x0000000182161D10-0x0000000182161D50
		private static void set_speed_Injected(IntPtr _unity_self, float value); // 0x0000000182162F70-0x0000000182162FC0
		private static void CrossFadeInFixedTime_Injected(IntPtr _unity_self, int stateHashName, float fixedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("0.0f")] float fixedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime); // 0x0000000182158E10-0x0000000182158E70
		private static void WriteDefaultValues_Injected(IntPtr _unity_self); // 0x00000001821600E0-0x0000000182160120
		private static void CrossFade_Injected(IntPtr _unity_self, int stateHashName, float normalizedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("0.0f")] float normalizedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime); // 0x0000000182159320-0x0000000182159380
		private static void PlayInFixedTime_Injected(IntPtr _unity_self, int stateNameHash, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float fixedTime); // 0x000000018215D150-0x000000018215D1B0
		private static void Play_Injected(IntPtr _unity_self, int stateNameHash, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float normalizedTime); // 0x000000018215D4D0-0x000000018215D530
		private static void ResetControllerState_Injected(IntPtr _unity_self, [DefaultValue("true")] bool resetParameters); // 0x000000018215D960-0x000000018215D9B0
		private static void SetTarget_Injected(IntPtr _unity_self, AvatarTarget targetIndex, float targetNormalizedTime); // 0x000000018215F840-0x000000018215F890
		private static void get_targetPosition_Injected(IntPtr _unity_self, ); // 0x0000000182161EF0-0x0000000182161F40
		private static void get_targetRotation_Injected(IntPtr _unity_self, ); // 0x0000000182161FB0-0x0000000182162000
		private static bool IsBoneTransform_Injected(IntPtr _unity_self, IntPtr transform); // 0x000000018215C7E0-0x000000018215C830
		private static IntPtr get_avatarRoot_Injected(IntPtr _unity_self); // 0x0000000182160420-0x0000000182160460
		private static IntPtr GetBoneTransformInternal_Injected(IntPtr _unity_self, int humanBoneId); // 0x000000018215A2B0-0x000000018215A2F0
		private static AnimatorCullingMode get_cullingMode_Injected(IntPtr _unity_self); // 0x0000000182160870-0x00000001821608B0
		private static void set_cullingMode_Injected(IntPtr _unity_self, AnimatorCullingMode value); // 0x00000001821627B0-0x00000001821627F0
		private static void StartPlayback_Injected(IntPtr _unity_self); // 0x000000018215FB70-0x000000018215FBB0
		private static void StopPlayback_Injected(IntPtr _unity_self); // 0x000000018215FCB0-0x000000018215FCF0
		private static float get_playbackTime_Injected(IntPtr _unity_self); // 0x00000001821618E0-0x0000000182161920
		private static void set_playbackTime_Injected(IntPtr _unity_self, float value); // 0x0000000182162C80-0x0000000182162CD0
		private static void StartRecording_Injected(IntPtr _unity_self, int frameCount); // 0x000000018215FC10-0x000000018215FC50
		private static void StopRecording_Injected(IntPtr _unity_self); // 0x000000018215FD50-0x000000018215FD90
		private static float GetRecorderStartTime_Injected(IntPtr _unity_self); // 0x000000018215C160-0x000000018215C1A0
		private static float GetRecorderStopTime_Injected(IntPtr _unity_self); // 0x000000018215C200-0x000000018215C240
		private static AnimatorRecorderMode get_recorderMode_Injected(IntPtr _unity_self); // 0x0000000182161980-0x00000001821619C0
		private static IntPtr get_runtimeAnimatorController_Injected(IntPtr _unity_self); // 0x0000000182161C40-0x0000000182161C80
		private static void set_runtimeAnimatorController_Injected(IntPtr _unity_self, IntPtr value); // 0x0000000182162EA0-0x0000000182162EF0
		private static bool get_hasBoundPlayables_Injected(IntPtr _unity_self); // 0x0000000182160C70-0x0000000182160CB0
		private static void ClearInternalControllerPlayable_Injected(IntPtr _unity_self); // 0x0000000182158D70-0x0000000182158DB0
		private static bool HasState_Injected(IntPtr _unity_self, int layerIndex, int stateID); // 0x000000018215C400-0x000000018215C450
		private static int StringToHash_Injected(ref ManagedSpanWrapper name); // 0x000000018215FDF0-0x000000018215FE30
		private static IntPtr get_avatar_Injected(IntPtr _unity_self); // 0x00000001821604F0-0x0000000182160530
		private static void set_avatar_Injected(IntPtr _unity_self, IntPtr value); // 0x0000000182162480-0x00000001821624D0
		private static void GetStats_Injected(IntPtr _unity_self, ); // 0x000000018215C2A0-0x000000018215C2F0
		private static void GetCurrentGraph_Injected(IntPtr _unity_self, ref PlayableGraph graph); // 0x000000018215AC50-0x000000018215ACA0
		private static bool IsInIKPass_Injected(IntPtr _unity_self); // 0x000000018215C8B0-0x000000018215C8F0
		private static void SetFloatString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, float value); // 0x000000018215E5B0-0x000000018215E610
		private static void SetFloatID_Injected(IntPtr _unity_self, int id, float value); // 0x000000018215E2E0-0x000000018215E330
		private static float GetFloatString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x000000018215ADB0-0x000000018215AE00
		private static float GetFloatID_Injected(IntPtr _unity_self, int id); // 0x000000018215AD10-0x000000018215AD50
		private static void SetBoolString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, bool value); // 0x000000018215E010-0x000000018215E070
		private static void SetBoolID_Injected(IntPtr _unity_self, int id, bool value); // 0x000000018215DF40-0x000000018215DFA0
		private static bool GetBoolString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x000000018215A860-0x000000018215A8B0
		private static bool GetBoolID_Injected(IntPtr _unity_self, int id); // 0x000000018215A7C0-0x000000018215A800
		private static void SetIntegerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, int value); // 0x000000018215F010-0x000000018215F070
		private static void SetIntegerID_Injected(IntPtr _unity_self, int id, int value); // 0x000000018215EF50-0x000000018215EFA0
		private static int GetIntegerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x000000018215B7E0-0x000000018215B830
		private static int GetIntegerID_Injected(IntPtr _unity_self, int id); // 0x000000018215B740-0x000000018215B780
		private static void SetTriggerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x000000018215F9A0-0x000000018215F9F0
		private static void SetTriggerID_Injected(IntPtr _unity_self, int id); // 0x000000018215F900-0x000000018215F940
		private static void ResetTriggerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x000000018215DAB0-0x000000018215DB00
		private static void ResetTriggerID_Injected(IntPtr _unity_self, int id); // 0x000000018215DA10-0x000000018215DA50
		private static bool IsParameterControlledByCurveString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x000000018215CA90-0x000000018215CAE0
		private static bool IsParameterControlledByCurveID_Injected(IntPtr _unity_self, int id); // 0x000000018215C9F0-0x000000018215CA30
		private static void SetFloatStringDamp_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, float value, float dampTime, float deltaTime); // 0x000000018215E3A0-0x000000018215E410
		private static void SetFloatIDDamp_Injected(IntPtr _unity_self, int id, float value, float dampTime, float deltaTime); // 0x000000018215E200-0x000000018215E260
		private static bool get_layersAffectMassCenter_Injected(IntPtr _unity_self); // 0x0000000182161350-0x0000000182161390
		private static void set_layersAffectMassCenter_Injected(IntPtr _unity_self, bool value); // 0x0000000182162A70-0x0000000182162AC0
		private static float get_leftFeetBottomHeight_Injected(IntPtr _unity_self); // 0x00000001821613F0-0x0000000182161430
		private static float get_rightFeetBottomHeight_Injected(IntPtr _unity_self); // 0x0000000182161A20-0x0000000182161A60
		private static bool get_supportsOnAnimatorMove_Injected(IntPtr _unity_self); // 0x0000000182161E50-0x0000000182161E90
		private static void OnUpdateModeChanged_Injected(IntPtr _unity_self); // 0x000000018215D0B0-0x000000018215D0F0
		private static void OnCullingModeChanged_Injected(IntPtr _unity_self); // 0x000000018215D010-0x000000018215D050
		private static void WriteDefaultPose_Injected(IntPtr _unity_self); // 0x0000000182160040-0x0000000182160080
		private static void Update_Injected(IntPtr _unity_self, float deltaTime); // 0x000000018215FF80-0x000000018215FFD0
		private static void Rebind_Injected(IntPtr _unity_self, bool writeDefaultValues); // 0x000000018215D850-0x000000018215D8A0
		private static void ApplyBuiltinRootMotion_Injected(IntPtr _unity_self); // 0x0000000182158BE0-0x0000000182158C20
		private static void EvaluateController_Injected(IntPtr _unity_self, float deltaTime); // 0x0000000182159850-0x00000001821598A0
		private static void GetAnimatorStateName_Injected(IntPtr _unity_self, int layerIndex, bool current, ); // 0x0000000182159DD0-0x0000000182159E40
		private static void ResolveHash_Injected(IntPtr _unity_self, int hash, ); // 0x000000018215DC80-0x000000018215DCD0
		private static bool get_logWarnings_Injected(IntPtr _unity_self); // 0x0000000182161530-0x0000000182161570
		private static void set_logWarnings_Injected(IntPtr _unity_self, bool value); // 0x0000000182162BD0-0x0000000182162C20
		private static bool get_fireEvents_Injected(IntPtr _unity_self); // 0x0000000182160B30-0x0000000182160B70
		private static void set_fireEvents_Injected(IntPtr _unity_self, bool value); // 0x0000000182162910-0x0000000182162960
		private static bool get_keepAnimatorStateOnDisable_Injected(IntPtr _unity_self); // 0x0000000182161270-0x00000001821612B0
		private static void set_keepAnimatorStateOnDisable_Injected(IntPtr _unity_self, bool value); // 0x0000000182162A20-0x0000000182162A70
		private static bool get_writeDefaultValuesOnDisable_Injected(IntPtr _unity_self); // 0x00000001821621D0-0x0000000182162210
		private static void set_writeDefaultValuesOnDisable_Injected(IntPtr _unity_self, bool value); // 0x0000000182163180-0x00000001821631D0
	}
}
