using System;
using UnityEngine;
using UnityEngine.UI;

public class tManager : MonoBehaviour
{
    //http�p
    [SerializeField]
    private string _hostUrl = @"http://localhost/phpSocialGame/";
    public string HostUrl { get { return _hostUrl; } }

    /*�Q�[���I�u�W�F�N�g�̕ϐ�*/
    [SerializeField]
    public GameObject LoginBox, CreateBox, NoticeBox;
    private GameObject _canvas, _buttonBox;

    /*�ϐ�*/
    bool _isUserID = false;

    /*�R���|�[�l���g�ϐ�*/
    Text _userIdLabel;
    Text _userNameLabel;

    /*Start*/
    private void Start()
    {
        /*�Q�[���I�u�W�F�N�g�擾*/
        _canvas = GameObject.Find("Canvas");
        _buttonBox = GameObject.Find("buttonBox");

        /*�R���|�[�l���g�̎擾*/
        _userIdLabel = GameObject.Find("userIdLabel").GetComponent<Text>();
        _userNameLabel = GameObject.Find("userNameLabel").GetComponent<Text>();
    }

    /*Update*/
    private void Update()
    {
        /*userID�̊m�F*/
        var id = PlayerPrefs.GetString("userID", String.Empty);
        if (id != string.Empty)
        {
            //ID������ꍇ
            _userIdLabel.text = $"ID:{id}";

        }
        else
        {
            //ID�������ꍇ
            _userIdLabel.text = $"ID: none ID.";
        }

        /*userName�̊m�F*/
        var name = PlayerPrefs.GetString("userName", String.Empty);
        if (name != string.Empty)
        {
            //ID������ꍇ
            _userNameLabel.text = $"Name:{name}";

        }
        else
        {
            //ID�������ꍇ
            _userNameLabel.text = $"Name: none Name.";
        }

    }

    /*�{�^�����\�b�h*/
    public void LoginButton()
    {
        /*�v���n�u�̍쐬�Ə�����*/
        GameObject tempObj = InstantiateuGUIBox(LoginBox, _canvas, "loginBox");
    }
    public void CreateButton()
    {
        /*�v���n�u�̍쐬�Ə�����*/
        GameObject tempObj = InstantiateuGUIBox(CreateBox, _canvas, "createBox");

    }
    public void NoticeButton()
    {
        /*�v���n�u�̍쐬�Ə�����*/
        GameObject tempObj = InstantiateuGUIBox(NoticeBox,_canvas,"noticeBox");
    }
    public void DropButton()
    {
        PlayerPrefs.DeleteAll();
    }


    /*���\�b�h*/
    /// <summary>
    /// �y���[�U��`�zuGUI���uiBOX���쐬(create,login,notice).
    /// </summary>
    /// <param name="createObj">�쐬����I�u�W�F�N�g</param>
    /// <param name="parentObj">�e�I�u�W�F�N�g</param>
    /// <param name="objName">�쐬����I�u�W�F�N�g��</param>
    private GameObject InstantiateuGUIBox(GameObject createObj,GameObject parentObj,string objName)
    {
        //�v���n�u�̍쐬
        var tempObj = Instantiate(createObj);
        //�e�I�u�W�F�N�g�̐ݒ�
        tempObj.transform.SetParent(parentObj.transform);
        //�I�u�W�F�N�g�̖��O�����
        tempObj.name = objName;
        //�쐬�����I�u�W�F�N�g�̈ʒu
        tempObj.GetComponent<RectTransform>().anchoredPosition= Vector3.zero;
        //retrun
        return tempObj;
    }
}
