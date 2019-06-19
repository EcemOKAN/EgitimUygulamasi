using System.Web.Mvc;

namespace egitimUygulamasi.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            //context.MapRoute(name: "Admin", url: "", defaults: new { controller = "Home", action = "Index" });

            #region Lessons
            context.MapRoute(name: "Lessons", url: "admin/dersler", defaults: new { controller = "Lesson", action = "Index" });
            context.MapRoute(name: "AddLesson", url: "admin/dersEkle", defaults: new { controller = "Lesson", action = "Add" });
            context.MapRoute(name: "EditLesson", url: "admin/dersDuzenle/{ID}", defaults: new { controller = "Lesson", action = "Edit", ID = UrlParameter.Optional });
            context.MapRoute(name: "DeleteLesson", url: "admin/dersSil", defaults: new { controller = "Lesson", action = "Delete" });
            #endregion


            #region Topics
            context.MapRoute(name: "Topics", url: "admin/konular", defaults: new { controller = "Topic", action = "Index" });
            context.MapRoute(name: "AddTopic", url: "admin/konuEkle", defaults: new { controller = "Topic", action = "Add" });
            context.MapRoute(name: "EditTopic", url: "admin/konuDuzenle/{ID}", defaults: new { controller = "Topic", action = "Edit", ID = UrlParameter.Optional });
            context.MapRoute(name: "DeleteTopic", url: "admin/konuSil", defaults: new { controller = "Topic", action = "Delete" });
            #endregion


            #region TopicContents
            context.MapRoute(name: "TopicContents", url: "admin/konuicerikleri", defaults: new { controller = "Topiccontent", action = "Index" });
            context.MapRoute(name: "AddTopicContent", url: "admin/konuicerikEkle", defaults: new { controller = "Topiccontent", action = "Add" });
            context.MapRoute(name: "EditTopicContent", url: "admin/konuicerikDuzenle/{ID}", defaults: new { controller = "Topiccontent", action = "Edit" });
            context.MapRoute(name: "DeleteTopicContent", url: "admin/konuicerikSil", defaults: new { controller = "Topiccontent", action = "Delete" });
            #endregion

            #region Questions
            context.MapRoute(name: "Questions", url: "admin/sorular", defaults: new { controller = "Question", action = "Index" });
            context.MapRoute(name: "AddQuestion", url: "admin/soruEkle", defaults: new { controller = "Question", action = "Add" });
            context.MapRoute(name: "EditQuestion", url: "admin/soruDuzenle/{ID}", defaults: new { controller = "Question", action = "Edit" });
            context.MapRoute(name: "DeleteQuestion", url: "admin/soruSil", defaults: new { controller = "Question", action = "Delete" });
            #endregion

            #region Questions
            context.MapRoute(name: "Users", url: "admin/kullanicilar", defaults: new { controller = "Users", action = "Index" });
            context.MapRoute(name: "AddUser", url: "admin/kullaniciEkle", defaults: new { controller = "Users", action = "Add" });
            context.MapRoute(name: "EditUser", url: "admin/kullaniciDuzenle/{ID}", defaults: new { controller = "Users", action = "Edit" });
            context.MapRoute(name: "DeleteUser", url: "admin/kullaniciSil", defaults: new { controller = "Users", action = "Delete" });
            #endregion

            context.MapRoute(name: "Home", url: "admin", defaults: new { controller = "Home", action = "Index" });

            context.MapRoute(
               "admin_default",
               "admin/{controller}/{action}/{id}",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional }

           );
        }
    }
}