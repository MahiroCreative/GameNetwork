using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
//�ǉ�
using UnityEngine.Networking;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    /*Http�ʐM*/
    //getRanking
    const string _getPass = @"getRanking.php";
    //postRanking
    const string _postPass = @"postRanking.php";
    //resetDB
    const string _resetPass = @"resetDB.php";
    //createTable
    const string _createPass = @"createTable.php";

    /*�����L���O�\��*/
    string _rankingText = string.Empty;

    /*uGUI*/
    //�T�[�oURL�̓���
    InputField _serverUrlField;
    //�e�[�u����M
    Text _rankingLabel;
    InputField _gettTableField;
    //�e�[�u���X�V
    InputField _upTableField;
    InputField _nameField;
    InputField _scoreField;
    //�e�[�u���쐬
    InputField _createTableField;
    InputField _colum1TableField;
    InputField _colum2TableField;
    InputField _colum3TableField;

    // Start is called before the first frame update
    void Start()
    {
        /*uGUI�p*/
        //�T�[�oURL
        _serverUrlField = GameObject.Find("serverUrlField").GetComponent<InputField>();
        //�e�[�u����M
        _rankingLabel = GameObject.Find("RankingLabel").GetComponent<Text>();
        _gettTableField = GameObject.Find("getTableField").GetComponent<InputField>();
        //�e�[�u���X�V
        _upTableField = GameObject.Find("upTableField").GetComponent<InputField>();
        _nameField = GameObject.Find("nameField").GetComponent<InputField>();
        _scoreField = GameObject.Find("scoreField").GetComponent<InputField>();
        //�e�[�u���쐬
        _createTableField = GameObject.Find("createTableField").GetComponent<InputField>();
        _colum1TableField = GameObject.Find("colum1Field").GetComponent<InputField>();
        _colum2TableField = GameObject.Find("colum2Field").GetComponent<InputField>();
        _colum3TableField = GameObject.Find("colum3Field").GetComponent<InputField>();

        /*������*/
        _serverUrlField.text = @"http://mahiro.punyu.jp/SimpleRanking/";
        _gettTableField.text = @"Ranking";
        _upTableField.text = @"Ranking";
        _createTableField.text = @"Ranking";
        _colum1TableField.text = @"rank";
        _colum2TableField.text = @"name";
        _colum3TableField.text = @"score";

    }

    // Update is called once per frame
    void Update()
    {
        //�����L���O�̍X�V
        _rankingLabel.text = _rankingText;
    }

    /*�{�^���p�̃��\�b�h*/
    public void GetRanking()//��M
    {
        //Unity��http�ʐM���s�����߂ɂ͔񓯊��ʐM���K�v
        //���̂���StartCoroutine���\�b�h���g���āA�ʃX���b�h�Ƀ��\�b�h�����s������
        string tes = _serverUrlField.text;
        StartCoroutine(GetRequest(_serverUrlField.text,_getPass));
    }
    public void PostRanking()//���M
    {
        StartCoroutine(PostRequest(_serverUrlField.text,_postPass));
    }
    public void ResetDB()//�f�[�^�x�[�X�̏�����
    {
        StartCoroutine(GetRequest(_serverUrlField.text,_resetPass));
    }
    public void CreateTable()//�e�[�u���̍쐬
    {
        StartCoroutine(PostCreate(_serverUrlField.text,_createPass)) ;
    }

    /*Http���\�b�h*/
    //�ʃX���b�h�ŏ�����������(�R���[�`���Ƃ��ď�����������)���߂ɂ�  
    //IEnumerator��Ԃ�l�Ƃ��Ď��K�v������܂��B
    //����͕ʃX���b�h���猋�ʂ��Ԃ��Ă���܂Ŕ񓯊��ɉ��x�����ʂ�v������K�v�����邽�߂ł��B
    IEnumerator GetRequest(string serverUrl, string getPass)
    {
        /*URL�̍쐬*/
        string _getUrl = serverUrl + getPass + @"?" + @"table=" + _gettTableField.text;

        /*GetRequest*/
        //using�ɂ��X�R�[�v�𔲂����玩���Ń��������
        using UnityWebRequest _getRequest = UnityWebRequest.Get(_getUrl);

        /*yield return*/
        //yield return�ɂ��A���ʂ��҂�܂ł��̃��\�b�h���̈ȍ~�̏������s���Ȃ��B
        //���\�b�h�̌Ăяo�����Ƃɖ߂��ĕʂ̏������p������B
        yield return _getRequest.SendWebRequest();

        //�ʐM�̃G���[����
        if (_getRequest.isNetworkError || _getRequest.isHttpError)
        {
            // �G���[���N�����ꍇ�̓G���[���e��\��
            Debug.Log(_getRequest.error);
            Debug.Log(_getUrl);
        }
        else
        {
            //�����L���O�e�L�X�g�̍X�V
            Debug.Log(_getUrl);
            _rankingText = _getRequest.downloadHandler.text;
        }
    }
    //Post�ʐM���s�����\�b�h
    //������̓f�[�^�̑��M���s���B
    IEnumerator PostRequest(string serverUrl, string postPass)
    {
        /*URL�̍쐬*/
        string _postUrl = serverUrl + postPass;

        /*�t�H�[���̍쐬*/
        //�|�X�g��URL�݂̂̒ʐM�ł͂Ȃ��AURL�ɑ債��From��n�����ƂŒʐM����B
        //�Ȃ̂Ńt�H�[�����쐬����K�v������B
        WWWForm form = new WWWForm();
        form.AddField("table", _gettTableField.text);
        form.AddField("name", _nameField.text);
        form.AddField("score", _scoreField.text);

        /*PostRequest*/
        //using�ɂ��X�R�[�v�𔲂����玩���Ń��������
        using UnityWebRequest _postRequest = UnityWebRequest.Post(_postUrl, form);

        /*yield return*/
        yield return _postRequest.SendWebRequest();

        /*�G���[����*/
        if (_postRequest.isNetworkError)
        {
            //�ʐM���s
            Debug.Log(_postRequest.error);
            Debug.Log(_postUrl);
        }
        else
        {
            //�ʐM����
            Debug.Log(_postRequest.downloadHandler.text);
            Debug.Log(_postUrl);
        }
    }
    //�e�[�u���̍쐬
    IEnumerator PostCreate(string serverUrl, string createPass)
    {
        /*URL�̍쐬*/
        string _postUrl = serverUrl + createPass;

        /*�t�H�[���̍쐬*/
        //�|�X�g��URL�݂̂̒ʐM�ł͂Ȃ��AURL�ɑ債��From��n�����ƂŒʐM����B
        //�Ȃ̂Ńt�H�[�����쐬����K�v������B
        WWWForm form = new WWWForm();
        form.AddField("table", _createTableField.text);
        form.AddField("colum1",_colum1TableField.text);
        form.AddField("colum2", _colum2TableField.text);
        form.AddField("colum3", _colum3TableField.text);

        /*PostRequest*/
        //using�ɂ��X�R�[�v�𔲂����玩���Ń��������
        using UnityWebRequest _postRequest = UnityWebRequest.Post(_postUrl, form);

        /*yield return*/
        yield return _postRequest.SendWebRequest();

        /*�G���[����*/
        if (_postRequest.isNetworkError)
        {
            //�ʐM���s
            Debug.Log(_postRequest.error);
            Debug.Log(_postUrl);
        }
        else
        {
            //�ʐM����
            Debug.Log(_postRequest.downloadHandler.text);
            Debug.Log(_postUrl);
        }
    }
}

