using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoalCountManagment : MonoBehaviour
{
    Text text;
    public int price;
    public GameObject NotEnough;
    public GameObject coals;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    void Update()
    {
         if (GetComponent<Text>() != null)
        {
            text = GetComponent<Text>();
            text.text = ScoreManager.instance.GetHighScore().ToString();
        }
        if (ScoreManager.instance.GetHighScore() <  price && GetComponent<Button>() != null)
        {
            GetComponent<Button>().interactable = false;
            NotEnough.SetActive (true);
        }
        else if (GetComponent<Button>() != null)
        {
            GetComponent<Button>().interactable = true;
            NotEnough.SetActive (false);
        }
        // disables button if player cant afford item - Z
    }

    public void Deductor()
    {
        ScoreManager.instance.DeductFromHighScore(price);
        text = coals.GetComponent<Text>();
        text.text = ScoreManager.instance.GetHighScore().ToString();
        //subtracts coals when item bought - Z
    }

  
    // public void NoDiamond()
    // {
    //     Error.SetActive (true);
           //error message for not enough diamonds - Z
    // }

}
