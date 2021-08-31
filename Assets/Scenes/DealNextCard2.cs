using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealNextCard2 : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Image P1C2;
    
    
    public Image P2C2;
   
    
    public Image P3C2;
    
    
    public Image P4C2;
    
    
    public Image P5C2;
    
    public Text Seat1;
    public Text Seat2;
    public Text Seat3;
    public Text Seat4;
    public Text Seat5;
    private Animator cAnim;
    
    public void FromP1C2()
    {
        if (Seat2.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P2C2.GetComponent<Animator>();
            cAnim.Play("P2C2Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat3.text != "EMPTY")
        {
            cAnim = P3C2.GetComponent<Animator>();
            cAnim.Play("P3C2Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C2.GetComponent<Animator>();
            cAnim.Play("P4C2Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C2.GetComponent<Animator>();
            cAnim.Play("P5C2Animation");
        }
    }
    public void FromP2C2()
    {

        if (Seat3.text != "EMPTY")
        {
            cAnim = P3C2.GetComponent<Animator>();
            cAnim.Play("P3C2Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C2.GetComponent<Animator>();
            cAnim.Play("P4C2Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C2.GetComponent<Animator>();
            cAnim.Play("P5C2Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C2.GetComponent<Animator>();
            cAnim.Play("P1C2Animation");
            //yield return new WaitForSeconds(0.25f);
        }
    }
    public void FromP3C2()
    {

        if (Seat4.text != "EMPTY")
        {
            cAnim = P4C2.GetComponent<Animator>();
            cAnim.Play("P4C2Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C2.GetComponent<Animator>();
            cAnim.Play("P5C2Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C2.GetComponent<Animator>();
            cAnim.Play("P1C2Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C2.GetComponent<Animator>();
            cAnim.Play("P2C2Animation");
        }
    }
    public void FromP4C2()
    {


        if (Seat5.text != "EMPTY")
        {
            cAnim = P5C2.GetComponent<Animator>();
            cAnim.Play("P5C2Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C2.GetComponent<Animator>();
            cAnim.Play("P1C2Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C2.GetComponent<Animator>();
            cAnim.Play("P2C2Animation");
        }
        else if (Seat3.text != "EMPTY")
        {
            cAnim = P3C2.GetComponent<Animator>();
            cAnim.Play("P3C2Animation");
        }
    }
    public void FromP5C2()
    {

        if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C2.GetComponent<Animator>();
            cAnim.Play("P1C2Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C2.GetComponent<Animator>();
            cAnim.Play("P2C2Animation");
        }
        else if (Seat3.text != "EMPTY")
        {
            cAnim = P3C2.GetComponent<Animator>();
            cAnim.Play("P3C2Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C2.GetComponent<Animator>();
            cAnim.Play("P4C2Animation");
        }
    }

    
}
