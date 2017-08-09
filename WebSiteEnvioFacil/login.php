
<div class="modal fade" id="login-modal" tabindex="-1" role="dialog" aria-labelledby="Login" aria-hidden="true">
    <div class="modal-dialog modal-sm">

        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <br>
                <img src="img/logo.png" alt="Obaju template">
                <br>
            </div>
            <br>
            <div class="modal-body">
                <form action="logar.php" method="POST">
                    <div class="form-group">
                        <input type="text" class="form-control" name="usuario" placeholder="Usuário">
                    </div>
                    <div class="form-group">
                        <input type="password" class="form-control" name="senha" placeholder="Senha">
                    </div>
                    <br>
                    <p class="text-center">
                        <input type="submit" value="Efetuar login" class="btn btn-template-main"/>
                    </p>

                </form>

            </div>
        </div>
    </div>
</div>
