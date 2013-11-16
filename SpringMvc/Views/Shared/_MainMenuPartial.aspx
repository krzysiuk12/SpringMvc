<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<section class="featured">
    <div class="content-wrapper">
        <div class="float-right">
            <nav>
                <ul id="menu">
                    <li><%: Html.ActionLink("User Account Panel", "Index", "MainShop") %></li>
                    <li><%: Html.ActionLink("Administrator Panel", "Index", "MainShop") %></li>
                    <li><%: Html.ActionLink("Worker Panel", "Index", "MainShop") %></li>
                    <li><%: Html.ActionLink("Shop", "Index", "MainShop") %></li>
                </ul>
            </nav>
        </div>
    </div>
</section>
