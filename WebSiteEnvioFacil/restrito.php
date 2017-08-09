<?php
    session_start();

    include ('inicio.php');
    include ('header.php');
    include ('login.php');

    if ($_SESSION['sessaoEnvioFacil']) {

        $pagina = $_GET['acessando'];

        if($pagina=='')
        {
            include('restrito/inicio.php');
        }
        elseif(file_exists('restrito/'.$pagina .'.php'))
        {
            include ('restrito/'.$pagina.'.php');
        }
        else
        {
            include('restrito/inicio.php');
        }
    }
    else
    {
        include('erroLogin.php');
    }

    include ('footer.php');

?>