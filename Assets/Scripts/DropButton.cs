using System;
using UnityEngine;
using UnityEngine.UI;

public class DropButton : MonoBehaviour
{

    private Button dropBtn;

    private void Start()
    {
        dropBtn = GetComponent<Button>();
    }







    public void DropItem(Action dropFunction)
    {
        dropBtn.gameObject.SetActive(true);
        dropBtn.onClick.AddListener(dropFunction.Invoke);
        dropBtn.onClick.RemoveAllListeners();
        dropBtn.gameObject.SetActive(false);
        
    }

}
