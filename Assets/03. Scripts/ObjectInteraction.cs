using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{

    public Image imageToDeactivate;

    public GameObject particleEffect;

    private void OnTriggerEnter(Collider other)
    {
        // Collider에 닿은 오브젝트의 태그가 “flour”일 때만 작동
        if (other.CompareTag("flour"))
        {
            // UI 이미지를 비활성화
            if (imageToDeactivate != null)
            {
                imageToDeactivate.enabled = false;
            }

            // 가루 효과를 활성화
            if (particleEffect != null)
            {
                particleEffect.SetActive(true);
            }
        }
    }
}
