using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefinition : MonoBehaviour
{
    public Sprite portrait;
    public string characterName;

    public Animator anim;

    public bool startsAngry;
    public bool startsCrying;
    public bool startsThinking;
    public bool startsTalking;
    public bool startsWalking;

    public Vector3 direction_;

    private void Start()
    {
        anim = GetComponent<Animator>();

        if (startsAngry)
            GoAngryState();
        else if (startsCrying)
            GoCryingState();
        else if (startsThinking)
            GoThinkingState();
        else if (startsTalking)
            GoTalkingState();
        else if (startsWalking)
            GoWalk(direction_);
        else
            GoIdleState();
    }

    public void GoAngryState()
    {
        GoIdleState();
        anim.SetBool("isAngry", true);
    }

    public void GoCryingState()
    {
        GoIdleState();
        anim.SetBool("isCrying", true);
    }

    public void GoThinkingState()
    {
        GoIdleState();
        anim.SetBool("isThinking", true);
    }

    public void GoTalkingState()
    {
        GoIdleState();
        anim.SetBool("isTalking", true);
    }

    public void GoWalk(Vector3 direction)
    {
        GoIdleState();
        StartCoroutine(Walk(direction));
    }

    private IEnumerator Walk(Vector3 direction)
    {
        anim.SetBool("isWalking", true);
        transform.DOMove(direction, 1f);
        yield return new WaitForSeconds(0.9f);
        anim.SetBool("isWalking", false);
    }

    public void GoIdleState()
    {
        anim.SetBool("isAngry", false);
        anim.SetBool("isCrying", false);
        anim.SetBool("isThinking", false);
        anim.SetBool("isTalking", false);
        anim.SetBool("isWalking", false);
    }
}
