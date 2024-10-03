using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//�l�b�g���[�N�p
using System.Net;
using UnityEngine.Networking;

public class tLoginBox : MonoBehaviour
{
    //http�p
    private string _hostUrl;
    private string _passUrl;
    WWWForm _form;

    /*�Q�[���I�u�W�F�N�g�ϐ�*/
    GameObject _buttonBox;

    /*�R���|�[�l���g�ϐ�*/
    Text _loginText;

    /*�ϐ�*/
    bool _isUserId = false;
    string _userID;
    string _userPass;
    string _userName;
    string _sessionKey;

    void Start()
    {
        /*�Q�[���I�u�W�F�N�g�̎擾*/
        _hostUrl = GameObject.Find("tManager").GetComponent<tManager>().HostUrl;
        _buttonBox = GameObject.Find("buttonBox");

        /*�R���|�[�l���g�̎擾*/
        _loginText = GameObject.Find("loginText").GetComponent<Text>();

        /*buttonBox���ꎞ�I�ɏ���*/
        _buttonBox.SetActive(false);

        /*uesrID�̊m�F*/
        var tempID = PlayerPrefs.GetString("userID", String.Empty);
        var tempPass = PlayerPrefs.GetString("userPass", String.Empty);
        var tempName = PlayerPrefs.GetString("userName", String.Empty);
        if (tempID != string.Empty && tempPass != string.Empty)
        {
            //ID������ꍇ
            _loginText.text = $"�ڑ����ł�...";
            _userID = tempID;
            _userPass = tempPass;
            _userName = tempName;
            _isUserId = true;
        }
        else
        {
            //ID�������ꍇ
            _loginText.text = $"�w����񂪂���܂���B\n�܂��͓��w���܂��傤�B";
            NetManager.s_httpResult = null;
            _isUserId = false;
        }

        /*Post�ʐM*/
        if(_isUserId == true)
        {
            //uri�̐ݒ�
            _passUrl = @"Login.php";
            //�Z�b�V����KEY�̍쐬
            _sessionKey = MakeSessionKey(8);
            //form�̍쐬
            _form = new WWWForm();
            _form.AddField("userID", _userID);
            _form.AddField("userPass", _userPass);
            _form.AddField("userName", _userName);
            _form.AddField("sessionKey", _sessionKey);
            StartCoroutine(NetManager.HttpPostEnumerable(_hostUrl,_passUrl,_form));
        }

    }

    private void Update()
    {
        //�e�L�X�g�̍X�V
        if (NetManager.s_httpResult != null)
        {
            _loginText.text = NetManager.s_httpResult;
        }
    }


    /*�{�^�����\�b�h*/
    //�߂�{�^��
    public void LoginReturnB()
    {
        /*buttonBox���Đ���*/
        _buttonBox.SetActive(true);

        /*NetManager�̏�����*/
        NetManager.s_httpResult = null;

        /*���g�̍폜*/
        Destroy(this.gameObject);
    }

    /*���상�\�b�h*/
    /// <summary>
    /// �Z�b�V�����L�[���쐬����֐��B�����_���ȕ����񐔒l���쐬����B
    /// </summary>
    /// <param name="num">������</param>
    /// <returns></returns>
    string MakeSessionKey(int num)
    {
        /*�ϐ�*/
        //�������p��
        var txt = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //������
        var n = 8;
        //���������p
        var random = new System.Random();
        //���ʊi�[�p
        string result="";

        /*�����_��������쐬*/
        for(int i = 0 ; i < n ; i++)
        {
            result += txt[random.Next(txt.Length)];
        }

        return result;
    }
}
