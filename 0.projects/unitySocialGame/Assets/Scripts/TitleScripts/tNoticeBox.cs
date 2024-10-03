using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//�l�b�g���[�N�p
using System.Net;
using UnityEngine.Networking;

public class tNoticeBox : MonoBehaviour
{
    //http�p
    private string _hostUrl;
    private string _passurl;

    /*�Q�[���I�u�W�F�N�g�ϐ�*/
    GameObject _buttonBox;

    /*�R���|�[�l���g�ϐ�*/
    Text _noticeText;

    void Start()
    {
        /*�Q�[���I�u�W�F�N�g�̎擾*/
        _hostUrl = GameObject.Find("tManager").GetComponent<tManager>().HostUrl;
        _buttonBox = GameObject.Find("buttonBox");

        /*�R���|�[�l���g�̎擾*/
        _noticeText = GameObject.Find("noticeText").GetComponent<Text>();

        /*buttonBox���ꎞ�I�ɏ���*/
        _buttonBox.SetActive(false);

        /*text�̏�����*/
        _noticeText.text = $"�ڑ����ł�...";

        /*Get�ʐM*/
        _passurl = @"Notice.php";
        StartCoroutine(NetManager.HttpGetEnumerable(_hostUrl, _passurl));
        
    }

    private void Update()
    {
        //�e�L�X�g�̍X�V
        if (NetManager.s_httpResult != null)
        {
            _noticeText.text = NetManager.s_httpResult;
        }
    }

    /*�{�^�����\�b�h*/
    //�߂�{�^��
    public void NoticeReturnB()
    {
        /*buttonBox���Đ���*/
        _buttonBox.SetActive(true);

        /*http������*/
        NetManager.s_httpResult = null;

        /*���g�̍폜*/
        Destroy(this.gameObject);
    }
}
