using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealNextCard3 : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Image P1C3;
    
    public Image P2C3;
    
    public Image P3C3;
   
    public Image P4C3;
    
    public Image P5C3;
    public Text Seat1;
    public Text Seat2;
    public Text Seat3;
    public Text Seat4;
    public Text Seat5;
    private Animator cAnim;
    

    public void FromP1C3()
    {
        if (Seat2.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P2C3.GetComponent<Animator>();
            cAnim.Play("P2C3Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat3.text != "EMPTY")
        {
            cAnim = P3C3.GetComponent<Animator>();
            cAnim.Play("P3C3Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C3.GetComponent<Animator>();
            cAnim.Play("P4C3Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C3.GetComponent<Animator>();
            cAnim.Play("P5C3Animation");
        }
    }
    public void FromP2C3()
    {

        if (Seat3.text != "EMPTY")
        {
            cAnim = P3C3.GetComponent<Animator>();
            cAnim.Play("P3C3Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C3.GetComponent<Animator>();
            cAnim.Play("P4C3Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C3.GetComponent<Animator>();
            cAnim.Play("P5C3Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C3.GetComponent<Animator>();
            cAnim.Play("P1C3Animation");
            //yield return new WaitForSeconds(0.25f);
        }
    }
    public void FromP3C3()
    {

        if (Seat4.text != "EMPTY")
        {
            cAnim = P4C3.GetComponent<Animator>();
            cAnim.Play("P4C3Animation");
        }
        else if (Seat5.text != "EMPTY")
        {
            cAnim = P5C3.GetComponent<Animator>();
            cAnim.Play("P5C3Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C3.GetComponent<Animator>();
            cAnim.Play("P1C3Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C3.GetComponent<Animator>();
            cAnim.Play("P2C3Animation");
        }
    }
    public void FromP4C3()
    {


        if (Seat5.text != "EMPTY")
        {
            cAnim = P5C3.GetComponent<Animator>();
            cAnim.Play("P5C3Animation");
        }
        else if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C3.GetComponent<Animator>();
            cAnim.Play("P1C3Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C3.GetComponent<Animator>();
            cAnim.Play("P2C3Animation");
        }
        else if (Seat3.text != "EMPTY")
        {
            cAnim = P3C3.GetComponent<Animator>();
            cAnim.Play("P3C3Animation");
        }
    }
    public void FromP5C3()
    {

        if (Seat1.text != "EMPTY")
        {

            //ap2c1.Play("DealerHand");
            cAnim = P1C3.GetComponent<Animator>();
            cAnim.Play("P1C3Animation");
            //yield return new WaitForSeconds(0.25f);
        }
        else if (Seat2.text != "EMPTY")
        {
            cAnim = P2C3.GetComponent<Animator>();
            cAnim.Play("P2C3Animation");
        }
        else if (Seat3.text != "EMPTY")
        {
            cAnim = P3C3.GetComponent<Animator>();
            cAnim.Play("P3C3Animation");
        }
        else if (Seat4.text != "EMPTY")
        {
            cAnim = P4C3.GetComponent<Animator>();
            cAnim.Play("P4C3Animation");
        }
    }
}
