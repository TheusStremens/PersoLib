<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="PersoLib.PaginaInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="SHIELD - Free Bootstrap 3 Theme">
    <meta name="author" content="Carlos Alvarez - Alvarez.is - blacktie.co">
    <link rel="shortcut icon" href="assets/ico/favicon.png">
    <title>PersoLib- Biblioteca Pessoal</title>
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <link href="assets/css/main.css" rel="stylesheet">
    <link rel="stylesheet" href="assets/css/icomoon.css">
    <link href="assets/css/animate-custom.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic'
        rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,300,700' rel='stylesheet'
        type='text/css'>
    <script src="assets/js/jquery.min.js"></script>
    <script type="text/javascript" src="assets/js/modernizr.custom.js"></script>
</head>
<body data-spy="scroll" data-offset="0" data-target="#navbar-main">
    <form id="form_body" runat="server">
        <div id="navbar-main">
            <div class="navbar navbar-inverse navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon icon-shield" style="font-size: 30px; color: #3498db;"></span>
                        </button>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li><a href="#home" class="smoothScroll">PersoLib</a></li>
                            <li><a href="#about" class="smoothScroll">Sobre</a></li>
                            <li>
                                <div class="col-lg-2 login">
                                    <button runat="server" data-target="#modal_login" data-toggle="modal" id="btn_login"
                                        class="btn btn-info login">
                                        Fazer Login
                                    </button>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div id="headerwrap" id="home" name="home">
            <header class="clearfix">
                <h1><span class="icon"></span></h1>
                <p>Biblioteca Pessoal</p>
                <h3>
                    <p>Seus livros em um só lugar</p>
                </h3>
                <p>
                    <button data-target="#modal_cadastro" data-toggle="modal" type="button" class="btn btn-danger alert-success btn-lg">Comece a usar agora!</button></p>
            </header>
        </div>
        <div id="greywrap">
            <div class="row">
                <div class="col-lg-4 callout">
                    <span class="icon icon-stack"></span>
                    <h2>Cadastre seus Livros</h2>
                    <p>
                        Tenha um controle sobre seus livros. É fácil cadastrá-los, alterá-los, remove-los
                    ou...
                    </p>
                </div>
                <div class="col-lg-4 callout">
                    <span class="icon icon-eye"></span>
                    <h2>Empreste seus Livros</h2>
                    <p>
                        Agora você pode sempre lembrar a quem você emprestou seu livro!
                    </p>
                </div>
                <div class="col-lg-4 callout">
                    <span class="icon icon-heart"></span>
                    <h2>Alerta de Prazo</h2>
                    <p>
                        A Biblioteca Pessoal alerta você e o emprestante da aproximação da data de devolução!
                    </p>
                </div>
            </div>
        </div>
        <div class="container" id="about" name="about">
            <div class="row white">
                <br>
                <h1 class="centered">Sobre nós</h1>
                <hr>
                <div class="col-lg-6 text-justify">
                    <p>
                        Caros amigos, a execução dos pontos do programa auxilia a preparação e a composição
                    do retorno esperado a longo prazo. Percebemos, cada vez mais, que a constante divulgação
                    das informações agrega valor ao estabelecimento do fluxo de informações. Não obstante,
                    a consulta aos diversos militantes não pode mais se dissociar das condições financeiras
                    e administrativas exigidas. É importante questionar o quanto a expansão dos mercados
                    mundiais prepara-nos para enfrentar situações atípicas decorrentes dos índices pretendidos.
                    O cuidado em identificar pontos críticos na competitividade nas transações comerciais
                    garante a contribuição de um grupo importante na determinação das diretrizes de
                    desenvolvimento para o futuro.
                    </p>
                </div>
                <div class="col-lg-6 text-justify">
                    <p>
                        A prática cotidiana prova que o aumento do diálogo entre os diferentes setores produtivos
                    assume importantes posições no estabelecimento das formas de ação. No entanto, não
                    podemos esquecer que o surgimento do comércio virtual pode nos levar a considerar
                    a reestruturação dos níveis de motivação departamental. Assim mesmo, a consolidação
                    das estruturas obstaculiza a apreciação da importância dos procedimentos normalmente
                    adotados. Acima de tudo, é fundamental ressaltar que a contínua expansão de nossa
                    atividade oferece uma interessante oportunidade para verificação dos modos de operação
                    convencionais.
                    </p>
                </div>
            </div>
        </div>
        <section class="section-divider textdivider "></section>
        <div id="footerwrap">
            <div class="container">
                <h4>Created by <a href="">Stremens Corp.</a> - TMA LTDA.</h4>
            </div>
        </div>
        <div class="modal fade" id="modal_cadastro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog">
                <div runat="server" class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                        </button>
                        <h4 class="modal-title" id="myModalLabel">Digite seus Dados!
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_email">
                                    Email:
                                </label>
                                <div class="col-md-4">
                                    <input id="txt_email" name="txt_email" type="text" placeholder="email@servidor.com"
                                        class="form-control input-md" required>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_name">
                                    Nome:
                                </label>
                                <div class="col-md-4">
                                    <input id="txt_name" name="txt_name" runat="server" type="text" placeholder="Seu nome" class="form-control input-md"
                                        required>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_senha">
                                    Senha:
                                </label>
                                <div class="col-md-4">
                                    <input id="txt_senha" name="txt_senha" type="password" placeholder="*********" class="form-control input-md"
                                        required="">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_repete_senha">
                                    Repita a senha:
                                </label>
                                <div class="col-md-4">
                                    <input id="txt_repete_senha" name="txt_repete_senha" type="password" placeholder="*********"
                                        class="form-control input-md" required="">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">                        
                        <asp:Button ID="btn_cadastrar_usuario" runat="server" class="btn btn-success" OnClick="CadastrarUsuario" Text="Cadastrar" />
                        <button id="btn_cancelar" type="reset" data-dismiss="modal" name="btn_cancelar" class="btn btn-danger">
                            Cancelar
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_login" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                        </button>
                        <h4 class="modal-title" id="myModalLabel">Login
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail1" class="col-lg-4 control-label">
                                </label>
                                <div class="col-lg-10">
                                    <input type="email" class="form-control" id="inputEmail1" placeholder="Email">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="text1" class="col-lg-4 control-label">
                                </label>
                                <div class="col-lg-10">
                                    <input type="password" class="form-control" id="text1" placeholder="Senha">
                                </div>
                            </div>
                            <div class="modal-footer">
                                <a href="PaginaPrincipal.aspx" class="btn btn-success">Entrar</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <style type="text/css">
                .login {
                    padding-top: 7px;
                }

                .email {
                    padding-top: 15px;
                    color: White;
                    text-align: right;
                }
            </style>
            <script type="text/javascript" src="assets/js/jquery.easing.1.3.js"></script>
            <script type="text/javascript" src="assets/js/jquery-func.js"></script>
            <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
            <script type="text/javascript" src="assets/js/retina.js"></script>
            <script type="text/javascript" src="assets/js/smoothscroll.js"></script>
    </form>
</body>
</html>
