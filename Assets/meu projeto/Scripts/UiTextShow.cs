using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.meu_projeto.Scripts
{
    public class UiTextShow : MonoBehaviour
    {
        public GameObject UItext;
        void Start()
        {
            UItext.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                UItext.SetActive(true);
                StartCoroutine("WaitForSec");
            }
        }

        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(5);
            Destroy(UItext);
        }
    }
}