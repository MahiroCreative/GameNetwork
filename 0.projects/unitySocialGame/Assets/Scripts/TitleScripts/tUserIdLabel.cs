using System;
using UnityEngine;
using UnityEngine.UI;

public class tUserIdLabel : MonoBehaviour
{
    /*�R���|�[�l���g�ϐ�*/
    Text _userIdLabel;

    // Start is called before the first frame update
    void Start()
    {
        /*�R���|�[�l���g�̎擾*/
        _userIdLabel = GameObject.Find("userIdLabel").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        /*userID�̊m�F*/
        var temp = PlayerPrefs.GetString("userID", String.Empty);
        if (temp != string.Empty)
        {
            //ID������ꍇ
            _userIdLabel.text = $"ID:{temp}";

        }
        else
        {
            //ID�������ꍇ
            _userIdLabel.text = $"userID: none ID.";
        }
    }
}
