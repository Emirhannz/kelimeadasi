<?php
ini_set('memory_limit', '512M');

ini_set('display_errors',1);
date_default_timezone_set('Europe/Istanbul'); 

$conf = array (
'dbhost'		=> 'localhost', 
'dbname'		=> 'kelimeadasidb',	
'dbuser'		=> 'nev3r',	
'dbpass'		=> '4OvLiGZhh[xbBiVZ',
);

define("ROOT_PATH", dirname(dirname(__FILE__))."/");

error_reporting(E_ERROR | E_PARSE | E_COMPILE_ERROR);
?>