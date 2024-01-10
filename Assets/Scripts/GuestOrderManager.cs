using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuestOrderManager : MonoBehaviour
{
    public Sprite[] guests;
    public Image guestFrame;

    public SongPyeon orderSongPyeon;

    public TextMeshProUGUI songPyeonText;

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
        int orderIndex = Random.Range(0, GameManager.Instance.songPyeons.Count);
        orderSongPyeon = GameManager.Instance.songPyeons[orderIndex];
        songPyeonText.text = orderSongPyeon.name;
    }
}
