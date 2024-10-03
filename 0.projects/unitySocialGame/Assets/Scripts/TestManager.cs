using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//�l�b�g���[�N�p
using System.Net;
using UnityEngine.Networking;

public class TestManager : MonoBehaviour
{
    /*�ϐ�*/
    //http�p
    string _hostUrl = @"http://localhost/phpSocialGame/";
    //string _hostUrl = @"https://ohara-fic-game.fool.jp/2023GameEngineFor2022/socialGame/";
    //�R���|�[�l���g
    TextMeshProUGUI resultLabel;

    /*Start*/
    private void Start()
    {
        /*�I�u�W�F�N�g(or�R���|�[�l���g)�̎擾*/
        resultLabel = GameObject.Find("httpResLabel").GetComponent<TextMeshProUGUI>();
    }


    /*�Q�[�����[�v*/
    private void Update()
    {
        /*GUI�X�V*/
        //http���X�|���X�m�F
        resultLabel.text = NetManager.s_httpResult;
    }

    /*�{�^�����\�b�h*/

    public void TestGet()
    {
        /*URL�ƃN�G��*/
        string passUrl = @"TestGetHttp.php";
        string query = "tes1=1&tes2=2";

        //Get���\�b�h�̎��s
        StartCoroutine(NetManager.HttpGetEnumerable(_hostUrl, passUrl, query));
    }
    public void TestPost()
    {
        /*URL�ƃN�G��*/
        string passUrl = @"TestPostHttp.php";

        /*�t�H�[���̍쐬*/
        WWWForm form = new WWWForm();
        form.AddField("userID", 1234);
        form.AddField("userName", "Takashi");
        form.AddField("userPass", 4321);

        //Get���\�b�h�̎��s
        StartCoroutine(NetManager.HttpPostEnumerable(_hostUrl, passUrl, form));
    }

}
