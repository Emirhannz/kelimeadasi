<?php

if( isset( $_SERVER["HTTP_CLIENT_IP"] ) ) {
	$remoteIP = $_SERVER["HTTP_CLIENT_IP"];
} elseif( isset( $_SERVER["HTTP_X_FORWARDED_FOR"] ) ) {
	$remoteIP = $_SERVER["HTTP_X_FORWARDED_FOR"];
} elseif (isset($_SERVER["HTTP_CF_CONNECTING_IP"])) {
  $remoteIP = $_SERVER["HTTP_CF_CONNECTING_IP"];
} else {
	$remoteIP = $_SERVER["REMOTE_ADDR"];
}

require_once (ROOT_PATH.'inc/clases/ezsql/autoload.php');

use ezsql\Config;
use ezsql\Database\ez_pdo;

$settings = new Config('pdo', ['mysql:host='.$conf['dbhost'].';dbname='.$conf['dbname'], $conf['dbuser'], $conf['dbpass'], $other_settings]);
$db = new ez_pdo($settings);
$db->query("SET NAMES 'utf8'; SET CHARSET 'utf8'");
?>