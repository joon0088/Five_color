using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FoodDrag
{
    public class ShowMouseCorsor : MonoBehaviour, IPointerClickHandler
    {
        public Image cilickedImage;

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.position = Input.mousePosition;
        }
    }
}
