using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormCollision : MonoBehaviour
{
    public Animator ObjectAnimator;
    private bool Once = false;
    private void OnCollisionEnter2D( Collision2D collision )
     {
        GameObject other = collision.gameObject;
        if (!Once)
        {
            if (other.CompareTag("Player"))
            {
                GameObject.Find("TutorialManager").GetComponent<TutorialManager>().Next();
                ObjectAnimator.SetTrigger("enemy");
                this.GetComponentInParent<Animator>().SetTrigger("fourthappear");

            }
            Once = true;
        }
     }
}
