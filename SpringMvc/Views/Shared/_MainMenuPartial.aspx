<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<section class="featured">
    <div class="content-wrapper">
         <div class="float-right"> 
            <nav>
				<!-- @foreach Primary Position in Menu
						<ul> ...... ></ul>
						@foreache SecondaryPosition in PrimaryMenyu 
							<li><a href="#"> .... -->
                <ul id="menu" class="topmenu">
                    <li><%: Html.ActionLink("User Account", "Index", "Home") %>
						<ul>
							<li><a href="#">link1</a></li>
							<li><a href="#">link2</a></li>
							<li><a href="#">link3</a></li>
						</ul>
                    </li>
                    <li><%: Html.ActionLink("About", "About", "Home") %></li>
                    <li><%: Html.ActionLink("Contact", "Contact", "Home") %></li>
                </ul>
            </nav>
        </div>
    </div>
</section>
