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
    private string[] _columnKeys;
    private List<Dictionary<string, string>> _rowDataMap;
    
    private List<ColumnView> _columnViewList = new List<ColumnView>();
    
    public void SetData(JsonDataModel jsonData)
    {
        _title = jsonData.Title;
        _titleField.text = _title;
        _columnKeys = jsonData.ColumnHeaders;
        _rowDataMap = jsonData.Data;
        
        for (int i = 0; i < _columnKeys.Length; i++)
        {
            string key = _columnKeys[i];

            ColumnView column = Instantiate(_columnTemplate, _columnTemplate.transform.parent);
            column.SetHeader(key);
            for (int j = 0; j < _rowDataMap.Count; j++)
            {
                column.SetItem(_rowDataMap[j][key]);
                column.gameObject.SetActive(true);
            }
        }
    }
}
