<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<section class="featured">
    <div class="content-wrapper">
        <div class="float-right">
            <nav>
                <ul id="menu">
                    <li><%: Html.ActionLink("User Account", "Index", "Home") %></li>
                    <li><%: Html.ActionLink("About", "About", "Home") %></li>
                    <li><%: Html.ActionLink("Contact", "Contact", "Home") %></li>
                </ul>
            </nav>
        </div>
    </div>
</section>
