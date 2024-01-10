using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
    public Animator ShakingFoodAnimator;

    private int[] Food = new int[4];
    private bool Water = false;
    public GameObject ShakingFoodObj;
    public GameObject KneatingNextBtn;
    public GameObject Dough_Step1;
    public GameObject ColorNextBtn;
    public GameObject CowNextBtn;
    public GameObject DecoNextBtn;

    private int[] Buyint = new int[6];
    public GameObject[] BuyObj = new GameObject[6];
    public TextMeshProUGUI[] BuyText = new TextMeshProUGUI[6];
    private int[] Decoint = new int[6];
    private int score;

    public List<SongPyeon> songPyeons = new List<SongPyeon>();


    private void Start()
    {
        ShakingFoodObj.SetActive(false);
    }

    public void Purchase(int t)
    {
        Buyint[t]++;
        int a = t + 1;
        Debug.Log(a + "???? ?????? ??????" + Buyint[t] + "??");
    }

    public void KneatingFood(int t)
    {
       
        
        if (Food[0] != 0)
        {
            return;
        }

        Food[0] = t;

        if (Water)
        {
           // KneatingNextBtn.SetActive(true);
           // Dough_Step1.SetActive(true);
        }
    }

    public void GetWater()
    {
        Water = true;

        if (Food[0] > 0)
        {
          // KneatingNextBtn.SetActive(true);
          // Dough_Step1.SetActive(true);
        }
    }

    public void KneadingAgain()
    {
        Food[0] = 0;
        Water = false;
       // KneatingNextBtn.SetActive(false);
       // Dough_Step1.SetActive(false);
    }

    public void TimingGameTransitionAnimationStart()
    {
        ShakingFoodAnimator.Play("TimingGameObj");
    }

    public void SelectColorAniStart()
    {
        ShakingFoodAnimator.Play("SelectColorGameObj");
    }

    public void SelectColor(int t)
    {
        if (Food[1] != 0)
        {
            return;
        }

        Food[1] = t;

        ColorNextBtn.SetActive(true);
    }

    public void ColorAgin()
    {
        Food[1] = 0;
        ColorNextBtn.SetActive(false);
    }

    public void CowFiilAniStart()
    {
        ShakingFoodAnimator.Play("CowFillGameObj");
    }

    public void CowFill(int t)
    {
        if (Food[2] != 0) { return; }

        Food[2] = t;

        CowNextBtn.SetActive(true);
    }
    public void CowFillAgain()
    {
        Food[2] = 0;
        CowNextBtn.SetActive(false);
    }

    public void DecoAniStart()
    {
        ShakingFoodAnimator.Play("DecoGameObj");

        for (int i = 0; i < 6; i++)
        {
            if (Buyint[i] > 0)
            {
                BuyObj[i].SetActive(true);
                BuyText[i].text = Buyint[i].ToString();
            }
        }
    }

    public void Deco(int t)
    {
        int a = t - 1;
        if (Buyint[a] < 1) return;
        Decoint[a]++;
        Buyint[a]--;
        BuyText[a].text = Buyint[a].ToString();
    }

    public void DecoAgain()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Decoint[i] > 0)
            {
                Buyint[i] += Decoint[i];
                Decoint[i] = 0;
                BuyText[i].text = Buyint[i].ToString();
            }
        }
    }

    public void Result()
    {
        if (Food[0] == 1)
        {
            score += 30;
        }
        else if (Food[0] == 2)
        {
            score += 50;
        }
        else if (Food[0] == 3)
        {
            score += 100;
        }

        if (Food[1] == 1)
        {
            score += 30;
        }
        else if (Food[1] == 2)
        {
            score += 50;
        }
        else if (Food[1] == 3)
        {
            score += 100;
        }
    }

}