using UnityEngine;

public class TotalDiamondsManager : MonoBehaviour
{
    static public TotalDiamondsManager instance;
    private int oldDC;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        //ResetDiamondCount();  // TO BE REMOVE BEFORE SUBMISSION. ONLY FOR TESTING

        oldDC = PlayerPrefs.GetInt("DiamondCount", 0);
    }

    public int GetDiamondCount()  // To be used by shop to get remaining diamonds
    {
        return PlayerPrefs.GetInt("DiamondCount", 0);
    }

    public bool DeductFromDiamondCount(int deductVal)  // To be used by shop when an item is bought using diamonds
    {
        oldDC = PlayerPrefs.GetInt("DiamondCount", 0);

        int globalDC = oldDC;

        if (globalDC >= deductVal)
        {
            globalDC = globalDC - deductVal;

            PlayerPrefs.SetInt("DiamondCount", globalDC);

            return true;
        }

        return false;
    }

    public void AddToDiamondCount(int addVal)  // For summary and shop (if money buys diamonds)
    {
        oldDC = PlayerPrefs.GetInt("DiamondCount", 0);

        int globalDC = oldDC + addVal;

        PlayerPrefs.SetInt("DiamondCount", globalDC);
    }

    //public void ResetDiamondCount()  // TO BE REMOVED ONCE GAME IS FULLY MADE. COMMENT OUT BEFORE SUBMISSION. ONLY FOR TESTING
    //{
    //    PlayerPrefs.DeleteKey("DiamondCount");
    //}

}

