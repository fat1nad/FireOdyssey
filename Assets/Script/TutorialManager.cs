using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    public Animator FrameAnimator;
    public Animator CoalAnimator;
    public Animator PlatformAnimator;
    public Animator ObjectAnimator;
    public Joystick MovementJoyStick;
    public Joystick ShootJoyStick;
    public GameObject Healer;

    private float delay = 0.05f;
	public Text text;
    public Text CoalText;
	private string fullText;
	private string currentText = "";
    private int Index;
    private bool healer;

    public Button NextButton;

    private List<string> Lines;
    Coroutine WriteText = null;


    void Start() {
        Lines = new List<string>();
        Index = 0;
        AddLines();
        TypeText();
        healer= false;

    }
    void Update() 
    {
        
        if (CoalText.GetComponent<Text>().text == "x1" && Index == 3)
        {
            StopCoroutine(WriteText);
            FrameAnimator.Play("Handle4");
            Next();
        }
        else if (CoalText.GetComponent<Text>().text == "x3" && Index == 4)
        {
            StopCoroutine(WriteText);
            PlatformAnimator.SetTrigger("firstappear");
            FrameAnimator.Play("IdleFrame");
            Next();
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && Index == 7)
        {
            StopCoroutine(WriteText);
           // FrameAnimator.Play("HealthFrame");
            Next();
        }
       if (GameObject.FindGameObjectsWithTag("Healer").Length == 0 && healer && Index == 8)
        {
            StopCoroutine(WriteText);
            //FrameAnimator.Play("GlassFrame");
            Next();
        }



        
    }

	
    public void Next()
    {
        Index++;
        HandleEvents();
        TypeText();
    }

    private void AddLines()
    {
        Lines.Add("Welcome to Fire Odyssey! ");
        Lines.Add("Here's a quick tutorial on how to play. ");
        Lines.Add("Move the flicker using this joystick. ");
        Lines.Add("These are coals used as currency. Try collecting them all! ");
        Lines.Add("The number of coals collected is displayed here. ");
        Lines.Add("Great Job! To move forward, try jumping on the platform.");
        Lines.Add("Watch out for the darkness. It will try to kill you. ");
        Lines.Add("Try killing it with a fireball! ");
        Lines.Add("Nice! Oh, a healer just appeared! Try collecting it! ");
        Lines.Add("Health Restored! You're on a glass platform, it helps gives you a boost while jumping. Try finding the candle to complete the level!");
        Lines.Add("The wooden platform burns because of your flame!");
        Lines.Add("Find the candle to complete the level!");
    }

    private void HandleEvents()
    {
        switch(Index) 
        {
            case 2:
                NextButton.interactable = false;
                FrameAnimator.Play("MoveJoyStick");
                break;
            case 3:
                MovementJoyStick.GetComponent<Image>().raycastTarget = true;
                MovementJoyStick.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
                CoalAnimator.SetTrigger("appear");
                FrameAnimator.Play("Handle3");
                break;
            case 7: 
                ShootJoyStick.GetComponent<Image>().raycastTarget = true;
                ShootJoyStick.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
                FrameAnimator.Play("ShootJoyStick");
                break;
            case 8:
                ObjectAnimator.SetTrigger("healer");
                Healer.SetActive(true);
                PlatformAnimator.Play("GlassPlatformAppear");
                healer= true;
                break;
            case 9:
                break;
                
                

        }


        
    }


    public void TypeText()
    {
        NextButton.interactable = false;
        text.text = "";
		fullText = Lines[Index];
		WriteText = StartCoroutine(ShowText());
		
	}
	
	IEnumerator ShowText(){
		for(int i = 0; i < fullText.Length; i++){
			currentText = fullText.Substring(0,i);
			text.text = currentText;
			yield return new WaitForSeconds(delay);
		}
        
        if (Index == 3 || Index == 5 || Index == 8)
        {
            NextButton.interactable = false;
        }
        else
        {
            NextButton.interactable = true;
        }

	}


    
  


    
}
