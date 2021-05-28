using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElement;

    public static Tooltip current;

    public int characterWrapLimit;

    private void Awake()
    {
        current = this;
        SetAndShowToolTip("Header","content");
        
    }

    private void Start()
    {
        HideToolTip();
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
        
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

    public void SetAndShowToolTip(string header, string content)
    {
        gameObject.SetActive(true);
        headerField.text = header;
        contentField.text = content;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        headerField.text = string.Empty;
        contentField.text = string.Empty;
    }

}

