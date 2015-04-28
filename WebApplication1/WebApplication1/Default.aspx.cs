using Newtonsoft.Json.Linq;
using React;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using System.Web.Optimization;
using WebApplication1.Controllers;
using Newtonsoft.Json;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //var env = AssemblyRegistration.Container.Resolve<IReactEnvironment>();
            //var objectModel = new { user = "React User" };

            //var books = new JArray();
            //books.Add();

            //var data = new JObject();
            //data["books"] = new 
            //var reactComponent = env.CreateComponent("PageContent", objectModel);
            
            //Original Code
            var env = AssemblyRegistration.Container.Resolve<IReactEnvironment>();
            var objectModel = new { user = "React User" };
            var reactComponent = env.CreateComponent("PageContent", objectModel);
            PageContent.Text = reactComponent.RenderHtml();

            //The following will replace this code with server-side rendering
            //React.render(
            //  <CommentBox url="api/Home" submitUrl="api/Home/addcomment" pollInterval={2000} />,
            //  document.getElementById('content')
            //);
            var homeController = new HomeController();
            var data = homeController.Get();
            var commentBoxOptions = new
            {
                initialData = data,
                url = "api/Home",
                submitUrl="api/Home/addcomment",
                pollInterval=2000
            };

            //Option 1: Render HTML server-side.  Better for SEO and appearance since page comes filled in, even though it actually takes longer to load the DOM, since react has to do virtual DOM diff with the preloaded html.
            var commentBoxComponent = env.CreateComponent("CommentBox", commentBoxOptions);
            app.Text = commentBoxComponent.RenderHtml();


            //Option 2: Render HTML client-side but with data so no post needed
            //var commentBoxComponent = env.CreateComponent("CommentBox", commentBoxOptions);


            string initJS = env.GetInitJavaScript();
            litInitJS.Text = initJS;


        }
    }
}