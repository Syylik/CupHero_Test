using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private readonly int IsRunAnimHash = Animator.StringToHash("IsRun");
    private Animator _anim;

    private void Awake() => _anim ??= GetComponent<Animator>();

    public void StartRunAnim() => _anim.SetBool(IsRunAnimHash, true);
    public void EndRunAnim() => _anim.SetBool(IsRunAnimHash, false);
}
