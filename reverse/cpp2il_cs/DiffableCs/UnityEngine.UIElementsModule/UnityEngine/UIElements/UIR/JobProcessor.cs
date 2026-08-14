namespace UnityEngine.UIElements.UIR;

[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIRendererJobProcessor.h")]
internal static class JobProcessor
{

	internal static JobHandle ScheduleConvertMeshJobs(IntPtr buffer, int jobCount) { }

	private static void ScheduleConvertMeshJobs_Injected(IntPtr buffer, int jobCount, out JobHandle ret) { }

	internal static JobHandle ScheduleCopyMeshJobs(IntPtr buffer, int jobCount) { }

	private static void ScheduleCopyMeshJobs_Injected(IntPtr buffer, int jobCount, out JobHandle ret) { }

	internal static JobHandle ScheduleNudgeJobs(IntPtr buffer, int jobCount) { }

	private static void ScheduleNudgeJobs_Injected(IntPtr buffer, int jobCount, out JobHandle ret) { }

}

