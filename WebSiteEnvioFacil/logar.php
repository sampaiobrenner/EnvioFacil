<?php

    session_start();

    $usuario = $_POST['usuario'];
    $senha = $_POST['senha'];


    if ($usuario == 'admin' and $senha == 'admin') {
        $_SESSION['sessaoEnvioFacil'] = true;
    } else {
        $_SESSION['sessaoEnvioFacil'] = false;
    }

    header('Location: restrito.php?acessando=inicio');

?>