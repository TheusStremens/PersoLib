<%@ Page Title="" Language="C#" MasterPageFile="~/master/master.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="PersoLib.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="navbar-main">
        <!-- Fixed navbar -->
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon icon-shield" style="font-size: 30px; color: #3498db;"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse">
                    <div class="email col-lg-1">
                        <label>
                            Email:</label>
                    </div>
                    <div class="col-lg-3 login">
                        <asp:TextBox runat="server" MaxLength="50" required pattern="^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$"
                            CssClass="form-control input-md" ID="txt_login"></asp:TextBox>
                    </div>
                    <div class="email col-lg-1">
                        <label>
                            Senha:</label>
                    </div>
                    <div class="col-lg-2 login">
                        <asp:TextBox runat="server" MaxLength="20" required TextMode="Password" CssClass="form-control input-md"
                            ID="TextBox1"></asp:TextBox>
                    </div>
                    <div class="col-lg-2 login">
                        <button runat="server" id="btn_login" class="btn btn-default">
                            Login!</button>
                    </div>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>
    </div>
    <!-- ==== HEADERWRAP ==== -->
    <div id="headerwrap" id="home" name="home">
        <header class="clearfix">
	  		 		<h1><span class="icon"></span></h1>
	  		 		<p>Personal Library</p>
	  		 		<p>New Generation.</p>
                    <p><br /></p>
                    <p><button data-target="#modal_cadastro" data-toggle="modal" type="button" class="btn alert-success btn-lg">Comece a usar agora!</button></p>
	  		</header>
    </div>
    <!-- /headerwrap -->
    <!-- ==== GREYWRAP ==== -->
    <div id="greywrap">
        <div class="row">
            <div class="col-lg-4 callout">
                <span class="icon icon-stack"></span>
                <h2>
                    Bootstrap 3</h2>
                <p>
                    Shield Theme is powered by Bootstrap 3. The incredible Mobile First Framework is
                    the best option to run your website.
                </p>
            </div>
            <!-- col-lg-4 -->
            <div class="col-lg-4 callout">
                <span class="icon icon-eye"></span>
                <h2>
                    Retina Ready</h2>
                <p>
                    You can use this theme with your iPhone, iPad or MacBook Pro. This theme is retina
                    ready and that is awesome.
                </p>
            </div>
            <!-- col-lg-4 -->
            <div class="col-lg-4 callout">
                <span class="icon icon-heart"></span>
                <h2>
                    Crafted with Love</h2>
                <p>
                    We don't make sites, we craft themes with love & passion. That is our most valued
                    secret. We only do thing that we love.
                </p>
            </div>
            <!-- col-lg-4 -->
        </div>
        <!-- row -->
    </div>
    <!-- greywrap -->
    <!-- ==== ABOUT ==== -->
    <div class="container" id="about" name="about">
        <div class="row white">
            <br>
            <h1 class="centered">
                A LITTLE ABOUT OUR AGENCY</h1>
            <hr>
            <div class="col-lg-6">
                <p>
                    We believe ideas come from everyone, everywhere. In fact, at BlackTie, everyone
                    within our agency walls is a designer in their own right. And there are a few principles
                    we believe—and we believe everyone should believe—about our design craft. These
                    truths drive us, motivate us, and ultimately help us redefine the power of design.
                    We’re big believers in doing right by our neighbors. After all, we grew up in the
                    Twin Cities and we believe this place has much to offer. So we do what we can to
                    support the community we love.</p>
            </div>
            <!-- col-lg-6 -->
            <div class="col-lg-6">
                <p>
                    Over the past four years, we’ve provided more than $1 million in combined cash and
                    pro bono support to Way to Grow, an early childhood education and nonprofit organization.
                    Other community giving involvement throughout our agency history includes pro bono
                    work for more than 13 organizations, direct giving, a scholarship program through
                    the Minneapolis College of Art & Design, board memberships, and ongoing participation
                    in the Keystone Club, which gives five percent of our company’s earnings back to
                    the community each year.</p>
            </div>
            <!-- col-lg-6 -->
        </div>
        <!-- row -->
    </div>
    <!-- container -->
    <div id="footerwrap">
        <div class="container">
            <h4>
                Created by <a href="http://blacktie.co">BlackTie.co</a> - Copyright 2014</h4>
        </div>
    </div>
    <div class="modal fade" id="modal_cadastro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">
                        Digite seus Dados!</h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                            <!-- Text input-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_email">
                                    Email:</label>
                                <div class="col-md-4">
                                    <input id="txt_email" name="txt_email" type="text" placeholder="email@servidor.com"
                                        class="form-control input-md" required>
                                </div>
                            </div>
                            <!-- Password input-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_senha">
                                    Senha:</label>
                                <div class="col-md-4">
                                    <input id="txt_senha" name="txt_senha" type="password" placeholder="*********" class="form-control input-md"
                                        required="">
                                </div>
                            </div>
                            <!-- Password input-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_repete_senha">
                                    Repete Senha:</label>
                                <div class="col-md-4">
                                    <input id="txt_repete_senha" name="txt_repete_senha" type="password" placeholder="*********"
                                        class="form-control input-md" required="">
                                </div>
                            </div>
                            <!-- Text input-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="txt_telefone">
                                    Telefone:</label>
                                <div class="col-md-4">
                                    <input id="txt_telefone" name="txt_telefone" type="text" placeholder="" class="form-control input-md">
                                </div>
                            </div>
                            <!-- Button (Double) -->
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btn_cadastrar" type="button" runat="server" name="btn_cadastrar" class="btn btn-success">
                        Cadastrar</button>
                    <button id="btn_cancelar" type="reset" data-dismiss="modal" name="btn_cancelar" class="btn btn-danger">
                        Cancelar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
