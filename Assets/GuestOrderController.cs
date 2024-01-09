using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestOrderController : MonoBehaviour
{
    public Sprite[] guests;
    public Image guestFrame;

    public SongPyeon orderSongPyeon;

    // Start is called before the first frame update
    void Start()
    {
        RandomGuest();
        OrderSongPyeon();
    }

    public void RandomGuest()
    {
        int guestIndex = Random.Range(0, guests.Length);
        guestFrame.sprite = guests[guestIndex];
    }

    public void OrderSongPyeon()
    {

    }
}
