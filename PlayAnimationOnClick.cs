using UnityEngine;

public class PlayAnimationOnClick : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to the Animator component
    [SerializeField] private AnimationClip animationClip; // The animation clip to play

    private AnimatorOverrideController overrideController;

    void Start()
    {
        // Ensure the Animator is assigned
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (animator == null)
        {
            Debug.LogError("Animator component not found! Please assign it in the Inspector.");
            return;
        }

        // Ensure an AnimationClip is assigned
        if (animationClip == null)
        {
            Debug.LogError("AnimationClip not assigned! Please assign it in the Inspector.");
            return;
        }

        // Set up an AnimatorOverrideController to play the clip
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;
    }

    void OnMouseDown()
    {
        // Check if Animator and AnimationClip are valid
        if (animator != null && animationClip != null)
        {
            // Override the default animation with the clip and play it
            overrideController["OvenDoor"] = animationClip; // Replace "Default" with the name of your default animation state
            animator.Play("OvenDoor", 0, 0f); // Play the animation from the beginning
        }
    }
}
