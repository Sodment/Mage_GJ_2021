using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
    public void SwitchToState(string state)
    {
        anim.Play(state);
    }
}
