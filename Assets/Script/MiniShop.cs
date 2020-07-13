using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniShop : MonoBehaviour
{
    public Image Item;
    public Sprite Slotted;
    public Text Main;
    public Text Descript;
    public GameObject Button;
    public int value;
    private CoalCountManagment buy;


    // Start is called before the first frame update
    void Start()
    {
        buy = Button.GetComponent<CoalCountManagment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bought()
    {
       Item.sprite =  Slotted;
       Item.enabled = true;
       Main.text = Descript.text;
       buy.price = value;
    }
}
