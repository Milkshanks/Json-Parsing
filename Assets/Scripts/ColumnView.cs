using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColumnView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _header = null;
    [SerializeField]
    private TextMeshProUGUI _rowItemTemplate = null;

    private List<string> _dataList = new List<string>();
    private List<TextMeshProUGUI> _rowItemList = new List<TextMeshProUGUI>();

    public void Initialize(string headerText)
    {
        _header.text = headerText;
        _dataList.Clear();
    }

    public void SetItemData(string data)
    {
        _dataList.Add(data);
    }
    
    public void SetColumn()
    {
        int lastItemIndex = _rowItemList.Count - 1;
        for (int i = 0; i < _dataList.Count; i++)
        {
            TextMeshProUGUI textField;

            if (lastItemIndex < i)
            {
                textField = Instantiate(_rowItemTemplate, _rowItemTemplate.transform.parent);
                _rowItemList.Add(textField);
            }
            else
            {
                textField = _rowItemList[i];
            }

            textField.text = _dataList[i];
            textField.gameObject.SetActive(true);
        }

        for (int i = _dataList.Count; i < _rowItemList.Count; i++)
        {
            _rowItemList[i].gameObject.SetActive(false);
        }
    }
}
