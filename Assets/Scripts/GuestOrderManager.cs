using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuestOrderManager : MonoBehaviour
{
    public Image guestFrame;

    public GuestAndOrder orderSongPyeon;

    public TextMeshProUGUI orderText;

    public Image songpyeonFrame;

    // Start is called before the first frame update
    void Start()
    {
        // RandomGuest();
        SetGuestAndOrder();
    }

    //public void RandomGuest()
    //{
    //    int guestIndex = Random.Range(0, guests.Length);
    //    guestFrame.sprite = guests[guestIndex];
    //}

    public void SetGuestAndOrder()
    {
        int orderIndex = Random.Range(0, GameManager.Instance.guests.Count);
        orderSongPyeon = GameManager.Instance.guests[orderIndex];
        orderText.text = orderSongPyeon.songpyeonText;
        songpyeonFrame.sprite = orderSongPyeon.songpyeonImage;
        guestFrame.sprite = orderSongPyeon.guestImage;
    }
}
