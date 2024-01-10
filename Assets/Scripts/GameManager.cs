using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Animator MakingSongPyeonAnimator;
    public Animator GameStart;

    private int[] SongPyeonYouMaking = new int[4];
    private bool Water = false;
    public GameObject MakingSongPyeon;
    public GameObject KneatingNextBtn;
    public GameObject ColorNextBtn;
    public GameObject FillingNextBtn;
    public GameObject DecoNextBtn;

    private int[] BoughtDecoItemInt = new int[6];
    public GameObject[] BoughtDecoItemObj = new GameObject[6];
    public TextMeshProUGUI[] BoughtDecoItemText = new TextMeshProUGUI[6];
    
    private int[] UsedDecoItemInt = new int[6];
    
    private int score;

    public List<SongPyeon> songPyeons = new List<SongPyeon>();

    public GuestOrderManager guestOrderManager;

    public TextMeshProUGUI scoreText;

    private bool correctServe = true;

    public TimingGame timingGame;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        MakingSongPyeon.SetActive(false);

        scoreText.text = "Score : 0";

        Intialize();
    }

    public void Intialize()
    {
        for (int i = 0; i < SongPyeonYouMaking.Length; i++)
        {
            SongPyeonYouMaking[i] = -1;
        }

        correctServe = true;

        KneatingNextBtn.SetActive(false);
        ColorNextBtn.SetActive(false);
        FillingNextBtn.SetActive(false);
        Water = false;

        MakingSongPyeon.SetActive(false);

        GameStart.Play("GameStart");

        timingGame.Initialize();
    }

    public void GamePlay()
    {
        MakingSongPyeon.SetActive(true);
        MakingSongPyeonAnimator.Play("ShakingFood");
    }

    public void PurchaseDecoItem(int chosenOne)
    {
        BoughtDecoItemInt[chosenOne]++;
    }

    public void KneatingFlour(int chosenOne)
    {
        if (SongPyeonYouMaking[0] != -1)
        {
            return;
        }

        SongPyeonYouMaking[0] = chosenOne;

        if (Water)
        {
            KneatingNextBtn.SetActive(true);
        }
    }

    public void GetWater()
    {
        Water = true;

        if (SongPyeonYouMaking[0] > -1)
        {
            KneatingNextBtn.SetActive(true);
        }
    }

    public void KneatingAgain()
    {
        SongPyeonYouMaking[0] = -1;
        Water = false;
        KneatingNextBtn.SetActive(false);
    }

    public void TimingGameTransitionAnimationStart()
    {
        MakingSongPyeonAnimator.Play("TimingGameObj");
    }

    public void SelectColorTransitionAnimationStart()
    {
        MakingSongPyeonAnimator.Play("SelectColorGameObj");
    }

    public void SelectColor(int chosenOne)
    {
        if (SongPyeonYouMaking[1] != -1)
        {
            return;
        }

        SongPyeonYouMaking[1] = chosenOne;

        ColorNextBtn.SetActive(true);
    }

    public void ColorAgin()
    {
        SongPyeonYouMaking[1] = -1;
        ColorNextBtn.SetActive(false);
    }

    public void FillingTransitionAnimationStart()
    {
        MakingSongPyeonAnimator.Play("CowFillGameObj");
    }

    public void Filling(int chosenOne)
    {
        if (SongPyeonYouMaking[2] != -1) 
        { 
            return; 
        }

        SongPyeonYouMaking[2] = chosenOne;

        FillingNextBtn.SetActive(true);
    }
    public void FillingAgain()
    {
        SongPyeonYouMaking[2] = -1;
        FillingNextBtn.SetActive(false);
    }

    public void DecoTransitionAnimationStart()
    {
        MakingSongPyeonAnimator.Play("DecoGameObj");

        for (int i = 0; i < 6; i++)
        {
            if (BoughtDecoItemInt[i] > -1)
            {
                BoughtDecoItemObj[i].SetActive(true);
                BoughtDecoItemText[i].text = BoughtDecoItemInt[i].ToString();
            }
        }
    }

    public void Deco(int chosenOne)
    {
        if (BoughtDecoItemInt[chosenOne] < 1)
        {
            return;
        }

        UsedDecoItemInt[chosenOne]++;
        BoughtDecoItemInt[chosenOne]--;
        BoughtDecoItemText[chosenOne].text = BoughtDecoItemInt[chosenOne].ToString();
    }

    public void DecoAgain()
    {
        for (int i = 0; i < 6; i++)
        {
            if (UsedDecoItemInt[i] > 0)
            {
                BoughtDecoItemInt[i] += UsedDecoItemInt[i];
                UsedDecoItemInt[i] = 0;
                BoughtDecoItemText[i].text = BoughtDecoItemInt[i].ToString();
            }
        }
    }

    public void CheckOrderAndServe()
    {
        GameStart.Play("GameStart-Initialize");

        for (int i = 0; i < SongPyeonYouMaking.Length;i++)
        {
            if (SongPyeonYouMaking[0] != guestOrderManager.orderSongPyeon.flour)
            {
                Debug.Log("Fail!");
                correctServe = false;
            }

            if (SongPyeonYouMaking[1] != guestOrderManager.orderSongPyeon.color)
            {
                Debug.Log("Fail!");
                correctServe = false;
            }

            if (SongPyeonYouMaking[2] != guestOrderManager.orderSongPyeon.filling)
            {
                Debug.Log("Fail!");
                correctServe = false;
            }
        }

        if (correctServe == true)
        {
            score += 30;
            scoreText.text = "Score : " + score.ToString();
        }

        Invoke(nameof(Intialize), 3f);
    }

}