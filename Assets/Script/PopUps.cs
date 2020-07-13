using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PopUps : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator popUpAnimator;
    public TMP_Text popUpText;
    public string Text;
    public string ManagerName;
    //public AudioSource audioSource;
    

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = Text;
        popUpAnimator.SetTrigger("pop");
        //audioSource.Play();
    }



    public void Confirm()
    {
        PopUps pop = GameObject.FindGameObjectWithTag(ManagerName).GetComponent<PopUps>();
        pop.PopUp(Text);
    }
}
