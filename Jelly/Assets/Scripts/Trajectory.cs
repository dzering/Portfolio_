using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sausage
{
    internal sealed class Trajectory : MonoBehaviour
    {
        [SerializeField] int dotsNumber;
        [SerializeField] Transform dotsParent;
        [SerializeField] Transform dotPref;
        [SerializeField] float dotsSpacing;

        [SerializeField] Color startColor;
        [SerializeField] Color endColor;

        float timeStamp;
        float offset;
        Vector3 pos;

        Transform[] dotsList;
        private void Start()
        {
            Hide();
            PrepeareDots();
        }

        public void UpdateDots(Vector3 playerPos, Vector3 forceApplied)
        {
            timeStamp = dotsSpacing;
            for (int i = 0; i < dotsList.Length; i++)
            {

                pos.x = (playerPos.x + forceApplied.x * timeStamp);
                pos.y = (playerPos.y + forceApplied.y * timeStamp) - (Physics.gravity.magnitude * timeStamp * timeStamp) / 2f;
                pos.z = playerPos.z;

                dotsList[i].position = pos;
                timeStamp += dotsSpacing;

            }
        }
        void PrepeareDots()
        {
            dotsList = new Transform[dotsNumber];
            for (int i = 0; i < dotsList.Length; i++)
            {
                var newDot = Instantiate(dotPref, null);
                ChangeColor(newDot, i);

                dotsList[i] = newDot;
                dotsList[i].parent = dotsParent;
            }
        }

        void ChangeColor(Transform newDot, int i)
        {
            Renderer dotRenderer = newDot.GetComponent<Renderer>();
            Material dotMaterial = new Material(dotRenderer.sharedMaterial);
            float percentage = (float)i / dotsNumber;
            dotMaterial.color = Color.Lerp(startColor, endColor, percentage);
            dotRenderer.material = dotMaterial;
            newDot.localScale = newDot.localScale * (1 - percentage);
        }

        public void Hide()
        {
            dotsParent.gameObject.SetActive(false);
        }

        public void Show()
        {
            dotsParent.gameObject.SetActive(true);
        }
    }
}