using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace FoodDrag
{
    public class CircleLine : MonoBehaviour
    {
        public UILineRenderer lineRenderer;

        public float radius = 200f;
        public float thickness = 10f;
        [SerializeField] float minPointDistance = 20f;


        public void Draw(float radius, float thickness = 10f, float midPintDistance = 20f)
        {
            if (minPointDistance <= 1)
                minPointDistance = 1f;

            float circumference = 2 * Mathf.PI * radius;
            int numPoints = Mathf.Max(2, Mathf.RoundToInt(circumference / minPointDistance));
            float angleIncrement = 360f / numPoints; // 원 전체의 각도를 점의 수로 나눈 값

            var positions = new List<Vector2>();
            for (int i = 0; i <= numPoints; i++)
            {
                var angle = i * angleIncrement;
                float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
                float y = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

                var curPos = new Vector2(x, y);
                positions.Add(curPos);
                angle += angleIncrement;
            }

            lineRenderer.LineThickness = thickness;
            lineRenderer.Points = positions.ToArray();
        }
    }
}
