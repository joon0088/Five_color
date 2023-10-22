using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FoodDrag
{
    public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] float clickScale = 2f;
        [SerializeField] float basketRandomRange = 20f;
        private Vector3 originalPosition;

        private void Start()
        {
            originalPosition = GetComponent<RectTransform>().position;// transform.localPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            this.transform.localScale = new Vector3(clickScale, clickScale, clickScale);
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            CheckEndDrag(eventData);
        }

        private void CheckEndDrag(PointerEventData eventData)
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);

            // 레이캐스트를 수행하여 현재 마우스 위치의 UI 오브젝트들을 찾음
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            int findBasket = 0;
            if (results.Count > 0)
            {

                foreach (RaycastResult result in results)
                {//현재는 오브젝트 이름으로 구별, 차후 태그로 바꾸면 좋을 듯
                    if (result.gameObject.name == "Basket")
                    {
                        findBasket++;
                        var addRandomXPosition = UnityEngine.Random.Range(-basketRandomRange, basketRandomRange);
                        var addRandomYPosition = UnityEngine.Random.Range(-basketRandomRange, basketRandomRange);
                        this.transform.position = result.gameObject.transform.position + new Vector3(addRandomXPosition, addRandomYPosition, 0f);
                    }
                    //Debug.Log("Hit: " + result.gameObject.name);
                }
            }
            if (findBasket == 0)
                this.transform.position = originalPosition;
        }
    }
}
