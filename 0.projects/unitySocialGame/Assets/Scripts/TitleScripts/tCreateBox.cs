using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//�l�b�g���[�N�p
using System.Net;
using UnityEngine.Networking;

public class tCreateBox : MonoBehaviour
{
    //http�p
    private string _hostUrl;
    private string _passUrl = @"CreateUser.php";
    WWWForm _form;

    /*�Q�[���I�u�W�F�N�g�ϐ�*/
    GameObject _buttonBox;

    /*�R���|�[�l���g�̎擾*/
    Text _createText;
    Text _nameText;

    void Start()
    {
        /*�Q�[���I�u�W�F�N�g�̎擾*/
        _buttonBox = GameObject.Find("buttonBox");

        /*�R���|�[�l���g�̎擾*/
        _hostUrl = GameObject.Find("tManager").GetComponent<tManager>().HostUrl;    
        _nameText = GameObject.Find("nameText").GetComponent<Text>();
        _createText = GameObject.Find("createText").GetComponent<Text>();

        /*buttonBox���ꎞ�I�ɏ���*/
        _buttonBox.SetActive(false);

        /*�\���e�L�X�g�̏�����*/
        _createText.text = "���w�菑";
    }


    private void Update()
    {
        if (NetManager.s_httpResult != null)
        {
            //���ʂ̏o��
            _createText.text = NetManager.s_httpResult;
        }

    }

    /*�{�^�����\�b�h*/
    //�o��{�^��
    public void CreatePostB()
    {
        /*�e�L�X�g���͔���*/
        if(_nameText.text != String.Empty)
        {
            //debug.
            Debug.Log("create");

            //userData�̍쐬
            PlayerPrefs.SetString("userID", "0001");
            PlayerPrefs.SetString("userPass", "abcd");
            PlayerPrefs.SetString("userName",_nameText.text);

            //form�̍쐬
            _form = new WWWForm();
            _form.AddField("userID", "0001");
            _form.AddField("userPass", "abcd");
            _form.AddField("userName", _nameText.text);

            //post�ʐM
            StartCoroutine(NetManager.HttpPostEnumerable(_hostUrl, _passUrl, _form));

            //�e�L�X�g�\��
            _createText.text = "�菑��o��...";
        }
        else
        {
            //�G���[��
            _createText.text = "���͒l���s���ł��I";

        }

    }
    //�߂�{�^��
    public void CreateReturnB()
    {
        /*buttonBox���Đ���*/
        _buttonBox.SetActive(true);

        /*NetManager�̏�����*/
        NetManager.s_httpResult = null;

        /*���g�̍폜*/
        Destroy(this.gameObject);
    }
}