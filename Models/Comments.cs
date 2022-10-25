using System.Web.Mvc;

namespace webAppCroosSS.Models
{
    public class Comments
    {
        public Guid Id { get; set; }
        [AllowHtml]
        public string Name { get; set; }
        [AllowHtml]
        public string Comment { get; set; }
        //public List<Comments> commentList = new List<Comments>();

    }
}
