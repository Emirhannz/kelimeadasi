<?php
require_once('inc/config.php');
require_once(ROOT_PATH.'inc/app_top.php');


if ($_POST['Islem'] == "Kayit") {
    $Kontrol = $db->get_row("select id from playerstat where email = '".$_POST['Email']."' ");
    if ($Kontrol->id > 0) {

        echo "E-posta kayıtlı!";

    } else {
        $query = $db->query("INSERT INTO playerstat (ad_soyad, kullanici_adi, parola, email) VALUES ('".$_POST["AdSoyad"]."', '".$_POST["Kullanici"]."', '".md5($_POST["Parola"])."', '".$_POST["Email"]."')");
        if($query){
            $lastID = $db->insert_id;
                echo 'Kayit basarili';   
        } else {         
            echo "Kayit tamamlanamadi";
        }
    }
}   


if ($_POST['Islem'] == "Giris") {
    $Kontrol = $db->get_row("SELECT id, parola FROM playerstat WHERE kullanici_adi = '" . $_POST['Kullanici'] . "'");
    if (!empty($Kontrol)) {
        if (md5($_POST['Parola']) != $Kontrol->parola) {
            echo "HATALI KULLANICI ADI VEYA PAROLA";
        } else {
            echo "GİRİŞ BAŞARILI";
        }
    } else {
        echo "HATALI KULLANICI ADI VEYA PAROLA";
    }
}
