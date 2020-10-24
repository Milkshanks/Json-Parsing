using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColumnView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _header = null;
    [SerializeField]
    private TextMeshProUGUI _rowItemTemplate = null;

    private List<TextMeshProUGUI> _rowItemList = new List<TextMeshProUGUI>();

    public void SetHeader(string headerText)
    {
        _header.text = headerText;
    }
    
    public void SetItem(string itemText)
    {
        TextMeshProUGUI item = Instantiate(_rowItemTemplate, _rowItemTemplate.transform.parent);
        item.text = itemText;
        item.gameObject.SetActive(true);
    }
}
