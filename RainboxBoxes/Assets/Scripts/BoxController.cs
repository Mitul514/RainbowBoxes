using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxController : MonoBehaviour
{
  [SerializeField] private TextMeshPro m_NumText;

  public int CurrVal;

  public void SetData(int val)
  {
    m_NumText.text = val.ToString();
    CurrVal = val;
  }

  private void OnMouseDown()
  {
    BoxManager.BMinstance.GetClickedObjects(this.gameObject);
  }
}
