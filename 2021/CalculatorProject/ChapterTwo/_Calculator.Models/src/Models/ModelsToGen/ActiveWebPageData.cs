using System.Collections.Generic;


namespace Calculator.Models
{
    public partial class ActiveWebPageData
    {
        public ActiveWebPageData()
        {
            WebContents = new HashSet<WebContent>();
        }

        public virtual WebPage WebPage { get; set; }
        public virtual ICollection<WebContent> WebContents { get; set; }
    }
}