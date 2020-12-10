using UnityEditor;
using UnityEngine;

namespace CommonECS
{
	public class AnimationEditor : MonoBehaviour
	{
		public Animator animator;

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (animator == null)
				return;

			var animationClips = animator.runtimeAnimatorController.animationClips;
			foreach (var animationClip in animationClips)
			{
				var animationClipSettings = AnimationUtility.GetAnimationClipSettings(animationClip);

				var transform = this.transform;

				var editorCurveBindings = AnimationUtility.GetCurveBindings(animationClip);
				foreach (var editorCurveBinding in editorCurveBindings)
				{
					var animationCurve = AnimationUtility.GetEditorCurve(animationClip, editorCurveBinding);
				}

				var editorCurveBindings2 = AnimationUtility.GetObjectReferenceCurveBindings(animationClip);
				foreach (var editorCurveBinding in editorCurveBindings2)
				{
					var objectReferenceKeyframes = AnimationUtility.GetObjectReferenceCurve(animationClip, editorCurveBinding);
				}
			}
		}
#endif
	}
}