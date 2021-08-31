using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealNextCard1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Image P1C1;
    
    public Image P2C1;
    
    public Image P3C1;
    
    public Image P4C1;
    
    public Image P5C1;
   
    public Text Seat1;
    public Text Seat2;
    public Text Seat3;
    public Text Seat4;
    public Text Seat5;
    private Animator cAnim;
    
    public void BeginCardAnimation()
    {
        GameState.CardAnimateFinished = false;
    }
    public void EndCardAnimation()
    {
        GameState.CardAnimateFinished = true;
    }
    public void FromP1C1()
    {
        if (Seat2.text != "EMPTY")
        {
            GameState.CardAnimateFinished = true;
            //ap2c1.Play("DealerHand");
            cAnim = P2C1.GetComponent<Animator>();
            cAnim.Play("P2C1Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if(Seat3.text!= "EMPTY")
        {
            cAnim = P3C1.GetComponent<Animator>();
            cAnim.Play("P3C1Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C1.GetComponent<Animator>();
            cAnim.Play("P4C1Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C1.GetComponent<Animator>();
            cAnim.Play("P5C1Animation");
        }
    }
    public void FromP2C1()
    {
        
        if (Seat3.text != "EMPTY")
        {
            cAnim = P3C1.GetComponent<Animator>();
            cAnim.Play("P3C1Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C1.GetComponent<Animator>();
            cAnim.Play("P4C1Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C1.GetComponent<Animator>();
            cAnim.Play("P5C1Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C1.GetComponent<Animator>();
            cAnim.Play("P1C1Animation");
            //yield return new WaitForSeconds(0.25f);
        }
    }
    public void FromP3C1()
    {
                
         if (Seat4.text != "EMPTY")
        {
            cAnim = P4C1.GetComponent<Animator>();
            cAnim.Play("P4C1Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C1.GetComponent<Animator>();
            cAnim.Play("P5C1Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C1.GetComponent<Animator>();
            cAnim.Play("P1C1Animation");
            //yield return new WaitForSeconds(0.25f);
        }
         else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C1.GetComponent<Animator>();
            cAnim.Play("P2C1Animation");
        }
    }
    public void FromP4C1()
    {

        
         if (Seat5.text != "EMPTY")
        {
            cAnim = P5C1.GetComponent<Animator>();
            cAnim.Play("P5C1Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C1.GetComponent<Animator>();
            cAnim.Play("P1C1Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C1.GetComponent<Animator>();
            cAnim.Play("P2C1Animation");
        }
         else if (Seat3.text != "EMPTY")
        {
            cAnim = P3C1.GetComponent<Animator>();
            cAnim.Play("P3C1Animation");
        }
    }
    public void FromP5C1()
    {
               
        if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C1.GetComponent<Animator>();
            cAnim.Play("P1C1Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C1.GetComponent<Animator>();
            cAnim.Play("P2C1Animation");
        }
        else if (Seat3.text != "EMPTY")
        {
            cAnim = P3C1.GetComponent<Animator>();
            cAnim.Play("P3C1Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C1.GetComponent<Animator>();
            cAnim.Play("P4C1Animation");
        }
    }
   

    
}
