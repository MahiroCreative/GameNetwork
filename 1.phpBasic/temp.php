<pre>
<?php
/*ファイルの読み込み*/
//ファイル名(pass)
$filename = "test.txt";
//ファイルの存在を確認する
$result = file_exists($filename);
//存在していた場合
if($result)
{
    //ファイルを読み込む
    $data = file_get_contents($filename);
    //ブラウザに表示
    echo $data;
}
else{
    echo "not file";
}

?>
</pre>