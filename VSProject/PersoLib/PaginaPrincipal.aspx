<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="PersoLib.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>PersoLib- Biblioteca Pessoal</title>
    <link rel="shortcut icon" href="assets/ico/favicon.png">
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <link href="assets/css/main.css" rel="stylesheet">
    <link rel="stylesheet" href="assets/css/icomoon.css">
    <link href="assets/css/datepicker.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/animate-custom.css" rel="stylesheet">
    <link href="assets/css/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="assets/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="assets/js/jasny-bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="assets/js/dataTables.bootstrap.js"></script>
    <script type="text/javascript" src="assets/js/modernizr.custom.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/retina.js"></script>
    <script type="text/javascript" src="assets/js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="assets/js/jquery-func.js"></script>
    <script type="text/javascript" src="assets/js/smoothscroll.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#grid_livros').dataTable();
            $('#grid_emprestimos').dataTable();
            $('#txt_nova_data_prazo').datepicker({
                dateFormat: 'dd-mm-yy'
            });
            $('#txt_nova_data').datepicker({
                dateFormat: 'dd-mm-yy'
            });
        });
    </script>
    <script type="text/javascript">
        function selecionar_aba(aba) {               
            $.ajax({
                type: "POST",
                url: window.location.href + "/selecao_aba",
                data: "{codigo: '" + aba + "'}",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    if (aba == "aba1") {
                        $("#div_aba1").tab("show");
                        $("#li_aba1").addClass("active");
                        $("#li_aba2").removeClass("active");
                        $("#li_aba3").removeClass("active");
                    } else if (aba == "aba2") {
                        $("#div_aba2").tab("show");
                        $("#li_aba1").removeClass("active");
                        $("#li_aba2").addClass("active");
                        $("#li_aba3").removeClass("active");
                    } else if (aba == "aba3") {
                        $("#div_aba3").tab("show");
                        $("#li_aba1").removeClass("active");
                        $("#li_aba2").removeClass("active");
                        $("#li_aba3").addClass("active");
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .login {
            padding-top: 7px;
        }

        .email {
            padding-top: 15px;
            color: White;
            text-align: right;
        }

        .datepicker {
            z-index: 1151 !important;
        }

        @media (min-width: 768px) {
            .acao {
                width: 60px !important;
                max-width: 60px !important;
                min-width: 60px !important;
            }
        }
    </style>
    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic'
        rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,300,700' rel='stylesheet'
        type='text/css'>
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
                            <li runat="server" id="li_aba1" class="active"><a href="" class="smoothScroll" onclick="selecionar_aba('aba1');">Meus Livros</a></li>
                            <li runat="server" id="li_aba2"><a href="" class="smoothScroll" onclick="selecionar_aba('aba2');">Meus Emprestimos</a></li>
                            <li runat="server" id="li_aba3"><a href="" class="smoothScroll" onclick="selecionar_aba('aba3');">Meu Perfil</a></li>
                            <li>
                                <div class="col-lg-2 login">
                                    <a href="PaginaInicial.aspx" id="btn_login" class="btn btn-danger login">Fazer Logout
                                    </a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3>Principal</h3>
                    <div class="tabbable-panel">
                        <div class="tabbable-line">
                            <div class="tab-content">
                                <div class="tab-pane fade in active" runat="server" id="div_aba1">
                                    <div style="padding-top: 20px; padding-left: 15px;">
                                        <a class="btn btn-success" data-toggle="modal" data-target="#modal_novo_livro">Cadastrar novo livro</a>
                                    </div>
                                    <div class="container" style="padding-top: 20px;">
                                        <table id="grid_livros" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>Nome do Livro
                                                    </th>
                                                    <th>Quantidade
                                                    </th>
                                                    <th>Quantidade Emprestada
                                                    </th>
                                                    <th class="acao">Ações
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>O Símbolo Perdido
                                                    </td>
                                                    <td>5
                                                    </td>
                                                    <td>2
                                                    </td>
                                                    <td>
                                                        <a title="Editar este livro" class="btn btn-primary btn-xs" data-toggle="modal"
                                                            data-target="#edit">
                                                            <span class="glyphicon glyphicon-pencil"></span>
                                                        </a>
                                                        <a title="Excluir este livro" class="btn btn-danger btn-xs" data-toggle="modal"
                                                            data-target="#delete">
                                                            <span class="glyphicon glyphicon-trash"></span>
                                                        </a>
                                                        <a title="Empreste este livro" class="btn btn-warning btn-xs" data-toggle="modal"
                                                            data-target="#modal_novo_emprestimo">
                                                            <span class="glyphicon glyphicon-new-window"></span>
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Assassinato no Expresso do Oriente
                                                    </td>
                                                    <td>1
                                                    </td>
                                                    <td>0
                                                    </td>
                                                    <td>
                                                        <a title="Editar este livro" class="btn btn-primary btn-xs" data-toggle="modal"
                                                            data-target="#edit">
                                                            <span class="glyphicon glyphicon-pencil"></span>
                                                        </a>
                                                        <a title="Excluir este livro" class="btn btn-danger btn-xs" data-toggle="modal"
                                                            data-target="#delete">
                                                            <span class="glyphicon glyphicon-trash"></span>
                                                        </a>
                                                        <a title="Empreste este livro" class="btn btn-warning btn-xs" data-toggle="modal"
                                                            data-target="#modal_novo_emprestimo">
                                                            <span class="glyphicon glyphicon-new-window"></span>
                                                        </a>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="div_aba2" runat="server">
                                    <div class="container" style="padding-top: 20px;">
                                        <table id="grid_emprestimos" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>Nome do Livro
                                                    </th>
                                                    <th>Nome do Emprestante
                                                    </th>
                                                    <th>Email do Emprestante
                                                    </th>
                                                    <th>Data de Devolução
                                                    </th>
                                                    <th class="acao">Ações
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>Assassinato no Expresso do Oriente
                                                    </td>
                                                    <td>Matheus Magalhães
                                                    </td>
                                                    <td>matheus@magalhaes.com
                                                    </td>
                                                    <td>15/11/2014
                                                    </td>
                                                    <td>
                                                        <span style="padding-left: 14px;">
                                                            <a title="Alterar prazo" class="btn btn-warning btn-xs" data-toggle="modal"
                                                                data-target="#modal_alterar_prazo">
                                                                <span class="glyphicon glyphicon-calendar"></span>
                                                            </a>
                                                            <a title="Finalizar empréstimo" class="btn btn-success btn-xs" data-toggle="modal"
                                                                data-target="#modal_finalizar_emprestimo">
                                                                <span class="glyphicon glyphicon-ok"></span>
                                                            </a>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="div_aba3" runat="server">
                                    <div class="container" style="padding-top: 20px;">
                                        <div runat="server" id="div_mensagem_perfil" visible="false" class="alert alert-info alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <span class="sr-only"></span>
                                            <asp:Label runat="server" ID="lbl_mensagem_perfil" Text=""> </asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <h4>Nome
                                            </h4>
                                            <input runat="server" id="txt_nome" class="form-control" type="text" maxlength="50" placeholder="">
                                        </div>
                                        <div class="form-group">
                                            <h4>E-mail</h4>
                                            <input runat="server" id="txt_email" class="form-control " type="text" maxlength="50" placeholder="">
                                        </div>
                                        <div class="form-group">
                                            <h4>Nova Senha</h4>
                                            <input runat="server" id="txt_nova_senha" class="form-control " type="password" maxlength="20" placeholder="">
                                        </div>
                                        <div class="form-group">
                                            <h4>Confirme a nova senha</h4>
                                            <input runat="server" id="txt_nova_senha_confirmacao" class="form-control " type="password" maxlength="20" placeholder="">
                                        </div>
                                        <asp:LinkButton class="btn btn-info" runat="server" ID="LinkButton" OnClick="AtualizarPerfil" Text="Atualizar Perfil"></asp:LinkButton>
                                        <a class="btn btn-danger" data-toggle="modal" data-target="#modal_excluir_conta">Desativar conta
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    <div id="footerwrap" class="navbar-fixed-bottom">
        <div class="container">
            <h4>Created by <a href="">Stremens Corp.</a> - TMA LTDA.</h4>
        </div>
    </div>
        <div class="modal fade" id="modal_novo_livro" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <h4 class="modal-title custom_align" id="H1">Cadastre seu Livro</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <input class="form-control " type="text" placeholder="Nome do Livro">
                        </div>
                        <div class="form-group">
                            <input class="form-control " type="text" placeholder="Quantidade">
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <button type="button" class="btn btn-success btn-lg" data-dismiss="modal" style="width: 100%;">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Salvar</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <h4 class="modal-title custom_align">Editando...</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <input class="form-control " type="text" placeholder="Nome do Livro">
                        </div>
                        <div class="form-group">
                            <input class="form-control " type="text" placeholder="Quantidade">
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <button type="button" class="btn btn-warning btn-lg" data-dismiss="modal" style="width: 100%;">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Update</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_novo_emprestimo" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×
                        </button>
                        <h4 class="modal-title custom_align">Emprestar Livro
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <input class="form-control" disabled type="text" placeholder="O Símbolo Perdido">
                        </div>
                        <div class="form-group">
                            <input class="form-control " type="text" placeholder="Nome do Emprestante">
                        </div>
                        <div class="form-group">
                            <input class="form-control " type="text" placeholder="E-mail do Emprestante">
                        </div>
                        <div class="form-group">
                            <input id="txt_nova_data" maxlength="10" class="form-control" data-mask="99/99/9999"
                                type="text" placeholder="Data de Devolução">
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <button type="button" class="btn btn-success">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Emprestar
                        </button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Cancelar
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <h4 class="modal-title custom_align">Deletar</h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-warning">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;&nbsp;Você tem certeza
                        que gostaria de deletar este livro e todas as suas cópias?
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <button type="button" class="btn btn-success">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Sim</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Não</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_excluir_conta" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×
                        </button>
                        <h4 class="modal-title custom_align">Desativar Conta
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-warning">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;&nbsp;Caso deseje reativar sua conta, 
                            basta fazer o login na página inicial e sua conta será reativada automaticamente. Você tem certeza
                        que gostaria de desativar sua conta na Biblioteca Pessoal?
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <%--<button type="button" class="btn btn-success">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Sim
                        </button>--%>
                        <asp:LinkButton runat="server" ID="btn_desativar_conta" OnClick="DesativarUsuario" Text="Sim" CssClass="btn btn-success" />
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Não
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_finalizar_emprestimo" tabindex="-1" role="dialog"
            aria-labelledby="edit" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×
                        </button>
                        <h4 class="modal-title custom_align">Devolução de Livro
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-warning">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;&nbsp;Você tem certeza
                        que gostaria de finalizar o empréstimo deste livro?
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <button type="button" class="btn btn-success">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Sim
                        </button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Não
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modal_alterar_prazo" tabindex="-1" role="dialog" aria-labelledby="edit"
            aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <h4 class="modal-title custom_align" id="H3">Alterando o prazo...</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <input class="form-control" disabled type="text" placeholder="24/11/2014">
                        </div>
                        <div class="form-group">
                            <input id="txt_nova_data_prazo" maxlength="10" class="form-control" data-mask="99/99/9999"
                                type="text" placeholder="Nova data">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-success" data-dismiss="modal" style="width: 100%;">
                            <span class="glyphicon glyphicon-ok-sign"></span>&nbsp;&nbsp;Salvar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
