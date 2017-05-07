 

<?php 
    header('Content-Type:text/json;charset=utf-8');
header('Access-Control-Allow-Origin:*'); 
	$str = array
       (
          'Result'=>'xiaolou'           
       );

	$jsonencode = json_encode($str);
	echo $jsonencode;
?>