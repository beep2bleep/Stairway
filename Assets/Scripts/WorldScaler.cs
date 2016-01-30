using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class WorldScaler : MonoBehaviour
{
    [SerializeField]
    private Transform gameCameraTfm = Camera.main.transform;

    private Transform tfm = null;
    
	private void LateUpdate()
	{
        if (this.tfm == null)
        {
            this.tfm = this.GetComponent<Transform>();
        }

        //Commented out was throwing error probably won't use
        //this.tfm.localScale = new Vector3(1, 1 / Mathf.Cos(this.gameCameraTfm.eulerAngles.x * Mathf.Deg2Rad), 1 / Mathf.Sin(this.gameCameraTfm.eulerAngles.x * Mathf.Deg2Rad));
	}
}
