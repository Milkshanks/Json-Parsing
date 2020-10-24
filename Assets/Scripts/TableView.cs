using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _titleField = null;
    [SerializeField]
    private ColumnView _columnTemplate = null;
    
    private JsonDataModel _jsonData;
    private string _title;
    private string[] _columnData;
    private List<TextMeshProUGUI> _headerItemList = new List<TextMeshProUGUI>();
    
    public void SetData(JsonDataModel jsonData)
    {
        _title = jsonData.Title;
        _titleField.text = _title;
        
        _columnData = jsonData.ColumnHeaders;

        int headerListLastIndex = _headerItemList.Count - 1;
    }
}
