using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditTogglePrefab : MonoBehaviour {

    public Image bg_image;
    public Text des_text;

    public EditItemType type;

    public void OnTogglePressed(Toggle toggle)
    {
        if(toggle.isOn)
        {
            EditDirector.mInstance.UpdateEditItem(this.gameObject);

        }
    }
}
