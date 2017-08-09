<?php

    session_start();

    include ('inicio.php');
    include ('header.php');
    include ('login.php');


    $pagina = $_GET['acessando'];

        if($pagina=='')
          include ('principal.php');
        elseif(file_exists($pagina.'.html')){
          include ($pagina.'.html');
        }
        elseif(file_exists($pagina.'.php')){
          include ($pagina.'.php');
        }
        else
          include ('principal.php');


    include ('footer.php');

?>