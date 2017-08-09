<header>

    <!-- *** TOP ***
_________________________________________________________ -->
    <div id="top" class="light">
        <div class="container">
            <div class="row">
                <div class="col-xs-5 contact">
                    <p class="hidden-sm hidden-xs">Atendimento: (53) 98106-5455 ou sampaio.brenner@gmail.com</p>
                    <p class="hidden-md hidden-lg"><a href="#" data-animate-hover="pulse"><i class="fa fa-phone"></i></a>  <a href="#" data-animate-hover="pulse"><i class="fa fa-envelope"></i></a>
                    </p>
                </div>
                <div class="col-xs-7">
                    <div class="social">
                        <a href="#" class="external facebook" data-animate-hover="pulse"><i class="fa fa-facebook"></i></a>
                        <a href="#" class="external gplus" data-animate-hover="pulse"><i class="fa fa-google-plus"></i></a>
                        <a href="#" class="external twitter" data-animate-hover="pulse"><i class="fa fa-twitter"></i></a>
                        <a href="#" class="email" data-animate-hover="pulse"><i class="fa fa-envelope"></i></a>
                    </div>

                    <div class="login">
                        <?php
                            if ($_SESSION['sessaoEnvioFacil']) {
                                echo '<a href="restrito.php?acessando=inicio"><i class="fa fa-user"></i> <span class="hidden-xs text-uppercase">Área Restrita</span></a>';
                                echo '<a href="deslogar.php"><i class="fa fa-sign-in"></i> <span class="hidden-xs text-uppercase">Sair</span></a>';
                            } else {
                               echo '<a href="#" data-toggle="modal" data-target="#login-modal"><i class="fa fa-sign-in"></i> <span class="hidden-xs text-uppercase">Entrar</span></a>';
                            }
                        ?>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <!-- *** TOP END *** -->

    <!-- *** NAVBAR ***
_________________________________________________________ -->

    <div class="navbar-affixed-top" data-spy="affix" data-offset-top="200">

        <div class="navbar navbar-default yamm" role="navigation" id="navbar">

            <div class="container">
                <div class="navbar-header">

                    <a class="navbar-brand home" href="conteudo.php?acessando=principal">
                        <img src="img/logo.png" alt="Universal logo" class="hidden-xs hidden-sm">
                        <img src="img/logo-small.png" alt="Universal logo" class="visible-xs visible-sm"><span class="sr-only">Envio Fácil - Ir para a Home</span>
                    </a>
                    <div class="navbar-buttons">
                        <button type="button" class="navbar-toggle btn-template-main" data-toggle="collapse" data-target="#navigation">
                            <span class="sr-only">Toggle navigation</span>
                            <i class="fa fa-align-justify"></i>
                        </button>
                    </div>
                </div>
                <!--/.navbar-header -->

                <div class="navbar-collapse collapse" id="navigation">

                    <ul class="nav navbar-nav navbar-right">

                        <li class="">
                            <a href="conteudo.php?acessando=principal" class="">Home</a>
                        </li>

                        <li class="">
                            <a href="conteudo.php?acessando=comoFunciona" class="">Como Funciona</a>
                        </li>

                        <li class="">
                            <a href="conteudo.php?acessando=aplicacao" class="">Aplicação</a>
                        </li>

                        <li class="">
                            <a href="conteudo.php?acessando=tarifas_todas" class="">Tarifas</a>
                        </li>

                        <li class="">
                            <a href="conteudo.php?acessando=faq" class="">FAQ</a>
                        </li>

                        <li class="">
                            <a href="conteudo.php?acessando=contato" class="">Contato</a>
                        </li>


                </div>


            </div>


        </div>
        <!-- /#navbar -->

    </div>

    <!-- *** NAVBAR END *** -->

</header>