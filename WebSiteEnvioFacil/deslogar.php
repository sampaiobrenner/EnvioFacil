<?php

    session_start();

    unset($_SESSION['sessaoEnvioFacil']);

    header('Location: restrito.php?acessando=inicio');

?>