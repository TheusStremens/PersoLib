<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="PersoLib.PaginaInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="SHIELD - Free Bootstrap 3 Theme">
    <meta name="author" content="Carlos Alvarez - Alvarez.is - blacktie.co">
    <link rel="shortcut icon" href="assets/ico/favicon.ico">
    <title>PersoLib- Biblioteca Pessoal</title>
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <link href="assets/css/main.css" rel="stylesheet">
    <link rel="stylesheet" href="assets/css/icomoon.css">
    <link href="assets/css/animate-custom.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic'
        rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,300,700' rel='stylesheet'
        type='text/css'>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="assets/js/modernizr.custom.js"></script>
    <script type="text/javascript" src="assets/js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="assets/js/jquery-func.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/retina.js"></script>
    <script type="text/javascript" src="assets/js/smoothscroll.js"></script>
</head>
<body data-spy="scroll" data-offset="0" data-target="#navbar-main">
    <form id="form_body" runat="server">
        <div id="navbar-main">
            <div class="navbar navbar-inverse navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="glyphicon glyphicon-th-list" style="font-size: 30px; color: #3498db;"></span>
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
                    <button data-target="#modal_cadastro" data-toggle="modal" type="button" class="btn btn-danger alert-success btn-lg">Comece a usar agora!</button>
                </p>
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
                    <span class="icon icon-arrow-up-right"></span>
                    <h2>Empreste seus Livros</h2>
                    <p>
                        Agora você pode sempre lembrar a quem você emprestou seu livro!
                    </p>
                </div>
                <div class="col-lg-4 callout">
                    <span class="icon icon-feed"></span>
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
                <div class="col-lg-12 text-justify">
                    <p>
                        PersoLib é um projeto idealizado pelo prof. Ivan Machado, durante o curso da disciplina Engenharia de Software II,
                        oferecido pela Universidade Federal da Bahia, no curso de Ciência da Computação.
                        O PersoLib irá gerenciar seu controle de empréstimos de livros, mas de forma eletrônica. Você não precisará mais lembrar
                        por si só a quem você emprestou aquele seu livro e que nunca mais foi visto.
                        Você pode inserir novos livros na sua estante virtual, bem como editá-los e deletá-los. Você pode também conferir quais livros
                        estão emprestados, a fim de lembrar com quem estão seus amados livros, e saber de quem cobrar. Falando nisso, não se preocupe. 
                        O PersoLib irá notificar aos seus amigos, para não deixá-los esquecer de devolver seus preciosos. Deixe com a gente, iremos 
                        cuidar de seus livros como se fossem nossos.
                    </p>
                </div>
            </div>
        </div>
        <section class="section-divider textdivider "></section>
        <div class="container">&nbsp;<br />&nbsp;&nbsp;<br />&nbsp;&nbsp;<br />&nbsp;&nbsp;<br />&nbsp;</div>
        <div id="footerwrap">
            <div class="container">
                <h4>Created by <a href="">Stremens Corp.</a> - TMA LTDA.</h4>
            </div>
        </div>
        <div runat="server" id="modal_cadastrado_sucesso" data-backdrop="static" class="modal fade bs-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title custom_align">Cadastro de Conta</h4>
                    </div>
                    <div class="modal-body">
                        <div class="text-justify alert alert-sucess">
                            Sua conta foi criada com sucesso! Agora você já pode fazer seu login e começar a usar a Biblioteca Pessoal!
                        </div>
                        <div class="modal-footer-sm">
                            <button runat="server" onserverclick="FecharPopupCadastro" type="button" class="btn btn-success">
                                <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Ok
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_cadastro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div runat="server" class="modal-content">
                    <div class="modal-header">
                        <div runat="server" id="div_mensagem_modal" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <span class="sr-only"></span>
                            <asp:Label runat="server" ID="lbl_mensagem_modal" Text=""> </asp:Label>
                        </div>
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
                                    <input runat="server" id="txt_email_cadastro" type="text" placeholder="email@servidor.com"
                                        class="form-control input-md" required>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_name">
                                    Nome:
                                </label>
                                <div class="col-md-4">
                                    <input runat="server" id="txt_name" name="txt_name" runat="server" type="text" placeholder="Seu nome" class="form-control input-md"
                                        required>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_senha">
                                    Senha:
                                </label>
                                <div class="col-md-4">
                                    <input runat="server" id="txt_senha" name="txt_senha" type="password" placeholder="*********" class="form-control input-md"
                                        required="">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_repete_senha">
                                    Repita a senha:
                                </label>
                                <div class="col-md-4">
                                    <input runat="server" id="txt_repete_senha" name="txt_repete_senha" type="password" placeholder="*********"
                                        class="form-control input-md" required="">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btn_cadastrar_usuario" runat="server" class="btn btn-success" OnClick="CadastrarUsuario" Text="Cadastrar" />
                        <asp:LinkButton ID="btn_cancelar" runat="server" class="btn btn-danger" OnClick="FecharPopupCadastro" Text="Cancelar"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_login" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <div runat="server" id="div_erro_login" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <span class="sr-only"></span>
                            <asp:Label runat="server" ID="lbl_mensagem_login" Text=""> </asp:Label>
                        </div>
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                        </button>
                        <h4 class="modal-title" id="myModalLabel2">Login
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail1" class="col-lg-4 control-label">
                                </label>
                                <div class="col-lg-10">
                                    <input runat="server" type="text" class="form-control" id="txt_email_login" placeholder="Email">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="text1" class="col-lg-4 control-label">
                                </label>
                                <div class="col-lg-10">
                                    <input runat="server" type="password" class="form-control" id="txt_senha_login" placeholder="Senha">
                                </div>
                            </div>
                            <div class="modal-footer-sm ">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="LoginUsuario" Text="Entrar"></asp:LinkButton>
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
            <button class="hide" runat="server" id="btn_registro_sucesso" onserverclick="AbrirPopupConfirmacao"></button>
    </form>
</body>
</html>
