using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FoodDrag
{
    public class TimingPop : MonoBehaviour, IPointerClickHandler
    {
        public Action<float> scoreAction; //터치 성공 정도를 float 점수로 외부에 신호

        public float startRadius = 600f;
        public float randomStart = 100f;
        public float fadeSpeed = 200f; // 단위: radius/sec
        private float popRadius = 200f;
        [SerializeField] CircleLine circleLine;
        [SerializeField] TextMeshProUGUI text;

        bool isDone = false;
        float m_curRadius;
        private Coroutine coroutine;

        // Start is called before the first frame update
        void Start()
        {

            popRadius = GetComponent<RectTransform>().sizeDelta.x / 2f;
            StartGame();
        }

        private void StartGame()
        {
            isDone = false;
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(Fade());
        }

        IEnumerator Fade()
        {
            var rand = UnityEngine.Random.Range(0f, randomStart);
            m_curRadius = startRadius + rand;
            //float timeCheck = 0f;
            while (m_curRadius > 0f)
            {
                circleLine.Draw(m_curRadius);
                //timeCheck += Time.deltaTime;
                m_curRadius -= fadeSpeed * Time.deltaTime;
                yield return null;
            }
            if (isDone == false)
            {
                text.text = "Fail!";
                scoreAction?.Invoke(100f);
                StartGame();
            }
        }

        private void SetText()
        {
            float differ = popRadius - m_curRadius;
            text.text = "It differs by ( " + differ + " ) !!";
            scoreAction?.Invoke(differ);
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            isDone = true;
            SetText();
            StartGame();
        }
    }
}
