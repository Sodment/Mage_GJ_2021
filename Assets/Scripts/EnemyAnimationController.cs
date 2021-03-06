using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void SwitchToState(string state)
    {
        anim.Play(state);
    }
}
