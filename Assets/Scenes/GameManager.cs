
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager
{
    // Start is called before the first frame update
    private bool gameon, one, two, three, four, five;
    private int[] cardsuitnumber;
    
    private long FirstHandValue=0, SecondHandValue=0, ThirdHandValue=0, FourthHandValue=0, FifthHandValue=0;
    private int cardnumber;

    public long SecondPlayerCardWeight
    {
        get { return SecondHandValue; }
        set { SecondHandValue = value; }
    }

    public long FirstPlayerCardWeight
    {
        get { return FirstHandValue; }
        set { FirstHandValue = value; }
    }
    public long ThirdPlayerCardWeight
    {
        get { return ThirdHandValue; }
        set { ThirdHandValue = value; }
    }
    public long FourthPlayerCardWeight
    {
        get { return FourthHandValue; }
        set { FourthHandValue = value; }
    }

    public long FifthPlayerCardWeight
    {
        get { return FifthHandValue; }
        set { FifthHandValue = value; }
    }

   

    public int GetRandomCard
    {
        get
        {
            return cardsuitnumber[Random.Range(0, cardsuitnumber.Length)];
        }
    }
    public bool GameON 
    { 
        get { return gameon; }
        set { gameon = value; }
    }
    public bool IsOneActive
    {
        get { return one; }
        set { one = value; }
    }

    public bool IsTwoActive
    {
        get { return two; }
        set { two = value; }
    }

    public bool IsThreeActive
    {
        get { return three; }
        set { three = value; }
    }

    public bool IsFourActive
    {
        get { return four; }
        set { four = value; }
    }

    public bool IsFiveActive
    {
        get { return five; }
        set { five = value; }
    }
    public void ResetCards()
    {
       cardsuitnumber = new int[] {102,103,104,105,106,107,108,109,110,111,112,113,114,
                               202,203,204,205,206,207,208,209,210,211,212,213,214,
                               302,303,304,305,306,307,308,309,310,311,312,313,314,
                               402,403,404,405,406,407,408,409,410,411,412,413,414};
}

    public void RemoveRandomCard(int CardToRemove)
    {
        int numIndex = System.Array.IndexOf(cardsuitnumber, CardToRemove);
        cardsuitnumber = cardsuitnumber.Where((val, idx) => idx != numIndex).ToArray();
    }
}
